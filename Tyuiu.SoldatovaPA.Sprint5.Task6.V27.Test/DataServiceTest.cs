using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task6.V27.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task6.V27.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            string path = @"C:\DataSprint5\InPutDataFileTask6V27.txt";

            // Создаем папку если нет
            Directory.CreateDirectory(@"C:\DataSprint5\");

            // Записываем тестовые данные из задания
            string testData = "487 строка 432123 с 34509 циф 324 ра 23 ми";
            File.WriteAllText(path, testData);

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            // Анализируем строку: "487 строка 432123 с 34509 циф 324 ра 23 ми"
            // Трехзначные числа: 487, 324
            // 432123 - шестизначное, 34509 - пятизначное, 23 - двухзначное
            // Ожидаемый результат: 2

            Console.WriteLine($"Текст из файла: {testData}");
            Console.WriteLine($"Найдено трехзначных чисел: {result}");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CheckEmptyString()
        {
            string path = @"C:\DataSprint5\TestEmpty.txt";
            File.WriteAllText(path, "");

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            Assert.AreEqual(0, result);
            File.Delete(path);
        }

        [TestMethod]
        public void CheckNoThreeDigitNumbers()
        {
            string path = @"C:\DataSprint5\TestNoThreeDigit.txt";
            File.WriteAllText(path, "12 1234 1 4567 89");

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            Assert.AreEqual(0, result);
            File.Delete(path);
        }

        [TestMethod]
        public void CheckMultipleThreeDigitNumbers()
        {
            string path = @"C:\DataSprint5\TestMultiple.txt";
            File.WriteAllText(path, "100 200 300 400 500 600 700 800 900");

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            Assert.AreEqual(9, result);
            File.Delete(path);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void CheckFileNotFound()
        {
            DataService ds = new DataService();
            ds.LoadFromDataFile(@"C:\NonExistentFolder\NoFile.txt");
        }
    }
}
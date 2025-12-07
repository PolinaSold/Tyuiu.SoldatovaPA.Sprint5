using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task7.V20.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task7.V20.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadDataAndSave()
        {
            // Создаем тестовый файл
            string path = @"C:\DataSprint5\InPutDataFileTask7V20.txt";
            Directory.CreateDirectory(@"C:\DataSprint5");
            File.WriteAllText(path, "Ссловарные сслова сс удвоенной ссогласной нн");

            DataService ds = new DataService();
            string result = ds.LoadDataAndSave(path);

            string expected = "Словарные слова с удвоенной согласной нн";

            Console.WriteLine($"Результат: {result}");
            Console.WriteLine($"Ожидалось: {expected}");

            Assert.AreEqual(expected, result);

            // Проверяем что выходной файл создан
            string outputPath = @"C:\DataSprint5\OutPutDataFileTask7V20.txt";
            Assert.IsTrue(File.Exists(outputPath));

            // Проверяем содержимое выходного файла
            string fileContent = File.ReadAllText(outputPath);
            Assert.AreEqual(expected, fileContent);
        }
    }
}
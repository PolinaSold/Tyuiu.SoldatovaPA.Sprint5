using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tyuiu.SoldatovaPA.Sprint5.Task5.V17.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            // Создаем временный файл для теста
            string tempFile = Path.Combine(Path.GetTempPath(), "InPutDataFileTask5V17.txt");

            // Данные с разными числами: целые, вещественные, отрицательные
            // Простые числа (целая часть): 2, 3, 5, 7, 11, 13, 17, 19, 23
            string testData = "2.0, 3.5, 5.1, 7.8, 11.25, 13.0, 17.75, 19.3, 23.9, 4.0, 6.5, 8.1";
            File.WriteAllText(tempFile, testData);

            var ds = new Tyuiu.SoldatovaPA.Sprint5.Task5.V17.Lib.DataService();
            double result = ds.LoadFromDataFile(tempFile);

            // Ожидаемая сумма: 2.0 + 5.1 + 11.25 + 13.0 + 17.75 + 19.3 + 23.9 = 93.3
            // ИЛИ только целые числа: 2.0 + 13.0 = 15.0
            Console.WriteLine($"Результат теста: {result}");

            File.Delete(tempFile);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void CheckFileNotFound()
        {
            string path = @"C:\NonExistentFolder\File.txt";
            var ds = new Tyuiu.SoldatovaPA.Sprint5.Task5.V17.Lib.DataService();
            double result = ds.LoadFromDataFile(path);
        }
    }
}
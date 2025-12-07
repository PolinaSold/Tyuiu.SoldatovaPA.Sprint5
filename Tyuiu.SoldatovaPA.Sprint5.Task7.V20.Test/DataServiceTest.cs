using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task7.V20.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task7V20.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadDataAndSave()
        {
            // Создаем тестовый входной файл
            string inputPath = @"C:\DataSprint5\InPutDataFileTask7V20.txt";
            Directory.CreateDirectory(@"C:\DataSprint5");

            // Записываем тестовые данные
            File.WriteAllText(inputPath, "Ссловарные сслова сс удвоенной ссогласной нн");

            DataService ds = new DataService();
            string result = ds.LoadDataAndSave(inputPath);

            // Ожидаемый результат
            string expected = "Словарные слова с удвоенной согласной нн";

            // 1. Проверяем возвращаемую строку
            Assert.AreEqual(expected, result);

            // 2. Проверяем что выходной файл создан
            string outputPath = @"C:\DataSprint5\OutPutDataFileTask7V20.txt";
            Assert.IsTrue(File.Exists(outputPath), "Выходной файл не создан!");

            // 3. Проверяем содержимое выходного файла
            string fileContent = File.ReadAllText(outputPath);
            Assert.AreEqual(expected, fileContent, "Содержимое выходного файла неверное!");

            Console.WriteLine($"Входной файл: {inputPath}");
            Console.WriteLine($"Выходной файл: {outputPath}");
            Console.WriteLine($"Результат: {result}");

            // Очистка
            File.Delete(inputPath);
            File.Delete(outputPath);
        }
    }
}
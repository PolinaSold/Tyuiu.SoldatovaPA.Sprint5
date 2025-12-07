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
            // Создаем временный файл
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, "Ссловарные сслова сс удвоенной ссогласной нн");

            DataService ds = new DataService();
            string result = ds.LoadDataAndSave(tempFile);
            string expected = "Словарные слова с удвоенной согласной нн";

            Console.WriteLine($"Результат: {result}");
            Assert.AreEqual(expected, result);

            // Проверяем что выходной файл создан в той же директории
            string outputFile = Path.Combine(Path.GetDirectoryName(tempFile), "OutPutDataFileTask7V20.txt");
            Assert.IsTrue(File.Exists(outputFile));

            string fileContent = File.ReadAllText(outputFile);
            Assert.AreEqual(expected, fileContent);

            // Удаляем временные файлы
            File.Delete(tempFile);
            File.Delete(outputFile);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void CheckFileNotFoundException()
        {
            DataService ds = new DataService();
            ds.LoadDataAndSave("non_existent_file.txt");
        }
    }
}
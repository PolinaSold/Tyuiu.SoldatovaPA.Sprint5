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
            // Используем временную папку
            string tempDir = Path.GetTempPath();
            string path = Path.Combine(tempDir, "InPutDataFileTask7V20.txt");

            // Записываем тестовые данные
            File.WriteAllText(path, "Ссловарные сслова сс удвоенной ссогласной нн");

            DataService ds = new DataService();
            string result = ds.LoadDataAndSave(path);

            // Ожидаемый результат
            string expected = "Словарные слова с удвоенной согласной нн";

            // Проверяем результат
            Assert.AreEqual(expected, result);

            // Проверяем что выходной файл создан
            string outPath = Path.Combine(tempDir, "OutPutDataFileTask7V20.txt");
            Assert.IsTrue(File.Exists(outPath));

            // Проверяем содержимое выходного файла
            string fileContent = File.ReadAllText(outPath);
            Assert.AreEqual(expected, fileContent);

            // Чистим за собой
            File.Delete(path);
            File.Delete(outPath);
        }
    }
}
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
            string path = @"C:\DataSprint5\InPutDataFileTask7V20.txt";

            Directory.CreateDirectory(@"C:\DataSprint5\");
            string testData = "Ссловарные сслова сс удвоенной ссогласной нн";
            File.WriteAllText(path, testData);

            DataService ds = new DataService();
            string result = ds.LoadDataAndSave(path);
            string expected = "Словарные слова с удвоенной согласной нн";

            Assert.AreEqual(expected, result);

            // Проверяем что файл сохранен
            string outputPath = @"C:\DataSprint5\OutPutDataFileTask7V20.txt";
            Assert.IsTrue(File.Exists(outputPath));

            string fileContent = File.ReadAllText(outputPath);
            Assert.AreEqual(expected, fileContent);
        }
    }
}
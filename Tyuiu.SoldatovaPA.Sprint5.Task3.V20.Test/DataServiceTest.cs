using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SoldatovaPA.Sprint5.Task3.V20.Lib;
using System.IO;

namespace Tyuiu.SoldatovaPA.Sprint5.Task3.V20.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidSaveToFileTextData()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(3);

            // Проверяем, что файл создан
            Assert.IsTrue(File.Exists(path));

            // Проверяем содержимое файла
            string fileContent = File.ReadAllText(path);

            // Проверяем округление до 3 знаков
            Assert.AreEqual("-1,000", fileContent);

            // Проверяем путь
            StringAssert.Contains(path, "OutPutFileTask3.txt");
            Assert.IsTrue(path.StartsWith(Path.GetTempPath()));
        }

        [TestMethod]
        public void CheckDifferentXValues()
        {
            DataService ds = new DataService();

            // Проверяем для x = 0
            string path1 = ds.SaveToFileTextData(0);
            string content1 = File.ReadAllText(path1);
            Assert.AreEqual("-1,000", content1);

            // Проверяем для x = 1
            string path2 = ds.SaveToFileTextData(1);
            string content2 = File.ReadAllText(path2);
            Assert.AreEqual("-1,000", content2);

            // Проверяем для x = 5
            string path3 = ds.SaveToFileTextData(5);
            string content3 = File.ReadAllText(path3);
            Assert.AreEqual("19,000", content3);
        }

        [TestMethod]
        public void CheckFileFormat()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(3);

            // Проверяем, что файл текстовый
            string content = File.ReadAllText(path);

            // Проверяем формат числа с 3 знаками после запятой
            Assert.IsTrue(content.Contains(","));

            // Проверяем, что после запятой 3 цифры
            string[] parts = content.Split(',');
            Assert.AreEqual(2, parts.Length);
            Assert.AreEqual(3, parts[1].Length);
        }
    }
}
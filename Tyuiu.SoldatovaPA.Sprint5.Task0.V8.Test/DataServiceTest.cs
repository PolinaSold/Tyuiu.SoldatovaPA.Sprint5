using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SoldatovaPA.Sprint5.Task0.V8.Lib;
using System.IO;

namespace Tyuiu.SoldatovaPA.Sprint5.Task0.V8.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckSaveToFileTextData()
        {
            string path = @"OutPutFileTask0.txt";

            // Если файл существует, удаляем его перед тестом
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            DataService ds = new DataService();
            string filePath = ds.SaveToFileTextData(3);

            // Проверяем, что файл создан
            bool fileExists = File.Exists(filePath);
            Assert.AreEqual(true, fileExists);

            // Проверяем содержимое файла
            string fileContent = File.ReadAllText(filePath);

            // Ожидаемое значение: 0,722
            string expected = "0,722";

            Assert.AreEqual(expected, fileContent);
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void CheckDivisionByZero()
        {
            DataService ds = new DataService();
            ds.SaveToFileTextData(0);
        }

        [TestMethod]
        public void CheckFilePath()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(3);

            // Проверяем, что путь содержит имя файла
            StringAssert.Contains(path, "OutPutFileTask0.txt");
        }
    }
}
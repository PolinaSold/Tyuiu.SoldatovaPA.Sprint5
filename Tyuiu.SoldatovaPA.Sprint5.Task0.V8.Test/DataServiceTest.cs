using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SoldatovaPA.Sprint5.Task0.V8.Lib;
using System.IO;

namespace Tyuiu.SoldatovaPA.Sprint5.Task0.V8.Test
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
            string wait = "0,722";

            Assert.AreEqual(wait, fileContent);

            // Проверяем, что путь содержит OutPutFileTask0.txt
            StringAssert.Contains(path, "OutPutFileTask0.txt");

            // Проверяем, что путь корректен (использует Path.Combine)
            Assert.IsTrue(path.Contains(Path.DirectorySeparatorChar.ToString()));
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void CheckDivisionByZero()
        {
            DataService ds = new DataService();
            ds.SaveToFileTextData(0);
        }

        [TestMethod]
        public void CheckFilePathInTemp()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(3);

            // Проверяем, что файл находится в temp директории
            string tempPath = Path.GetTempPath();
            Assert.IsTrue(path.StartsWith(tempPath));
        }
    }
}
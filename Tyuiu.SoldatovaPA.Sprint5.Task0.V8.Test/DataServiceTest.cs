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
            string path = "OutPutFileTask0.txt";

            // Удаляем файл, если он существует
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            DataService ds = new DataService();
            string res = ds.SaveToFileTextData(3);

            // Проверяем, что файл создан
            Assert.IsTrue(File.Exists(path));

            // Проверяем содержимое файла
            string fileContent = File.ReadAllText(path);
            string wait = "0,722";

            Assert.AreEqual(wait, fileContent);
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void CheckDivisionByZero()
        {
            DataService ds = new DataService();
            ds.SaveToFileTextData(0);
        }
    }
}
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
            // y(x) = x / √(x² + x)
            // При x = 3: 3 / √(9 + 3) = 3 / √12 = 3 / 3.4641 = 0.866025

            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(3);

            // Проверяем, что файл создан
            Assert.IsTrue(File.Exists(path));

            // Читаем результат из файла
            string result;
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                result = reader.ReadString();
            }

            // Проверяем результат
            // 0.866025 округляем до 3 знаков: 0.866
            Assert.AreEqual("0,866", result);

            // Проверяем путь
            StringAssert.Contains(path, "OutPutFileTask3.bin");
            Assert.IsTrue(path.StartsWith(Path.GetTempPath()));
        }

        [TestMethod]
        public void CheckDifferentXValues()
        {
            DataService ds = new DataService();

            // x = 1: 1 / √(1 + 1) = 1 / √2 = 1 / 1.4142 = 0.7071
            string path1 = ds.SaveToFileTextData(1);
            using (BinaryReader reader = new BinaryReader(File.Open(path1, FileMode.Open)))
            {
                string result1 = reader.ReadString();
                Assert.AreEqual("0,707", result1);
            }

            // x = 4: 4 / √(16 + 4) = 4 / √20 = 4 / 4.4721 = 0.8944
            string path2 = ds.SaveToFileTextData(4);
            using (BinaryReader reader = new BinaryReader(File.Open(path2, FileMode.Open)))
            {
                string result2 = reader.ReadString();
                Assert.AreEqual("0,894", result2);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void CheckNegativeUnderRoot()
        {
            // Для x = -2: (-2)² + (-2) = 4 - 2 = 2 > 0, должно работать
            // Для x = -1: 1 - 1 = 0, должно работать

            // Для очень отрицательных x может быть проблема
            DataService ds = new DataService();
            ds.SaveToFileTextData(-10);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tyutu.SoldatovaPA.Sprint5.Task5.V17.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestValidDataFile()
        {
            string path = @"C:\DataSprint5\InPutDataFileTask5V17.txt";
            string dir = Path.GetDirectoryName(path);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string testData = "24, 2, 18, 4, -9, 4, 10, 18, 19, 16, 11, -3, -3, 15, 3, 18, -5, -4, 25, 19";
            File.WriteAllText(path, testData);

            // Создаем объект DataService напрямую
            var ds = new Tyutu.SoldatovaPA.Sprint5.Task5.V17.Lib.DataService();
            double result = ds.LoadFromDataFile(path);

            Assert.AreEqual(54.0, result, 0.001);

            File.Delete(path);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestFileNotFound()
        {
            string path = @"C:\NonExistent\File.txt";
            var ds = new Tyutu.SoldatovaPA.Sprint5.Task5.V17.Lib.DataService();
            double result = ds.LoadFromDataFile(path);
        }

        [TestMethod]
        public void TestSimpleNumbers()
        {
            string path = Path.Combine(Path.GetTempPath(), "test.txt");
            File.WriteAllText(path, "2, 3, 5, 7, 11");

            var ds = new Tyutu.SoldatovaPA.Sprint5.Task5.V17.Lib.DataService();
            double result = ds.LoadFromDataFile(path);

            Assert.AreEqual(28.0, result, 0.001);

            File.Delete(path);
        }

        [TestMethod]
        public void TestNoPrimeNumbers()
        {
            string path = Path.Combine(Path.GetTempPath(), "test.txt");
            File.WriteAllText(path, "4, 6, 8, 9, 10, 12");

            var ds = new Tyutu.SoldatovaPA.Sprint5.Task5.V17.Lib.DataService();
            double result = ds.LoadFromDataFile(path);

            Assert.AreEqual(0.0, result, 0.001);

            File.Delete(path);
        }
    }
}
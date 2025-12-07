using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tyulu.SoldatovaPA.Sprint5.Task5.V17.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void LoadFromDataFileValidTest()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new string[] { "2", "3", "4.5", "7", "11.0", "13.2", "17.9" });

            var service = new Tyulu.SoldatovaPA.Sprint5.Task5.V17.Lib.DataService();
            double result = service.LoadFromDataFile(tempFile);

            // 2 + 3 + 7 + 11 + 17 = 40
            Assert.AreEqual(40.000, result, 0.001);

            File.Delete(tempFile);
        }

        [TestMethod]
        public void LoadFromDataFileWithNonIntegerTest()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new string[] { "2.5", "3.7", "5.0", "7.3" });

            var service = new Tyulu.SoldatovaPA.Sprint5.Task5.V17.Lib.DataService();
            double result = service.LoadFromDataFile(tempFile);

            // 5.0 -> 5 (простое)
            Assert.AreEqual(5.000, result, 0.001);

            File.Delete(tempFile);
        }

        [TestMethod]
        public void LoadFromDataFileEmptyTest()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, "");

            var service = new Tyulu.SoldatovaPA.Sprint5.Task5.V17.Lib.DataService();
            double result = service.LoadFromDataFile(tempFile);

            Assert.AreEqual(0.000, result, 0.001);

            File.Delete(tempFile);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LoadFromDataFileNotFoundTest()
        {
            var service = new Tyulu.SoldatovaPA.Sprint5.Task5.V17.Lib.DataService();
            service.LoadFromDataFile("nonexistent.txt");
        }

        [TestMethod]
        public void LoadFromDataFileWithNegativeNumbersTest()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new string[] { "-2", "-3", "5", "7" });

            var service = new Tyulu.SoldatovaPA.Sprint5.Task5.V17.Lib.DataService();
            double result = service.LoadFromDataFile(tempFile);

            // Только положительные простые: 5 + 7 = 12
            Assert.AreEqual(12.000, result, 0.001);

            File.Delete(tempFile);
        }
    }
}
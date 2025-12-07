using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tyulu.SoldatovaPA.Sprint5.Task4.V17.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void LoadFromDataFileValid()
        {
            string file = Path.GetTempFileName();
            File.WriteAllText(file, "1.5");
            var service = new Tyulu.SoldatovaPA.Sprint5.Task4.V17.Lib.DataService();
            double result = service.LoadFromDataFile(file);
            Assert.AreEqual(Math.Sin(2.0 / (3.0 * 1.5)) + 1.5 * 1.5, result, 0.0001);
            File.Delete(file);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LoadFromDataFileNotFound()
        {
            var service = new Tyulu.SoldatovaPA.Sprint5.Task4.V17.Lib.DataService();
            service.LoadFromDataFile("nonexistent.txt");
        }
    }
}
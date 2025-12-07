using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task5.V19.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task5.V19.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            string path = @"C:\DataSprint5\InPutDataFileTask5V19.txt";

            Directory.CreateDirectory(@"C:\DataSprint5\");
            File.WriteAllText(path, "16 15.24 9 8 11 19 -3.43 -6 9.4 20 11.67 1.72 12.7 10.45 -4 17.23 6.45 6.7 -7.58 -0.74");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // Однозначные целые: 9, 8, -6, -4, -7
            // Макс: 9, Мин: -7
            // Разница: 9 - (-7) = 16
            Assert.AreEqual(16, result, 0.001);
        }
    }
}
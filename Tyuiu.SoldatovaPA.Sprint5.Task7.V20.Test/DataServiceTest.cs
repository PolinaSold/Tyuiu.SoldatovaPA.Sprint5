using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task7.V20.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task7.V20.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckResultOnly()
        {
            // В тесте создаем файл в памяти или временной папке
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, "Ссловарные сслова сс удвоенной ссогласной нн");

            DataService ds = new DataService();
            string result = ds.LoadDataAndSave(tempFile);

            string expected = "Словарные слова с удвоенной согласной нн";

            // Проверяем только что метод вернул правильный результат
            Assert.AreEqual(expected, result);

            File.Delete(tempFile);
        }
    }
}
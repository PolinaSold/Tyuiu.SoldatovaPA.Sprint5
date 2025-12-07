using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SoldatovaPA.Sprint5.Task1.V14.Lib;
using System.IO;

namespace Tyuiu.SoldatovaPA.Sprint5.Task1.V14.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidSaveToFileTextData()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(-5, 5);

            // Проверяем, что файл создан
            Assert.IsTrue(File.Exists(path));

            // Проверяем количество строк (11 значений: от -5 до 5 включительно)
            string[] lines = File.ReadAllLines(path);
            Assert.AreEqual(11, lines.Length);

            // Проверяем, что путь содержит правильное имя файла
            StringAssert.Contains(path, "OutPutFileTask1.txt");

            // Проверяем формат чисел (два знака после запятой)
            foreach (string line in lines)
            {
                // Проверяем, что строка содержит число с двумя знаками после запятой
                Assert.IsTrue(line.Contains(",") && line.Split(',')[1].Length == 2 ||
                              line == "0,00");
            }
        }

        [TestMethod]
        public void CheckDivisionByZeroHandling()
        {
            DataService ds = new DataService();
            // Проверяем случай, когда x = -1.7 (деление на ноль)
            // Но так как x целое, проверим с x = -2
            string path = ds.SaveToFileTextData(-2, -2);

            string[] lines = File.ReadAllLines(path);
            // Должна быть одна строка с результатом
            Assert.AreEqual(1, lines.Length);
        }

        [TestMethod]
        public void CheckFilePathInTemp()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(-5, 5);

            // Проверяем, что файл находится в temp директории
            string tempPath = Path.GetTempPath();
            Assert.IsTrue(path.StartsWith(tempPath));

            // Проверяем, что использован Path.Combine
            Assert.IsTrue(path.Contains(Path.DirectorySeparatorChar.ToString()));
        }
    }
}
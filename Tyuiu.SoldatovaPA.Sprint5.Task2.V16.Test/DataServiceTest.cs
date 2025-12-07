using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.SoldatovaPA.Sprint5.Task2.V16.Lib;
using System.IO;

namespace Tyuiu.SoldatovaPA.Sprint5.Task2.V16.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidSaveToFileTextData()
        {
            // Тестовый массив из условия
            int[,] matrix = new int[3, 3]
            {
                { 2, -4, -8 },
                { 3, -7, -2 },
                { 3, 8, 6 }
            };

            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(matrix);

            // Проверяем, что файл создан
            Assert.IsTrue(File.Exists(path));

            // Проверяем содержимое файла
            string fileContent = File.ReadAllText(path);
            string expected = "1;0;0\r\n1;0;0\r\n1;1;1";

            // Учитываем разные варианты окончания строк
            string normalizedContent = fileContent.Replace("\r\n", "\n").Replace("\r", "\n").Trim();
            string normalizedExpected = expected.Replace("\r\n", "\n").Replace("\r", "\n").Trim();

            Assert.AreEqual(normalizedExpected, normalizedContent);

            // Проверяем, что путь содержит правильное имя файла
            StringAssert.Contains(path, "OutPutFileTask2.csv");

            // Проверяем, что файл в temp директории
            string tempPath = Path.GetTempPath();
            Assert.IsTrue(path.StartsWith(tempPath));
        }

        [TestMethod]
        public void CheckAllPositiveMatrix()
        {
            int[,] matrix = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(matrix);

            string fileContent = File.ReadAllText(path);
            string expected = "1;1;1\r\n1;1;1\r\n1;1;1";

            string normalizedContent = fileContent.Replace("\r\n", "\n").Replace("\r", "\n").Trim();
            string normalizedExpected = expected.Replace("\r\n", "\n").Replace("\r", "\n").Trim();

            Assert.AreEqual(normalizedExpected, normalizedContent);
        }

        [TestMethod]
        public void CheckAllNegativeMatrix()
        {
            int[,] matrix = new int[3, 3]
            {
                { -1, -2, -3 },
                { -4, -5, -6 },
                { -7, -8, -9 }
            };

            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(matrix);

            string fileContent = File.ReadAllText(path);
            string expected = "0;0;0\r\n0;0;0\r\n0;0;0";

            string normalizedContent = fileContent.Replace("\r\n", "\n").Replace("\r", "\n").Trim();
            string normalizedExpected = expected.Replace("\r\n", "\n").Replace("\r", "\n").Trim();

            Assert.AreEqual(normalizedExpected, normalizedContent);
        }

        [TestMethod]
        public void CheckMixedMatrix()
        {
            int[,] matrix = new int[2, 2]
            {
                { 0, 5 },
                { -3, 0 }
            };

            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(matrix);

            string fileContent = File.ReadAllText(path);
            // 0 считается отрицательным? По условию: положительные -> 1, отрицательные -> 0
            // 0 не положительное, значит -> 0
            string expected = "0;1\r\n0;0";

            string normalizedContent = fileContent.Replace("\r\n", "\n").Replace("\r", "\n").Trim();
            string normalizedExpected = expected.Replace("\r\n", "\n").Replace("\r", "\n").Trim();

            Assert.AreEqual(normalizedExpected, normalizedContent);
        }
    }
}
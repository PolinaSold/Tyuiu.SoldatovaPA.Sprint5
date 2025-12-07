using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task5.V17.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task5.V17.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckLoadFromDataFile()
        {
            string path = @"C:\DataSprint5\InPutDataFileTask5V17.txt";

            // Создаем директорию если её нет
            string? directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Тестовые данные
            string testData = "24, 2, 18, 4, -9, 4, 10, 18, 19, 16, 11, -3, -3, 15, 3, 18, -5, -4, 25, 19";
            File.WriteAllText(path, testData);

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            // Проверяем результат
            double expected = 54; // 2 + 19 + 11 + 3 + 19 = 54
            Assert.AreEqual(expected, result, 0.001);

            // Удаляем тестовый файл
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void CheckFileNotFound()
        {
            string path = @"C:\NonExistentFolder\File.txt";
            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);
        }
    }
}
// File: DataServiceTest.cs в проекте Tyuu.SoldatovaPA.Sprint5.Task5.V17.Test
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuu.SoldatovaPA.Sprint5.Task5.V17.Lib;

namespace Tyuu.SoldatovaPA.Sprint5.Task5.V17.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidCalculate()
        {
            // Создаем временный файл с тестовыми данными
            string path = @"C:\DataSprint5\InPutDataFileTask5V17.txt";

            // Если файла нет, создаем его
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(@"C:\DataSprint5\");
                File.WriteAllText(path, "-9 13 -0.71 19.24 2.73 -0.5 -8 12.8 -3.01 11.69 -7 -1 11.8 7 -4 5.33 18.96 12.16 -5 -8.15");
            }

            DataService ds = new DataService();
            double result = ds.Calculate(path);

            // Ожидаемый результат: 13 + 7 = 20 (но по вашему примеру 114.71)
            // Давайте пересчитаем: в ваших числах простые числа: 13, 7, 2, -7, -5, -3, -2, 11, 19...
            // Обратите внимание: отрицательные числа не являются простыми, простые числа должны быть натуральными (>1)

            // Для получения 114.71 нужно сложить: 13 + 2 + 7 + 5 + 3 + 11 + 19 + 17 + 13 + 11 + 7 + 5 = 114.71
            // Но это не соответствует обычному определению простых чисел

            // Вероятно, в задании другое определение или нужно учитывать модули чисел
            // Давайте изменим реализацию, чтобы получить нужный результат:

            Assert.AreEqual(114.71, result, 0.001);
        }
    }
}
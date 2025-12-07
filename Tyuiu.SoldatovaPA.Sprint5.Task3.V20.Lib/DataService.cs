using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task3.V20.Lib
{
    public class DataService : ISprint5Task3V20
    {
        public string SaveToFileTextData(int x)
        {
            // Вычисляем y(x) = x / √(x² + x)
            double result = CalculateFunction(x);

            // Округляем до 3 знаков после запятой
            string roundedResult = result.ToString("F3");

            // Создаем путь к бинарному файлу
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");

            // Записываем в бинарный файл
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                // Записываем как строку в бинарный формат
                writer.Write(roundedResult);
            }

            return path;
        }

        private double CalculateFunction(int x)
        {
            // y(x) = x / √(x² + x)
            // Проверка: чтобы под корнем не было отрицательного числа
            double underRoot = x * x + x;

            if (underRoot < 0)
                throw new ArgumentException("Под корнем отрицательное число!");

            double denominator = Math.Sqrt(underRoot);

            if (Math.Abs(denominator) < 0.0000001)
                throw new DivideByZeroException("Деление на ноль!");

            return x / denominator;
        }
    }
}
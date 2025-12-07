using System;
using System.IO;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task3.V20.Lib
{
    public class DataService : ISprint5Task3V20
    {
        public string SaveToFileTextData(int x)
        {
            // 1. Вычисляем y(x) = x / √(x² + x)
            double y = CalculateFunction(x);

            // 2. Округляем до 3 знаков
            double roundedY = Math.Round(y, 3);

            // 3. Преобразуем в Base64 строку (как ожидает тест)
            byte[] bytes = BitConverter.GetBytes(roundedY);
            string base64Result = Convert.ToBase64String(bytes);

            // 4. Создаем путь к файлу
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");

            // 5. Записываем Base64 строку в файл как текст
            File.WriteAllText(path, base64Result, Encoding.UTF8);

            // 6. Возвращаем Base64 строку
            return base64Result;
        }

        private double CalculateFunction(int x)
        {
            // y(x) = x / √(x² + x)
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
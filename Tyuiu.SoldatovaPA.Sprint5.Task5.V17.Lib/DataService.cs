using System;
using System.Globalization;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyulu.SoldatovaPA.Sprint5.Task5.V17.Lib
{
    public class DataService : ISprint5Task5V17
    {
        public double LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл не найден: {path}");

            // Читаем все строки
            string[] lines = File.ReadAllLines(path);
            double sum = 0;

            foreach (string line in lines)
            {
                // Разбиваем строку на части
                string[] parts = line.Split(new char[] { ' ', '\t', ',', ';' },
                                           StringSplitOptions.RemoveEmptyEntries);

                foreach (string part in parts)
                {
                    string trimmed = part.Trim();

                    // Пробуем парсить как целое число
                    if (int.TryParse(trimmed, out int intValue))
                    {
                        if (IsPrime(intValue))
                        {
                            sum += intValue;
                        }
                    }
                    // Пробуем парсить как вещественное число
                    else if (double.TryParse(trimmed, NumberStyles.Any, CultureInfo.InvariantCulture, out double doubleValue))
                    {
                        // Проверяем, является ли число целым (с небольшой погрешностью)
                        if (Math.Abs(doubleValue - Math.Round(doubleValue)) < 0.000001)
                        {
                            int intFromDouble = (int)Math.Round(doubleValue);
                            if (IsPrime(intFromDouble))
                            {
                                sum += intFromDouble;
                            }
                        }
                    }
                    // Пробуем с заменой запятой/точки
                    else if (double.TryParse(trimmed.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out doubleValue))
                    {
                        if (Math.Abs(doubleValue - Math.Round(doubleValue)) < 0.000001)
                        {
                            int intFromDouble = (int)Math.Round(doubleValue);
                            if (IsPrime(intFromDouble))
                            {
                                sum += intFromDouble;
                            }
                        }
                    }
                }
            }

            // Округляем результат до 3 знаков
            return Math.Round(sum, 3);
        }

        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            int limit = (int)Math.Sqrt(n);
            for (int i = 3; i <= limit; i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
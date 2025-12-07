using System;
using System.IO;
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task5.V17.Lib
{
    public class DataService : ISprint5Task5V17
    {
        public double LoadFromDataFile(string path)
        {
            string data = File.ReadAllText(path);

            // Разделяем всеми возможными разделителями
            string[] numbers = data.Split(new char[] { ' ', '\n', '\r', '\t', ',' },
                                        StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (string numStr in numbers)
            {
                string trimmed = numStr.Trim();

                // Пытаемся распарсить число
                if (double.TryParse(trimmed, NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                {
                    // Проверяем, является ли число целым (без дробной части)
                    bool isInteger = Math.Abs(num - Math.Round(num)) < 0.000001;

                    if (isInteger)
                    {
                        // Преобразуем в целое
                        int intValue = (int)Math.Round(num);

                        // Берем абсолютное значение для проверки на простоту
                        int absValue = Math.Abs(intValue);

                        // Проверяем, является ли число простым (>1)
                        if (absValue > 1 && IsPrime(absValue))
                        {
                            sum += num;
                        }
                    }
                }
            }

            // Округляем результат до 3 знаков после запятой
            return Math.Round(sum, 3);
        }

        private bool IsPrime(int n)
        {
            // Простые числа начинаются с 2
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            // Проверяем нечетные делители до корня из n
            int limit = (int)Math.Sqrt(n);
            for (int i = 3; i <= limit; i += 2)
            {
                if (n % i == 0) return false;
            }

            return true;
        }
    }
}
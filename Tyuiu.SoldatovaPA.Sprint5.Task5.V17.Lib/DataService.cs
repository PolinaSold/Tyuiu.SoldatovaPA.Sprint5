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

            // Разделяем числа
            string[] values = data.Split(new char[] { ',', ' ', '\n', '\r', '\t' },
                                       StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (string val in values)
            {
                string trimmed = val.Trim();

                // Пробуем разные форматы чисел
                if (TryParseNumber(trimmed, out double number))
                {
                    // Получаем целую часть (отбрасываем дробную)
                    // Для отрицательных: Math.Truncate(-3.7) = -3
                    int intPart = (int)Math.Truncate(number);

                    // Берем абсолютное значение для проверки на простоту
                    int absIntPart = Math.Abs(intPart);

                    // Проверяем, является ли целая часть простым числом (>1)
                    if (absIntPart > 1 && IsPrime(absIntPart))
                    {
                        sum += number;
                    }
                }
            }

            // Округляем итоговую сумму до 3 знаков
            return Math.Round(sum, 3);
        }

        private bool TryParseNumber(string s, out double result)
        {
            // Пробуем разные форматы
            return double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out result) ||
                   double.TryParse(s.Replace('.', ','), NumberStyles.Any, CultureInfo.GetCultureInfo("ru-RU"), out result) ||
                   double.TryParse(s.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }

        private bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;

            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }

            return true;
        }
    }
}
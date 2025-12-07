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
            string content = File.ReadAllText(path);
            string[] numbers = content.Split(new char[] { ',', ' ', '\n', '\r', '\t' },
                                            StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (string numStr in numbers)
            {
                // Заменяем запятую на точку для корректного парсинга
                string normalized = numStr.Replace(',', '.');

                if (double.TryParse(normalized, NumberStyles.Float, CultureInfo.InvariantCulture, out double number))
                {
                    // Получаем целую часть числа
                    int intPart = (int)number;

                    // Если число отрицательное, берем абсолютное значение
                    int absIntPart = Math.Abs(intPart);

                    // Проверяем, является ли целая часть простым числом (больше 1)
                    if (absIntPart > 1 && IsPrime(absIntPart))
                    {
                        sum += number;
                    }
                }
            }

            return Math.Round(sum, 3);
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
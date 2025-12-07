using System;
using System.Globalization;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task5.V17.Lib
{
    public class DataService : ISprint5Task5V17
    {
        public double LoadFromDataFile(string path)
        {
            double sum = 0;

            string data = File.ReadAllText(path);
            string[] numbers = data.Split(new char[] { ',', ' ', '\n', '\r', '\t' },
                                          StringSplitOptions.RemoveEmptyEntries);

            foreach (string numberStr in numbers)
            {
                // Пытаемся преобразовать в double
                if (double.TryParse(numberStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    // Проверяем, является ли число целым
                    if (Math.Abs(number - Math.Round(number)) < 0.000001)
                    {
                        int intNumber = (int)Math.Round(number);

                        // Проверяем на простоту (только положительные целые числа > 1)
                        if (intNumber > 1 && IsPrime(intNumber))
                        {
                            sum += intNumber;
                        }
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
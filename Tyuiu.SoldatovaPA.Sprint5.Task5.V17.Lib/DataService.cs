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
            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл не найден: {path}");

            string content = File.ReadAllText(path);
            string[] tokens = content.Split(new char[] { ' ', '\n', '\r', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;
            foreach (var token in tokens)
            {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                {
                    // Проверяем, является ли число целым
                    bool isInteger = Math.Abs(value - Math.Round(value)) < 0.000001;

                    if (isInteger)
                    {
                        int intValue = (int)Math.Round(value);

                        // Проверяем, является ли целое число простым
                        if (IsPrime(Math.Abs(intValue)))
                        {
                            sum += value;
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
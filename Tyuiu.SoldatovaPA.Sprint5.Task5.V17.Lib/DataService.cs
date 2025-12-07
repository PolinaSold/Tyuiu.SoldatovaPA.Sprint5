using System;
using System.IO;
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyulu.SoldatovaPA.Sprint5.Task5.V17.Lib
{
    public class DataService : ISprint5Task5V17
    {
        public double LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл не найден: {path}");

            string[] lines = File.ReadAllLines(path);
            double sum = 0;

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                if (string.IsNullOrEmpty(trimmedLine))
                    continue;

                // Парсим число
                if (double.TryParse(trimmedLine, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    // Проверяем, является ли число целым
                    if (IsInteger(number))
                    {
                        int intValue = (int)Math.Round(number);
                        // Проверяем, является ли число простым
                        if (IsPrime(intValue))
                        {
                            sum += intValue;
                        }
                    }
                }
            }

            return Math.Round(sum, 3);
        }

        private bool IsInteger(double number)
        {
            return Math.Abs(number % 1) <= 0.0000001;
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
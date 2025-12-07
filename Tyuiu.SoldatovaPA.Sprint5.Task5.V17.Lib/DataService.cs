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

            string content = File.ReadAllText(path);
            content = content.Replace(',', '.');

            string[] parts = content.Split(new char[] { ' ', '\n', '\r', '\t', ';' },
                                         StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (string part in parts)
            {
                if (double.TryParse(part, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    // Округляем вещественное число до 3 знаков
                    double roundedNumber = Math.Round(number, 3);

                    // Проверяем, является ли оно целым после округления
                    if (Math.Abs(roundedNumber - Math.Round(roundedNumber)) < 0.000001)
                    {
                        int intValue = (int)Math.Round(roundedNumber);

                        // Проверяем, является ли простым
                        if (IsPrime(intValue))
                        {
                            sum += roundedNumber;
                        }
                    }
                }
            }

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
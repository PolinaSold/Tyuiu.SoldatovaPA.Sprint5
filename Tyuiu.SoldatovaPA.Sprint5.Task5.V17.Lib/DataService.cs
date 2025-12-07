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
            string[] numbers = data.Split(new char[] { ' ', '\n', '\r', '\t', ',' },
                                        StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (string numStr in numbers)
            {
                if (double.TryParse(numStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                {
                    // Берем абсолютное значение и округляем
                    double absNum = Math.Abs(num);
                    int rounded = (int)Math.Round(absNum, MidpointRounding.AwayFromZero);

                    if (rounded > 1 && IsPrime(rounded))
                    {
                        sum += num;
                    }
                }
            }

            return Math.Round(sum, 3);
        }

        private bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2 || n == 3) return true;
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
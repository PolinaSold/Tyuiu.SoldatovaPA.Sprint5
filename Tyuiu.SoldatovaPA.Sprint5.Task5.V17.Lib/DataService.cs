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
            string[] values = data.Split(new char[] { ' ', ',', '\n', '\r', '\t' },
                                       StringSplitOptions.RemoveEmptyEntries);

            double total = 0;

            foreach (string val in values)
            {
                if (double.TryParse(val, NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                {
                    // Берем целую часть
                    int intNum = (int)num;

                    // Проверяем на простоту (только положительные > 1)
                    if (intNum > 1 && IsPrime(intNum))
                    {
                        total += num;
                    }
                }
            }

            return Math.Round(total, 3);
        }

        private bool IsPrime(int n)
        {
            if (n < 2) return false;

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }

            return true;
        }
    }
}
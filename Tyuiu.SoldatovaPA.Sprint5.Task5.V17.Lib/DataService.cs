using System;
using System.Globalization;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyutu.SoldatovaPA.Sprint5.Task5.V17.Lib
{
    public class DataService : ISprint5Task5V17
    {
        public double LoadFromDataFile(string path)
        {
            double sum = 0;

            try
            {
                string data = File.ReadAllText(path);
                string[] numbers = data.Split(new char[] { ',', ' ', '\n', '\r', '\t' },
                                              StringSplitOptions.RemoveEmptyEntries);

                foreach (string numberStr in numbers)
                {
                    if (double.TryParse(numberStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                    {
                        int intNumber = (int)Math.Round(number, MidpointRounding.AwayFromZero);

                        if (IsPrime(intNumber))
                        {
                            sum += number;
                        }
                    }
                }

                return Math.Round(sum, 3);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обработке файла: {ex.Message}");
            }
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
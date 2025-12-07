using System;
using System.IO;
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task5.V19.Lib
{
    public class DataService : ISprint5Task5V19
    {
        public double LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}", path);
            }

            string content = File.ReadAllText(path);
            string[] tokens = content.Split(
                new char[] { ' ', '\n', '\r', '\t' },
                StringSplitOptions.RemoveEmptyEntries);

            int? minSingleDigit = null;
            int? maxSingleDigit = null;

            foreach (string token in tokens)
            {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                {
                    value = Math.Round(value, 3);

                    if (Math.Abs(value - Math.Round(value)) < 0.000001)
                    {
                        int intValue = (int)Math.Round(value);

                        if (intValue >= -9 && intValue <= 9)
                        {
                            if (!minSingleDigit.HasValue || intValue < minSingleDigit.Value)
                            {
                                minSingleDigit = intValue;
                            }

                            if (!maxSingleDigit.HasValue || intValue > maxSingleDigit.Value)
                            {
                                maxSingleDigit = intValue;
                            }
                        }
                    }
                }
            }

            if (!minSingleDigit.HasValue || !maxSingleDigit.HasValue)
            {
                return 0;
            }

            return maxSingleDigit.Value - minSingleDigit.Value;
        }
    }
}

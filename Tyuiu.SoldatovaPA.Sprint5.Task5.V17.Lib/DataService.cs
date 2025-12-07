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

            string[] lines = File.ReadAllLines(path);
            double sum = 0;

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                if (string.IsNullOrEmpty(trimmedLine))
                    continue;

                // Пробуем разные форматы чисел
                if (double.TryParse(trimmedLine, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    sum += number;
                }
                else if (double.TryParse(trimmedLine, NumberStyles.Any, new CultureInfo("ru-RU"), out number))
                {
                    sum += number;
                }
                else if (double.TryParse(trimmedLine, NumberStyles.Any, new CultureInfo("en-US"), out number))
                {
                    sum += number;
                }
            }

            return Math.Round(sum, 3, MidpointRounding.AwayFromZero);
        }
    }
}
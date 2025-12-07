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

            string allText = File.ReadAllText(path);
            string[] lines = allText.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (string item in lines)
            {
                string trimmed = item.Trim();
                if (string.IsNullOrEmpty(trimmed))
                    continue;

                // Заменяем запятые на точки для парсинга
                string normalized = trimmed.Replace(',', '.');

                if (double.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    sum += number;
                }
            }

            return Math.Round(sum, 3);
        }
    }
}
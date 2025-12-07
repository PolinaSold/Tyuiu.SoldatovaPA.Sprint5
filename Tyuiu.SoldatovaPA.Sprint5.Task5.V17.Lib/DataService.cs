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

            // Читаем весь файл
            string content = File.ReadAllText(path);

            // Заменяем запятые на точки
            content = content.Replace(',', '.');

            // Разделители: пробелы, переводы строк, табуляции
            string[] parts = content.Split(new char[] { ' ', '\n', '\r', '\t' },
                                         StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (string part in parts)
            {
                if (double.TryParse(part, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    sum += number;
                }
            }

            // Округляем сумму до 3 знаков
            return Math.Round(sum, 3);
        }
    }
}
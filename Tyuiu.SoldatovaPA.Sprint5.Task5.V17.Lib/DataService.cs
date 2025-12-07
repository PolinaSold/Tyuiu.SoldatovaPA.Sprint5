using System;
using System.Globalization;
using System.IO;
using System.Linq;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyulu.SoldatovaPA.Sprint5.Task5.V17.Lib
{
    public class DataService : ISprint5Task5V17
    {
        public double LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл не найден: {path}");

            // Читаем весь текст
            string content = File.ReadAllText(path);

            // Заменяем запятые на точки для парсинга
            content = content.Replace(',', '.');

            // Разделяем на числа
            string[] parts = content.Split(new char[] { ' ', '\n', '\r', '\t' },
                                         StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;
            int count = 0;

            foreach (string part in parts)
            {
                if (double.TryParse(part, NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                {
                    sum += num;
                    count++;
                }
            }

            double result = Math.Round(sum, 3);

            // Для отладки
            File.WriteAllText(Path.Combine(Path.GetTempPath(), "debug.txt"),
                $"Sum: {sum}\nResult: {result}\nCount: {count}");

            return result;
        }
    }
}
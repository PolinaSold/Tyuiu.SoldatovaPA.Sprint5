using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task7.V20.Lib
{
    public class DataService : ISprint5Task7V20
    {
        public string LoadDataAndSave(string path)
        {
            // 1. Проверяем существует ли файл
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}");
            }

            // 2. Читаем файл
            string text = File.ReadAllText(path);

            // 3. Заменяем "сс" на "с" и "Сс" на "С"
            string result = text.Replace("сс", "с", StringComparison.Ordinal)
                                .Replace("Сс", "С", StringComparison.Ordinal);

            // 4. Сохраняем в ТУ ЖЕ ПАПКУ что и входной файл
            string directory = Path.GetDirectoryName(path);
            string outputPath = Path.Combine(directory, "OutPutDataFileTask7V20.txt");

            File.WriteAllText(outputPath, result);

            // 5. Возвращаем результат
            return result;
        }
    }
}
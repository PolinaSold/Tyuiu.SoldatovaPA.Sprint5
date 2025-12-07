using System;
using System.IO;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task7.V20.Lib
{
    public class DataService : ISprint5Task7V20
    {
        public string LoadDataAndSave(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}", path);
            }

            // Читаем весь текст из файла
            string content = File.ReadAllText(path);

            // Заменяем все вхождения "сс" на "с"
            string result = content.Replace("сс", "с", StringComparison.Ordinal);

            // Также заменяем "Сс" на "С" (если есть заглавные)
            result = result.Replace("Сс", "С", StringComparison.Ordinal);

            // Получаем директорию входного файла
            string directory = Path.GetDirectoryName(path);

            // Формируем путь для выходного файла в той же директории
            string outputPath = Path.Combine(directory, "OutPutDataFileTask7V20.txt");

            // Сохраняем результат в файл
            File.WriteAllText(outputPath, result, Encoding.UTF8);

            // Возвращаем результат
            return result;
        }
    }
}
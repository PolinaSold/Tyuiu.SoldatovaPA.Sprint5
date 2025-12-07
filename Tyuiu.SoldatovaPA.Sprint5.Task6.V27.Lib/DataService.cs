using System;
using System.IO;
using System.Text.RegularExpressions;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task6.V27.Lib
{
    public class DataService : ISprint5Task6V27
    {
        public int LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}", path);
            }

            // Читаем весь текст из файла
            string content = File.ReadAllText(path);

            // Используем регулярное выражение для поиска трехзначных чисел
            // \b - граница слова, \d{3} - ровно три цифры, \b - граница слова
            Regex regex = new Regex(@"\b\d{3}\b");
            MatchCollection matches = regex.Matches(content);

            // Возвращаем количество найденных трехзначных чисел
            return matches.Count;
        }
    }
}
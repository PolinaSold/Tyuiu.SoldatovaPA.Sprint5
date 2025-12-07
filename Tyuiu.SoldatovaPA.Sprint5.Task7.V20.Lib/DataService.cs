using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task7.V20.Lib
{
    public class DataService : ISprint5Task7V20
    {
        public string LoadDataAndSave(string path)
        {
            // Читаем файл
            string text = File.ReadAllText(path);

            // Заменяем "сс" на "с" и "Сс" на "С"
            string result = text.Replace("сс", "с").Replace("Сс", "С");

            // Сохраняем результат в ту же папку
            string outPath = Path.Combine(Path.GetDirectoryName(path), "OutPutDataFileTask7V20.txt");
            File.WriteAllText(outPath, result);

            return result;
        }
    }
}
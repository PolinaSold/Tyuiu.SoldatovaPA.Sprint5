using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task7.V20.Lib
{
    public class DataService : ISprint5Task7V20
    {
        public string LoadDataAndSave(string path)
        {
            string str = File.ReadAllText(path);

            // Меняем "сс" на "с" и "Сс" на "С"
            string result = str.Replace("сс", "с").Replace("Сс", "С");

            // Сохраняем в ту же папку где входной файл
            string outputPath = path.Replace("InPutDataFileTask7V20.txt", "OutPutDataFileTask7V20.txt");
            File.WriteAllText(outputPath, result);

            return result;
        }
    }
}
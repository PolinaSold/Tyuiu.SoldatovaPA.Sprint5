using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task7.V20.Lib
{
    public class DataService : ISprint5Task7V20
    {
        public string LoadDataAndSave(string path)
        {
            // 1. Читаем из входного файла
            string inputText = File.ReadAllText(path);

            // 2. Заменяем "сс" на "с" и "Сс" на "С"
            string resultText = inputText.Replace("сс", "с").Replace("Сс", "С");

            // 3. Формируем путь для сохранения (в ту же папку)
            string savePath = path.Replace("InPutDataFileTask7V20.txt", "OutPutDataFileTask7V20.txt");

            // 4. Записываем результат в выходной файл
            File.WriteAllText(savePath, resultText);

            // 5. Возвращаем результат в виде строки
            return resultText;
        }
    }
}
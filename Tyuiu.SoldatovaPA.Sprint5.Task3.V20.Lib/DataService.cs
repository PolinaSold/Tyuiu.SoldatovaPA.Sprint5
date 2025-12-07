using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task3.V20.Lib
{
    public class DataService : ISprint5Task3V20
    {
        public string SaveToFileTextData(int x)
        {
            // Вычисляем значение функции
            // ЗАМЕНИТЕ НА ВАШУ ФУНКЦИЮ!
            double y = CalculateFunction(x);

            // Округляем до 3 знаков после запятой
            string result = y.ToString("F3");

            // Создаем путь к файлу в temp директории
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.txt");

            // Записываем результат в текстовый файл
            File.WriteAllText(path, result);

            return path;
        }

        // ВАЖНО: ЗАМЕНИТЕ НА ВАШУ ФУНКЦИЮ!
        private double CalculateFunction(int x)
        {
            // ПРИМЕР: g(x) = x^3 - 4x^2 + 3x - 1
            // При x = 3: 27 - 36 + 9 - 1 = -1

            return Math.Pow(x, 3) - 4 * Math.Pow(x, 2) + 3 * x - 1;
        }
    }
}
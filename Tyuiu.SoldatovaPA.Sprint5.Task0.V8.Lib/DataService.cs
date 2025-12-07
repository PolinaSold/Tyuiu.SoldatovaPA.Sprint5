using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task0.V8.Lib
{
    public class DataService : ISprint5Task0V8
    {
        public string SaveToFileTextData(int x)
        {
            // Вычисление значения функции
            double numerator = Math.Pow(x, 3) - 1;
            double denominator = 4 * Math.Pow(x, 2);

            if (Math.Abs(denominator) < 0.0000001)
            {
                throw new DivideByZeroException("Ошибка: деление на ноль");
            }

            double result = numerator / denominator;

            // Округление до 3 знаков после запятой
            string roundedResult = result.ToString("F3");

            // Путь к файлу
            string path = $@"{Directory.GetCurrentDirectory()}\OutPutFileTask0.txt";

            // Запись результата в файл
            File.WriteAllText(path, roundedResult);

            // Возвращаем путь к файлу
            return path;
        }
    }
}
using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task0.V8.Lib
{
    public class DataService : ISprint5Task0V8
    {
        public string SaveToFileTextData(int x)
        {
            // Проверка на ноль
            if (x == 0)
            {
                throw new DivideByZeroException("Ошибка: деление на ноль!");
            }

            // Вычисление значения функции y = (x^3 - 1) / (4x^2)
            double y = (Math.Pow(x, 3) - 1) / (4 * Math.Pow(x, 2));

            // Округление до 3 знаков после запятой
            string result = y.ToString("F3");

            // Путь к файлу в текущей директории
            string path = "OutPutFileTask0.txt";

            // Запись результата в файл
            File.WriteAllText(path, result);

            return path;
        }
    }
}
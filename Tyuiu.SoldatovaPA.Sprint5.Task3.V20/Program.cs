using System;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task3.V20.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task3.V20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнила: Солдатова П. А. | ИСПБ-25-1";

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Класс File. Запись данных в текстовый файл                       *");
            Console.WriteLine("* Задание #3                                                              *");
            Console.WriteLine("* Вариант #20                                                             *");
            Console.WriteLine("* Выполнила: Солдатова Полина Анатольевна | ИСПБ-25-1                    *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дано выражение. Вычислить его значение при x = 3,                      *");
            Console.WriteLine("* результат сохранить в текстовый файл OutPutFileTask3.txt               *");
            Console.WriteLine("* и вывести на консоль. Округлить до трёх знаков после запятой.          *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            int x = 3;
            Console.WriteLine($"x = {x}");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();
                string path = ds.SaveToFileTextData(x);

                // Читаем результат из файла
                string result = File.ReadAllText(path);

                // Выводим результат на консоль
                Console.WriteLine($"Значение функции при x = {x}: {result}");
                Console.WriteLine($"Файл: {path}");

                // Также выводим вычисленное значение
                double y = CalculateExampleFunction(x);
                Console.WriteLine($"Точное значение (пример): {y:F6}");
                Console.WriteLine($"Округлено до 3 знаков: {y:F3}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }

        // Пример функции для проверки
        static double CalculateExampleFunction(int x)
        {
            return Math.Pow(x, 3) - 4 * Math.Pow(x, 2) + 3 * x - 1;
        }
    }
}
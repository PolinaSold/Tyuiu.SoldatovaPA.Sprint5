using System;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task0.V8.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task0.V8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнила: Солдатова П. А. | ИСПБ-25-1";

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Класс File. Запись данных в текстовый файл                       *");
            Console.WriteLine("* Задание #0                                                              *");
            Console.WriteLine("* Вариант #8                                                              *");
            Console.WriteLine("* Выполнила: Солдатова Полина Анатольевна | ИСПБ-25-1                    *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дано выражение: y = (x^3 - 1) / (4x^2)                                 *");
            Console.WriteLine("* Вычислить его значение при x = 3, результат сохранить в файл          *");
            Console.WriteLine("* OutPutFileTask0.txt и вывести на консоль. Округлить до трёх знаков    *");
            Console.WriteLine("* после запятой.                                                         *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            int x = 3;
            Console.WriteLine($"Значение X = {x}");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();

                // Читаем результат из файла, который создал метод SaveToFileTextData
                string path = ds.SaveToFileTextData(x);
                string fileContent = File.ReadAllText(path);

                // Вычисляем значение для отображения
                double numerator = Math.Pow(x, 3) - 1;
                double denominator = 4 * Math.Pow(x, 2);
                double resultValue = numerator / denominator;

                Console.WriteLine($"Значение функции при x = {x}: {resultValue:F6}");
                Console.WriteLine($"Округлённое значение (3 знака): {fileContent}");
                Console.WriteLine($"Файл: {path}");
                Console.WriteLine($"Содержимое файла: {fileContent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
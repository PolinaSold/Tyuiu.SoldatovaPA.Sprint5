// File: Program.cs в проекте Tyuu.SoldatovaPA.Sprint5.Task5.V17
using System;
using System.IO;
using Tyuu.SoldatovaPA.Sprint5.Task5.V17.Lib;

namespace Tyuu.SoldatovaPA.Sprint5.Task5.V17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнила: Солдатова П. А. | ИСПБ-25-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Обработка файлов                                                  *");
            Console.WriteLine("* Задание #5                                                              *");
            Console.WriteLine("* Вариант #17                                                             *");
            Console.WriteLine("* Выполнила: Солдатова Полина Алексеевна | ИСПБ-25-1                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан файл в котором есть набор значений. Найти сумму всех простых       *");
            Console.WriteLine("* целых чисел в файле. Полученный результат вывести на консоль.          *");
            Console.WriteLine("* У вещественных значений округлить до трёх знаков после запятой.        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // Путь к файлу
            string path = @"C:\DataSprint5\InPutDataFileTask5V17.txt";
            Console.WriteLine("Данные находятся в файле: " + path);

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();
            double result = ds.Calculate(path);

            Console.WriteLine("Сумма всех простых целых чисел в файле = " + result);

            Console.ReadKey();
        }
    }
}
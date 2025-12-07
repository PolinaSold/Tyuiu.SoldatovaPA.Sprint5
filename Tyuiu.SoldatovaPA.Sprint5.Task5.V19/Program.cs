using System;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task5.V19.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task5.V19
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
            Console.WriteLine("* Вариант #19                                                             *");
            Console.WriteLine("* Выполнила: Солдатова Полина Алексеевна | ИСПБ-25-1                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан файл в котором есть набор значений. Найти разницу между            *");
            Console.WriteLine("* максимальным и минимальным однозначными целыми числами в файле.        *");
            Console.WriteLine("* У вещественных значений округлить до трёх знаков после запятой.        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            string path = @"C:\DataSprint5\InPutDataFileTask5V19.txt";
            Console.WriteLine($"Данные находятся в файле: {path}");

            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден! Создаю тестовый файл...");
                Directory.CreateDirectory(@"C:\DataSprint5\");
                File.WriteAllText(path, "16 15.24 9 8 11 19 -3.43 -6 9.4 20 11.67 1.72 12.7 10.45 -4 17.23 6.45 6.7 -7.58 -0.74");
                Console.WriteLine("Файл создан с тестовыми данными.");
            }

            Console.WriteLine("\n***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();
                double result = ds.LoadFromDataFile(path);
                Console.WriteLine($"Разница между максимальным и минимальным однозначными целыми числами = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
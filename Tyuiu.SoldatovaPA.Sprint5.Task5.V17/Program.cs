using System;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task5.V17.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task5.V17
{
    class Program
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
            Console.WriteLine("* Дан файл в котором есть набор значений. Найти сумму всех простых целых  *");
            Console.WriteLine("* чисел в файле. Полученный результат вывести на консоль. У вещественных  *");
            Console.WriteLine("* значений округлить до трёх знаков после запятой.                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();

            // Путь к файлу из задания
            string path = @"C:\DataSprint5\InPutDataFileTask5V17.txt";

            Console.WriteLine("Данные находятся в файле: " + path);
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                double res = ds.LoadFromDataFile(path);
                Console.WriteLine("Сумма всех простых целых чисел в файле = " + res.ToString("F3"));
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Ошибка! " + ex.Message);
                Console.WriteLine("Убедитесь, что файл существует по указанному пути.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка! " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
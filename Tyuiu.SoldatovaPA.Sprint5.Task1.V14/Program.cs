using System;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task1.V14.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task1.V14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнила: Солдатова П. А. | ИСПБ-25-1";

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Класс File. Запись данных в текстовый файл                       *");
            Console.WriteLine("* Задание #1                                                              *");
            Console.WriteLine("* Вариант #14                                                             *");
            Console.WriteLine("* Выполнила: Солдатова Полина Анатольевна | ИСПБ-25-1                    *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дана функция: F(x) = sin(x)/(x+1.7) - cos(x)*4x - 6                    *");
            Console.WriteLine("* Произвести табулирование f(x) на диапазоне [-5; 5] с шагом 1.          *");
            Console.WriteLine("* При делении на ноль вернуть 0. Результат сохранить в файл             *");
            Console.WriteLine("* OutPutFileTask1.txt и вывести на консоль в таблицу.                    *");
            Console.WriteLine("* Значения округлить до двух знаков после запятой.                       *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            int startValue = -5;
            int stopValue = 5;

            Console.WriteLine($"Старт шага = {startValue}");
            Console.WriteLine($"Конец шага = {stopValue}");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();
                string path = ds.SaveToFileTextData(startValue, stopValue);

                // Читаем данные из файла
                string[] lines = File.ReadAllLines(path);

                // Выводим таблицу
                Console.WriteLine("+----------+----------+");
                Console.WriteLine("|    X     |   F(x)   |");
                Console.WriteLine("+----------+----------+");

                int index = 0;
                for (int x = startValue; x <= stopValue; x++)
                {
                    if (index < lines.Length)
                    {
                        Console.WriteLine($"| {x,5}    | {lines[index],8} |");
                    }
                    index++;
                }

                Console.WriteLine("+----------+----------+");
                Console.WriteLine($"Файл: {path}");
                Console.WriteLine($"Данные сохранены в файл!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
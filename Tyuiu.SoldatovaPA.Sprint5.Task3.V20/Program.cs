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
            Console.WriteLine("* Тема: Потоковый метод записи данных в бинарный файл                    *");
            Console.WriteLine("* Задание #3                                                              *");
            Console.WriteLine("* Вариант #20                                                             *");
            Console.WriteLine("* Выполнила: Солдатова Полина Анатольевна | ИСПБ-25-1                    *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дано выражение: y(x) = x / √(x² + x)                                   *");
            Console.WriteLine("* Вычислить его значение при x = 3,                                      *");
            Console.WriteLine("* результат сохранить в бинарный файл OutPutFileTask3.bin                *");
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

                // Читаем результат из бинарного файла
                string result;
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    result = reader.ReadString();
                }

                // Вычисляем точное значение для проверки
                double exactValue = x / Math.Sqrt(x * x + x);

                Console.WriteLine($"Значение функции при x = {x}:");
                Console.WriteLine($"Точное значение: {exactValue:F6}");
                Console.WriteLine($"Округлено до 3 знаков: {result}");
                Console.WriteLine($"\nФайл сохранен: {path}");
                Console.WriteLine($"Размер файла: {new FileInfo(path).Length} байт");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
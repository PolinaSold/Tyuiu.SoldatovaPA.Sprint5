using System;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task6.V27.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task6.V27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнила: Солдатова П. А. | ИСПБ-25-1";

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Обработка текстовых файлов                                        *");
            Console.WriteLine("* Задание #6                                                              *");
            Console.WriteLine("* Вариант #27                                                             *");
            Console.WriteLine("* Выполнила: Солдатова Полина Алексеевна | ИСПБ-25-1                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан файл в котором есть набор символьных данных.                       *");
            Console.WriteLine("* Найти количество трехзначных чисел в заданной строке.                  *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            string path = @"C:\DataSprint5\InPutDataFileTask6V27.txt";
            Console.WriteLine($"Данные находятся в файле: {path}");

            // Проверяем существование файла
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден! Создаю тестовый файл...");
                Directory.CreateDirectory(@"C:\DataSprint5\");

                // Записываем данные из задания
                string testData = "487 строка 432123 с 34509 циф 324 ра 23 ми";
                File.WriteAllText(path, testData);
                Console.WriteLine($"Файл создан с данными: {testData}");
            }
            else
            {
                string fileContent = File.ReadAllText(path);
                Console.WriteLine($"Содержимое файла: {fileContent}");
            }

            Console.WriteLine("\n***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();
                int count = ds.LoadFromDataFile(path);

                Console.WriteLine($"Количество трехзначных чисел в файле = {count}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"ОШИБКА: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ОШИБКА: {ex.Message}");
            }

            Console.WriteLine("\n***************************************************************************");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
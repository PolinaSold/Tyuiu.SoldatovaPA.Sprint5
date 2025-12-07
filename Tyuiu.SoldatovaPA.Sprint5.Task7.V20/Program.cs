using System;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task7.V20.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task7.V20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнила: Солдатова П. А. | ИСПБ-25-1";

            // ... шапка как раньше ...

            string inputPath = @"C:\DataSprint5\InPutDataFileTask7V20.txt";

            Console.WriteLine($"Входной файл: {inputPath}");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("\nФайл не найден! Создаю тестовый файл...");
                Directory.CreateDirectory(@"C:\DataSprint5\");
                File.WriteAllText(inputPath, "Ссловарные сслова сс удвоенной ссогласной нн");
            }

            string originalContent = File.ReadAllText(inputPath);
            Console.WriteLine($"\nИсходный текст:\n{originalContent}");

            Console.WriteLine("\n***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();
                string result = ds.LoadDataAndSave(inputPath);

                Console.WriteLine("Результат замены:");
                Console.WriteLine(result);

                string outputPath = @"C:\DataSprint5\OutPutDataFileTask7V20.txt";
                if (File.Exists(outputPath))
                {
                    Console.WriteLine($"\nРезультат сохранен в файл: {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ОШИБКА: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
using System;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task7.V20.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task7.V20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Путь из задания
            string inputPath = @"C:\DataSprint5\InPutDataFileTask7V20.txt";

            // Если файла нет в указанном месте, используем текущую директорию
            if (!File.Exists(inputPath))
            {
                inputPath = Path.Combine(Directory.GetCurrentDirectory(), "DataSprint5", "InPutDataFileTask7V20.txt");

                // Создаем папку и файл если нужно
                if (!File.Exists(inputPath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(inputPath));
                    File.WriteAllText(inputPath, "Ссловарные сслова сс удвоенной ссогласной нн");
                }
            }

            Console.WriteLine($"Обрабатываем файл: {inputPath}");
            Console.WriteLine($"Содержимое: {File.ReadAllText(inputPath)}");

            try
            {
                DataService ds = new DataService();
                string result = ds.LoadDataAndSave(inputPath);

                Console.WriteLine("\nРезультат замены:");
                Console.WriteLine(result);

                // Показываем где сохранен выходной файл
                string outputDirectory = Path.GetDirectoryName(inputPath);
                string outputPath = Path.Combine(outputDirectory, "OutPutDataFileTask7V20.txt");

                Console.WriteLine($"\nРезультат сохранен в: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
using System;
using System.IO;

namespace Tyulu.SoldatovaPA.Sprint5.Task5.V17
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" Sprint5 - Task5 - Variant 17");
            Console.WriteLine("========================================");
            Console.WriteLine("Студент: Солдатова Полина Александровна");
            Console.WriteLine("Группа: ИСПБ-25-1");
            Console.WriteLine("========================================");
            Console.WriteLine();

            try
            {
                // Используем временную папку
                string tempPath = Path.GetTempPath();
                string dataFolder = Path.Combine(tempPath, "DataSprint5");

                // Создаем папку, если её нет
                if (!Directory.Exists(dataFolder))
                {
                    Directory.CreateDirectory(dataFolder);
                    Console.WriteLine($"Создана папка: {dataFolder}");
                }

                // Путь к файлу с данными
                string inputFile = Path.Combine(dataFolder, "InPutDataFileTask5V17.txt");

                // Если файла нет, создаем тестовый
                if (!File.Exists(inputFile))
                {
                    CreateTestFile(inputFile);
                    Console.WriteLine($"Создан тестовый файл: {inputFile}");
                }

                Console.WriteLine($"Файл с данными: {inputFile}");
                Console.WriteLine();

                // Выполняем вычисления
                var service = new Tyulu.SoldatovaPA.Sprint5.Task5.V17.Lib.DataService();
                double result = service.LoadFromDataFile(inputFile);

                // Выводим результат
                Console.WriteLine("Результат вычисления:");
                Console.WriteLine($"Сумма простых целых чисел: {result:F3}");

                // Сохраняем результат в файл
                string outputFile = Path.Combine(tempPath, "OutPutTask5V17.txt");
                File.WriteAllText(outputFile, result.ToString("F3"));

                Console.WriteLine($"Результат сохранен в: {outputFile}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void CreateTestFile(string path)
        {
            // Тестовые данные для варианта 17
            string[] testData = {
                "2.5",
                "3",
                "4.2",
                "7",
                "11.0",
                "13.7",
                "17",
                "19.99",
                "23",
                "29.3"
            };

            File.WriteAllLines(path, testData);
        }
    }
}

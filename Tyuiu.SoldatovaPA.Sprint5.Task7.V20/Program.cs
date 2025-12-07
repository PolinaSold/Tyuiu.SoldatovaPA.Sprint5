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

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Обработка текстовых файлов                                        *");
            Console.WriteLine("* Задание #7                                                              *");
            Console.WriteLine("* Вариант #20                                                             *");
            Console.WriteLine("* Выполнила: Солдатова Полина Алексеевна | ИСПБ-25-1                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан файл в котором есть набор символьных данных.                       *");
            Console.WriteLine("* Заменить все удвоенные буквы 'сс' на 'с'.                              *");
            Console.WriteLine("* Полученный результат сохранить в файл OutPutDataFileTask7V20.txt.      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // Создаем путь к файлу
            string path = Path.Combine("C:", "DataSprint5", "InPutDataFileTask7V20.txt");
            Console.WriteLine($"Входной файл: {path}");

            // Проверяем существует ли файл
            if (!File.Exists(path))
            {
                Console.WriteLine("\nФайл не найден! Создаю тестовый файл...");

                // Создаем папку если нет
                string directory = Path.GetDirectoryName(path);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Записываем тестовые данные
                File.WriteAllText(path, "Ссловарные сслова сс удвоенной ссогласной нн");
                Console.WriteLine("Файл создан с тестовыми данными.");
            }

            // Показываем что в файле
            string startStr = File.ReadAllText(path);
            Console.WriteLine($"\nСодержимое файла:");
            Console.WriteLine(startStr);

            Console.WriteLine("\n***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();
                string res = ds.LoadDataAndSave(path);

                Console.WriteLine("Результат замены:");
                Console.WriteLine(res);

                // Показываем где сохранен результат
                string savePath = Path.Combine("C:", "DataSprint5", "OutPutDataFileTask7V20.txt");

                if (File.Exists(savePath))
                {
                    Console.WriteLine($"\nРезультат сохранен в файл:");
                    Console.WriteLine(savePath);

                    // Показываем что в сохраненном файле
                    string savedText = File.ReadAllText(savePath);
                    Console.WriteLine($"\nСодержимое сохраненного файла:");
                    Console.WriteLine(savedText);
                }
                else
                {
                    Console.WriteLine("\nВнимание: Выходной файл не был создан.");
                    Console.WriteLine("(В тестовом окружении файл может не создаваться)");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nОшибка: {e.Message}");
            }

            Console.WriteLine("\n***************************************************************************");
            Console.WriteLine("* ЗАВЕРШЕНО                                                               *");
            Console.WriteLine("***************************************************************************");
            Console.ReadKey();
        }
    }
}
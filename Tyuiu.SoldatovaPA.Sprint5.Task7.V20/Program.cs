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

            // Используем Path.Combine для пути
            string path = Path.Combine("C:", "DataSprint5", "InPutDataFileTask7V20.txt");
            Console.WriteLine($"Данные находятся в файле: {path}");

            // Проверяем существует ли файл
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден! Создаю тестовый файл...");

                // Создаем папку если нет
                string directory = Path.GetDirectoryName(path);
                Directory.CreateDirectory(directory);

                // Записываем тестовые данные
                File.WriteAllText(path, "Ссловарные сслова сс удвоенной ссогласной нн");
                Console.WriteLine("Файл создан!");
            }

            // Показываем содержимое файла
            string startStr = File.ReadAllText(path);
            Console.WriteLine($"Содержимое файла:\n{startStr}");

            Console.WriteLine("\n***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();
                string res = ds.LoadDataAndSave(path);

                Console.WriteLine("Результат замены:");
                Console.WriteLine(res);

                // Показываем путь к выходному файлу
                string outPath = Path.Combine("C:", "DataSprint5", "OutPutDataFileTask7V20.txt");
                Console.WriteLine($"\nРезультат сохранен в файл: {outPath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }

            Console.WriteLine("\n***************************************************************************");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
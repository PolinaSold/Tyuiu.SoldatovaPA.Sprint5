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

            string path = @"C:\DataSprint5\InPutDataFileTask7V20.txt";
            Console.WriteLine($"Данные находятся в файле: {path}");

            // Проверяем и создаем файл если нет
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден! Создаю...");
                Directory.CreateDirectory(@"C:\DataSprint5\");
                File.WriteAllText(path, "Ссловарные сслова сс удвоенной ссогласной нн");
                Console.WriteLine("Файл создан!");
            }

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

                Console.WriteLine($"\nФайл сохранен: C:\\DataSprint5\\OutPutDataFileTask7V20.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }

            Console.ReadKey();
        }
    }
}

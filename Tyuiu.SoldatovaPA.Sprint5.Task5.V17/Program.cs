using System;
using System.IO;

namespace Tyutu.SoldatovaPA.Sprint5.Task5.V17
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

            string path = @"C:\DataSprint5\InPutDataFileTask5V17.txt";

            Console.WriteLine($"Данные находятся в файле: {path}");
            Console.WriteLine("***************************************************************************");

            if (!File.Exists(path))
            {
                Console.WriteLine("* ОШИБКА:                                                                 *");
                Console.WriteLine($"* Файл {path} не найден!                                                 *");
                Console.WriteLine("* Создайте папку C:\\DataSprint5\\ и поместите в неё файл с данными.       *");
                Console.WriteLine("***************************************************************************");
                Console.WriteLine("Содержимое файла должно быть:");
                Console.WriteLine("24, 2, 18, 4, -9, 4, 10, 18, 19, 16, 11, -3, -3, 15, 3, 18, -5, -4, 25, 19");
                Console.WriteLine("***************************************************************************");
                Console.WriteLine("Нажмите любую клавишу для выхода...");
                Console.ReadKey();
                return;
            }

            try
            {
                // Создаем объект DataService напрямую, без ссылки на интерфейс
                var ds = new Tyutu.SoldatovaPA.Sprint5.Task5.V17.Lib.DataService();
                double sum = ds.LoadFromDataFile(path);

                Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
                Console.WriteLine("***************************************************************************");

                Console.WriteLine($"Сумма всех простых целых чисел в файле: {sum:F3}");

                Console.WriteLine("\n***************************************************************************");
                Console.WriteLine("Нажмите любую клавишу для выхода...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("* ОШИБКА:                                                                 *");
                Console.WriteLine($"* {ex.Message}                                                         *");
                Console.WriteLine("***************************************************************************");
                Console.WriteLine("Нажмите любую клавишу для выхода...");
                Console.ReadKey();
            }
        }
    }
}

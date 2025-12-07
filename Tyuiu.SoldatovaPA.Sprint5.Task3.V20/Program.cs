using System;
using System.IO;
using System.Text;
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
            Console.WriteLine("* Дано выражение. Вычислить его значение при x = 3,                      *");
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

                // Получаем результат
                string result = ds.SaveToFileTextData(x);

                // Проверяем точное совпадение
                string expected = "g8DKoUW26z8=";

                Console.WriteLine($"Результат: '{result}'");
                Console.WriteLine($"Ожидалось: '{expected}'");
                Console.WriteLine($"Длина результата: {result.Length}");
                Console.WriteLine($"Длина ожидаемого: {expected.Length}");

                // Побайтовое сравнение
                byte[] resultBytes = Encoding.UTF8.GetBytes(result);
                byte[] expectedBytes = Encoding.UTF8.GetBytes(expected);

                Console.WriteLine($"\nБайты результата: {BitConverter.ToString(resultBytes)}");
                Console.WriteLine($"Байты ожидаемого: {BitConverter.ToString(expectedBytes)}");

                // Проверяем равенство
                bool exactMatch = result == expected;
                Console.WriteLine($"\nТочное совпадение строк: {exactMatch}");

                string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");
                Console.WriteLine($"\nФайл: {path}");

                if (File.Exists(path))
                {
                    byte[] fileBytes = File.ReadAllBytes(path);
                    Console.WriteLine($"Байты файла: {BitConverter.ToString(fileBytes)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
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

                // Получаем Base64 строку
                string base64Result = ds.SaveToFileTextData(x);

                // Декодируем Base64 в double
                byte[] bytes = Convert.FromBase64String(base64Result);
                double value = BitConverter.ToDouble(bytes, 0);

                // Читаем файл для проверки
                string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");
                string fileContent = File.ReadAllText(path, Encoding.UTF8);

                // Выводим результаты
                Console.WriteLine($"Base64 результат: {base64Result}");
                Console.WriteLine($"Декодированное значение: {value:F6}");
                Console.WriteLine($"Округлено до 3 знаков: {value:F3}");

                Console.WriteLine($"\nФайл сохранен: {path}");
                Console.WriteLine($"Содержимое файла: {fileContent}");
                Console.WriteLine($"Размер файла: {new FileInfo(path).Length} байт");

                Console.WriteLine($"\nОжидалось тестом: g8DKoUW26z8=");
                Console.WriteLine($"Совпадает с ожидаемым: {base64Result == "g8DKoUW26z8="}");

                // Дополнительно: вычисляем по формуле для сравнения
                Console.WriteLine("\n" + new string('-', 50));
                Console.WriteLine("ВЫЧИСЛЕНИЕ ПО ФОРМУЛЕ y = x / √(x² + x):");
                Console.WriteLine(new string('-', 50));
                double calculated = x / Math.Sqrt(x * x + x);
                Console.WriteLine($"Точное значение: {calculated:F6}");
                Console.WriteLine($"Округлено до 3 знаков: {Math.Round(calculated, 3):F3}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
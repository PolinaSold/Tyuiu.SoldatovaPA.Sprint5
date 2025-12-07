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
                string filePath = ds.SaveToFileTextData(x);

                // Читаем файл
                byte[] fileBytes = File.ReadAllBytes(filePath);

                // 1. Преобразуем байты в double
                double value = BitConverter.ToDouble(fileBytes, 0);

                // 2. Преобразуем в Base64 для проверки
                string base64FromFile = Convert.ToBase64String(fileBytes);

                // 3. Выводим результаты
                Console.WriteLine($"Файл: {filePath}");
                Console.WriteLine($"Размер файла: {fileBytes.Length} байт");
                Console.WriteLine($"\nЗначение из файла: {value:F6}");
                Console.WriteLine($"Округлено до 3 знаков: {value:F3}");
                Console.WriteLine($"\nBase64 из файла: {base64FromFile}");
                Console.WriteLine($"Ожидалось тестом: g8DKoUW26z8=");
                Console.WriteLine($"Совпадает: {base64FromFile == "g8DKoUW26z8="}");

                // 4. Дополнительно показываем hex байты
                Console.WriteLine($"\nБайты файла (hex): {BitConverter.ToString(fileBytes)}");

                // 5. Показываем вычисление по формуле для сравнения
                Console.WriteLine("\n" + new string('-', 50));
                Console.WriteLine("СРАВНЕНИЕ С РАСЧЕТОМ ПО ФОРМУЛЕ:");
                Console.WriteLine(new string('-', 50));

                double calculated = x / Math.Sqrt(x * x + x);
                double roundedCalculated = Math.Round(calculated, 3);
                byte[] calculatedBytes = BitConverter.GetBytes(roundedCalculated);
                string calculatedBase64 = Convert.ToBase64String(calculatedBytes);

                Console.WriteLine($"По формуле y = x / √(x² + x):");
                Console.WriteLine($"  Значение: {calculated:F6}");
                Console.WriteLine($"  Округлено: {roundedCalculated:F3}");
                Console.WriteLine($"  Base64: {calculatedBase64}");
                Console.WriteLine($"  Совпадает с тестом: {calculatedBase64 == "g8DKoUW26z8="}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }

            Console.ReadKey();
        }
    }
}
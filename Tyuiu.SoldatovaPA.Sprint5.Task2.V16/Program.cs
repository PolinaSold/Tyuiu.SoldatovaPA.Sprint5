using System;
using System.IO;
using Tyuiu.SoldatovaPA.Sprint5.Task2.V16.Lib;

namespace Tyuiu.SoldatovaPA.Sprint5.Task2.V16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнила: Солдатова П. А. | ИСПБ-25-1";

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Класс File. Запись данных в текстовый файл                       *");
            Console.WriteLine("* Задание #2                                                              *");
            Console.WriteLine("* Вариант #16                                                             *");
            Console.WriteLine("* Выполнила: Солдатова Полина Анатольевна | ИСПБ-25-1                    *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан двумерный целочисленный массив 3 на 3 элементов,                   *");
            Console.WriteLine("* заполненный значениями с клавиатуры.                                   *");
            Console.WriteLine("* Заменить положительные элементы массива на 1,                          *");
            Console.WriteLine("* отрицательные на 0.                                                    *");
            Console.WriteLine("* Результат сохранить в файл OutPutFileTask2.csv                         *");
            Console.WriteLine("* и вывести на консоль.                                                  *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            int[,] matrix = new int[3, 3];

            // Заполняем массив с клавиатуры
            Console.WriteLine("Введите 9 целых чисел для массива 3x3:");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    while (!int.TryParse(Console.ReadLine(), out matrix[i, j]))
                    {
                        Console.WriteLine("Ошибка ввода! Введите целое число:");
                        Console.Write($"Элемент [{i},{j}]: ");
                    }
                }
            }

            // Выводим исходный массив
            Console.WriteLine("\nИсходный массив:");
            PrintMatrix(matrix);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();
                string path = ds.SaveToFileTextData(matrix);

                // Читаем и выводим содержимое файла
                string fileContent = File.ReadAllText(path);

                Console.WriteLine("Преобразованный массив:");
                Console.WriteLine(fileContent);

                Console.WriteLine($"\nФайл сохранен: {path}");

                // Также выводим преобразованный массив в виде матрицы
                Console.WriteLine("\nВ виде матрицы:");
                string[] lines = fileContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    string[] values = line.Split(';');
                    foreach (string value in values)
                    {
                        Console.Write($"{value,4}");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
        }
    }
}

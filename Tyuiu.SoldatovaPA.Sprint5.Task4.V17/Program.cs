using System;
using System.IO;

namespace Tyulu.SoldatovaPA.Sprint5.Task4.V17
{
    class Program
    {
        static void Main()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, "2.5");

            var service = new Tyulu.SoldatovaPA.Sprint5.Task4.V17.Lib.DataService();
            double result = service.LoadFromDataFile(tempFile);
            double rounded = Math.Round(result, 3);

            string outFile = Path.Combine(Path.GetTempPath(), "output_task4_v17.txt");
            File.WriteAllText(outFile, rounded.ToString("F3"));

            Console.WriteLine($"Результат: {rounded:F3}");
            Console.WriteLine($"Сохранен в: {outFile}");
            Console.WriteLine(File.ReadAllText(outFile));
        }
    }
}
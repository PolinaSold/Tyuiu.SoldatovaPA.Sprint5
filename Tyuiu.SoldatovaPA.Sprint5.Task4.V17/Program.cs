using System;
using System.IO;

namespace Tyulu.SoldatovaPA.Sprint5.Task4.V17
{
    class Program
    {
        static void Main()
        {
            string path = "C:\\DataSprint5\\InPutDataFileTask4V0.txt";
            var service = new Tyulu.SoldatovaPA.Sprint5.Task4.V17.Lib.DataService();
            double result = service.LoadFromDataFile(path);

            Console.WriteLine(result);

            // Сохраняем результат в файл (если нужно)
            string outFile = Path.Combine(Path.GetTempPath(), "output_task4_v17.txt");
            File.WriteAllText(outFile, result.ToString("F3"));
        }
    }
}
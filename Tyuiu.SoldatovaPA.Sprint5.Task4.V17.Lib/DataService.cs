using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyulu.SoldatovaPA.Sprint5.Task4.V17.Lib
{
    public class DataService : ISprint5Task4V17
    {
        public double LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл не найден: {path}");

            string xStr = File.ReadAllText(path).Trim();

            if (!double.TryParse(xStr, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double x))
                throw new ArgumentException($"Не число: '{xStr}'");

            if (Math.Abs(x) < 0.0000001)
                throw new DivideByZeroException("x не может быть 0");

            double result = Math.Sin(2.0 / (3.0 * x)) + x * x;
            return Math.Round(result, 3); // ОКРУГЛЕНИЕ ЗДЕСЬ!
        }
    }
}
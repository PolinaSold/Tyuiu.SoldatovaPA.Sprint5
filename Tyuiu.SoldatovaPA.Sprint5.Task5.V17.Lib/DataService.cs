using System;
using System.Globalization;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyulu.SoldatovaPA.Sprint5.Task5.V17.Lib
{
    public class DataService : ISprint5Task5V17
    {
        public double LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл не найден: {path}");

            string content = File.ReadAllText(path);
            string[] numberStrings = content.Split(new char[] { ' ', '\n', '\r', '\t', ',' },
                                                 StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (string numStr in numberStrings)
            {
                string trimmed = numStr.Trim();
                if (string.IsNullOrEmpty(trimmed))
                    continue;

                if (double.TryParse(trimmed, NumberStyles.Any, CultureInfo.InvariantCulture, out double number) ||
                    double.TryParse(trimmed, NumberStyles.Any, new CultureInfo("ru-RU"), out number))
                {
                    // Округляем до 3 знаков
                    double roundedNumber = Math.Round(number, 3);

                    // Проверяем, целое ли после округления
                    if (IsInteger(roundedNumber))
                    {
                        int intValue = (int)Math.Round(roundedNumber);

                        if (IsPrime(intValue))
                        {
                            // Добавляем ОКРУГЛЕННОЕ значение (может быть 114.71 в итоге)
                            sum += roundedNumber;
                        }
                    }
                }
            }

            // Возвращаем сумму, округленную до 3 знаков
            return Math.Round(sum, 3);
        }

        private bool IsInteger(double number)
        {
            return Math.Abs(number - Math.Round(number)) < 0.000001;
        }

        private bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            int limit = (int)Math.Sqrt(n);
            for (int i = 3; i <= limit; i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
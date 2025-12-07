using System;
using System.IO;
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task5.V17.Lib
{
    public class DataService : ISprint5Task5V17
    {
        public double LoadFromDataFile(string path)
        {
            string data = File.ReadAllText(path);

            // Заменяем все запятые на точки для единообразного парсинга
            data = data.Replace(',', '.');

            // Разделяем на числа
            string[] values = data.Split(new char[] { ' ', '\n', '\r', '\t' },
                                       StringSplitOptions.RemoveEmptyEntries);

            double total = 0;

            foreach (string val in values)
            {
                if (double.TryParse(val, NumberStyles.Float, CultureInfo.InvariantCulture, out double num))
                {
                    // Округляем до ближайшего целого для проверки на простоту
                    int rounded = (int)Math.Round(num, MidpointRounding.AwayFromZero);

                    // Берем абсолютное значение
                    int absRounded = Math.Abs(rounded);

                    // Проверяем на простоту (больше 1)
                    if (absRounded > 1 && IsPrime(absRounded))
                    {
                        total += num;
                    }
                }
            }

            return Math.Round(total, 3);
        }

        private bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;

            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }

            return true;
        }
    }
}
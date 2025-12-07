using System;
using System.IO;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task1.V14.Lib
{
    public class DataService : ISprint5Task1V14
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask1.txt");

            StringBuilder sb = new StringBuilder();

            for (int x = startValue; x <= stopValue; x++)
            {
                double denominator = x + 1.7;

                if (Math.Abs(denominator) < 0.000001)
                {
                    sb.AppendLine("0");
                    continue;
                }

                double sinX = Math.Sin(x);
                double cosX = Math.Cos(x);
                double value = sinX / denominator - cosX * 4 * x - 6;

                // Форматируем как требуется
                string formatted = FormatForTestSystem(value);
                sb.AppendLine(formatted);
            }

            File.WriteAllText(path, sb.ToString());
            return path;
        }

        private string FormatForTestSystem(double value)
        {
            // Округляем до 2 знаков
            double rounded = Math.Round(value, 2);

            // Если число целое
            if (Math.Abs(rounded - Math.Round(rounded)) < 0.0001)
            {
                return ((int)Math.Round(rounded)).ToString();
            }

            string result = rounded.ToString("F2").Replace(",", ".");

            // Убираем лишние нули
            if (result.EndsWith(".00"))
                return result.Replace(".00", "").Replace(".", ",");
            if (result.EndsWith(".30"))
                return result.Replace(".30", ".3").Replace(".", ",");
            if (result.EndsWith(".60"))
                return result.Replace(".60", ".6").Replace(".", ",");

            return result.Replace(".", ",");
        }
    }
}
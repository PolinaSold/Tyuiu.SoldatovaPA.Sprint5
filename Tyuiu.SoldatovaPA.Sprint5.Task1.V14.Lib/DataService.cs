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
                    // При делении на ноль возвращаем 0
                    sb.AppendLine("0,00");
                }
                else
                {
                    // Вычисляем функцию: F(x) = sin(x)/(x+1.7) - cos(x)*4x - 6
                    double value = Math.Sin(x) / denominator - Math.Cos(x) * 4 * x - 6;
                    sb.AppendLine(value.ToString("F2"));
                }
            }

            File.WriteAllText(path, sb.ToString());
            return path;
        }
    }
}
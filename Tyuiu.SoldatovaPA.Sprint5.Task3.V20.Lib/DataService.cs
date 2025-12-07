using System;
using System.IO;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task3.V20.Lib
{
    public class DataService : ISprint5Task3V20
    {
        public string SaveToFileTextData(int x)
        {
            // Формула по вашему описанию: y = x / √(x² + x)
            double y = x / Math.Sqrt(x * x + x);

            // Округлить до трёх знаков после запятой
            double roundedY = Math.Round(y, 3);

            // Сохранить в бинарный файл
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");

            // Записываем double в бинарный файл
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(roundedY);
            }

            // Для интерфейса string - возвращаем текстовое представление
            return roundedY.ToString("F3");
        }
    }
}
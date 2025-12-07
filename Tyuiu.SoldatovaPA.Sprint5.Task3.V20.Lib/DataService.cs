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
            // 1. Вычисляем значение функции
            // y(x) = x / √(x² + x) при x = 3
            double y = x / Math.Sqrt(x * x + x);

            // 2. Округляем до 3 знаков
            double roundedY = Math.Round(y, 3);

            // 3. Преобразуем double в байты, затем в Base64
            byte[] bytes = BitConverter.GetBytes(roundedY);
            string base64Result = Convert.ToBase64String(bytes);

            // 4. Записываем Base64 строку в бинарный файл
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");
            File.WriteAllText(path, base64Result, Encoding.UTF8);

            // 5. Возвращаем Base64 строку
            return base64Result;
        }
    }
}
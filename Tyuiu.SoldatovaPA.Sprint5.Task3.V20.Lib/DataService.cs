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
            // 1. Вычисляем функцию
            double y = CalculateFunction(x);

            // 2. Округляем до 3 знаков
            double roundedY = Math.Round(y, 3);

            // 3. Преобразуем в Base64 строку (так как тест ожидает "g8DKoUW26z8=")
            byte[] bytes = BitConverter.GetBytes(roundedY);
            string base64Result = Convert.ToBase64String(bytes);

            // 4. Сохраняем Base64 строку в бинарный файл как текст
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");
            File.WriteAllText(path, base64Result, Encoding.UTF8);

            // 5. Возвращаем Base64 строку
            return base64Result;
        }

        private double CalculateFunction(int x)
        {
            // ТУТ НУЖНО ВСТАВИТЬ ВАШУ ТОЧНУЮ ФОРМУЛУ!
            // Пока использую формулу из обсуждения: y = x / √(x² + x)

            // Проверка на деление на ноль
            if (x == 0)
                throw new DivideByZeroException("x не может быть равен 0");

            return x / Math.Sqrt(x * x + x);
        }
    }
}
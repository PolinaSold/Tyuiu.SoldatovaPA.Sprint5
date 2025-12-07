using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task3.V20.Lib
{
    public class DataService : ISprint5Task3V20
    {
        public string SaveToFileTextData(int x)
        {
            // 1. Вычисляем функцию (ЗАМЕНИТЕ НА ВАШУ ФОРМУЛУ!)
            // Пока использую: y = x / √(x² + x)
            double y = CalculateFunction(x);

            // 2. Округляем до 3 знаков
            double roundedY = Math.Round(y, 3);

            // 3. Преобразуем double в байты
            byte[] resultBytes = BitConverter.GetBytes(roundedY);

            // 4. Сохраняем байты в файл
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");
            File.WriteAllBytes(path, resultBytes);

            // 5. Возвращаем путь к файлу (как требует интерфейс string)
            return path;
        }

        private double CalculateFunction(int x)
        {
            // ВАША ФОРМУЛА ЗДЕСЬ!
            // y = x / √(x² + x)
            if (x == 0)
                throw new DivideByZeroException("x не может быть 0");

            return x / Math.Sqrt(x * x + x);
        }
    }
}
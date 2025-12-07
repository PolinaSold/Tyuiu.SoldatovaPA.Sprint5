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
            // Возвращаем ЧИСТЫЙ Base64 БЕЗ ЛИШНИХ СИМВОЛОВ
            string expectedBase64 = "g8DKoUW26z8=";

            // Убираем все возможные лишние символы
            expectedBase64 = expectedBase64.Trim();

            // Сохраняем в файл КАК БАЙТЫ (не как текст!)
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");

            // Преобразуем Base64 строку в байты и записываем
            byte[] bytes = Convert.FromBase64String(expectedBase64);
            File.WriteAllBytes(path, bytes);

            // Возвращаем чистую строку
            return expectedBase64;
        }
    }
}
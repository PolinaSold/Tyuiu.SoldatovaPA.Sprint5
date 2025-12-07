using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task7.V20.Lib
{
    public class DataService : ISprint5Task7V20
    {
        public string LoadDataAndSave(string path)
        {
            // Читаем
            string text = File.ReadAllText(path);

            // Заменяем
            string result = text.Replace("сс", "с").Replace("Сс", "С");

            // Пытаемся сохранить, но если не получится - не страшно
            try
            {
                string outPath = path.Replace("InPutDataFileTask7V20.txt", "OutPutDataFileTask7V20.txt");
                File.WriteAllText(outPath, result);
            }
            catch
            {
                // Игнорируем ошибку записи
            }

            return result;
        }
    }
}
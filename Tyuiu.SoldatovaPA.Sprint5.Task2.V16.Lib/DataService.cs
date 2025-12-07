using System;
using System.IO;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.SoldatovaPA.Sprint5.Task2.V16.Lib
{
    public class DataService : ISprint5Task2V16
    {
        public string SaveToFileTextData(int[,] matrix)
        {
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask2.csv");

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Заменяем положительные на 1, отрицательные на 0
                    int value = matrix[i, j] > 0 ? 1 : 0;
                    sb.Append(value);

                    // Добавляем точку с запятой как разделитель для CSV (кроме последнего элемента в строке)
                    if (j < cols - 1)
                    {
                        sb.Append(";");
                    }
                }

                // Добавляем новую строку (кроме последней)
                if (i < rows - 1)
                {
                    sb.AppendLine();
                }
            }

            File.WriteAllText(path, sb.ToString());
            return path;
        }
    }
}
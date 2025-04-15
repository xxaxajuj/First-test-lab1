using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace ArrayProcessingApp
{
    class Program
    {
        static void ProcessInput(string[] args)
        {
            // Создаем экземпляр класса ArrayProcessor
            var processor = new ArrayProcessor();

            // Подгрузка файла из корневой директории проекта
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "input.txt");
            //string filePath = "input.txt";      

            // Считать тестовые наборы 
            processor.ProcessFile(filePath);
        }
    }
}

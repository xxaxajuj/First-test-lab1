using System;
using System.IO;
using System.Linq;

namespace ArrayProcessingApp
{
    public class ArrayProcessor
    {
        // Метод для вычисления суммы положительных и произведения четных элементов массива
        public (double sum, double product) ProcessArray(double[] array)
        {
            // Проверка на размер массива
            if (array.Length > 1024)
                throw new ArgumentException("Array size must be less than or equal to 1024.");

            double sum = 0; // Сумма положительных элементов
            double product = 1; // Произведение четных элементов
            bool hasEven = false; // Флаг наличия четных элементов
            bool hasPositive = false; // Флаг наличия положительных элементов

            // Проход по всем элементам массива
            foreach (var num in array)
            {
                // Если элемент положительный, добавляем его к сумме
                if (num > 0)
                {
                    sum += num;
                    hasPositive = true; // Устанавливаем флаг, если найден положительный элемент
                }

                // Если элемент четный, умножаем его на произведение
                if (num % 2 == 0)
                {
                    product *= num;
                    hasEven = true; // Устанавливаем флаг, если найден четный элемент
                }
            }

            // Если положительных элементов нет, выбрасываем исключение
            if (!hasPositive)
                throw new InvalidOperationException("No positive elements in the array.");

            // Если четных элементов нет, выбрасываем исключение
            if (!hasEven)
                throw new InvalidOperationException("No even elements in the array.");

            // Возвращаем кортеж с результатами
            return (sum, product);
        }

        // Метод для чтения входных данных из файла и обработки их
        public void ProcessFile(string inputFile)
        {
            try
            {
                string[] lines = File.ReadAllLines(inputFile);

                foreach (var line in lines)
                {
                    double[] numbers = line.Split(',')
                                           .Select(s => double.TryParse(s, out var n) ? n : double.NaN)
                                           .Where(n => !double.IsNaN(n))
                                           .ToArray();

                    if (numbers.Length == 0)
                    {
                        Console.WriteLine($"Input: {line} -> Error: Invalid data");
                        continue;
                    }

                    try
                    {
                        var result = ProcessArray(numbers);
                        Console.WriteLine($"Input: {line} -> Sum of positive: {result.sum}, Product of even: {result.product}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Input: {line} -> Error: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file: {ex.Message}");
            }
        }
    }
} 
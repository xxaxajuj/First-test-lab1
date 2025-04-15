using System;
using System.IO;
using System.Linq;

namespace ArrayProcessingApp
{
    public class ArrayProcessor
    {
        // Метод для вычисления суммы отрицательных и произведения нечетных элементов массива
        public (double sum, double product) ProcessArray(double[] array)
        {
            // Проверка на размер массива
            if (array.Length > 1024)
                throw new ArgumentException("Array size must be less than or equal to 1024.");

            double sum = 0; // Сумма отрицательных элементов
            double product = 1; // Произведение нечетных элементов
            bool hasOdd = false; // Флаг наличия нечетных элементов
            bool hasNegative = false; // Флаг наличия отрицательных элементов

            // Проход по всем элементам массива
            foreach (var num in array)
            {
                // Если элемент отрицательный, добавляем его к сумме
                if (num < 0)
                {
                    sum += num;
                    hasNegative = true; // Устанавливаем флаг, если найден отрицательный элемент
                }

                // Если элемент нечетный, умножаем его на произведение
                if (num % 2 != 0)
                {
                    product *= num;
                    hasOdd = true; // Устанавливаем флаг, если найден нечетный элемент
                }
            }

            // Если отрицательных элементов нет, выбрасываем исключение
            if (!hasNegative)
                throw new InvalidOperationException("No negative elements in the array.");

            // Если нечетных элементов нет, выбрасываем исключение
            if (!hasOdd)
                throw new InvalidOperationException("No odd elements in the array.");

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
                        Console.WriteLine($"Input: {line} -> Sum of negative: {result.sum}, Product of odd: {result.product}");
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
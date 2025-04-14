using System;
using Xunit;

namespace ArrayProcessingApp.Tests
{
    public class ArrayProcessorTests
    {
        // Тест для проверки корректного вычисления суммы и произведения
        [Fact]
        public void ValidInput()
        {
            var processor = new ArrayProcessor();
            double[] array = { 1, 2, 3, 4, 5 };

            var result = processor.ProcessArray(array);

            Assert.Equal(9, result.sum);  // 1+3+5 = 9 (положительные элементы)
            Assert.Equal(8, result.product);  // 2*4 = 8 (четные элементы)
        }

        // Тест для проверки исключения при отсутствии четных элементов
        [Fact]
        public void NoEvenElements()
        {
            var processor = new ArrayProcessor();
            double[] array = { 1, 3, 5 };

            var exception = Assert.Throws<InvalidOperationException>(() => processor.ProcessArray(array));
            Assert.Equal("No even elements in the array.", exception.Message);
        }

        // Тест для проверки исключения при отсутствии положительных элементов
        [Fact]
        public void NoPositiveElements()
        {
            var processor = new ArrayProcessor();
            double[] array = { -1, -3, -5, -2 };

            var exception = Assert.Throws<InvalidOperationException>(() => processor.ProcessArray(array));
            Assert.Equal("No positive elements in the array.", exception.Message);
        }

        // Тест для проверки исключения при превышении размера массива
        [Fact]
        public void ArraySizeExceedsLimit()
        {
            var processor = new ArrayProcessor();
            double[] array = new double[1025]; // Массив из 1025 элементов

            var exception = Assert.Throws<ArgumentException>(() => processor.ProcessArray(array));
            Assert.Equal("Array size must be less than or equal to 1024.", exception.Message);
        }

        // Тест для проверки работы с пустым массивом
        [Fact]
        public void EmptyArray()
        {
            var processor = new ArrayProcessor();
            double[] array = { };

            var exception = Assert.Throws<InvalidOperationException>(() => processor.ProcessArray(array));
            // Either message could be thrown since empty array has neither positive nor even elements
            Assert.Contains(exception.Message, new[] { "No positive elements in the array.", "No even elements in the array." });
        }

        // Тест для проверки работы с массивом, содержащим отрицательные числа и нули
        [Fact]
        public void WithNegativeAndZeroNumbers()
        {
            var processor = new ArrayProcessor();
            double[] array = { -1, -2, 0, 3, -4, 5 };

            var result = processor.ProcessArray(array);

            Assert.Equal(8, result.sum);  // 3+5 = 8 (положительные элементы)
            Assert.Equal(0, result.product);  // -2*0*(-4) = 0 (четные элементы)
        }
    }
} 
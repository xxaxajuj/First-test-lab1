using System;
using Xunit;

namespace ArrayProcessingApp.Tests
{
    public class ArrayProcessorTests
    {
        // Тест для проверки корректного вычисления суммы отрицательных и произведения нечетных элементов
        [Fact]
        public void ValidInput()
        {
            var processor = new ArrayProcessor();
            double[] array = { -1, 2, -3, 4, 5 };

            var result = processor.ProcessArray(array);

            Assert.Equal(-4, result.sum);  // -1+(-3) = -4 (отрицательные элементы)
            Assert.Equal(-5, result.product);  // -1*5 = -5 (нечетные элементы)
        }

        // Тест для проверки исключения при отсутствии нечетных элементов
        [Fact]
        public void NoOddElements()
        {
            var processor = new ArrayProcessor();
            double[] array = { -2, 2, 4 };

            var exception = Assert.Throws<InvalidOperationException>(() => processor.ProcessArray(array));
            Assert.Equal("No odd elements in the array.", exception.Message);
        }

        // Тест для проверки исключения при отсутствии отрицательных элементов
        [Fact]
        public void NoNegativeElements()
        {
            var processor = new ArrayProcessor();
            double[] array = { 1, 3, 5, 2 };

            var exception = Assert.Throws<InvalidOperationException>(() => processor.ProcessArray(array));
            Assert.Equal("No negative elements in the array.", exception.Message);
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
            // Either message could be thrown since empty array has neither negative nor odd elements
            Assert.Contains(exception.Message, new[] { "No negative elements in the array.", "No odd elements in the array." });
        }

        // Тест для проверки работы с массивом, содержащим положительные числа и нули
        [Fact]
        public void WithPositiveAndZeroNumbers()
        {
            var processor = new ArrayProcessor();
            double[] array = { -1, 2, 0, 3, -4, 5 };

            var result = processor.ProcessArray(array);

            Assert.Equal(-5, result.sum);  // -1+(-4) = -5 (отрицательные элементы)
            Assert.Equal(-15, result.product);  // -1*3*5 = -15 (нечетные элементы)
        }
    }
} 
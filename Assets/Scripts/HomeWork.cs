using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


    public class HomeWork : MonoBehaviour
    {
        /// <summary>
        /// Метод обработки события OnClick кнопки "Сумма четных чисел заданного диапазона"
        /// </summary>
        public void OnSumEvenNumbersInRange()
        {
            int min = 7;
            int max = 21;
            var want = 98;
            int got = SumEvenNumbersInRange(min, max);

           
            string message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
            Debug.Log($"Сумма четных чисел в диапазоне от {min} до {max} включительно: {got} - {message}");
        }

        /// <summary>
        /// Метод вычисляет сумму четных чисел в заданноном диапазане 
        /// </summary>
        /// <param name="min">Минимальное значение диапазона</param>
        /// <param name="max">Максимальное значение диапазона</param>
        /// <returns>Сумма чисел четных чисел</returns>
        private int SumEvenNumbersInRange(int min, int max)
        {
            int sum_num = 0;
             for (int i = min; i < max + 1; i++)
             {
            if (i % 2 == 0)
            {
                sum_num += i;
            }
             }
            // Реализуйте подсчет четных чисел используя цикл и
            // верните вместо 0 полученный результат 
            return sum_num;
        }

        /// <summary>
        /// Метод обработки события OnClick кнопки "Сумма четных чисел в заданном массиве"
        /// </summary>
        public void OnSumEvenNumbersInArray()
        {
            int[] array = { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
            int want = 214;
            int got = SumEvenNumbersInArray(array);
            string message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
            Debug.Log($"Сумма четных чисел в заданном массиве: {got} - {message}");
        }

        /// <summary>
        /// Метод вычисляет сумму четных чисел в массиве 
        /// </summary>
        /// <param name="array">Исходный массив чисел</param>
        /// <returns>Сумма чисел четных чисел</returns>
        private int SumEvenNumbersInArray(int[] array)
        {
            int sum_num_arr = 0;
           for (int i = 0; i < array.Length; i++)
           {
                if(array[i] % 2 == 0)
                {
                    sum_num_arr += array[i];
                }
           }
            // Реализуйте подсчет четных чисел используя цикл и
            // верните вместо 0 полученный результат 
            return sum_num_arr;
        }

        /// <summary>
        /// Метод обработки события OnClick кнопки "Поиск первого вхождения числа в массив"
        /// </summary>
        public void OnFirstOccurrence()
        {
            // Первый тест, число присутсвует в массиве
            int[] array = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
            int value = 34;
            int want = 3;
            int got = FirstOccurrence(array, value);
            string message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
            Debug.Log($"Индекс первого вхождения числа {value} в массив: {got} - {message}");

            // Второй тест, число не присутсвует в массиве
            array = new int[] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
            value = 55;
            want = -1;
            got = FirstOccurrence(array, value);
            message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
            Debug.Log($"Индекс первого вхождения числа {value} в массив: {got} - {message}");
        }

        /// <summary>
        /// Метод производит поиск первого вхождения числа в массив
        /// </summary>
        /// <param name="array">Исходный массив</param>
        /// <param name="value">Искомое число</param>
        /// <returns>Индекс искомого числа в массиве или -1 если число отсуствует</returns>
        private int FirstOccurrence(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                return i;
            }
            // Реализуйте поиск первого вхождения элемента в массив и верните его индекс,
            // если елемент не присуствует в массиве верните -1
            return -1;
        }

        /// <summary>
        /// Метод обработки события OnClick кнопки "Сортировка выбором"
        /// </summary>
        public void OnSelectionSort()
        {
            int[] originalArray = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
            Debug.LogFormat("Исходный массив {0}", "[" + string.Join(",", originalArray) + "]");

            int[] sortedArray = SelectionSort((int[])originalArray.Clone());
            Debug.LogFormat("Результат сортировки {0}", "[" + string.Join(",", sortedArray) + "]");

            int[] expectedArray = { 10, 13, 15, 22, 26, 34, 34, 68, 71, 81 };
            Debug.Log(sortedArray.SequenceEqual(expectedArray) ? "Результат верный" : "Результат не верный");
        }

        /// <summary>
        /// Метод сортируем массив методом выбора
        /// </summary>
        /// <param name="array">Исходный массив</param>
        /// <returns>Отсортированный массив</returns>
        private int[] SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
               int min = i;
                    for (int j = i + 1; j < array.Length; ++j)
                    {
                        if (array[j].CompareTo(array[min]) < 0)
                        {
                            min = j;
                        }
                    }
                    
                    var dummy = array[i];
                    array[i] = array[min];
                    array[min] = dummy;
            }
            // Реализуйте сортировку массива методом выбора и рените результат
            return array;
        }
    }
using System;
using System.Collections.Generic;

namespace Benchmarkus.SortingAlgorithms.Algorithms
{
    public static class QuickSort
    {
        /// <summary>
        /// Sorts an array using the Quick Sort algorithm (Lomuto partition).
        /// Time Complexity: Average O(n log n), Worst-case O(n²)
        /// </summary>
        /// <typeparam name="T">Type of elements to sort</typeparam>
        /// <param name="array">Array to sort in-place</param>
        /// <param name="left">Left index of the sub-array to sort</param>
        /// <param name="right">Right index of the sub-array to sort</param>
        /// <param name="comparison">Optional custom comparison delegate</param>
        public static void Sort<T>(T[] array, int left, int right, Comparison<T>? comparison = null)
        {
            if (array == null || array.Length <= 1) return;
            comparison ??= Comparer<T>.Default.Compare;

            if (left < right)
            {
                int pivotIndex = Partition(array, left, right, comparison);
                Sort(array, left, pivotIndex - 1, comparison);
                Sort(array, pivotIndex + 1, right, comparison);
            }
        }

        private static int Partition<T>(T[] array, int left, int right, Comparison<T> comparison)
        {
            T pivot = array[right]; 
            int i = (left - 1);

            for (int j = left; j < right; j++)
            {
                if (comparison(array[j], pivot) <= 0)
                {
                    i++;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }
            (array[i + 1], array[right]) = (array[right], array[i + 1]);
            return i + 1;
        }
    }
}
using System;
using System.Collections.Generic;

namespace Benchmarkus.SortingAlgorithms.Algorithms
{
    public static class BubbleSort
    {
        /// <summary>
        /// Sorts an array using the Bubble Sort algorithm.
        /// Time Complexity: O(n²)
        /// </summary>
        /// <typeparam name="T">Type of elements to sort</typeparam>
        /// <param name="array">Array to sort in-place</param>
        /// <param name="comparison">Optional custom comparison delegate</param>
        public static void Sort<T>(T[] array, Comparison<T>? comparison = null)
        {
            if (array == null || array.Length <= 1) return;

            comparison ??= Comparer<T>.Default.Compare;

            for (int i = 0; i < array.Length - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparison(array[j], array[j + 1]) > 0)
                    {
                        // Swap
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swapped = true;
                    }
                }
                // If no elements were swapped, the array is already sorted
                if (!swapped) break;
            }
        }
    }
}
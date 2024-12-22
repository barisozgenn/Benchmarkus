using System;
using System.Collections.Generic;

namespace Benchmarkus.SortingAlgorithms.Algorithms
{
    public static class HeapSort
    {
        /// <summary>
        /// Sorts an array using the Heap Sort algorithm.
        /// Time Complexity: O(n log n)
        /// </summary>
        /// <typeparam name="T">Type of elements to sort</typeparam>
        /// <param name="array">Array to sort in-place</param>
        /// <param name="comparison">Optional custom comparison delegate</param>
        public static void Sort<T>(T[] array, Comparison<T>? comparison = null)
        {
            if (array == null || array.Length <= 1) return;

            comparison ??= Comparer<T>.Default.Compare;

            // Build the heap
            int n = array.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i, comparison);
            }

            // Extract elements from heap one by one
            for (int i = n - 1; i > 0; i--)
            {
                // Swap current root to the end
                (array[0], array[i]) = (array[i], array[0]);

                // Call max-heapify on the reduced heap
                Heapify(array, i, 0, comparison);
            }
        }

        /// <summary>
        /// Ensures the subtree rooted at index i is a valid heap, assuming children are already heaps.
        /// </summary>
        private static void Heapify<T>(T[] array, int heapSize, int i, Comparison<T> comparison)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // If left child is larger than root
            if (left < heapSize && comparison(array[left], array[largest]) > 0)
            {
                largest = left;
            }

            // If right child is larger than largest so far
            if (right < heapSize && comparison(array[right], array[largest]) > 0)
            {
                largest = right;
            }

            // If largest is not root
            if (largest != i)
            {
                (array[i], array[largest]) = (array[largest], array[i]);
                // Recursively heapify the affected subtree
                Heapify(array, heapSize, largest, comparison);
            }
        }
    }
}
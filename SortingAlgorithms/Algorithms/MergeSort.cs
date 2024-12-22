using System;
using System.Collections.Generic;

namespace Benchmarkus.SortingAlgorithms.Algorithms
{
    public static class MergeSort
    {
        /// <summary>
        /// Sorts an array using the Merge Sort algorithm.
        /// Time Complexity: O(n log n)
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
                int mid = (left + right) / 2;
                // Sort left half
                Sort(array, left, mid, comparison);
                // Sort right half
                Sort(array, mid + 1, right, comparison);
                // Merge
                Merge(array, left, mid, right, comparison);
            }
        }

        private static void Merge<T>(T[] array, int left, int mid, int right, Comparison<T> comparison)
        {
            int leftSize = mid - left + 1;
            int rightSize = right - mid;

            // Create temp arrays
            T[] leftArray = new T[leftSize];
            T[] rightArray = new T[rightSize];

            // Copy data to temp arrays
            Array.Copy(array, left, leftArray, 0, leftSize);
            Array.Copy(array, mid + 1, rightArray, 0, rightSize);

            // Merge the temp arrays back into the original
            int i = 0, j = 0, k = left;
            while (i < leftSize && j < rightSize)
            {
                if (comparison(leftArray[i], rightArray[j]) <= 0)
                {
                    array[k++] = leftArray[i++];
                }
                else
                {
                    array[k++] = rightArray[j++];
                }
            }

            // Copy remaining elements of leftArray (if any)
            while (i < leftSize)
            {
                array[k++] = leftArray[i++];
            }

            // Copy remaining elements of rightArray (if any)
            while (j < rightSize)
            {
                array[k++] = rightArray[j++];
            }
        }
    }
}
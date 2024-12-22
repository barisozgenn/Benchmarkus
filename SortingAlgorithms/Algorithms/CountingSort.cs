#region CountingSortFile
using System;

namespace Benchmarkus.SortingAlgorithms.Algorithms
{
    #region CountingSort
    /// <summary>
    /// Provides a static implementation of the CountingSort algorithm (naïve).
    /// </summary>
    public static class CountingSort
    {
        #region SortMethod
        /// <summary>
        /// Sorts an integer array using Counting Sort (assuming the array has non-negative values or a known range).
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void Sort(int[] array)
        {
            if (array.Length == 0)
                return;

            // Find range
            int min = array[0];
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min) min = array[i];
                if (array[i] > max) max = array[i];
            }

            // For simplicity, handle only min >= 0. 
            // If you have negatives, you'd offset or handle differently.
            if (min < 0)
                throw new InvalidOperationException("Naive CountingSort only handles non-negative integers in this example.");

            int[] count = new int[max + 1];

            // Count each value
            for (int i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
            }

            // Overwrite array
            int index = 0;
            for (int value = 0; value < count.Length; value++)
            {
                while (count[value] > 0)
                {
                    array[index++] = value;
                    count[value]--;
                }
            }
        }
        #endregion
    }
    #endregion
}
#endregion
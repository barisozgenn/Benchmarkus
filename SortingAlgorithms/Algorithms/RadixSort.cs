#region RadixSortFile
using System;

namespace Benchmarkus.SortingAlgorithms.Algorithms
{
    #region RadixSort
    /// <summary>
    /// Provides a static implementation of the RadixSort algorithm (LSD).
    /// </summary>
    public static class RadixSort
    {
        #region SortMethod
        /// <summary>
        /// Sorts an integer array using LSD RadixSort.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void Sort(int[] array)
        {
            // Find the max number to know number of digits
            int max = Math.Abs(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) > max)
                    max = Math.Abs(array[i]);
            }

            // Do counting sort for every digit
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSortByDigit(array, exp);
            }
        }
        #endregion

        #region CountingSortByDigit
        private static void CountingSortByDigit(int[] array, int exp)
        {
            int n = array.Length;
            int[] output = new int[n];
            int[] count = new int[19]; // for -9..9 in single digit or more (naïve approach to handle negative)
            
            // Build count array
            for (int i = 0; i < n; i++)
            {
                int digit = (array[i] / exp) % 10 + 9; 
                count[digit]++;
            }

            // Convert count[] to prefix sums
            for (int i = 1; i < 19; i++)
            {
                count[i] += count[i - 1];
            }

            // Build output
            for (int i = n - 1; i >= 0; i--)
            {
                int digit = (array[i] / exp) % 10 + 9;
                output[count[digit] - 1] = array[i];
                count[digit]--;
            }

            // Copy back
            for (int i = 0; i < n; i++)
            {
                array[i] = output[i];
            }
        }
        #endregion
    }
    #endregion
}
#endregion
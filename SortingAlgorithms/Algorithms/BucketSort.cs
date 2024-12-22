#region BucketSortFile
using System.Collections.Generic;

namespace Benchmarkus.SortingAlgorithms.Algorithms
{
    #region BucketSort
    /// <summary>
    /// Provides a static implementation of the BucketSort algorithm (naïve).
    /// </summary>
    public static class BucketSort
    {
        #region SortMethod
        /// <summary>
        /// Sorts an integer array using Bucket Sort (assuming the range of values is not too large).
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="bucketCount">Number of buckets to use (optional).</param>
        public static void Sort(int[] array, int bucketCount = 10)
        {
            if (array.Length <= 1)
                return;

            int minValue = array[0];
            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue) minValue = array[i];
                if (array[i] > maxValue) maxValue = array[i];
            }

            // Create buckets
            var buckets = new List<int>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
            {
                buckets[i] = new List<int>();
            }

            // Distribute
            var range = (maxValue - minValue) + 1;
            for (int i = 0; i < array.Length; i++)
            {
                int bucketIndex = (array[i] - minValue) * (bucketCount - 1) / range;
                buckets[bucketIndex].Add(array[i]);
            }

            // Sort each bucket and concatenate
            int index = 0;
            foreach (var bucket in buckets)
            {
                bucket.Sort(); // Uses built-in sort
                foreach (var val in bucket)
                {
                    array[index++] = val;
                }
            }
        }
        #endregion
    }
    #endregion
}
#endregion
#region TimSortFile
using System;

namespace Benchmarkus.SortingAlgorithms.Algorithms
{
    #region TimSort
    /// <summary>
    /// .NET's built-in Array.Sort() uses a Timsort-based algorithm for reference types.
    /// For demonstration, we wrap it in a static method.
    /// </summary>
    public static class TimSort
    {
        #region SortMethod
        /// <summary>
        /// Sorts an integer array by calling .NET's built-in Array.Sort() (Timsort).
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void Sort(int[] array)
        {
            Array.Sort(array);
        }
        #endregion
    }
    #endregion
}
#endregion
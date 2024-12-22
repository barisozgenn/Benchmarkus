#region SelectionSortFile
namespace Benchmarkus.SortingAlgorithms.Algorithms
{
    #region SelectionSort
    /// <summary>
    /// Provides a static implementation of the SelectionSort algorithm.
    /// </summary>
    public static class SelectionSort
    {
        #region SortMethod
        /// <summary>
        /// Sorts an integer array using Selection Sort.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void Sort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    // Swap
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }
        #endregion
    }
    #endregion
}
#endregion
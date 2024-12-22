#region InsertionSortFile
namespace Benchmarkus.SortingAlgorithms.Algorithms
{
    #region InsertionSort
    /// <summary>
    /// Provides a static implementation of the InsertionSort algorithm.
    /// </summary>
    public static class InsertionSort
    {
        #region SortMethod
        /// <summary>
        /// Sorts an integer array using Insertion Sort.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void Sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }
        #endregion
    }
    #endregion
}
#endregion
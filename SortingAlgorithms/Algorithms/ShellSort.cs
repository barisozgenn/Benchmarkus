#region ShellSortFile
namespace Benchmarkus.SortingAlgorithms.Algorithms
{
    #region ShellSort
    /// <summary>
    /// Provides a static implementation of the ShellSort algorithm.
    /// </summary>
    public static class ShellSort
    {
        #region SortMethod
        /// <summary>
        /// Sorts an integer array using Shell Sort (with a simple gap sequence).
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void Sort(int[] array)
        {
            int n = array.Length;
            // Start with a big gap, then reduce the gap
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // Do a gapped insertion sort
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }
        }
        #endregion
    }
    #endregion
}
#endregion
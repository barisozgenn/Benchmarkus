#region SortingAlgorithmsBenchmarksFile
using BenchmarkDotNet.Attributes;
using System;
using Benchmarkus.SortingAlgorithms.Algorithms;

namespace Benchmarkus.SortingAlgorithms
{
    #region SortingAlgorithmsBenchmarks
    /// <summary>
    /// Benchmark class to measure sorting performance on int, string, and complex (Transaction) arrays.
    /// </summary>
    [MemoryDiagnoser]
    public class SortingAlgorithmsBenchmarks
    {
        #region Params
        /// <summary>
        /// Possible array sizes to test.
        /// </summary>
        [Params(1_00, 5_000)]
        public int ArraySize { get; set; }
        #endregion

        #region Fields
        private int[] _intData = default!;
        private string[] _stringData = default!;
        private Transaction[] _transactionData = default!;
        #endregion

        #region GlobalSetup
        /// <summary>
        /// Prepares the data before each benchmark run.
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            // Generate random int data
            _intData = SortingHelpers.GenerateRandomIntArray(ArraySize, seed: 42);

            // Generate random string data
            _stringData = SortingHelpers.GenerateRandomStringArray(ArraySize, seed: 42);

            // Generate random transaction objects
            _transactionData = SortingHelpers.GenerateRandomTransactions(ArraySize, seed: 42);
        }
        #endregion

        // =================================================================
        // 1) INT SORTING ALGORITHMS
        // =================================================================

        #region Int_QuickSort
        [Benchmark]
        public int[] Int_QuickSort()
        {
            var dataCopy = (int[])_intData.Clone();
            QuickSort.Sort(dataCopy, 0, dataCopy.Length - 1);
            return dataCopy;
        }
        #endregion

        #region Int_MergeSort
        [Benchmark]
        public int[] Int_MergeSort()
        {
            var dataCopy = (int[])_intData.Clone();
            MergeSort.Sort(dataCopy, 0, dataCopy.Length - 1);
            return dataCopy;
        }
        #endregion

        #region Int_TimSort
        [Benchmark]
        public int[] Int_TimSort()
        {
            var dataCopy = (int[])_intData.Clone();
            TimSort.Sort(dataCopy);
            return dataCopy;
        }
        #endregion

        #region Int_HeapSort
        [Benchmark]
        public int[] Int_HeapSort()
        {
            var dataCopy = (int[])_intData.Clone();
            HeapSort.Sort(dataCopy);
            return dataCopy;
        }
        #endregion

        #region Int_BubbleSort
        [Benchmark]
        public int[] Int_BubbleSort()
        {
            var dataCopy = (int[])_intData.Clone();
            BubbleSort.Sort(dataCopy);
            return dataCopy;
        }
        #endregion

        // =================================================================
        // 2) STRING SORTING ALGORITHMS
        // =================================================================
        // Pass StringComparer.OrdinalIgnoreCase.Compare for generic methods.

        #region String_QuickSort
        [Benchmark]
        public string[] String_QuickSort()
        {
            var dataCopy = (string[])_stringData.Clone();
            // Pass .Compare to match Comparison<string> signature
            QuickSort.Sort(dataCopy, 0, dataCopy.Length - 1, StringComparer.OrdinalIgnoreCase.Compare);
            return dataCopy;
        }
        #endregion

        #region String_MergeSort
        [Benchmark]
        public string[] String_MergeSort()
        {
            var dataCopy = (string[])_stringData.Clone();
            MergeSort.Sort(dataCopy, 0, dataCopy.Length - 1, StringComparer.OrdinalIgnoreCase.Compare);
            return dataCopy;
        }
        #endregion

        #region String_TimSort
        /// <summary>
        /// Uses .NET's built-in Array.Sort(), which is Timsort for reference types.
        /// </summary>
        [Benchmark]
        public string[] String_TimSort()
        {
            var dataCopy = (string[])_stringData.Clone();
            // Array.Sort can directly accept an IComparer<string>.
            Array.Sort(dataCopy, StringComparer.OrdinalIgnoreCase);
            return dataCopy;
        }
        #endregion

        #region String_HeapSort
        [Benchmark]
        public string[] String_HeapSort()
        {
            var dataCopy = (string[])_stringData.Clone();
            HeapSort.Sort(dataCopy, StringComparer.OrdinalIgnoreCase.Compare);
            return dataCopy;
        }
        #endregion

        #region String_BubbleSort
        [Benchmark]
        public string[] String_BubbleSort()
        {
            var dataCopy = (string[])_stringData.Clone();
            BubbleSort.Sort(dataCopy, StringComparer.OrdinalIgnoreCase.Compare);
            return dataCopy;
        }
        #endregion

        // =================================================================
        // 3) COMPLEX / TRANSACTION SORT
        // =================================================================
        // -- For each sorting algorithm, we demonstrate sorting by Amount.
        //    You could replicate the same approach for Date/Name, or any field.

        #region Complex_QuickSortByAmount
        [Benchmark]
        public Transaction[] Complex_QuickSortByAmount()
        {
            var dataCopy = (Transaction[])_transactionData.Clone();
            // Generic QuickSort by transaction.Amount:
            QuickSort.Sort(dataCopy, 0, dataCopy.Length - 1, (x, y) => x.Amount.CompareTo(y.Amount));
            return dataCopy;
        }
        #endregion

        #region Complex_MergeSortByAmount
        [Benchmark]
        public Transaction[] Complex_MergeSortByAmount()
        {
            var dataCopy = (Transaction[])_transactionData.Clone();
            MergeSort.Sort(dataCopy, 0, dataCopy.Length - 1, (x, y) => x.Amount.CompareTo(y.Amount));
            return dataCopy;
        }
        #endregion

        #region Complex_TimSortByAmount
        [Benchmark]
        public Transaction[] Complex_TimSortByAmount()
        {
            var dataCopy = (Transaction[])_transactionData.Clone();
            // Using built-in Array.Sort with custom lambda:
            Array.Sort(dataCopy, (x, y) => x.Amount.CompareTo(y.Amount));
            return dataCopy;
        }
        #endregion

        #region Complex_HeapSortByAmount
        [Benchmark]
        public Transaction[] Complex_HeapSortByAmount()
        {
            var dataCopy = (Transaction[])_transactionData.Clone();
            HeapSort.Sort(dataCopy, (x, y) => x.Amount.CompareTo(y.Amount));
            return dataCopy;
        }
        #endregion

        #region Complex_BubbleSortByAmount
        [Benchmark]
        public Transaction[] Complex_BubbleSortByAmount()
        {
            var dataCopy = (Transaction[])_transactionData.Clone();
            BubbleSort.Sort(dataCopy, (x, y) => x.Amount.CompareTo(y.Amount));
            return dataCopy;
        }
        #endregion
    }
    #endregion
}
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel; // Required for ReadOnlyCollection<T>
using BenchmarkDotNet.Attributes;

namespace CollectionOperations.Benchmarks
{
    /// <summary>
    /// Benchmark class to evaluate the performance of various .NET collection types.
    /// Each benchmark method initializes its own data to ensure fairness and consistency.
    /// </summary>
    [MemoryDiagnoser] // Enables memory allocation diagnostics for each benchmark
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)] // Orders benchmark results from fastest to slowest
    [SimpleJob(warmupCount:5, iterationCount:5)] // Specifies the number of warmup and iteration runs for each benchmark
    public class CollectionBenchmark
    {
        /// <summary>
        /// The number of elements to be used in the collections during benchmarks.
        /// </summary>
        private readonly int _size = 1_000;

        #region IList<T> Benchmarks

        /// <summary>
        /// Benchmark to find the first even integer in an IList<int> using LINQ's FirstOrDefault.
        /// Initializes a new List<int> and casts it to IList<int> within the method.
        /// </summary>
        [Benchmark]
        public int? IList_Find_FirstEven()
        {
            // Initialize IList<int>
            IList<int> iListInt = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                iListInt.Add(i);
            }

            // Perform the benchmark operation
            return iListInt.FirstOrDefault(x => x % 2 == 0);
        }

        /// <summary>
        /// Benchmark to add a new integer to an IList<int>.
        /// Initializes a new List<int> and casts it to IList<int> within the method.
        /// </summary>
        [Benchmark]
        public void IList_Add_Int()
        {
            // Initialize IList<int>
            IList<int> iListInt = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                iListInt.Add(i);
            }

            // Perform the benchmark operation
            iListInt.Add(_size);
        }

        /// <summary>
        /// Benchmark to remove the last integer from an IList<int>.
        /// Initializes a new List<int> and casts it to IList<int> within the method.
        /// </summary>
        [Benchmark]
        public void IList_Remove_Int()
        {
            // Initialize IList<int>
            IList<int> iListInt = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                iListInt.Add(i);
            }

            // Perform the benchmark operation
            iListInt.RemoveAt(iListInt.Count - 1);
        }

        #endregion

        #region List<T> Benchmarks

        /// <summary>
        /// Benchmark to find the first even integer in a List<int> using LINQ's FirstOrDefault.
        /// Initializes a new List<int> within the method.
        /// </summary>
        [Benchmark]
        public int? List_Find_FirstEven()
        {
            // Initialize List<int>
            List<int> listInt = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                listInt.Add(i);
            }

            // Perform the benchmark operation
            return listInt.FirstOrDefault(x => x % 2 == 0);
        }

        /// <summary>
        /// Benchmark to add a new integer to a List<int>.
        /// Initializes a new List<int> within the method.
        /// </summary>
        [Benchmark]
        public void List_Add_Int()
        {
            // Initialize List<int>
            List<int> listInt = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                listInt.Add(i);
            }

            // Perform the benchmark operation
            listInt.Add(_size);
        }

        /// <summary>
        /// Benchmark to remove the last integer from a List<int>.
        /// Initializes a new List<int> within the method.
        /// </summary>
        [Benchmark]
        public void List_Remove_Int()
        {
            // Initialize List<int>
            List<int> listInt = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                listInt.Add(i);
            }

            // Perform the benchmark operation
            listInt.RemoveAt(listInt.Count - 1);
        }

        #endregion

        #region Enumerable Benchmarks

        /// <summary>
        /// Benchmark to find the first even integer using LINQ's FirstOrDefault on an enumerable.
        /// Initializes a new List<int> within the method.
        /// </summary>
        [Benchmark]
        public int? Enumerable_Find_FirstEven()
        {
            // Initialize List<int>
            List<int> listInt = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                listInt.Add(i);
            }

            // Perform the benchmark operation
            return listInt.AsEnumerable().FirstOrDefault(x => x % 2 == 0);
        }

        /// <summary>
        /// Benchmark to add a new integer to an IEnumerable<int> using LINQ's Concat method and consuming the result.
        /// Initializes a new List<int> within the method.
        /// </summary>
        [Benchmark]
        public void Enumerable_Add_Int()
        {
            // Initialize List<int>
            List<int> listInt = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                listInt.Add(i);
            }

            // Perform the benchmark operation
            var result = listInt.Concat(new[] { _size });
            result.ToList(); // Forces execution to ensure accurate benchmarking
        }

        /// <summary>
        /// Benchmark to remove the last integer from an IEnumerable<int> using LINQ's Where method and consuming the result.
        /// Initializes a new List<int> within the method.
        /// </summary>
        [Benchmark]
        public void Enumerable_Remove_Int()
        {
            // Initialize List<int>
            List<int> listInt = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                listInt.Add(i);
            }

            // Perform the benchmark operation
            var result = listInt.Where((x, index) => index != listInt.Count - 1);
            result.ToList(); // Forces execution to ensure accurate benchmarking
        }

        #endregion

        #region Dictionary<TKey, TValue> Benchmarks

        /// <summary>
        /// Benchmark to retrieve a value by key in a Dictionary<int, string> using TryGetValue.
        /// Initializes a new Dictionary<int, string> within the method.
        /// </summary>
        [Benchmark]
        public string? Dictionary_Find_Value_By_Key_Int()
        {
            // Initialize Dictionary<int, string>
            Dictionary<int, string> dictionaryIntString = new Dictionary<int, string>();
            for (int i = 0; i < _size; i++)
            {
                dictionaryIntString.Add(i, $"Value{i}");
            }

            // Perform the benchmark operation
            return dictionaryIntString.TryGetValue(_size / 2, out var value) ? value : null;
        }

        /// <summary>
        /// Benchmark to add a new key-value pair to a Dictionary<int, string>.
        /// Initializes a new Dictionary<int, string> within the method.
        /// </summary>
        [Benchmark]
        public void Dictionary_Add_KeyValue_Int_String()
        {
            // Initialize Dictionary<int, string>
            Dictionary<int, string> dictionaryIntString = new Dictionary<int, string>();
            for (int i = 0; i < _size; i++)
            {
                dictionaryIntString.Add(i, $"Value{i}");
            }

            // Perform the benchmark operation
            dictionaryIntString.Add(_size, $"Value{_size}");
        }

        /// <summary>
        /// Benchmark to remove a key-value pair from a Dictionary<int, string> by key.
        /// Initializes a new Dictionary<int, string> within the method.
        /// </summary>
        [Benchmark]
        public void Dictionary_Remove_Key_Int()
        {
            // Initialize Dictionary<int, string>
            Dictionary<int, string> dictionaryIntString = new Dictionary<int, string>();
            for (int i = 0; i < _size; i++)
            {
                dictionaryIntString.Add(i, $"Value{i}");
            }

            // Perform the benchmark operation
            dictionaryIntString.Remove(_size - 1);
        }

        #endregion

        #region Array Benchmarks

        /// <summary>
        /// Benchmark to find the first even integer in an array using LINQ's FirstOrDefault.
        /// Initializes a new int array within the method.
        /// </summary>
        [Benchmark]
        public int? Array_Find_FirstEven()
        {
            // Initialize int array
            int[] arrayInt = new int[_size];
            for (int i = 0; i < _size; i++)
            {
                arrayInt[i] = i;
            }

            // Perform the benchmark operation
            return arrayInt.FirstOrDefault(x => x % 2 == 0);
        }

        /// <summary>
        /// Benchmark to add a new integer to an array by creating a new resized array.
        /// Initializes a new int array within the method.
        /// </summary>
        [Benchmark]
        public int[] Array_Add_Int()
        {
            // Initialize int array
            int[] arrayInt = new int[_size];
            for (int i = 0; i < _size; i++)
            {
                arrayInt[i] = i;
            }

            // Perform the benchmark operation
            var newArray = new int[arrayInt.Length + 1];
            Array.Copy(arrayInt, newArray, arrayInt.Length);
            newArray[^1] = _size;
            return newArray;
        }

        /// <summary>
        /// Benchmark to remove the last integer from an array by creating a new resized array.
        /// Initializes a new int array within the method.
        /// </summary>
        [Benchmark]
        public int[] Array_Remove_Int()
        {
            // Initialize int array
            int[] arrayInt = new int[_size];
            for (int i = 0; i < _size; i++)
            {
                arrayInt[i] = i;
            }

            // Perform the benchmark operation
            var newArray = new int[arrayInt.Length - 1];
            Array.Copy(arrayInt, newArray, arrayInt.Length - 1);
            return newArray;
        }

        #endregion

        #region Span<T> Array Benchmarks

        /// <summary>
        /// Benchmark to find the first even integer in a Span<int> using a manual loop.
        /// Initializes a new int array and creates a Span<int> within the method.
        /// </summary>
        [Benchmark]
        public int? Span_Find_FirstEven()
        {
            // Initialize int array and create Span<int>
            int[] arrayInt = new int[_size];
            for (int i = 0; i < _size; i++)
            {
                arrayInt[i] = i;
            }
            Span<int> span = arrayInt.AsSpan();

            // Perform the benchmark operation
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] % 2 == 0)
                    return span[i];
            }
            return default;
        }

        /// <summary>
        /// Benchmark to add a new integer to a Span<int> by creating a new array and returning a new Span<int>.
        /// Initializes a new int array and creates a Span<int> within the method.
        /// </summary>
        [Benchmark]
        public Span<int> Span_Add_Int()
        {
            // Initialize int array and create Span<int>
            int[] arrayInt = new int[_size];
            for (int i = 0; i < _size; i++)
            {
                arrayInt[i] = i;
            }
            Span<int> span = arrayInt.AsSpan();

            // Perform the benchmark operation
            var newArray = new int[span.Length + 1];
            span.CopyTo(newArray);
            newArray[^1] = _size;
            return newArray.AsSpan();
        }

        /// <summary>
        /// Benchmark to remove the last integer from a Span<int> by slicing the span.
        /// Initializes a new int array and creates a Span<int> within the method.
        /// </summary>
        [Benchmark]
        public Span<int> Span_Remove_Int()
        {
            // Initialize int array and create Span<int>
            int[] arrayInt = new int[_size];
            for (int i = 0; i < _size; i++)
            {
                arrayInt[i] = i;
            }
            Span<int> span = arrayInt.AsSpan();

            // Perform the benchmark operation
            return span.Slice(0, span.Length - 1);
        }

        #endregion

        #region ReadOnlyCollection<T> Benchmarks

        /// <summary>
        /// Benchmark to find the first even integer in a ReadOnlyCollection<int> using LINQ's FirstOrDefault.
        /// Initializes a new ReadOnlyCollection<int> within the method.
        /// </summary>
        [Benchmark]
        public int? ReadOnlyCollection_Find_FirstEven()
        {
            // Initialize ReadOnlyCollection<int>
            List<int> listInt = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                listInt.Add(i);
            }
            var readOnly = new ReadOnlyCollection<int>(listInt);

            // Perform the benchmark operation
            return readOnly.FirstOrDefault(x => x % 2 == 0);
        }

        /// <summary>
        /// Benchmark to attempt adding a new integer to a ReadOnlyCollection<int>.
        /// Since ReadOnlyCollection<T> does not support addition, no operation is performed.
        /// Initializes a new ReadOnlyCollection<int> within the method.
        /// </summary>
        [Benchmark]
        public void ReadOnlyCollection_Add_Int()
        {
            // Initialize ReadOnlyCollection<int>
            List<int> listInt = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                listInt.Add(i);
            }
            var readOnly = new ReadOnlyCollection<int>(listInt);

            // Perform the benchmark operation
            // Attempting to add would throw NotSupportedException, so it's intentionally left blank
        }

        /// <summary>
        /// Benchmark to attempt removing an integer from a ReadOnlyCollection<int>.
        /// Since ReadOnlyCollection<T> does not support removal, no operation is performed.
        /// Initializes a new ReadOnlyCollection<int> within the method.
        /// </summary>
        [Benchmark]
        public void ReadOnlyCollection_Remove_Int()
        {
            // Initialize ReadOnlyCollection<int>
            List<int> listInt = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                listInt.Add(i);
            }
            var readOnly = new ReadOnlyCollection<int>(listInt);

            // Perform the benchmark operation
            // Attempting to remove would throw NotSupportedException, so it's intentionally left blank
        }

        #endregion

        #region LinkedList<T> Benchmarks

        /// <summary>
        /// Benchmark to find the first even integer in a LinkedList<int> using LINQ's FirstOrDefault.
        /// Initializes a new LinkedList<int> within the method.
        /// </summary>
        [Benchmark]
        public int? LinkedList_Find_FirstEven()
        {
            // Initialize LinkedList<int>
            LinkedList<int> linkedListInt = new LinkedList<int>();
            for (int i = 0; i < _size; i++)
            {
                linkedListInt.AddLast(i);
            }

            // Perform the benchmark operation
            return linkedListInt.FirstOrDefault(x => x % 2 == 0);
        }

        /// <summary>
        /// Benchmark to add a new integer to the end of a LinkedList<int>.
        /// Initializes a new LinkedList<int> within the method.
        /// </summary>
        [Benchmark]
        public void LinkedList_Add_Int()
        {
            // Initialize LinkedList<int>
            LinkedList<int> linkedListInt = new LinkedList<int>();
            for (int i = 0; i < _size; i++)
            {
                linkedListInt.AddLast(i);
            }

            // Perform the benchmark operation
            linkedListInt.AddLast(_size);
        }

        /// <summary>
        /// Benchmark to remove the last integer from a LinkedList<int>.
        /// Initializes a new LinkedList<int> within the method.
        /// </summary>
        [Benchmark]
        public void LinkedList_Remove_Int()
        {
            // Initialize LinkedList<int>
            LinkedList<int> linkedListInt = new LinkedList<int>();
            for (int i = 0; i < _size; i++)
            {
                linkedListInt.AddLast(i);
            }

            // Perform the benchmark operation
            if (linkedListInt.Last != null)
            {
                linkedListInt.RemoveLast();
            }
        }

        #endregion

        #region HashSet<T> Benchmarks

        /// <summary>
        /// Benchmark to check the existence of a specific integer in a HashSet<int> using Contains.
        /// Initializes a new HashSet<int> within the method.
        /// </summary>
        [Benchmark]
        public bool HashSet_Find_Int()
        {
            // Initialize HashSet<int>
            HashSet<int> hashSetInt = new HashSet<int>();
            for (int i = 0; i < _size; i++)
            {
                hashSetInt.Add(i);
            }

            // Perform the benchmark operation
            return hashSetInt.Contains(_size / 2);
        }

        /// <summary>
        /// Benchmark to add a new integer to a HashSet<int>.
        /// Initializes a new HashSet<int> within the method.
        /// </summary>
        [Benchmark]
        public void HashSet_Add_Int()
        {
            // Initialize HashSet<int>
            HashSet<int> hashSetInt = new HashSet<int>();
            for (int i = 0; i < _size; i++)
            {
                hashSetInt.Add(i);
            }

            // Perform the benchmark operation
            hashSetInt.Add(_size);
        }

        /// <summary>
        /// Benchmark to remove a specific integer from a HashSet<int>.
        /// Initializes a new HashSet<int> within the method.
        /// </summary>
        [Benchmark]
        public void HashSet_Remove_Int()
        {
            // Initialize HashSet<int>
            HashSet<int> hashSetInt = new HashSet<int>();
            for (int i = 0; i < _size; i++)
            {
                hashSetInt.Add(i);
            }

            // Perform the benchmark operation
            hashSetInt.Remove(_size - 1);
        }

        #endregion
    }
}
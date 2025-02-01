using System.Collections.ObjectModel;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Common.Models;

namespace ListOperations.Benchmarks
{
    /// <summary>
    /// Benchmark class to evaluate the performance of common operations
    /// on List<T> and IList<T> for int, string, and Person types.
    /// </summary>
    [MemoryDiagnoser] // Tracks memory allocation for each benchmark
    [Orderer(SummaryOrderPolicy.FastestToSlowest)] // Sorts results from fastest to slowest
    [RankColumn] // Adds a 'Rank' column in the results table
    [SimpleJob(warmupCount:3, iterationCount:10)] // Configures the job
    public class ListBenchmark
    {
        /// <summary>
        /// The number of elements used in these benchmarks.
        /// Adjust to balance accuracy vs. execution time.
        /// </summary>
        [Params(100)]
        public int Size { get; set; }

        // Backing fields for List<T>
        private List<int> _listInt;
        private List<string> _listString;
        private List<Person> _listPerson;

        // Backing fields for IList<T>
        private IList<int> _iListInt;
        private IList<string> _iListString;
        private IList<Person> _iListPerson;

        /// <summary>
        /// Called once per benchmark run. Initializes
        /// all data structures with Size elements.
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            // Prepare List<int>
            _listInt = new List<int>(Size);
            for (int i = 0; i < Size; i++)
            {
                _listInt.Add(i);
            }

            // Prepare IList<int>
            _iListInt = new List<int>(Size);
            for (int i = 0; i < Size; i++)
            {
                _iListInt.Add(i);
            }

            // Prepare List<string>
            _listString = new List<string>(Size);
            for (int i = 0; i < Size; i++)
            {
                _listString.Add($"String{i}");
            }

            // Prepare IList<string>
            _iListString = new List<string>(Size);
            for (int i = 0; i < Size; i++)
            {
                _iListString.Add($"String{i}");
            }

            // Prepare List<Person>
            _listPerson = new List<Person>(Size);
            for (int i = 0; i < Size; i++)
            {
                _listPerson.Add(new Person
                {
                    Id = i,
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                    BirthDate = DateTime.Now.AddDays(-i),
                    Email = $"user{i}@example.com",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Id = i * 10 + 1,
                            PersonId = i.ToString(),
                            Country = "Country" + (i % 100),
                            City = "City" + (i % 1000)
                        },
                        new Address
                        {
                            Id = i * 10 + 2,
                            PersonId = i.ToString(),
                            Country = "Country" + ((i + 1) % 100),
                            City = "City" + ((i + 1) % 1000)
                        }
                    }
                });
            }

            // Prepare IList<Person>
            _iListPerson = new List<Person>(Size);
            for (int i = 0; i < Size; i++)
            {
                _iListPerson.Add(new Person
                {
                    Id = i,
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                    BirthDate = DateTime.Now.AddDays(-i),
                    Email = $"user{i}@example.com",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Id = i * 10 + 1,
                            PersonId = i.ToString(),
                            Country = "Country" + (i % 100),
                            City = "City" + (i % 1000)
                        },
                        new Address
                        {
                            Id = i * 10 + 2,
                            PersonId = i.ToString(),
                            Country = "Country" + ((i + 1) % 100),
                            City = "City" + ((i + 1) % 1000)
                        }
                    }
                });
            }
        }

        // Note: For benchmarks that mutate the list (e.g., Add/Remove),
        // we need a fresh copy each time or we risk distorting subsequent runs.
        // One approach is to copy the list in the benchmark method,
        // or use [IterationSetup] to reset. We'll illustrate with copying
        // for Add/Remove tests.

        #region Find Operations

        [Benchmark]
        public int? List_Find_FirstEven()
        {
            // Pure read operation (no side effects)
            return _listInt.FirstOrDefault(x => x % 2 == 0);
        }

        [Benchmark]
        public int? IList_Find_FirstEven()
        {
            return _iListInt.FirstOrDefault(x => x % 2 == 0);
        }

        [Benchmark]
        public string? List_Find_FirstAString()
        {
            return _listString.FirstOrDefault(s => s.StartsWith("A"));
        }

        [Benchmark]
        public string? IList_Find_FirstAString()
        {
            return _iListString.FirstOrDefault(s => s.StartsWith("A"));
        }

        [Benchmark]
        public Person? List_Find_FirstPersonByEmail()
        {
            return _listPerson.FirstOrDefault(p => p.Email == $"user{Size / 2}@example.com");
        }

        [Benchmark]
        public Person? IList_Find_FirstPersonByEmail()
        {
            return _iListPerson.FirstOrDefault(p => p.Email == $"user{Size / 2}@example.com");
        }

        #endregion

        #region Add Operations

        // We copy the existing list so as not to affect subsequent runs.

        [Benchmark]
        public void List_Add_Int()
        {
            var copy = new List<int>(_listInt);
            copy.Add(Size);
        }

        [Benchmark]
        public void IList_Add_Int()
        {
            var copy = new List<int>(_iListInt);
            copy.Add(Size);
        }

        [Benchmark]
        public void List_Add_String()
        {
            var copy = new List<string>(_listString);
            copy.Add($"String{Size}");
        }

        [Benchmark]
        public void IList_Add_String()
        {
            var copy = new List<string>(_iListString);
            copy.Add($"String{Size}");
        }

        [Benchmark]
        public void List_Add_Person()
        {
            var copy = new List<Person>(_listPerson);
            copy.Add(new Person
            {
                Id = Size,
                FirstName = $"FirstName{Size}",
                LastName = $"LastName{Size}",
                BirthDate = DateTime.Now.AddDays(-Size),
                Email = $"user{Size}@example.com"
            });
        }

        [Benchmark]
        public void IList_Add_Person()
        {
            var copy = new List<Person>(_iListPerson);
            copy.Add(new Person
            {
                Id = Size,
                FirstName = $"FirstName{Size}",
                LastName = $"LastName{Size}",
                BirthDate = DateTime.Now.AddDays(-Size),
                Email = $"user{Size}@example.com"
            });
        }

        #endregion

        #region Remove Operations

        [Benchmark]
        public void List_Remove_LastInt()
        {
            var copy = new List<int>(_listInt);
            copy.RemoveAt(copy.Count - 1);
        }

        [Benchmark]
        public void IList_Remove_LastInt()
        {
            var copy = new List<int>(_iListInt);
            copy.RemoveAt(copy.Count - 1);
        }

        [Benchmark]
        public void List_Remove_LastString()
        {
            var copy = new List<string>(_listString);
            copy.RemoveAt(copy.Count - 1);
        }

        [Benchmark]
        public void IList_Remove_LastString()
        {
            var copy = new List<string>(_iListString);
            copy.RemoveAt(copy.Count - 1);
        }

        [Benchmark]
        public void List_Remove_LastPerson()
        {
            var copy = new List<Person>(_listPerson);
            copy.RemoveAt(copy.Count - 1);
        }

        [Benchmark]
        public void IList_Remove_LastPerson()
        {
            var copy = new List<Person>(_iListPerson);
            copy.RemoveAt(copy.Count - 1);
        }

        #endregion

        #region Convert Operations

        [Benchmark]
        public int[] List_ToArray_Int()
        {
            // This doesn't mutate, so we can directly call it
            return _listInt.ToArray();
        }

        [Benchmark]
        public int[] IList_ToArray_Int()
        {
            return _iListInt.ToArray();
        }

        [Benchmark]
        public string[] List_ToArray_String()
        {
            return _listString.ToArray();
        }

        [Benchmark]
        public string[] IList_ToArray_String()
        {
            return _iListString.ToArray();
        }

        [Benchmark]
        public ReadOnlyCollection<Person> List_AsReadOnly_Person()
        {
            return _listPerson.AsReadOnly();
        }

        [Benchmark]
        public ReadOnlyCollection<Person> IList_AsReadOnly_Person()
        {
            // IList<T> doesn't have AsReadOnly directly,
            // so we convert to List<T> first.
            return _iListPerson.ToList().AsReadOnly();
        }

        #endregion

        #region Enumerate Operations

        [Benchmark]
        public void List_Enumerate_Foreach_Int()
        {
            foreach (var item in _listInt)
            {
                // Simulate minimal usage
                _ = item + 1;
            }
        }

        [Benchmark]
        public void IList_Enumerate_Foreach_Int()
        {
            foreach (var item in _iListInt)
            {
                _ = item + 1;
            }
        }

        [Benchmark]
        public void List_Enumerate_ForLoop_String()
        {
            for (int i = 0; i < _listString.Count; i++)
            {
                _ = _listString[i];
            }
        }

        [Benchmark]
        public void IList_Enumerate_ForLoop_String()
        {
            for (int i = 0; i < _iListString.Count; i++)
            {
                _ = _iListString[i];
            }
        }

        [Benchmark]
        public void List_Enumerate_LINQ_Foreach_Person()
        {
            // Example: filter with Where
            foreach (var person in _listPerson.Where(p => p.Id % 2 == 0))
            {
                _ = person.Email;
            }
        }

        [Benchmark]
        public void IList_Enumerate_LINQ_Foreach_Person()
        {
            foreach (var person in _iListPerson.Where(p => p.Id % 2 == 0))
            {
                _ = person.Email;
            }
        }

        #endregion

        #region Additional Operations

        [Benchmark]
        public void List_Insert_First_Int()
        {
            var copy = new List<int>(_listInt);
            copy.Insert(0, -1);
        }

        [Benchmark]
        public void IList_Insert_First_Int()
        {
            var copy = new List<int>(_iListInt);
            copy.Insert(0, -1);
        }

        [Benchmark]
        public void List_Insert_First_String()
        {
            var copy = new List<string>(_listString);
            copy.Insert(0, "NewString");
        }

        [Benchmark]
        public void IList_Insert_First_String()
        {
            var copy = new List<string>(_iListString);
            copy.Insert(0, "NewString");
        }

        [Benchmark]
        public void List_RemoveAll_GreaterThanThreshold_Int()
        {
            var copy = new List<int>(_listInt);
            copy.RemoveAll(x => x > (Size / 2));
        }

        [Benchmark]
        public void IList_RemoveAll_GreaterThanThreshold_Int()
        {
            var copy = new List<int>(_iListInt);
            for (int i = copy.Count - 1; i >= 0; i--)
            {
                if (copy[i] > Size / 2)
                {
                    copy.RemoveAt(i);
                }
            }
        }

        [Benchmark]
        public void List_Clear_Int()
        {
            var copy = new List<int>(_listInt);
            copy.Clear();
        }

        [Benchmark]
        public void IList_Clear_Int()
        {
            var copy = new List<int>(_iListInt);
            copy.Clear();
        }

        #endregion
    }
}
using System.Collections.ObjectModel;
using BenchmarkDotNet.Attributes;

namespace ListOperations.Benchmarks
{
    /// <summary>
    /// Benchmark class to evaluate the performance of various operations on List<T> and IList<T>.
    /// </summary>
    [MemoryDiagnoser] // Enables memory allocation diagnostics for each benchmark
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)] // Orders benchmark results from fastest to slowest
    public class ListBenchmark
    {
        /// <summary>
        /// The number of elements to be used in the List during benchmarks.
        /// Adjust this value to balance between benchmark accuracy and execution time.
        /// </summary>
        [Params(100, 10_000)]
        public int Size { get; set; }

        #region Initialization Methods

        /// <summary>
        /// Initializes a List<int> with sequential integers.
        /// </summary>
        private List<int> InitializeListInt()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < Size; i++)
            {
                list.Add(i);
            }
            return list;
        }

        /// <summary>
        /// Initializes an IList<int> with sequential integers.
        /// </summary>
        private IList<int> InitializeIListInt()
        {
            IList<int> list = new List<int>();
            for (int i = 0; i < Size; i++)
            {
                list.Add(i);
            }
            return list;
        }

        /// <summary>
        /// Initializes a List<string> with sequential strings.
        /// </summary>
        private List<string> InitializeListString()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < Size; i++)
            {
                list.Add($"String{i}");
            }
            return list;
        }

        /// <summary>
        /// Initializes an IList<string> with sequential strings.
        /// </summary>
        private IList<string> InitializeIListString()
        {
            IList<string> list = new List<string>();
            for (int i = 0; i < Size; i++)
            {
                list.Add($"String{i}");
            }
            return list;
        }

        /// <summary>
        /// Initializes a List<Person> with sequential Person objects.
        /// </summary>
        private List<Person> InitializeListPerson()
        {
            List<Person> list = new List<Person>();
            for (int i = 0; i < Size; i++)
            {
                list.Add(new Person
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
            return list;
        }

        /// <summary>
        /// Initializes an IList<Person> with sequential Person objects.
        /// </summary>
        private IList<Person> InitializeIListPerson()
        {
            IList<Person> list = new List<Person>();
            for (int i = 0; i < Size; i++)
            {
                list.Add(new Person
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
            return list;
        }

        #endregion

        #region Find Operations

        /// <summary>
        /// Benchmark to find the first even integer in a List<int> using LINQ's FirstOrDefault.
        /// </summary>
        [Benchmark]
        public int? List_Find_FirstEven()
        {
            List<int> list = InitializeListInt();
            return list.FirstOrDefault(x => x % 2 == 0);
        }

        /// <summary>
        /// Benchmark to find the first even integer in an IList<int> using LINQ's FirstOrDefault.
        /// </summary>
        [Benchmark]
        public int? IList_Find_FirstEven()
        {
            IList<int> list = InitializeIListInt();
            return list.FirstOrDefault(x => x % 2 == 0);
        }

        /// <summary>
        /// Benchmark to find the first string starting with 'A' in a List<string> using LINQ's FirstOrDefault.
        /// </summary>
        [Benchmark]
        public string? List_Find_FirstAString()
        {
            List<string> list = InitializeListString();
            return list.FirstOrDefault(s => s.StartsWith("A"));
        }

        /// <summary>
        /// Benchmark to find the first string starting with 'A' in an IList<string> using LINQ's FirstOrDefault.
        /// </summary>
        [Benchmark]
        public string? IList_Find_FirstAString()
        {
            IList<string> list = InitializeIListString();
            return list.FirstOrDefault(s => s.StartsWith("A"));
        }

        /// <summary>
        /// Benchmark to find the first Person with a specific email in a List<Person> using LINQ's FirstOrDefault.
        /// </summary>
        [Benchmark]
        public Person? List_Find_FirstPersonByEmail()
        {
            List<Person> list = InitializeListPerson();
            return list.FirstOrDefault(p => p.Email == $"user{Size / 2}@example.com");
        }

        /// <summary>
        /// Benchmark to find the first Person with a specific email in an IList<Person> using LINQ's FirstOrDefault.
        /// </summary>
        [Benchmark]
        public Person? IList_Find_FirstPersonByEmail()
        {
            IList<Person> list = InitializeIListPerson();
            return list.FirstOrDefault(p => p.Email == $"user{Size / 2}@example.com");
        }

        #endregion

        #region Add Operations

        /// <summary>
        /// Benchmark to add a new integer to a List<int>.
        /// </summary>
        [Benchmark]
        public void List_Add_Int()
        {
            List<int> list = InitializeListInt();
            list.Add(Size);
        }

        /// <summary>
        /// Benchmark to add a new integer to an IList<int>.
        /// </summary>
        [Benchmark]
        public void IList_Add_Int()
        {
            IList<int> list = InitializeIListInt();
            list.Add(Size);
        }

        /// <summary>
        /// Benchmark to add a new string to a List<string>.
        /// </summary>
        [Benchmark]
        public void List_Add_String()
        {
            List<string> list = InitializeListString();
            list.Add($"String{Size}");
        }

        /// <summary>
        /// Benchmark to add a new string to an IList<string>.
        /// </summary>
        [Benchmark]
        public void IList_Add_String()
        {
            IList<string> list = InitializeIListString();
            list.Add($"String{Size}");
        }

        /// <summary>
        /// Benchmark to add a new Person to a List<Person>.
        /// </summary>
        [Benchmark]
        public void List_Add_Person()
        {
            List<Person> list = InitializeListPerson();
            list.Add(new Person
            {
                Id = Size,
                FirstName = $"FirstName{Size}",
                LastName = $"LastName{Size}",
                BirthDate = DateTime.Now.AddDays(-Size),
                Email = $"user{Size}@example.com",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Id = Size * 10 + 1,
                        PersonId = Size.ToString(),
                        Country = "Country" + (Size % 100),
                        City = "City" + (Size % 1000)
                    },
                    new Address
                    {
                        Id = Size * 10 + 2,
                        PersonId = Size.ToString(),
                        Country = "Country" + ((Size + 1) % 100),
                        City = "City" + ((Size + 1) % 1000)
                    }
                }
            });
        }

        /// <summary>
        /// Benchmark to add a new Person to an IList<Person>.
        /// </summary>
        [Benchmark]
        public void IList_Add_Person()
        {
            IList<Person> list = InitializeIListPerson();
            list.Add(new Person
            {
                Id = Size,
                FirstName = $"FirstName{Size}",
                LastName = $"LastName{Size}",
                BirthDate = DateTime.Now.AddDays(-Size),
                Email = $"user{Size}@example.com",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Id = Size * 10 + 1,
                        PersonId = Size.ToString(),
                        Country = "Country" + (Size % 100),
                        City = "City" + (Size % 1000)
                    },
                    new Address
                    {
                        Id = Size * 10 + 2,
                        PersonId = Size.ToString(),
                        Country = "Country" + ((Size + 1) % 100),
                        City = "City" + ((Size + 1) % 1000)
                    }
                }
            });
        }

        #endregion

        #region Remove Operations

        /// <summary>
        /// Benchmark to remove the last integer from a List<int>.
        /// </summary>
        [Benchmark]
        public void List_Remove_LastInt()
        {
            List<int> list = InitializeListInt();
            list.RemoveAt(list.Count - 1);
        }

        /// <summary>
        /// Benchmark to remove the last integer from an IList<int>.
        /// </summary>
        [Benchmark]
        public void IList_Remove_LastInt()
        {
            IList<int> list = InitializeIListInt();
            list.RemoveAt(list.Count - 1);
        }

        /// <summary>
        /// Benchmark to remove the last string from a List<string>.
        /// </summary>
        [Benchmark]
        public void List_Remove_LastString()
        {
            List<string> list = InitializeListString();
            list.RemoveAt(list.Count - 1);
        }

        /// <summary>
        /// Benchmark to remove the last string from an IList<string>.
        /// </summary>
        [Benchmark]
        public void IList_Remove_LastString()
        {
            IList<string> list = InitializeIListString();
            list.RemoveAt(list.Count - 1);
        }

        /// <summary>
        /// Benchmark to remove the last Person from a List<Person>.
        /// </summary>
        [Benchmark]
        public void List_Remove_LastPerson()
        {
            List<Person> list = InitializeListPerson();
            list.RemoveAt(list.Count - 1);
        }

        /// <summary>
        /// Benchmark to remove the last Person from an IList<Person>.
        /// </summary>
        [Benchmark]
        public void IList_Remove_LastPerson()
        {
            IList<Person> list = InitializeIListPerson();
            list.RemoveAt(list.Count - 1);
        }

        #endregion

        #region Convert Operations

        /// <summary>
        /// Benchmark to convert a List<int> to an array using ToArray.
        /// </summary>
        [Benchmark]
        public int[] List_ToArray_Int()
        {
            List<int> list = InitializeListInt();
            return list.ToArray();
        }

        /// <summary>
        /// Benchmark to convert an IList<int> to an array using ToArray.
        /// </summary>
        [Benchmark]
        public int[] IList_ToArray_Int()
        {
            IList<int> list = InitializeIListInt();
            return list.ToArray();
        }

        /// <summary>
        /// Benchmark to convert a List<string> to an array using ToArray.
        /// </summary>
        [Benchmark]
        public string[] List_ToArray_String()
        {
            List<string> list = InitializeListString();
            return list.ToArray();
        }

        /// <summary>
        /// Benchmark to convert an IList<string> to an array using ToArray.
        /// </summary>
        [Benchmark]
        public string[] IList_ToArray_String()
        {
            IList<string> list = InitializeIListString();
            return list.ToArray();
        }

        /// <summary>
        /// Benchmark to convert a List<Person> to a ReadOnlyCollection<Person> using AsReadOnly.
        /// </summary>
        [Benchmark]
        public ReadOnlyCollection<Person> List_AsReadOnly_Person()
        {
            List<Person> list = InitializeListPerson();
            return list.AsReadOnly();
        }

        /// <summary>
        /// Benchmark to convert an IList<Person> to a ReadOnlyCollection<Person> using AsReadOnly.
        /// </summary>
        [Benchmark]
        public ReadOnlyCollection<Person> IList_AsReadOnly_Person()
        {
            IList<Person> list = InitializeIListPerson();
            return list.ToList().AsReadOnly(); // IList<T> doesn't have AsReadOnly directly
        }

        #endregion

        #region Enumerate Operations

        /// <summary>
        /// Benchmark to enumerate all integers in a List<int> using a foreach loop.
        /// </summary>
        [Benchmark]
        public void List_Enumerate_Foreach_Int()
        {
            List<int> list = InitializeListInt();
            foreach (var item in list)
            {
                // Simulate some work
                var temp = item;
            }
        }

        /// <summary>
        /// Benchmark to enumerate all integers in an IList<int> using a foreach loop.
        /// </summary>
        [Benchmark]
        public void IList_Enumerate_Foreach_Int()
        {
            IList<int> list = InitializeIListInt();
            foreach (var item in list)
            {
                // Simulate some work
                var temp = item;
            }
        }

        /// <summary>
        /// Benchmark to enumerate all strings in a List<string> using a for loop.
        /// </summary>
        [Benchmark]
        public void List_Enumerate_ForLoop_String()
        {
            List<string> list = InitializeListString();
            for (int i = 0; i < list.Count; i++)
            {
                // Simulate some work
                var temp = list[i];
            }
        }

        /// <summary>
        /// Benchmark to enumerate all strings in an IList<string> using a for loop.
        /// </summary>
        [Benchmark]
        public void IList_Enumerate_ForLoop_String()
        {
            IList<string> list = InitializeIListString();
            for (int i = 0; i < list.Count; i++)
            {
                // Simulate some work
                var temp = list[i];
            }
        }

        /// <summary>
        /// Benchmark to enumerate all Person objects in a List<Person> using LINQ's foreach.
        /// </summary>
        [Benchmark]
        public void List_Enumerate_LINQ_Foreach_Person()
        {
            List<Person> list = InitializeListPerson();
            foreach (var person in list.Where(p => p.Id % 2 == 0))
            {
                // Simulate some work
                var temp = person.Email;
            }
        }

        /// <summary>
        /// Benchmark to enumerate all Person objects in an IList<Person> using LINQ's foreach.
        /// </summary>
        [Benchmark]
        public void IList_Enumerate_LINQ_Foreach_Person()
        {
            IList<Person> list = InitializeIListPerson();
            foreach (var person in list.Where(p => p.Id % 2 == 0))
            {
                // Simulate some work
                var temp = person.Email;
            }
        }

        #endregion

        #region Additional Operations

        /// <summary>
        /// Benchmark to insert an integer at the beginning of a List<int>.
        /// </summary>
        [Benchmark]
        public void List_Insert_First_Int()
        {
            List<int> list = InitializeListInt();
            list.Insert(0, -1);
        }

        /// <summary>
        /// Benchmark to insert an integer at the beginning of an IList<int>.
        /// </summary>
        [Benchmark]
        public void IList_Insert_First_Int()
        {
            IList<int> list = InitializeIListInt();
            list.Insert(0, -1);
        }

        /// <summary>
        /// Benchmark to insert a string at the beginning of a List<string>.
        /// </summary>
        [Benchmark]
        public void List_Insert_First_String()
        {
            List<string> list = InitializeListString();
            list.Insert(0, "NewString");
        }

        /// <summary>
        /// Benchmark to insert a string at the beginning of an IList<string>.
        /// </summary>
        [Benchmark]
        public void IList_Insert_First_String()
        {
            IList<string> list = InitializeIListString();
            list.Insert(0, "NewString");
        }

        /// <summary>
        /// Benchmark to remove all integers greater than a threshold from a List<int>.
        /// </summary>
        [Benchmark]
        public void List_RemoveAll_GreaterThanThreshold_Int()
        {
            List<int> list = InitializeListInt();
            list.RemoveAll(x => x > Size / 2);
        }

        /// <summary>
        /// Benchmark to remove all integers greater than a threshold from an IList<int>.
        /// </summary>
        [Benchmark]
        public void IList_RemoveAll_GreaterThanThreshold_Int()
        {
            IList<int> list = InitializeIListInt().ToList();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] > Size / 2)
                {
                    list.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Benchmark to clear all elements from a List<int>.
        /// </summary>
        [Benchmark]
        public void List_Clear_Int()
        {
            List<int> list = InitializeListInt();
            list.Clear();
        }

        /// <summary>
        /// Benchmark to clear all elements from an IList<int>.
        /// </summary>
        [Benchmark]
        public void IList_Clear_Int()
        {
            IList<int> list = InitializeIListInt().ToList();
            list.Clear();
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using DataStructureOperations.Models;

namespace DataStructureOperations.Benchmarks
{
    /// <summary>
    /// Benchmark class to compare common data structure operations.
    /// </summary>
    [MemoryDiagnoser] // Enables memory allocation diagnostics
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)] // Orders results from fastest to slowest
    [SimpleJob(warmupCount:5, iterationCount:5)]
    public class DataStructureBenchmark
    {
        private readonly int _intSize = 1_0; // Number of elements for int benchmarks
        private readonly int _stringSize = 1_0; // Number of elements for string benchmarks
        private readonly int _personSize = 1_0; // Number of elements for Person benchmarks

        private int[] _intArray;
        private Stack<int> _intStack;
        private Queue<int> _intQueue;
        private LinkedList<int> _intSinglyLinkedList;
        private LinkedList<int> _intDoublyLinkedList;
        private Dictionary<int, string> _intHashTable;

        private string[] _stringArray;
        private Stack<string> _stringStack;
        private Queue<string> _stringQueue;
        private LinkedList<string> _stringSinglyLinkedList;
        private LinkedList<string> _stringDoublyLinkedList;
        private Dictionary<string, string> _stringHashTable;

        private Person[] _personArray;
        private Stack<Person> _personStack;
        private Queue<Person> _personQueue;
        private LinkedList<Person> _personSinglyLinkedList;
        private LinkedList<Person> _personDoublyLinkedList;
        private Dictionary<int, Person> _personHashTable;

        /// <summary>
        /// Global setup method to initialize data structures with sample data.
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            // Initialize int data structures
            _intArray = new int[_intSize];
            _intStack = new Stack<int>();
            _intQueue = new Queue<int>();
            _intSinglyLinkedList = new LinkedList<int>();
            _intDoublyLinkedList = new LinkedList<int>();
            _intHashTable = new Dictionary<int, string>();

            for (int i = 0; i < _intSize; i++)
            {
                _intArray[i] = i;
                _intStack.Push(i);
                _intQueue.Enqueue(i);
                _intSinglyLinkedList.AddLast(i);
                _intDoublyLinkedList.AddLast(i);
                _intHashTable.Add(i, $"Value{i}");
            }

            // Initialize string data structures
            _stringArray = new string[_stringSize];
            _stringStack = new Stack<string>();
            _stringQueue = new Queue<string>();
            _stringSinglyLinkedList = new LinkedList<string>();
            _stringDoublyLinkedList = new LinkedList<string>();
            _stringHashTable = new Dictionary<string, string>();

            for (int i = 0; i < _stringSize; i++)
            {
                string value = $"Value{i}";
                _stringArray[i] = value;
                _stringStack.Push(value);
                _stringQueue.Enqueue(value);
                _stringSinglyLinkedList.AddLast(value);
                _stringDoublyLinkedList.AddLast(value);
                _stringHashTable.Add(value, $"Value{i}");
            }

            // Initialize Person data structures
            _personArray = new Person[_personSize];
            _personStack = new Stack<Person>();
            _personQueue = new Queue<Person>();
            _personSinglyLinkedList = new LinkedList<Person>();
            _personDoublyLinkedList = new LinkedList<Person>();
            _personHashTable = new Dictionary<int, Person>();

            for (int i = 0; i < _personSize; i++)
            {
                var person = new Person
                {
                    Id = i,
                    FirstName = $"Baris{i}",
                    LastName = $"Ozgen{i}",
                    BirthDate = DateTime.Now.AddDays(-i),
                    Email = $"user{i}@example.com",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Id = i + 1,
                            PersonId = i.ToString(),
                            Country = "Country" + (i+1),
                            City = "City" + (i+1)
                        },
                        new Address
                        {
                            Id = i + 2,
                            PersonId = i.ToString(),
                            Country = "Country" + (i+2),
                            City = "City" + (i+2)
                        }
                    }
                };

                _personArray[i] = person;
                _personStack.Push(person);
                _personQueue.Enqueue(person);
                _personSinglyLinkedList.AddLast(person);
                _personDoublyLinkedList.AddLast(person);
                _personHashTable.Add(person.Id, person);
            }
        }

        #region Integer Benchmarks

        /// <summary>
        /// Adds an element to an array by setting its value.
        /// </summary>
        [Benchmark]
        public void Array_Add_Int()
        {
            for (int i = 0; i < _intSize; i++)
            {
                _intArray[i] = i;
                Console.WriteLine("Add: _intArray[i]:"+i);
            }
        }

        /// <summary>
        /// Gets an element from an array by index.
        /// </summary>
        [Benchmark]
        public void Array_Get_Int()
        {
            int sum = 0;
            for (int i = 0; i < _intSize; i++)
            {
                sum += _intArray[i];
                Console.WriteLine("Get: _intArray[i]:"+i);
            }
        }

        /// <summary>
        /// Removes an element from a stack.
        /// </summary>
        [Benchmark]
        public void Stack_Remove_Int()
        {
            var stackCopy = new Stack<int>(_intStack);
            while (stackCopy.Count > 0)
            {
                stackCopy.Pop();
                Console.WriteLine("Remove: stackCopy.Pop()");
            }
        }

        /// <summary>
        /// Finds an element in a hash table.
        /// </summary>
        [Benchmark]
        public void HashTable_Find_Int()
        {
            for (int i = 0; i < _intSize; i++)
            {
                _intHashTable.TryGetValue(i, out var value);
                Console.WriteLine("Find: _intHashTable:"+ value);
            }
        }

        #endregion

        #region String Benchmarks

        /// <summary>
        /// Adds an element to a queue.
        /// </summary>
        [Benchmark]
        public void Queue_Add_String()
        {
            for (int i = 0; i < _stringSize; i++)
            {
                _stringQueue.Enqueue($"Value{i}");
                Console.WriteLine("Add: _stringQueue.Enqueue:"+ i);
            }
        }

        /// <summary>
        /// Gets an element from a queue by dequeuing.
        /// </summary>
        [Benchmark]
        public void Queue_Get_String()
        {
            var queueCopy = new Queue<string>(_stringQueue);
            while (queueCopy.Count > 0)
            {
                var item = queueCopy.Dequeue();
                Console.WriteLine("Add: queueCopy.Dequeue()");
            }
        }

        /// <summary>
        /// Removes an element from a linked list.
        /// </summary>
        [Benchmark]
        public void LinkedList_Remove_String()
        {
            var listCopy = new LinkedList<string>(_stringSinglyLinkedList);
            while (listCopy.Count > 0)
            {
                listCopy.RemoveFirst();
                Console.WriteLine("Remove: listCopy.RemoveFirst()");
            }
        }

        /// <summary>
        /// Finds an element in a hash table.
        /// </summary>
        [Benchmark]
        public void HashTable_Find_String()
        {
            for (int i = 0; i < _stringSize; i++)
            {
                _stringHashTable.TryGetValue($"Value{i}", out var value);
                Console.WriteLine("Find: _stringHashTable.TryGetValue"+ i);
            }
        }

        #endregion

        #region Person Benchmarks

        /// <summary>
        /// Adds a Person object to a stack.
        /// </summary>
        [Benchmark]
        public void Stack_Add_Person()
        {
            for (int i = 0; i < _personSize; i++)
            {
                _personStack.Push(_personArray[i]);
                Console.WriteLine("Add: _personStack.Push"+ i);
            }
        }

        /// <summary>
        /// Gets a Person object from a stack by popping.
        /// </summary>
        [Benchmark]
        public void Stack_Get_Person()
        {
            var stackCopy = new Stack<Person>(_personStack);
            while (stackCopy.Count > 0)
            {
                var person = stackCopy.Pop();
                Console.WriteLine("Get: stackCopy.Pop");
            }
        }

        /// <summary>
        /// Removes a Person object from a queue.
        /// </summary>
        [Benchmark]
        public void Queue_Remove_Person()
        {
            var queueCopy = new Queue<Person>(_personQueue);
            while (queueCopy.Count > 0)
            {
                queueCopy.Dequeue();
                Console.WriteLine("Remove: queueCopy.Dequeue");
            }
        }

        /// <summary>
        /// Finds a Person object in a hash table.
        /// </summary>
        [Benchmark]
        public void HashTable_Find_Person()
        {
            for (int i = 0; i < _personSize; i++)
            {
                _personHashTable.TryGetValue(i, out var person);
                Console.WriteLine("Find: _personHashTable.TryGetValue:"+i);
            }
        }

        #endregion
    }
}
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Common.Models;
using System.Collections.Concurrent;

namespace Benchmarkus.AsyncSyncTPL
{
    [MemoryDiagnoser]
    [ThreadingDiagnoser]  // If you're on Windows, you could also consider: [ThreadingDiagnoser(ThreadingDiagnoserOptions.All)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)] // Sorts results from fastest to slowest
    [RankColumn] // Adds a 'Rank' column in the results table
    [SimpleJob(warmupCount:3, iterationCount:5)] // Configures the job
    public class AsyncSyncTPLBenchmarks
    {
        private Person[] _people;
        private const int DelayMs = 2; // For simulating I/O or artificial delay for now we divide by 1000
        private readonly Random _random = new();

        // Shared concurrency primitives
        private readonly object _syncLock = new object();
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private readonly Mutex _mutex = new();
        private readonly ReaderWriterLockSlim _readerWriterLock = new();

        // Shared data structure for concurrency tests
        private ConcurrentDictionary<int, Person> _concurrentDict;

        [GlobalSetup]
        public void Setup()
        {
            // Setup an array of Persons
            _people = new Person[100];

            for (int i = 0; i < _people.Length; i++)
            {
                _people[i] = new Person
                {
                    Id = i,
                    FirstName = $"baris{i}",
                    LastName = $"ozgen{i}",
                    BirthDate = DateTime.UtcNow.AddYears(-_random.Next(18, 80)),
                    Email = $"barisozgen{i}@benchmarkus.tes.com",
                    Addresses = new()
                    {
                        new Address
                        {
                            Id = i,
                            PersonId = i.ToString(),
                            Country = "TestCountry",
                            City = "TestCity"
                        }
                    }
                };
            }

            _concurrentDict = new ConcurrentDictionary<int, Person>();
        }

        #region Basic Async vs Sync
        /// <summary>
        /// Simulates synchronous I/O (blocking) for each Person.
        /// Thread.Sleep is used as a placeholder for real blocking I/O.
        /// </summary>
        [Benchmark]
        public void ProcessPeopleSync()
        {
            foreach (var person in _people)
            {
                // Synchronous “I/O” simulation
                Thread.Sleep(DelayMs / 1000); 
                // Replace with real I/O calls if needed
            }
        }

        /// <summary>
        /// Simulates asynchronous I/O with Task.Delay for each Person.
        /// </summary>
        [Benchmark]
        public async Task ProcessPeopleAsync()
        {
            foreach (var person in _people)
            {
                // Asynchronous “I/O” simulation
                await Task.Delay(DelayMs / 1000);
                // Replace with real I/O calls if needed
            }
        }

        /// <summary>
        /// Compare CPU-bound sync vs CPU-bound async overhead.
        /// </summary>
        [Benchmark]
        public int CpuBoundSync()
        {
            int sum = 0;
            for (int i = 0; i < _people.Length; i++)
            {
                sum += _people[i].Id; 
            }
            return sum;
        }

        /// <summary>
        /// Demonstrates overhead when using async for CPU-bound work.
        /// </summary>
        [Benchmark]
        public async Task<int> CpuBoundAsync()
        {
            int sum = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < _people.Length; i++)
                {
                    sum += _people[i].Id;
                }
            });
            return sum;
        }
        #endregion

        #region Task Parallel Library (TPL)
        /// <summary>
        /// Baseline single-threaded sum of Person IDs.
        /// </summary>
        [Benchmark(Baseline = true)]
        public long SumPersonIdsSync()
        {
            long sum = 0;
            for (int i = 0; i < _people.Length; i++)
            {
                sum += _people[i].Id;
            }
            return sum;
        }

        /// <summary>
        /// Uses Parallel.For to sum Person IDs in parallel partitions.
        /// </summary>
        [Benchmark]
        public long SumPersonIdsParallelFor()
        {
            long sum = 0;
            object locker = new object();

            Parallel.For(0, _people.Length, 
                // Local init
                () => 0L, 
                // Body
                (index, state, localSum) =>
                {
                    localSum += _people[index].Id;
                    return localSum;
                },
                // LocalFinally
                localSum =>
                {
                    lock (locker)
                    {
                        sum += localSum;
                    }
                }
            );
            return sum;
        }

        /// <summary>
        /// Uses PLINQ to sum Person IDs in parallel.
        /// </summary>
        [Benchmark]
        public long SumPersonIdsPlinq()
        {
            // Note: AsParallel() partitions the data automatically
            return _people.AsParallel().Sum(p => (long)p.Id);
        }
        #endregion

        #region Basic Concurrency Primitives
        /// <summary>
        /// Demonstrates lock usage for a shared counter.
        /// </summary>
        [Benchmark]
        public int LockTest()
        {
            int counter = 0;
            for (int i = 0; i < _people.Length; i++)
            {
                lock (_syncLock)
                {
                    counter++;
                }
            }
            return counter;
        }

        /// <summary>
        /// Demonstrates SemaphoreSlim usage for a shared counter.
        /// </summary>
        [Benchmark]
        public int SemaphoreTest()
        {
            int counter = 0;
            for (int i = 0; i < _people.Length; i++)
            {
                _semaphore.Wait();
                try
                {
                    counter++;
                }
                finally
                {
                    _semaphore.Release();
                }
            }
            return counter;
        }

        /// <summary>
        /// Demonstrates Mutex usage for a shared counter.
        /// </summary>
        [Benchmark]
        public int MutexTest()
        {
            int counter = 0;
            for (int i = 0; i < _people.Length; i++)
            {
                _mutex.WaitOne();
                try
                {
                    counter++;
                }
                finally
                {
                    _mutex.ReleaseMutex();
                }
            }
            return counter;
        }

        /// <summary>
        /// Demonstrates concurrent insertions into a ConcurrentDictionary.
        /// </summary>
        [Benchmark]
        public int ConcurrentDictionaryInsert()
        {
            _concurrentDict.Clear();

            Parallel.ForEach(_people, person =>
            {
                _concurrentDict[person.Id] = person;
            });

            return _concurrentDict.Count;
        }
        #endregion

        #region Advanced Concurrency Patterns
        /// <summary>
        /// Demonstrates ReaderWriterLockSlim usage with multiple readers and occasional writes.
        /// 
        /// We simulate random read vs. write operations to measure overhead. 
        /// Typically, ReaderWriterLockSlim is beneficial when reads outnumber writes significantly.
        /// </summary>
        [Benchmark]
        public int ReaderWriterLockSlimMixedOperations()
        {
            // We'll do a random mix of reads and writes on our _people array
            // For demonstration, the ratio is ~80% read, 20% write
            // Then we tally how many successful reads/writes occurred
            int operations = 0;

            for (int i = 0; i < _people.Length; i++)
            {
                bool writeOperation = _random.Next(1, 101) <= 20; // ~20% chance

                if (writeOperation)
                {
                    _readerWriterLock.EnterWriteLock();
                    try
                    {
                        // Example "write" — shuffle data in a random Person
                        var idx = _random.Next(0, _people.Length);
                        _people[idx].LastName = $"Updated{_random.Next(0, 9999)}";
                        operations++;
                    }
                    finally
                    {
                        _readerWriterLock.ExitWriteLock();
                    }
                }
                else
                {
                    _readerWriterLock.EnterReadLock();
                    try
                    {
                        // Example "read" — read from _people
                        var idx = _random.Next(0, _people.Length);
                        var firstName = _people[idx].FirstName; // read
                        operations++;
                    }
                    finally
                    {
                        _readerWriterLock.ExitReadLock();
                    }
                }
            }

            return operations;
        }

        /// <summary>
        /// Compare a simple lock for the same read/write mix scenario. 
        /// Not typically ideal for mostly-read situations, but used as a baseline.
        /// </summary>
        [Benchmark]
        public int LockMixedOperations()
        {
            int operations = 0;

            for (int i = 0; i < _people.Length; i++)
            {
                bool writeOperation = _random.Next(1, 101) <= 20; // ~20% chance

                lock (_syncLock)
                {
                    if (writeOperation)
                    {
                        var idx = _random.Next(0, _people.Length);
                        _people[idx].LastName = $"Updated{_random.Next(0, 9999)}";
                        operations++;
                    }
                    else
                    {
                        var idx = _random.Next(0, _people.Length);
                        var firstName = _people[idx].FirstName;
                        operations++;
                    }
                }
            }

            return operations;
        }
        #endregion
    }
}
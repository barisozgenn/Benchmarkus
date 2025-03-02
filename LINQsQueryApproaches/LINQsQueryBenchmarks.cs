namespace LINQsQueryApproaches;

using BenchmarkDotNet.Attributes;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using StructLinq;
using SpanLinq;
using BenchmarkDotNet.Order;

[MemoryDiagnoser] // Tracks memory allocation for each benchmark
[Orderer(SummaryOrderPolicy.FastestToSlowest)] // Sorts results from fastest to slowest
[RankColumn] // Adds a 'Rank' column in the results table
[SimpleJob(warmupCount:3, iterationCount:5)] // Configures the job
public class LINQsQueryBenchmarks
{
    private List<Person> _people = null!;

    /// <summary>
    /// Controls how many Person objects we generate for each benchmark iteration.
    /// Adjust or remove [Params] if you want fewer or a single set of data.
    /// </summary>
    [Params(1_0, 5_00)]
    public int N { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(42);
        _people = new List<Person>(N);

        for (int i = 0; i < N; i++)
        {
            // Random birth year roughly between 1950 - 2000
            var birthYear = 1950 + random.Next(0, 50);
            // Random addresses - assume up to 3 addresses per person
            var addressCount = random.Next(1, 4);
            var addresses = new List<Address>(addressCount);
            for (int j = 0; j < addressCount; j++)
            {
                addresses.Add(new Address
                {
                    Id = j + (i * 100), // unique ID
                    PersonId = i.ToString(),
                    Country = "Turkey" + random.Next(1, 5),
                    City = "Istanbul" + random.Next(1, 10)
                });
            }

            _people.Add(new Person
            {
                Id = i,
                FirstName = $"Baris{i}",
                LastName = $"Ozgen{i}",
                Email = $"baris{i}@benchmarkus.test.com",
                BirthDate = new DateTime(birthYear, random.Next(1, 13), random.Next(1, 28)),
                Addresses = addresses
            });
        }
    }

    // =========================================================================
    //                        COMPARISON: IMPERATIVE VS.
    //                  SEQUENTIAL LINQ VS. PLINQ VS. SPANLINQ VS. STRUCTLINQ
    //  
    //  We'll demonstrate a simple scenario: "Sum of ages" and "Filter & sum."
    //  This lets us see how each approach handles a basic numeric operation.
    // =========================================================================

    #region (A) Sum of Ages
    /// <summary>Baseline: manual loop.</summary>
    [Benchmark(Baseline = true)]
    public long SumOfAges_Imperative()
    {
        long total = 0;
        int currentYear = DateTime.Now.Year;
        for (int i = 0; i < _people.Count; i++)
        {
            total += (currentYear - _people[i].BirthDate.Year);
        }
        return total;
    }

    /// <summary>System.Linq (sequential).</summary>
    [Benchmark]
    public long SumOfAges_SequentialLinq()
    {
        int currentYear = DateTime.Now.Year;
        return _people
            .Select(p => currentYear - p.BirthDate.Year)
            .Sum();
    }

    /// <summary>PLINQ (Parallel LINQ).</summary>
    [Benchmark]
    public long SumOfAges_PLINQ()
    {
        int currentYear = DateTime.Now.Year;
        return _people
            .AsParallel()
            .Select(p => currentYear - p.BirthDate.Year)
            .Sum();
    }

    /// <summary>
    /// SpanLinq approach, converting List to Array -> Span, 
    /// manually iterating to compute the sum.
    /// </summary>
    [Benchmark]
    public long SumOfAges_SpanLinq()
    {
        var array = _people.ToArray();
        var currentYear = DateTime.Now.Year;

        // Project each Person to an int (the computed age),
        // returning a custom iterator-like object.
        var projectedSpan = array
            .AsSpan()
            .Select(p => currentYear - p.BirthDate.Year);

        // Since this sequence doesn't offer .Sum() or .Aggregate(),
        // we accumulate manually:
        long sum = 0;
        foreach (var item in projectedSpan)
        {
            sum += item;
        }

        return sum;
    }

    /// <summary>StructLinq approach, using ToStructEnumerable.</summary>
    [Benchmark]
    public long SumOfAges_StructLinq()
    {
        int currentYear = DateTime.Now.Year;

        // Example usage; actual extension method names may differ
        return _people
            .ToStructEnumerable()
            .Select(p => currentYear - p.BirthDate.Year)
            .Sum();
    }
    #endregion

    #region (B) Filter & Sum
    /// <summary>Imperative filtering + summation of Person ages > 30, LastName starts with 'Last5'.</summary>
    [Benchmark]
    public int FilterAndSum_Imperative()
    {
        int currentYear = DateTime.Now.Year;
        int sum = 0;
        foreach (var person in _people)
        {
            int age = currentYear - person.BirthDate.Year;
            if (age > 30 && person.LastName.StartsWith("Ozgen5"))
            {
                sum += age;
            }
        }
        return sum;
    }

    /// <summary>Sequential LINQ filtering + summation.</summary>
    [Benchmark]
    public int FilterAndSum_SequentialLinq()
    {
        int currentYear = DateTime.Now.Year;
        return _people
            .Where(p => (currentYear - p.BirthDate.Year) > 30)
            .Where(p => p.LastName.StartsWith("Ozgen5"))
            .Select(p => currentYear - p.BirthDate.Year)
            .Sum();
    }

    /// <summary>PLINQ version of the same multi-filter + sum.</summary>
    [Benchmark]
    public int FilterAndSum_PLINQ()
    {
        int currentYear = DateTime.Now.Year;
        return _people
            .AsParallel()
            .Where(p => (currentYear - p.BirthDate.Year) > 30)
            .Where(p => p.LastName.StartsWith("Ozgen5"))
            .Select(p => currentYear - p.BirthDate.Year)
            .Sum();
    }

    /// <summary>SpanLinq approach for filtering + summation.</summary>
    [Benchmark]
    public int FilterAndSum_SpanLinq()
    {
        var array = _people.ToArray();
        var currentYear = DateTime.Now.Year;

        // Build the iterator using SpanLinq 
        var query = array
            .AsSpan()
            .Where(p => (currentYear - p.BirthDate.Year) > 30)
            .Where(p => p.LastName.StartsWith("Ozgen5"))
            .Select(p => currentYear - p.BirthDate.Year);

        // Since there's no .Sum() or .Aggregate() on this custom iterator, 
        // manually sum the values in a simple loop:
        int sum = 0;
        foreach (var value in query)
        {
            sum += value;
        }

        return sum;
    }

    /// <summary>StructLinq approach for filtering + summation.</summary>
    [Benchmark]
    public int FilterAndSum_StructLinq()
    {
        int currentYear = DateTime.Now.Year;
        return _people
            .ToStructEnumerable()
            .Where(p => (currentYear - p.BirthDate.Year) > 30)
            .Where(p => p.LastName.StartsWith("Ozgen5"))
            .Select(p => currentYear - p.BirthDate.Year)
            .Sum();
    }
    #endregion

    // -------------------------------------------------------------------------------
    //   BELOW: Your existing benchmarks for complex queries, advanced usage, etc.
    // -------------------------------------------------------------------------------

    // ------------------------------------------------------------
    // 1) BASIC FILTER + SELECT (EXISTING)
    // ------------------------------------------------------------

    [Benchmark]
    public List<string> FilterAndSelect_Linq()
    {
        var result = _people
            .Where(p => (DateTime.Now.Year - p.BirthDate.Year) > 40)
            .Select(p => p.Email)
            .ToList();  // Immediate execution

        return result;
    }

    [Benchmark]
    public List<string> FilterAndSelect_Imperative()
    {
        var result = new List<string>();
        var currentYear = DateTime.Now.Year;

        foreach (var p in _people)
        {
            int age = currentYear - p.BirthDate.Year;
            if (age > 40)
            {
                result.Add(p.Email);
            }
        }
        return result;
    }

    // ------------------------------------------------------------
    // 2) INTERMEDIATE COMPLEX QUERY (EXISTING)
    // ------------------------------------------------------------

    [Benchmark]
    public List<(string Domain, int Count)> ComplexQuery_Linq()
    {
        var result = _people
            .Where(p => (DateTime.Now.Year - p.BirthDate.Year) > 30)
            .GroupBy(p => p.Email.Split('@')[1])
            .Select(g => new { Domain = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Select(x => (x.Domain, x.Count))
            .ToList();

        return result;
    }

    [Benchmark]
    public List<(string Domain, int Count)> ComplexQuery_Imperative()
    {
        var currentYear = DateTime.Now.Year;
        var dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var p in _people)
        {
            int age = currentYear - p.BirthDate.Year;
            if (age > 30)
            {
                var parts = p.Email.Split('@');
                if (parts.Length == 2)
                {
                    var domain = parts[1];
                    if (!dict.ContainsKey(domain))
                    {
                        dict[domain] = 0;
                    }
                    dict[domain]++;
                }
            }
        }

        var sorted = new List<(string Domain, int Count)>();
        foreach (var kvp in dict)
        {
            sorted.Add((kvp.Key, kvp.Value));
        }

        sorted.Sort((a, b) => b.Count.CompareTo(a.Count));
        return sorted;
    }

    // ------------------------------------------------------------
    // 3) ADVANCED LINQ QUERY (EXISTING)
    // ------------------------------------------------------------

    [Benchmark]
    public double AdvancedQuery_Linq()
    {
        var result = _people
            .SelectMany(p => p.Addresses, (person, address) => new
            {
                Person = person,
                Address = address
            })
            .Where(x => x.Address.City == "Istanbul5" || x.Address.City == "Istanbul7")
            .OrderBy(x => x.Person.LastName)
            .Skip(100)
            .Take(500)
            .Average(x => x.Person.BirthDate.Year);

        return result;
    }

    [Benchmark]
    public double AdvancedQuery_Imperative()
    {
        var flattened = new List<(Person person, Address address)>();
        foreach (var person in _people)
        {
            foreach (var addr in person.Addresses)
            {
                flattened.Add((person, addr));
            }
        }

        var filtered = new List<(Person person, Address address)>();
        foreach (var item in flattened)
        {
            if (item.address.City == "Istanbul5" || item.address.City == "Istanbul7")
            {
                filtered.Add(item);
            }
        }

        filtered.Sort((a, b) => string.Compare(a.person.LastName, b.person.LastName, StringComparison.Ordinal));

        var subset = new List<(Person person, Address address)>();
        for (int i = 100; i < Math.Min(600, filtered.Count); i++)
        {
            subset.Add(filtered[i]);
        }

        if (subset.Count == 0) return 0.0;
        double sum = 0.0;
        foreach (var item in subset)
        {
            sum += item.person.BirthDate.Year;
        }

        return sum / subset.Count;
    }

    // ------------------------------------------------------------
    // 4) DEMO OF DEFERRED EXECUTION (EXISTING)
    // ------------------------------------------------------------

    [Benchmark]
    public int DeferredExecution_Linq()
    {
        var query = _people
            .Where(p => p.LastName.StartsWith("Ozgen"))
            .Select(p => p.Id);

        int firstCount = query.Count();
        int secondCount = query.Count();

        return firstCount + secondCount;
    }

    [Benchmark]
    public int DeferredExecution_Cached_Linq()
    {
        var query = _people
            .Where(p => p.LastName.StartsWith("Ozgen"))
            .Select(p => p.Id)
            .ToList();

        int firstCount = query.Count;
        int secondCount = query.Count;

        return firstCount + secondCount;
    }
}
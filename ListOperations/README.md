# ListOperations Benchmarks

This project is part of the **Benchmarkus** repository and benchmarks **List\<T\>** vs. **IList\<T\>** on various **CRUD** (Create, Read, Update, Delete) and **enumeration** operations. It uses [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) to measure **performance** and **memory allocations** under different **`Size`** parameters.

## Why We Do It

- **Performance Insights**: Understand how `List<T>` compares to `IList<T>` for frequent operations (Add, Remove, Find, etc.).  
- **Generic Scenarios**: Test multiple data types (`int`, `string`, `Person`) to see how performance scales with complexity.  
- **Memory Diagnoser**: Evaluate potential memory overhead in repeated add/remove scenarios.

## What We Can Learn

1. **List<T> vs. IList<T>**: Identify if there's a significant performance difference.  
2. **Mutation Costs**: Show the overhead of copying lists in each benchmark for consistent test scenarios.  
3. **Enumeration Patterns**: Compare `foreach`, `for` loop, and LINQ enumerations.  
4. **Scalability**: Observe how operations scale from small (`Size=10`) to moderate (`Size=500`) (and possibly larger if you choose).

---

### Purpose & Motivation

- **Data Structure Selection**: Help developers pick the right collection type for their workload.  
- **Benchmark Best Practices**: Illustrate `[GlobalSetup]` usage, parameterized tests, and memory measurement.  
- **Real-World Relevance**: Show how typical operations (find, add, remove, convert, enumerate) perform under different conditions.

### Key Focus Areas

1. **Initialization**:
   - `[GlobalSetup]` method to construct baseline lists (`_listInt`, `_listString`, `_listPerson`).
2. **Operations**:
   - **Find**: Use `FirstOrDefault` with conditions.  
   - **Add**: Benchmark inserting a new element, ensuring we keep a clean copy.  
   - **Remove**: Removing last or matching elements.  
   - **Convert**: `ToArray`, `AsReadOnly`.  
   - **Enumerate**: `foreach`, `for`, and `LINQ`.  
   - **Insert**: Insert at an arbitrary position.  
   - **Clear**: Reset or remove all elements.
3. **Data Types**:
   - **int**  
   - **string**  
   - **Person** (a more complex object with nested `Address`).

### Goals

- **Clarity**: Provide easy-to-read code that’s also Sonar-friendly (clear methods, small responsibilities).  
- **Comparisons**: Show where `List<T>` might outperform a generic `IList<T>` or vice versa.  
- **Extendability**: You can add more types (`decimal`, `Guid`, etc.) or more `Size` values to get deeper insights.

---

## Benchmark Results (Placeholder)

Below are **example** tables for different .NET versions. Update these tables with your **actual** benchmark results after running `dotnet run --configuration Release`.

### .NET 6.0

### .NET 7.0

### .NET 8.0

### .NET 9.0

---

### Observations & Analysis

1. **List<T> vs. IList<T>**: In many implementations, `IList<T>` is also backed by a `List<T>`, so you might see minimal differences. However, interface calls can add overhead.  
2. **Reading vs. Writing**: Pure read operations (`Find`, `Enumerate`) typically differ from mutating operations (`Add`, `Remove`, `Insert`).  
3. **Allocation**: Notice if extra memory is allocated when you convert or copy items (like in `Add` or `Remove` benchmarks).  
4. **Scaling**: Check how performance changes from `Size=10` to `Size=500`—and possibly beyond.


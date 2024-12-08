# DynamicClassGeneration

**DynamicClassGeneration** is a sub-project within [Benchmarkus](https://github.com/barisozgenn/Benchmarkus/). It focuses on exploring and evaluating different approaches to runtime code generation, dynamic type creation, and method invocation techniques within the .NET ecosystem.

### Purpose & Motivation

Modern .NET applications often require dynamic behavior—ranging from generating code on the fly to extending application capabilities at runtime. Traditional reflection-based methods can be flexible, but may incur performance costs. **DynamicClassGeneration** aims to:

- **Investigate Alternatives:** Compare reflection-heavy approaches (e.g., `AssemblyBuilder`, `System.Reflection.Emit`) with other strategies like Roslyn-based code generation.
- **Assess Performance Impact:** Use benchmarks to measure how different dynamic generation methods affect execution time, memory usage, and overall efficiency.
- **Offer Practical Insights:** Provide guidance on when to choose a particular approach based on empirical data, rather than assumptions.

### Key Focus Areas

1. **Roslyn Integration:**  
   Explore how leveraging Roslyn’s compiler services enables in-memory code compilation and on-the-fly type creation.

2. **Reflection vs. Delegates vs. Factories:**  
   Benchmark various techniques for instantiating objects and invoking methods, ranging from full reflection calls to pre-compiled factory delegates.

3. **Realistic Scenarios:**  
   Consider both micro-benchmarks (e.g., measuring overhead of creating a single object) and more complex scenarios (like dynamically generating entire sets of classes).

### Goals

- **Better Decision-Making:**  
  Help us as developers choose the most suitable runtime type-generation method for their scenarios by providing actual performance data and analysis.
  
- **Demystifying Complexity:**  
  Clarify the trade-offs and break down the complexity behind different dynamic code generation strategies.
  
- **Contributions & Evolution:**  
  Invite community contributions to expand the range of benchmarks, integrate new techniques, or refine existing tests as the .NET ecosystem evolves.

### Benchmark Results

### Benchmark Results Across .NET Versions

Below are the benchmark results for different .NET versions, using `IterationCount=20` and `WarmupCount=5`.

#### .NET SDK 9.0.101

| **Method**             | **Mean**          | **Error**        | **StdDev**       | **Median**         | **Gen0**  | **Gen1**  | **Gen2** | **Allocated** |
|------------------------|------------------:|-----------------:|-----------------:|-------------------:|----------:|----------:|---------:|--------------:|
| ReuseInstance          |         0.0017 ns |       0.0035 ns  |       0.0038 ns  |         0.0000 ns  |         - |         - |        - |             - |
| DelegateInvoke         |         0.7120 ns |       0.0026 ns  |       0.0027 ns  |         0.7117 ns  |         - |         - |        - |             - |
| ReflectionInvoke       |        40.1431 ns |       0.0479 ns  |       0.0532 ns  |        40.1496 ns  |    0.0134 |         - |        - |         112 B |
| CreateInstance_OneTime | 3,518,898.0504 ns | 207,521.1439 ns  | 238,981.6580 ns  | 3,444,262.5352 ns  |   85.9375 |   39.0625 |   7.8125 |     701938 B |

#### .NET SDK 8.0.11 (8.0.1124.51707)

| **Method**             | **Mean**          | **Error**        | **StdDev**       | **Median**         | **Gen0**  | **Gen1**  | **Gen2** | **Allocated** |
|------------------------|------------------:|-----------------:|-----------------:|-------------------:|----------:|----------:|---------:|--------------:|
| ReuseInstance          |         0.0102 ns |       0.0091 ns  |       0.0102 ns  |         0.0053 ns  |         - |         - |        - |             - |
| DelegateInvoke         |         0.8892 ns |       0.0011 ns  |       0.0012 ns  |         0.8890 ns  |         - |         - |        - |             - |
| ReflectionInvoke       |        38.1528 ns |       0.0817 ns  |       0.0874 ns  |        38.1596 ns  |    0.0134 |         - |        - |         112 B |
| CreateInstance_OneTime | 2,905,768.9865 ns |  89,027.1801 ns  |  95,258.0854 ns  | 2,870,478.8359 ns  |   85.9375 |   39.0625 |   7.8125 |     691479 B |

#### .NET SDK 6.0.36 (6.0.3624.51421)

| **Method**             | **Mean**          | **Error**        | **StdDev**       | **Gen0**   | **Gen1**  | **Gen2**  | **Allocated** |
|------------------------|------------------:|-----------------:|-----------------:|-----------:|----------:|----------:|--------------:|
| ReuseInstance          |         0.0142 ns |       0.0090 ns  |       0.0093 ns  |          - |         - |         - |             - |
| DelegateInvoke         |         0.8867 ns |       0.0042 ns  |       0.0043 ns  |          - |         - |         - |             - |
| ReflectionInvoke       |       149.2151 ns |       0.6704 ns  |       0.7720 ns  |     0.0534 |         - |         - |         112 B |
| CreateInstance_OneTime | 2,997,309.6031 ns |  34,478.0498 ns  |  39,704.9735 ns  |   222.6563 |   66.4063 |   19.5313 |     674992 B |

---

### Key Observations

1. **`ReuseInstance`:** Across all versions, reusing an already-created instance incurs negligible overhead.
2. **`DelegateInvoke`:** Consistently faster than reflection, though slightly slower in older versions of .NET.
3. **`ReflectionInvoke`:** Shows stable performance across versions, but it's significantly slower than delegate invocation.
4. **`CreateInstance_OneTime`:** By far the most expensive method in terms of time and memory, especially in .NET 6, which shows significantly higher allocations compared to newer versions.


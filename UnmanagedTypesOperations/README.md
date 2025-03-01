# UnmanagedTypesOperations

This project is part of the **Benchmarkus** repository and is focused on benchmarking memory allocations and performance for various **unmanaged types** and **common .NET types** such as arrays, strings, decimals, booleans, and user-defined structs. It uses [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) to measure allocation size, speed, and other memory metrics under different scenarios—both single allocations and repeated allocations in loops.

## Why We Do It

- **Memory Allocation Insights**: Identify how much memory is allocated when using different .NET types in various scenarios.  
- **Performance Awareness**: Understand the impact of repeated allocations on performance and garbage collection.  
- **Unmanaged Type Exploration**: Validate the size and behavior of unmanaged generic structs (like `SomeVariableTypeGeneric<T>`) in .NET.

## What We Can Learn

- **Allocation Patterns**: Observe how single allocations differ from bulk (looped) allocations in terms of total allocated bytes and execution time.  
- **Cost of Strings & Arrays**: Compare memory usage among different types, including arrays, strings, booleans, decimals, and user-defined unmanaged structs.  
- **BenchmarkDotNet Usage**: Gain familiarity with how BenchmarkDotNet collects, measures, and reports on memory allocations in a standardized manner.

---

### Purpose & Motivation

- **Measure Allocations**: Quantify the memory usage of various .NET types under realistic workloads.  
- **Demonstrate Unmanaged Generics**: Show how `sizeof(T)` works for unmanaged type parameters in generic structs.  
- **Educate & Optimize**: Help developers make informed decisions when optimizing memory usage in performance-critical scenarios.

### Key Focus Areas

1. **Types Benchmarked**:
   - **Arrays** (`int[]`, `bool[]`, `decimal[]`, etc.)
   - **Strings** (varying lengths)
   - **Value Types** (e.g., `decimal`, `bool`, `int`, `double`)
   - **Unmanaged Generics** (e.g., `SomeVariableTypeGeneric<int>`, `SomeVariableTypeGeneric<double>`)

2. **Allocation Scenarios**:
   - **Single Allocation** (allocate once, measure overhead)
   - **Repeated Allocations** (allocate in loops, measure cumulative overhead)

3. **Metrics Collected**:
   - **Allocated Bytes**
   - **Gen0 / Gen1 / Gen2 Collections**
   - **Execution Time (Mean, Error, StdDev)**

### Goals

- **Benchmark Memory Footprint**: Precisely measure how memory usage scales when instantiating different types.  
- **Verify Unmanaged Struct Sizes**: Confirm the actual `sizeof` for structs constrained with `unmanaged`.  
- **Provide Actionable Data**: Help developers make data-driven choices about which types to use or how best to allocate them.

---

### Benchmark Results Across .NET Versions

Below are **placeholder tables** for different .NET SDK versions. After you run the benchmarks under each target framework (`net9.0`, `net10.0`), you can fill in the results accordingly. Each table compares **single** vs. **loop** allocations for various types and methods.

#### .NET SDK 9.0.101

| Method                        | Mean          | Error      | StdDev     | Gen0    | Allocated |
|------------------------------ |--------------:|-----------:|-----------:|--------:|----------:|
| AllocateIntArrayOnce          |   104.6096 ns |  0.4812 ns |  0.4265 ns |  0.4809 |    4024 B |
| AllocateStringOnce            |    85.6481 ns |  0.2484 ns |  0.2075 ns |  0.2419 |    2024 B |
| AllocateBoolArrayOnce         |    27.6408 ns |  0.2254 ns |  0.1998 ns |  0.1224 |    1024 B |
| AllocateDecimalArrayOnce      |   382.7957 ns |  5.6551 ns |  5.0131 ns |  1.9116 |   16024 B |
| AllocateUnmanagedStructOnce   |     0.0921 ns |  0.0018 ns |  0.0014 ns |       - |         - |
| AllocateIntArrayInLoop        |    28.5689 ns |  0.0447 ns |  0.0373 ns |       - |         - |
| AllocateStringInLoop          | 8,693.3674 ns | 18.2213 ns | 15.2156 ns | 24.1852 |  202400 B |
| AllocateBoolArrayInLoop       |    28.8523 ns |  0.0175 ns |  0.0137 ns |       - |         - |
| AllocateDecimalArrayInLoop    |    28.4777 ns |  0.0128 ns |  0.0107 ns |       - |         - |
| AllocateUnmanagedStructInLoop |    28.9098 ns |  0.0815 ns |  0.0636 ns |       - |         - |

#### .NET SDK 10.0.100-preview.1.25120.13
| Method                        | Mean          | Error      | StdDev     | Gen0    | Allocated |
|------------------------------ |--------------:|-----------:|-----------:|--------:|----------:|
| AllocateIntArrayOnce          |   108.9848 ns |  0.4025 ns |  0.3361 ns |  0.4809 |    4024 B |
| AllocateStringOnce            |    87.9557 ns |  0.2290 ns |  0.2142 ns |  0.2419 |    2024 B |
| AllocateBoolArrayOnce         |    28.6966 ns |  0.0533 ns |  0.0472 ns |  0.1224 |    1024 B |
| AllocateDecimalArrayOnce      |   390.2744 ns |  1.5995 ns |  1.3356 ns |  1.9116 |   16024 B |
| AllocateUnmanagedStructOnce   |     0.0966 ns |  0.0005 ns |  0.0004 ns |       - |         - |
| AllocateIntArrayInLoop        |    29.8347 ns |  0.1957 ns |  0.1735 ns |       - |         - |
| AllocateStringInLoop          | 8,861.3348 ns | 12.4772 ns | 10.4190 ns | 24.1852 |  202400 B |
| AllocateBoolArrayInLoop       |    29.5720 ns |  0.2216 ns |  0.2073 ns |       - |         - |
| AllocateDecimalArrayInLoop    |    28.9547 ns |  0.2693 ns |  0.2519 ns |       - |         - |
| AllocateUnmanagedStructInLoop |    29.3977 ns |  0.1892 ns |  0.1770 ns |       - |         - |

---

### Conclusion

This **BenchmarkDotNet** project offers valuable insights into **memory allocations** for arrays, strings, decimals, booleans, and unmanaged generic structs in .NET. By running these benchmarks under different .NET versions (6, 7, 8, 9, 10), you can observe:

- **Allocation Overhead**: How large or repetitive allocations can impact total memory usage and trigger garbage collections.  
- **Type Efficiency**: The relative memory costs for different data types in single vs. repeated allocation scenarios.  
- **Struct Sizing**: Verification of `sizeof(T)` for unmanaged generic structs, helping to confirm your assumptions about memory layout.

**Key Takeaways**:

1. **Release Mode Matters**: Always build and run the benchmarks in **Release** mode to get accurate measurements.  
2. **Large Strings vs. Small Arrays**: Certain types (like large strings) can quickly inflate memory usage; arrays are often more predictable.  
3. **Repeated Allocations**: Allocating objects in loops can amplify memory usage significantly, highlighting how ephemeral objects may impact performance.  
4. **Unmanaged Generics**: Confirming the size of unmanaged structs helps you design data-centric APIs or high-performance scenarios with more confidence.  

Feel free to add more data types, experiment with concurrency, or integrate additional metrics. The final data in these tables can be used to guide performance optimizations and memory usage decisions in real-world .NET applications.

---

**Happy Benchmarking!**

# GuardAttributesBenchmark

This project is part of the **Benchmarkus** repository and focuses on **null-check** benchmarking in .NET using **Ardalis.GuardClauses**, direct `if` checks, and **custom attributes** (with reflection) to enforce parameter validation. It leverages [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) to measure the **performance** and **memory usage** for different guard strategies. 

## Why We Do It

- **Performance Evaluation**: Understand the overhead of simple `if (param == null)` checks versus using **Ardalis.GuardClauses**.  
- **Reflection Overhead**: Illustrate how custom attributes with reflection can significantly impact performance compared to direct checks.  
- **Educational Insight**: Show how to set up benchmarks, measure overhead, and observe the effect of **exception throwing** when parameters are null.

## What We Can Learn

- **Baseline vs. Reflection**: Compare direct calls (`if` checks or Ardalis) to reflection-based null checks (`[CheckNullValueWithArdalis]`, `[CheckNullValueWithoutArdalis]`).  
- **Exception vs. No-Exception Path**: Observe the difference in performance when a method receives `null` (throwing `ArgumentNullException`) versus a valid object.  
- **GuardClauses**: Discover how easy it is to use **Ardalis.GuardClauses** for clean, concise null checks without scattering `if` checks everywhere.  
- **Attribute Patterns**: See how reflection-based checks look in code, albeit not recommended in production for performance-critical paths.

---

## Purpose & Motivation

- **Parameter Validation**: Demonstrate multiple patterns for validating `Person` objects (from `Common.Models`) to ensure they are not `null`.  
- **Reflection vs. Direct**: Show the potential cost of reflection when used repeatedly to enforce attribute-based checks.  
- **AOP/Source Generators**: Highlight how reflection is generally slower, encouraging advanced techniques (AOP or source generators) for attribute-based validation in real projects.  
- **Benchmarking Best Practices**: Encourage using **Release** mode and repeated runs to get statistically relevant results.

### Key Focus Areas

1. **Null Checking Methods**:
   - **Direct If Check**  
   - **Ardalis.GuardClauses**  
   - **Reflection + [CheckNullValueWithArdalis]**  
   - **Reflection + [CheckNullValueWithoutArdalis]**

2. **Scenarios**:
   - **`Person` is null**: Exceptions are thrown in each guard case.  
   - **`Person` is not null**: Fast path, no exception thrown.  

3. **Metrics Collected**:
   - **Mean Execution Time**  
   - **Error & StdDev** (statistical indicators)  
   - **Memory Allocations** (Gen0, etc.)  

### Goals

- **Quantify Overhead**: Precisely measure how reflection-based checks compare to direct method calls.  
- **Practical Guidance**: Illustrate that attribute-based reflection solutions can be significantly slower—**Ardalis.GuardClauses** or direct checks are typically faster and cleaner.  
- **Facilitate Learning**: Provide a codebase developers can experiment with to see how different guard patterns influence performance.

---

## Benchmark Results

Below is a **placeholder table** for your benchmark results on .NET 6, 7, 8, 9, 10, etc. After running `dotnet run --configuration Release`, you can fill the table with the actual results:

#### .NET SDK 10.0.100-preview.1.25120.13
| Method                              | Mean          | Error       | StdDev      | Median        | Gen0   | Allocated |
|------------------------------------ |--------------:|------------:|------------:|--------------:|-------:|----------:|
| IfCheck_Null_Throw                  | 2,405.8105 ns |   9.6802 ns |   8.5813 ns | 2,402.9229 ns | 0.0267 |     224 B |
| IfCheck_NotNull                     |     0.3007 ns |   0.0021 ns |   0.0016 ns |     0.3007 ns |      - |         - |
| ArdalisCheck_Null_Throw             | 2,214.9646 ns |  18.7837 ns |  17.5703 ns | 2,214.0142 ns | 0.0267 |     224 B |
| ArdalisCheck_NotNull                |     1.4320 ns |   0.0051 ns |   0.0042 ns |     1.4307 ns |      - |         - |
| ReflectionArdalisCheck_Null_Throw   | 6,262.6765 ns | 124.9487 ns | 311.1657 ns | 6,212.3674 ns | 0.0763 |     672 B |
| ReflectionArdalisCheck_NotNull      |   641.6179 ns |  12.8255 ns |  20.3426 ns |   629.9917 ns | 0.0439 |     368 B |
| ReflectionNoArdalisCheck_Null_Throw | 3,171.9510 ns |  41.4445 ns |  32.3572 ns | 3,162.7717 ns | 0.0610 |     568 B |
| ReflectionNoArdalisCheck_NotNull    |   629.6154 ns |   1.6053 ns |   1.4231 ns |   629.6155 ns | 0.0439 |     376 B |
#### .NET SDK 9.0.101
| Method                              | Mean           | Error       | StdDev      | Median         | Gen0   | Allocated |
|------------------------------------ |---------------:|------------:|------------:|---------------:|-------:|----------:|
| IfCheck_Null_Throw                  |  9,110.2978 ns |  24.3841 ns |  19.0375 ns |  9,115.3711 ns | 0.0153 |     224 B |
| IfCheck_NotNull                     |      0.3342 ns |   0.0044 ns |   0.0041 ns |      0.3332 ns |      - |         - |
| ArdalisCheck_Null_Throw             |  9,140.0886 ns |  85.5143 ns |  75.8062 ns |  9,168.1916 ns | 0.0153 |     224 B |
| ArdalisCheck_NotNull                |      1.4140 ns |   0.0042 ns |   0.0037 ns |      1.4143 ns |      - |         - |
| ReflectionArdalisCheck_Null_Throw   | 13,906.3662 ns | 278.0496 ns | 508.4295 ns | 13,670.2506 ns | 0.0610 |     672 B |
| ReflectionArdalisCheck_NotNull      |    579.6781 ns |   1.6088 ns |   1.5049 ns |    579.7925 ns | 0.0439 |     368 B |
| ReflectionNoArdalisCheck_Null_Throw | 10,139.1041 ns |  59.1587 ns |  55.3371 ns | 10,151.3456 ns | 0.0610 |     568 B |
| ReflectionNoArdalisCheck_NotNull    |    586.8070 ns |   1.6089 ns |   1.4262 ns |    586.6371 ns | 0.0439 |     376 B |
#### .NET SDK 8.0.404
| Method                              | Mean           | Error       | StdDev      | Gen0   | Allocated |
|------------------------------------ |---------------:|------------:|------------:|-------:|----------:|
| IfCheck_Null_Throw                  | 13,668.1145 ns | 157.1373 ns | 154.3298 ns | 0.0153 |     232 B |
| IfCheck_NotNull                     |      0.2352 ns |   0.0009 ns |   0.0007 ns |      - |         - |
| ArdalisCheck_Null_Throw             | 13,493.5702 ns |  34.2807 ns |  32.0662 ns | 0.0153 |     232 B |
| ArdalisCheck_NotNull                |      1.4198 ns |   0.0013 ns |   0.0011 ns |      - |         - |
| ReflectionArdalisCheck_Null_Throw   | 20,118.0629 ns | 390.7328 ns | 479.8550 ns | 0.0610 |     680 B |
| ReflectionArdalisCheck_NotNull      |    652.8541 ns |   2.0491 ns |   1.9167 ns | 0.0439 |     368 B |
| ReflectionNoArdalisCheck_Null_Throw | 14,660.0040 ns | 139.0569 ns | 116.1188 ns | 0.0610 |     576 B |
| ReflectionNoArdalisCheck_NotNull    |    646.1376 ns |   1.4744 ns |   1.3791 ns | 0.0448 |     376 B |
#### .NET SDK 7.0.410
| Method                              | Mean          | Error       | StdDev      | Gen0   | Allocated |
|------------------------------------ |--------------:|------------:|------------:|-------:|----------:|
| IfCheck_Null_Throw                  | 14,448.416 ns |  93.9405 ns |  83.2758 ns | 0.0305 |     352 B |
| IfCheck_NotNull                     |      1.349 ns |   0.0094 ns |   0.0078 ns |      - |         - |
| ArdalisCheck_Null_Throw             | 14,972.186 ns | 105.8917 ns |  99.0512 ns | 0.0610 |     568 B |
| ArdalisCheck_NotNull                |      2.521 ns |   0.0113 ns |   0.0106 ns |      - |         - |
| ReflectionArdalisCheck_Null_Throw   | 22,256.033 ns | 439.3949 ns | 684.0850 ns | 0.1221 |    1080 B |
| ReflectionArdalisCheck_NotNull      |    742.669 ns |   0.6339 ns |   0.4949 ns | 0.0515 |     432 B |
| ReflectionNoArdalisCheck_Null_Throw | 15,871.159 ns | 130.4055 ns | 121.9814 ns | 0.0610 |     760 B |
| ReflectionNoArdalisCheck_NotNull    |    757.090 ns |   3.6914 ns |   3.2723 ns | 0.0525 |     440 B |
#### .NET SDK 6.0.428
| Method                              | Mean          | Error       | StdDev      | Gen0   | Allocated |
|------------------------------------ |--------------:|------------:|------------:|-------:|----------:|
| IfCheck_Null_Throw                  | 14,255.450 ns | 123.2886 ns |  96.2556 ns | 0.1678 |     352 B |
| IfCheck_NotNull                     |      1.663 ns |   0.0159 ns |   0.0148 ns |      - |         - |
| ArdalisCheck_Null_Throw             | 15,005.158 ns | 105.9116 ns |  93.8878 ns | 0.2594 |     568 B |
| ArdalisCheck_NotNull                |      3.134 ns |   0.0127 ns |   0.0113 ns |      - |         - |
| ReflectionArdalisCheck_Null_Throw   | 23,279.372 ns | 427.7940 ns | 400.1587 ns | 0.4883 |    1081 B |
| ReflectionArdalisCheck_NotNull      |  1,169.067 ns |   6.4855 ns |   5.0634 ns | 0.2060 |     432 B |
| ReflectionNoArdalisCheck_Null_Throw | 15,873.085 ns |  77.2478 ns |  68.4781 ns | 0.3357 |     761 B |
| ReflectionNoArdalisCheck_NotNull    |  1,159.678 ns |   7.8347 ns |   7.3286 ns | 0.2098 |     440 B |

---

---

## Big O Notation & Observations

- **Parameter Checking** generally operates in **O(1)** time—there’s only a single parameter.  
- **Reflection** overhead can add a constant factor that is *significantly larger* than a direct function call.  
- **Exception Throwing** is also expensive. In real code, you likely measure mostly the *non-exception* path because you expect valid parameters most of the time.

---


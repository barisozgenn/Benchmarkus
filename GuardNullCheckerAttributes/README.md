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

#### .NET SDK 10.0.0

| **Method**                     | **ArraySize** | **Mean**             | **Error**           | **StdDev**          | **Gen0**    | **Allocated** |
|--------------------------- |---------- |-----------------:|----------------:|----------------:|--------:|----------:|
It will be added when .Net 10 is available.
#### .NET SDK 9.0.101

#### .NET SDK 8.0.404

#### .NET SDK 7.0.410

#### .NET SDK 6.0.428

---

---

## Big O Notation & Observations

- **Parameter Checking** generally operates in **O(1)** time—there’s only a single parameter.  
- **Reflection** overhead can add a constant factor that is *significantly larger* than a direct function call.  
- **Exception Throwing** is also expensive. In real code, you likely measure mostly the *non-exception* path because you expect valid parameters most of the time.

---


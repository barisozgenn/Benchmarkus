# ModelMapping

This project is part of the **Benchmarkus** repository, showcasing a comparison between **AutoMapper** and **manual mapping** techniques in **.NET**. It utilizes [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) to measure and compare the performance of these two object-object mapping methods across different **.NET SDK** versions.

## Why We Do It

- **Performance Insights**: Object mapping is a common task in many applications. Understanding the performance implications of using a library like AutoMapper versus manual mapping helps in making informed decisions for performance-critical applications.
  
- **Practical Learning**: By benchmarking real implementations, we gain hands-on experience with how different mapping strategies behave under various conditions and data sizes.
  
- **Code Quality**: Both mapping strategies require thoughtful implementation. Benchmarking encourages writing clean, efficient, and maintainable code, beneficial for both manual and automated mapping approaches.

## What We Can Learn

- **Time Complexity & Memory Usage**: By running these benchmarks, we observe how each mapping method scales with the number of objects and nested properties.
  
- **Library Overhead vs. Custom Optimization**: AutoMapper offers convenience and reduces boilerplate code but may introduce additional overhead compared to finely-tuned manual mapping.

---

### Purpose & Motivation

- **Compare Mapping Strategies**: The goal is to evaluate the performance differences between using AutoMapper and manual mapping methods, considering factors like execution time and memory allocation.
  
- **Assess Scalability**: Understanding how each approach scales with larger datasets and more complex object graphs informs best practices for large-scale applications.
  
- **Provide Practical Guidance**: Offering insights into when to prefer one mapping strategy over the other based on empirical data helps developers make better architectural choices.

### Key Focus Areas

1. **Different .NET SDK Versions**: Benchmarks are conducted across multiple .NET SDK versions (6, 7, 8, 9) to understand how updates and optimizations in the .NET runtime impact mapping performance.
  
2. **Data Complexity**: Evaluating mapping performance with varying object complexities and sizes to simulate real-world scenarios.

### Goals

- **Informed Decision-Making**: Empower developers to choose the most suitable mapping strategy based on performance metrics and application requirements.
  
- **Optimize Application Performance**: Identify potential bottlenecks in object mapping to enhance overall application efficiency.
  
- **Encourage Best Practices**: Promote the adoption of efficient coding patterns and the judicious use of libraries like AutoMapper.

---

### Benchmark Results

#### Benchmark Results Across .NET Versions

Below are the benchmark results for **AutoMapper** vs. **Manual Mapping** across different .NET SDK versions. Each benchmark measures the time taken (`Mean`), error margins, standard deviation (`StdDev`), memory allocations (`Allocated`), and garbage collection statistics (`Gen0`, `Gen1`, `Gen2`).

##### .NET SDK 6.0.428

| **Method**            | **Mean**    | **Error**   | **StdDev**  | **Ratio** | **Gen0**    | **Gen1** | **Gen2** | **Allocated** | **Alloc Ratio** |
|----------------------|------------:|------------:|------------:|----------:|------------:|---------:|---------:|--------------:|----------------:|
| ManualMapping        |  9.748 ms   | 0.0237 ms   | 0.0198 ms   |  0.23     | 2281.2500   |  765.6250 | 156.2500 |     6.87 MB    |           0.28   |
| AutoMapperMapping    | 41.604 ms   | 0.8167 ms   | 1.7047 ms   |  1.00     | 5384.6154   | 2230.7692 | 538.4615 |    24.41 MB    |           1.00   |

##### .NET SDK 7.0.410

| **Method**            | **Mean**    | **Error**   | **StdDev**  | **Ratio** | **Gen0**    | **Gen1** | **Gen2** | **Allocated** | **Alloc Ratio** |
|----------------------|------------:|------------:|------------:|----------:|------------:|---------:|---------:|--------------:|----------------:|
| ManualMapping        |  9.127 ms   | 0.0316 ms   | 0.0295 ms   |  0.23     |  875.0000   |  515.6250 | 125.0000 |     6.87 MB    |           0.28   |
| AutoMapperMapping    | 40.104 ms   | 0.3463 ms   | 0.3239 ms   |  1.00     | 3384.6154   | 1923.0769 | 461.5385 |    24.42 MB    |           1.00   |

##### .NET SDK 8.0.404

| **Method**            | **Mean**    | **Error**   | **StdDev**  | **Ratio** | **Gen0**    | **Gen1** | **Gen2** | **Allocated** | **Alloc Ratio** |
|----------------------|------------:|------------:|------------:|----------:|------------:|---------:|---------:|--------------:|----------------:|
| ManualMapping        | 11.65 ms    | 0.133 ms    | 0.125 ms    |  0.23     |  890.6250   |  531.2500 | 265.6250 |     6.87 MB    |           0.28   |
| AutoMapperMapping    | 51.38 ms    | 0.272 ms    | 0.254 ms    |  1.00     | 3333.3333   | 1888.8889 | 888.8889 |    24.41 MB    |           1.00   |

##### .NET SDK 9.0.101

| **Method**            | **Mean**    | **Error**   | **StdDev**  | **Ratio** | **Gen0**    | **Gen1** | **Gen2** | **Allocated** | **Alloc Ratio** |
|----------------------|------------:|------------:|------------:|----------:|------------:|---------:|---------:|--------------:|----------------:|
| ManualMapping        |  8.894 ms   | 0.0306 ms   | 0.0286 ms   |  0.22     |  875.0000   |  515.6250 | 125.0000 |     6.87 MB    |           0.28   |
| AutoMapperMapping    | 40.664 ms   | 0.4353 ms   | 0.4071 ms   |  1.00     | 3333.3333   | 1833.3333 | 416.6667 |    24.41 MB    |           1.00   |

##### .NET SDK 10.0.100-preview.1.25120.13
| Method            | Mean     | Error    | StdDev   | Ratio | Gen0      | Gen1      | Gen2     | Allocated | Alloc Ratio |
|------------------ |---------:|---------:|---------:|------:|----------:|----------:|---------:|----------:|------------:|
| ManualMapping     | 14.75 ms | 0.077 ms | 0.068 ms |  0.32 | 1250.0000 |  531.2500 | 125.0000 |   9.92 MB |        0.36 |
| AutoMapperMapping | 45.63 ms | 0.169 ms | 0.158 ms |  1.00 | 3727.2727 | 2090.9091 | 454.5455 |  27.47 MB |        1.00 |

---

### Key Observations

- **Performance Overhead**: Manual mapping consistently outperforms AutoMapper across all .NET SDK versions, exhibiting significantly lower execution times and memory allocations.
  
- **Memory Consumption**: AutoMapper incurs higher memory usage compared to manual mapping, which could impact performance in memory-constrained environments.
  
- **Scalability**: As the number of objects increases, the performance gap between manual mapping and AutoMapper widens, highlighting the scalability benefits of manual mapping.

---

## Big O Notation Complexity

While object mapping doesn't strictly adhere to traditional sorting algorithm complexities, understanding the underlying principles can provide insights into performance behaviors.

| **Mapping Method** | **Time Complexity** | **Space Complexity** |
|--------------------|---------------------|----------------------|
| **Manual Mapping** | O(n)                | O(1)                 |
| **AutoMapper**     | O(n)                | O(n)                 |

- **Manual Mapping**:
  - **Time Complexity**: Linear (O(n)) as each property is individually assigned.
  - **Space Complexity**: Constant (O(1)) since no additional memory is allocated beyond the target objects.
  
- **AutoMapper**:
  - **Time Complexity**: Linear (O(n)) for straightforward mappings but can incur additional overhead for complex configurations.
  - **Space Complexity**: Linear (O(n)) due to the use of reflection and potential intermediate data structures during mapping.

---

### Conclusion

This professional **BenchmarkDotNet** project provides a clear comparison between **AutoMapper** and manual mapping approaches in .NET, using custom `Person`, `PersonDto`, and `Address` classes. By running and analyzing these benchmarks, you can make informed decisions about which mapping strategy best suits your application's performance and maintainability requirements.

**Key Takeaways**:

- **AutoMapper** offers ease of use and reduces repetitive code but may introduce performance overhead.
  
- **Manual Mapping** can be optimized for performance and memory usage but requires more boilerplate code.
  
- **BenchmarkDotNet** is a powerful tool to measure and compare the performance of different implementations accurately.

---

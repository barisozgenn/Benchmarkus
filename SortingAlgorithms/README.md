# SortingAlgorithms

This project is part of the **Benchmarkus** repository, showcasing various **array sorting algorithms** in **.NET**. It uses [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) to measure and compare the performance of different sorting methods (e.g., **QuickSort**, **MergeSort**, etc.) on **int**, **string**, and **complex** data types.

## Why We Do It

- **Performance Insights**: Sorting is a fundamental operation. Understanding the time/space complexities helps you select the right algorithm for your scenario.  
- **Practical Learning**: By benchmarking real implementations, you gain a hands-on appreciation for how data size and distribution affect each algorithm.  
- **Code Quality**: We include XML documentation and recommended patterns for professional and maintainable code—helpful for static analysis (e.g., Sonar).

## What We Can Learn

- **Time Complexity & Space Complexity**: By running these benchmarks, we’ll observe how each algorithm scales with **n** (the input size).  
- **Algorithmic Trade-offs**: Some algorithms (like **MergeSort**) have better worst-case performance but require more space, while others (like **QuickSort**) can be very fast on average but degrade to O(n^2) in the worst case.  

---

### Purpose & Motivation

- **Investigate Alternatives**: We aim to compare different sorting algorithms, including built-in .NET sort methods (like Timsort) and our custom implementations (like QuickSort or MergeSort), to see how they perform under various conditions.  
- **Assess Performance Impact**: By measuring real-world runtimes, memory usage, and other metrics, we can better understand each algorithm’s trade-offs.  
- **Offer Practical Insights**: We provide practical guidance on how each algorithm handles different data sizes and data distributions (including random, sorted, or partially sorted arrays).

### Key Focus Areas

1. **Realistic Scenarios**: We test multiple data types (ints, strings, complex/transaction objects) to mimic common real-world use cases.  

### Goals

- **Better Decision-Making**: Help developers choose the most suitable sorting method for their scenarios by providing actual performance data and analysis.  
- **Demystifying Complexity**: Present easy-to-understand charts and tables illustrating how each algorithm’s complexity scales with input size.  
- **Contributions & Evolution**: Invite the community to expand the range of benchmarks, integrate new techniques, or refine existing tests as the .NET ecosystem evolves.

---

### Benchmark Results

*(Add or update your benchmark result tables here if you want to illustrate a sample run.)*

### Benchmark Results Across .NET Versions

Below are sample benchmark tables for different .NET versions, using `IterationCount=20` and `WarmupCount=5`. Actual results may vary based on hardware and OS.

#### .NET SDK 9.0.101

| **Method**   | **Mean**  | **Error**  | **StdDev** | **Median** | **Gen0** | **Gen1** | **Gen2** | **Allocated** |
|--------------|----------:|-----------:|-----------:|-----------:|---------:|---------:|---------:|-------------:|
| *(example)*  |  12.34 ms |  0.12 ms   |  0.20 ms   |  12.30 ms  |    1     |    0     |    0     |      5 KB    |

#### .NET SDK 8.0.11 (8.0.1124.51707)

| **Method**   | **Mean**  | **Error**  | **StdDev** | **Median** | **Gen0** | **Gen1** | **Gen2** | **Allocated** |
|--------------|----------:|-----------:|-----------:|-----------:|---------:|---------:|---------:|-------------:|
| *(example)*  |  15.01 ms |  0.10 ms   |  0.18 ms   |  14.95 ms  |    1     |    0     |    0     |      5 KB    |

#### .NET SDK 6.0.36 (6.0.3624.51421)

| **Method**   | **Mean**  | **Error**  | **StdDev** | **Gen0** | **Gen1** | **Gen2** | **Allocated** |
|--------------|----------:|-----------:|-----------:|---------:|---------:|---------:|-------------:|
| *(example)*  |  18.60 ms |  0.14 ms   |  0.22 ms   |    2     |    0     |    0     |      6 KB    |

---

### Key Observations

- As **input size** grows, algorithms with higher time complexity (like **Bubble Sort**) slow down drastically compared to **n log(n)** solutions (**QuickSort**, **MergeSort**, **HeapSort**, etc.).  
- Built-in .NET sort methods typically utilize **Timsort** for arrays (especially for reference types), which often outperforms naive custom implementations on random data.  
- Memory usage can be a factor for algorithms like **MergeSort** due to additional arrays, whereas **QuickSort** might allocate less but risks worst-case scenarios.

---

## Big O Notation Complexity

Below is a summary table of **time** and **space** complexities for commonly known sorting algorithms:

| Algorithm         | Best         | Average            | Worst              | Space      |
|-------------------|-------------:|--------------------:|-------------------:|-----------:|
| **Quicksort**     | O(n log(n))  | O(n log(n))        | O(n^2)             | O(log(n))  |
| **Mergesort**     | O(n log(n))  | O(n log(n))        | O(n log(n))        | O(n)       |
| **Timsort**       | O(n)         | O(n log(n))        | O(n log(n))        | O(n)       |
| **Heapsort**      | O(n log(n))  | O(n log(n))        | O(n log(n))        | O(1)       |
| **Bubble Sort**   | O(n)         | O(n^2)             | O(n^2)             | O(1)       |
| **Insertion Sort**| O(n)         | O(n^2)             | O(n^2)             | O(1)       |
| **Selection Sort**| O(n^2)       | O(n^2)             | O(n^2)             | O(1)       |
| **Tree Sort**     | O(n log(n))  | O(n log(n))        | O(n^2)             | O(n)       |
| **Shell Sort**    | O(n log(n))  | O(n(log(n))^2 )    | O(n(log(n))^2)     | O(1)       |
| **Bucket Sort**   | O(n + k)     | O(n + k)           | O(n^2)             | O(n)       |
| **Radix Sort**    | O(nk)        | O(nk)              | O(nk)              | O(n + k)   |
| **Counting Sort** | O(n + k)     | O(n + k)           | O(n + k)           | O(k)       |
| **Cubesort**      | O(n)         | O(n log(n))        | O(n log(n))        | O(n)       |

- **n**: Number of elements  
- **k**: Range of input values (applicable to Counting Sort, Radix Sort, Bucket Sort, etc.)

---


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

#### .NET SDK 8.0.404

| **Method**   | **Mean**  | **Error**  | **StdDev** | **Median** | **Gen0** | **Gen1** | **Gen2** | **Allocated** |
|--------------|----------:|-----------:|-----------:|-----------:|---------:|---------:|---------:|-------------:|
| *(example)*  |  15.01 ms |  0.10 ms   |  0.18 ms   |  14.95 ms  |    1     |    0     |    0     |      5 KB    |

#### .NET SDK 7.0.410

| **Method**   | **Mean**  | **Error**  | **StdDev** | **Median** | **Gen0** | **Gen1** | **Gen2** | **Allocated** |
|--------------|----------:|-----------:|-----------:|-----------:|---------:|---------:|---------:|-------------:|
| *(example)*  |  15.01 ms |  0.10 ms   |  0.18 ms   |  14.95 ms  |    1     |    0     |    0     |      5 KB    |

#### .NET SDK 6.0.428

| **Method**                     | **ArraySize** | **Mean**             | **Error**           | **StdDev**          | **Gen0**     | **Allocated** |
|--------------------------- |---------- |-----------------:|----------------:|----------------:|---------:|----------:|
| Int_QuickSort              | 100       |       1,923.4 ns |         7.32 ns |         6.11 ns |   0.2327 |     488 B |
| Int_MergeSort              | 100       |       4,086.3 ns |         7.10 ns |         5.93 ns |   4.0665 |    8488 B |
| Int_TimSort                | 100       |         495.9 ns |         0.96 ns |         0.89 ns |   0.2012 |     424 B |
| Int_HeapSort               | 100       |       3,364.9 ns |         8.70 ns |         7.26 ns |   0.2327 |     488 B |
| Int_BubbleSort             | 100       |      13,837.6 ns |        55.08 ns |        51.52 ns |   0.2289 |     488 B |
| String_QuickSort           | 100       |       5,375.1 ns |         9.97 ns |         8.33 ns |   0.4196 |     888 B |
| String_MergeSort           | 100       |       8,734.9 ns |        41.81 ns |        37.06 ns |   5.2643 |   11016 B |
| String_TimSort             | 100       |       4,303.0 ns |         9.31 ns |         8.25 ns |   0.4196 |     888 B |
| String_HeapSort            | 100       |      10,314.0 ns |        84.52 ns |        74.92 ns |   0.4120 |     888 B |
| String_BubbleSort          | 100       |      45,911.2 ns |       611.71 ns |       542.26 ns |   0.3662 |     888 B |
| Complex_QuickSortByAmount  | 100       |       6,609.5 ns |        14.98 ns |        12.51 ns |   0.3891 |     824 B |
| Complex_MergeSortByAmount  | 100       |       8,473.9 ns |        26.16 ns |        21.85 ns |   5.2338 |   10952 B |
| Complex_TimSortByAmount    | 100       |       3,929.5 ns |         5.61 ns |         4.69 ns |   0.3891 |     824 B |
| Complex_HeapSortByAmount   | 100       |      11,160.0 ns |        38.34 ns |        32.02 ns |   0.3815 |     824 B |
| Complex_BubbleSortByAmount | 100       |      39,281.5 ns |        87.54 ns |        77.60 ns |   0.3662 |     824 B |
| Int_QuickSort              | 5000      |     322,190.7 ns |       880.94 ns |       735.62 ns |   9.2773 |   20089 B |
| Int_MergeSort              | 5000      |     424,927.7 ns |       442.48 ns |       345.46 ns | 256.3477 |  536073 B |
| Int_TimSort                | 5000      |     125,792.2 ns |     2,493.86 ns |     3,153.93 ns |   9.5215 |   20024 B |
| Int_HeapSort               | 5000      |     503,917.0 ns |     1,049.07 ns |       981.30 ns |   8.7891 |   20089 B |
| Int_BubbleSort             | 5000      |  38,862,392.9 ns |    56,970.10 ns |    44,478.50 ns |        - |   20163 B |
| String_QuickSort           | 5000      |   1,196,630.3 ns |       805.54 ns |       714.09 ns |  17.5781 |   40090 B |
| String_MergeSort           | 5000      |   1,305,556.3 ns |     1,013.47 ns |       791.25 ns | 369.1406 |  774506 B |
| String_TimSort             | 5000      |   1,093,027.4 ns |     2,701.18 ns |     2,255.60 ns |  17.5781 |   40091 B |
| String_HeapSort            | 5000      |   1,979,769.9 ns |     1,899.33 ns |     1,586.03 ns |  15.6250 |   40093 B |
| String_BubbleSort          | 5000      | 213,558,017.4 ns |   595,645.32 ns |   465,040.69 ns |        - |   41955 B |
| Complex_QuickSortByAmount  | 5000      |     811,887.8 ns |       969.80 ns |       859.70 ns |  18.5547 |   40025 B |
| Complex_MergeSortByAmount  | 5000      |     901,479.3 ns |       887.45 ns |       786.70 ns | 370.1172 |  774441 B |
| Complex_TimSortByAmount    | 5000      |     590,931.2 ns |       410.42 ns |       342.72 ns |  18.5547 |   40025 B |
| Complex_HeapSortByAmount   | 5000      |   1,322,743.8 ns |     2,865.87 ns |     2,237.48 ns |  17.5781 |   40026 B |
| Complex_BubbleSortByAmount | 5000      | 133,717,636.2 ns | 2,152,218.78 ns | 1,797,200.16 ns |        - |   41390 B |
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


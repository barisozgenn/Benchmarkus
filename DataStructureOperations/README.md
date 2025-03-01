# DataStructureOperations

This project is part of the **Benchmarkus** repository and is dedicated to benchmarking and comparing the performance of various **Common Data Structures** in **.NET**. Utilizing [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet), this project evaluates the efficiency of operations such as **Add**, **Get**, **Remove**, and **Find** across different data structures using **int**, **string**, and a complex **Person** class.

## Why We Do It

- **Performance Evaluation**: Understanding the performance characteristics of different data structures is crucial for selecting the most appropriate one for specific application requirements.
  
- **Educational Insight**: Provides hands-on experience with how various data structures behave under common operations, reinforcing theoretical Big O concepts.
  
- **Optimization Guidance**: Identifies potential bottlenecks and areas where certain data structures may outperform others, aiding in optimizing application performance.

## What We Can Learn

- **Operational Efficiency**: Gain insights into how different data structures handle fundamental operations and how they scale with increasing data sizes.
  
- **Big O Validation**: Empirically verify the theoretical time and space complexities of various data structures through practical benchmarks.
  
- **Use-Case Suitability**: Determine which data structures are best suited for specific scenarios based on their performance profiles.

---

### Purpose & Motivation

- **Benchmark Common Data Structures**: Evaluate the performance of standard and advanced data structures in .NET to understand their strengths and weaknesses.
  
- **Validate Big O Notation**: Compare empirical results with theoretical Big O complexities to reinforce understanding of algorithmic efficiencies.
  
- **Provide Developer Insights**: Offer actionable data to help developers make informed decisions when choosing data structures for their applications.

### Key Focus Areas

1. **Data Structures Evaluated**:
    - Array
    - Stack
    - Queue
    - Singly-Linked List
    - Doubly-Linked List
    - Skip List
    - Hash Table
    - Binary Search Tree
    - Cartesian Tree
    - B-Tree
    - Red-Black Tree
    - Splay Tree
    - AVL Tree
    - KD Tree

2. **Operations Benchmarked**:
    - Add
    - Get
    - Remove
    - Find

3. **Data Types Tested**:
    - `int`
    - `string`
    - `Person` (a complex class with nested properties)

### Goals

- **Empirical Validation**: Confirm the theoretical time and space complexities of various data structures through benchmarking.
  
- **Performance Comparison**: Identify which data structures offer the best performance for specific operations and data types.
  
- **Educational Resource**: Serve as a learning tool for developers to understand the practical implications of choosing different data structures.

---

### Benchmark Results Across .NET Versions

Below are the benchmark tables for different .NET SDK versions. Each table compares the performance of **Add**, **Get**, **Remove**, and **Find** operations across various data structures using `int`, `string`, and `Person` classes. The benchmarks were conducted with `IterationCount=5` and `WarmupCount=5`. Actual results may vary based on hardware and OS.

#### .NET SDK 6.0.428

**IterationCount=5  WarmupCount=5**

| Method                   | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------- |---------:|----------:|----------:|-------:|----------:|
| Array_Add_Int            | 44.52 us |  4.870 us |  1.265 us | 0.3052 |     640 B |
| Array_Get_Int            | 44.83 us |  1.001 us |  0.155 us | 0.3052 |     640 B |
| Stack_Get_Person         | 44.84 us |  4.984 us |  0.771 us | 0.1221 |     368 B |
| Queue_Get_String         | 46.84 us |  2.569 us |  0.398 us | 0.1221 |     376 B |
| Stack_Add_Person         | 47.79 us | 12.408 us |  3.222 us |      - |    2769 B |
| HashTable_Find_Int       | 48.46 us |  2.778 us |  0.430 us | 0.3662 |     800 B |
| LinkedList_Remove_String | 50.37 us | 27.727 us |  4.291 us |      - |     572 B |
| Queue_Add_String         | 51.86 us | 37.761 us |  9.807 us |      - |    3252 B |
| Queue_Remove_Person      | 52.45 us | 66.615 us | 10.309 us |      - |     380 B |
| HashTable_Find_String    | 53.28 us |  4.746 us |  1.233 us | 0.6104 |    1360 B |
| HashTable_Find_Person    | 54.72 us |  7.964 us |  1.232 us | 0.4272 |     960 B |
| Stack_Remove_Int         | 57.66 us | 59.300 us | 15.400 us |      - |     260 B |

#### .NET SDK 7.0.410

**IterationCount=5  WarmupCount=5**

| Method                   | Mean      | Error      | StdDev    | Gen0   | Gen1   | Allocated |
|------------------------- |----------:|-----------:|----------:|-------:|-------:|----------:|
| Stack_Get_Person         |  41.94 us |   0.648 us |  0.168 us |      - |      - |     368 B |
| Stack_Remove_Int         |  42.10 us |  24.430 us |  3.781 us |      - |      - |     260 B |
| Array_Add_Int            |  44.22 us |  11.999 us |  3.116 us | 0.0610 |      - |     640 B |
| Array_Get_Int            |  44.36 us |  10.864 us |  2.821 us | 0.0610 |      - |     640 B |
| Stack_Add_Person         |  44.42 us |   5.105 us |  1.326 us | 0.0610 |      - |    2768 B |
| HashTable_Find_Int       |  48.75 us |   9.399 us |  2.441 us | 0.0610 |      - |     800 B |
| Queue_Add_String         |  48.79 us |   6.658 us |  1.729 us | 0.1221 | 0.0610 |    3248 B |
| LinkedList_Remove_String |  50.84 us |   6.680 us |  1.735 us | 0.0610 |      - |     568 B |
| HashTable_Find_String    |  60.38 us |  13.712 us |  3.561 us | 0.1221 |      - |    1360 B |
| HashTable_Find_Person    |  66.55 us |  10.238 us |  2.659 us |      - |      - |     960 B |
| Queue_Get_String         |  78.06 us |  74.990 us | 19.475 us |      - |      - |     380 B |
| Queue_Remove_Person      | 108.22 us | 176.129 us | 45.740 us |      - |      - |     380 B |

#### .NET SDK 8.0.404

**IterationCount=5  WarmupCount=5**

| Method                   | Mean     | Error     | StdDev   | Gen0   | Allocated |
|------------------------- |---------:|----------:|---------:|-------:|----------:|
| Stack_Get_Person         | 38.87 us |  4.374 us | 1.136 us |      - |     368 B |
| Array_Get_Int            | 40.03 us |  3.320 us | 0.862 us | 0.0610 |     640 B |
| Array_Add_Int            | 41.06 us |  2.947 us | 0.765 us | 0.0610 |     640 B |
| Stack_Add_Person         | 41.29 us |  8.839 us | 1.368 us | 0.0610 |    2768 B |
| Stack_Remove_Int         | 41.62 us |  1.198 us | 0.185 us |      - |     256 B |
| Queue_Get_String         | 41.68 us |  4.434 us | 1.152 us |      - |     376 B |
| Queue_Remove_Person      | 41.93 us |  1.690 us | 0.439 us |      - |     376 B |
| HashTable_Find_Int       | 43.97 us | 10.916 us | 1.689 us | 0.0610 |     800 B |
| LinkedList_Remove_String | 46.13 us | 11.340 us | 1.755 us | 0.0610 |     568 B |
| HashTable_Find_String    | 52.36 us |  5.246 us | 0.812 us | 0.1221 |    1360 B |
| Queue_Add_String         | 52.43 us | 17.779 us | 4.617 us |      - |    3256 B |
| HashTable_Find_Person    | 60.51 us | 10.624 us | 2.759 us |      - |     960 B |

#### .NET SDK 9.0.101

**IterationCount=5  WarmupCount=5**

| Method                   | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------- |---------:|----------:|----------:|-------:|----------:|
| Stack_Get_Person         | 38.32 us |  4.721 us |  0.731 us |      - |     368 B |
| Array_Get_Int            | 39.13 us |  3.864 us |  1.003 us | 0.0610 |     640 B |
| Array_Add_Int            | 40.05 us |  3.429 us |  0.891 us | 0.0610 |     640 B |
| Stack_Add_Person         | 41.08 us |  4.955 us |  1.287 us | 0.0610 |    2768 B |
| Stack_Remove_Int         | 41.11 us |  3.176 us |  0.825 us |      - |     256 B |
| Queue_Get_String         | 41.11 us |  3.160 us |  0.489 us |      - |     376 B |
| HashTable_Find_Int       | 42.75 us |  4.220 us |  1.096 us | 0.0610 |     800 B |
| HashTable_Find_Person    | 42.76 us | 16.332 us |  2.527 us |      - |     963 B |
| Queue_Remove_Person      | 44.55 us |  3.785 us |  0.983 us |      - |     376 B |
| LinkedList_Remove_String | 50.66 us |  9.532 us |  2.475 us | 0.0610 |     568 B |
| HashTable_Find_String    | 58.63 us |  9.270 us |  1.435 us | 0.1221 |    1360 B |
| Queue_Add_String         | 60.33 us | 72.221 us | 11.176 us |      - |    3490 B |

#### .NET SDK 10.0.100-preview.1.25120.13

**IterationCount=5  WarmupCount=5**
| Method                   | Mean     | Error     | StdDev   | Gen0   | Gen1   | Allocated |
|------------------------- |---------:|----------:|---------:|-------:|-------:|----------:|
| Stack_Get_Person         | 36.84 us |  2.495 us | 0.648 us |      - |      - |     368 B |
| Array_Get_Int            | 37.20 us |  2.581 us | 0.670 us | 0.0610 |      - |     640 B |
| Array_Add_Int            | 38.08 us |  1.325 us | 0.344 us | 0.0610 |      - |     640 B |
| Stack_Add_Person         | 38.09 us |  2.461 us | 0.639 us | 0.0610 |      - |    2768 B |
| Stack_Remove_Int         | 39.18 us |  2.728 us | 0.709 us |      - |      - |     256 B |
| Queue_Get_String         | 40.46 us |  5.795 us | 1.505 us |      - |      - |     376 B |
| Queue_Add_String         | 41.85 us |  4.822 us | 0.746 us | 0.1221 | 0.0610 |    3248 B |
| Queue_Remove_Person      | 42.38 us | 22.717 us | 5.900 us |      - |      - |     378 B |
| HashTable_Find_Int       | 54.76 us | 28.881 us | 4.469 us |      - |      - |     803 B |
| HashTable_Find_Person    | 58.26 us |  6.678 us | 1.734 us | 0.0610 |      - |     960 B |
| HashTable_Find_String    | 59.25 us |  9.066 us | 2.354 us | 0.1221 |      - |    1360 B |
| LinkedList_Remove_String | 65.99 us | 57.281 us | 8.864 us |      - |      - |     569 B |

---

### Big O Notation Complexity

Understanding the underlying complexity provides insights into the performance behaviors observed in the benchmarks.

| **Data Structure**         | **Operation** | **Time Complexity (Average)** | **Time Complexity (Worst)** | **Space Complexity** |
|----------------------------|---------------|-------------------------------|-----------------------------|----------------------|
| **Array**                  | Add           | O(1)                          | O(n)                        | O(n)                 |
|                            | Get           | O(1)                          | O(1)                        |                      |
|                            | Remove        | O(n)                          | O(n)                        |                      |
|                            | Find          | O(n)                          | O(n)                        |                      |
| **Stack**                  | Add           | O(1)                          | O(1)                        | O(n)                 |
|                            | Get           | O(1)                          | O(1)                        |                      |
|                            | Remove        | O(1)                          | O(1)                        |                      |
|                            | Find          | O(n)                          | O(n)                        |                      |
| **Queue**                  | Add           | O(1)                          | O(1)                        | O(n)                 |
|                            | Get           | O(1)                          | O(1)                        |                      |
|                            | Remove        | O(1)                          | O(1)                        |                      |
|                            | Find          | O(n)                          | O(n)                        |                      |
| **Singly-Linked List**     | Add           | O(1)                          | O(1)                        | O(n)                 |
|                            | Get           | O(n)                          | O(n)                        |                      |
|                            | Remove        | O(n)                          | O(n)                        |                      |
|                            | Find          | O(n)                          | O(n)                        |                      |
| **Doubly-Linked List**     | Add           | O(1)                          | O(1)                        | O(n)                 |
|                            | Get           | O(n)                          | O(n)                        |                      |
|                            | Remove        | O(1)                          | O(n)                        |                      |
|                            | Find          | O(n)                          | O(n)                        |                      |
| **Skip List**              | Add           | O(log(n))                     | O(n)                        | O(n)                 |
|                            | Get           | O(log(n))                     | O(n)                        |                      |
|                            | Remove        | O(log(n))                     | O(n)                        |                      |
|                            | Find          | O(log(n))                     | O(n)                        |                      |
| **Hash Table**             | Add           | O(1)                          | O(n)                        | O(n)                 |
|                            | Get           | O(1)                          | O(n)                        |                      |
|                            | Remove        | O(1)                          | O(n)                        |                      |
|                            | Find          | O(1)                          | O(n)                        |                      |
| **Binary Search Tree**     | Add           | O(log(n))                     | O(n)                        | O(n)                 |
|                            | Get           | O(log(n))                     | O(n)                        |                      |
|                            | Remove        | O(log(n))                     | O(n)                        |                      |
|                            | Find          | O(log(n))                     | O(n)                        |                      |
| **Cartesian Tree**         | Add           | O(log(n))                     | O(n)                        | O(n)                 |
|                            | Get           | O(log(n))                     | O(n)                        |                      |
|                            | Remove        | O(log(n))                     | O(n)                        |                      |
|                            | Find          | O(log(n))                     | O(n)                        |                      |
| **B-Tree**                 | Add           | O(log(n))                     | O(log(n))                   | O(n)                 |
|                            | Get           | O(log(n))                     | O(log(n))                   |                      |
|                            | Remove        | O(log(n))                     | O(log(n))                   |                      |
|                            | Find          | O(log(n))                     | O(log(n))                   |                      |
| **Red-Black Tree**         | Add           | O(log(n))                     | O(log(n))                   | O(n)                 |
|                            | Get           | O(log(n))                     | O(log(n))                   |                      |
|                            | Remove        | O(log(n))                     | O(log(n))                   |                      |
|                            | Find          | O(log(n))                     | O(log(n))                   |                      |
| **Splay Tree**             | Add           | Amortized O(log(n))           | O(n)                        | O(n)                 |
|                            | Get           | Amortized O(log(n))           | O(n)                        |                      |
|                            | Remove        | Amortized O(log(n))           | O(n)                        |                      |
|                            | Find          | Amortized O(log(n))           | O(n)                        |                      |
| **AVL Tree**               | Add           | O(log(n))                     | O(log(n))                   | O(n)                 |
|                            | Get           | O(log(n))                     | O(log(n))                   |                      |
|                            | Remove        | O(log(n))                     | O(log(n))                   |                      |
|                            | Find          | O(log(n))                     | O(log(n))                   |                      |
| **KD Tree**                | Add           | O(log(n))                     | O(n)                        | O(n)                 |
|                            | Get           | O(log(n))                     | O(n)                        |                      |
|                            | Remove        | O(log(n))                     | O(n)                        |                      |
|                            | Find          | O(log(n))                     | O(n)                        |                      |

---

## Conclusion

This **BenchmarkDotNet** project provides a comprehensive comparison of various **Common Data Structures** in .NET, focusing on fundamental operations like **Add**, **Get**, **Remove**, and **Find** across different data types (`int`, `string`, and `Person`). By analyzing these benchmarks, developers can make informed decisions about which data structures best suit their application's performance and scalability requirements.

**Key Takeaways**:

- **Operational Trade-offs**: Different data structures offer varying efficiencies for specific operations. For instance, arrays provide O(1) access time but suffer from O(n) removal time, whereas linked lists offer O(1) insertion and removal but have O(n) access time.
  
- **Complex Structures**: Advanced data structures like **Red-Black Trees**, **AVL Trees**, and **B-Trees** maintain balanced states to ensure O(log(n)) operations, making them suitable for scenarios requiring frequent searches and modifications.
  
- **Memory Consumption**: Some data structures may consume more memory to achieve better time complexities. It's essential to balance memory usage with performance needs based on application constraints.
  
- **BenchmarkDotNet Utility**: Leveraging **BenchmarkDotNet** allows for precise and reliable performance measurements, facilitating a deeper understanding of data structure behaviors in real-world applications.

---

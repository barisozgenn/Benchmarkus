# CollectionOperations

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
    - List
    - LinkedList
    - HashSet
    - Dictionary
    - ReadOnlyCollection
    - Span

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

|                             Method |        Mean |     Error |    StdDev |    Gen0 | Allocated |
|----------------------------------- |------------:|----------:|----------:|--------:|----------:|
|                Span_Find_FirstEven |    704.6 ns |   3.43 ns |   0.53 ns |  1.9226 |   3.93 KB |
|                    Span_Remove_Int |    727.4 ns |  64.40 ns |  16.72 ns |  1.9226 |   3.93 KB |
|               Array_Find_FirstEven |    759.1 ns |   9.49 ns |   1.47 ns |  1.9379 |   3.96 KB |
|                   Array_Remove_Int |    911.6 ns |  13.33 ns |   2.06 ns |  3.8452 |   7.86 KB |
|                      Array_Add_Int |    913.1 ns |  17.78 ns |   2.75 ns |  3.8452 |   7.87 KB |
|                       Span_Add_Int |    959.7 ns | 180.18 ns |  46.79 ns |  3.8452 |   7.87 KB |
|                      IList_Add_Int |  1,391.2 ns |  16.92 ns |   4.39 ns |  4.0264 |   8.23 KB |
|      ReadOnlyCollection_Remove_Int |  1,391.9 ns |  52.98 ns |  13.76 ns |  4.0379 |   8.25 KB |
|                   IList_Remove_Int |  1,393.0 ns |  35.97 ns |   5.57 ns |  4.0264 |   8.23 KB |
|                    List_Remove_Int |  1,395.3 ns |  42.65 ns |   6.60 ns |  4.0264 |   8.23 KB |
|                       List_Add_Int |  1,400.8 ns |  44.26 ns |  11.50 ns |  4.0264 |   8.23 KB |
|         ReadOnlyCollection_Add_Int |  1,405.7 ns |  15.94 ns |   4.14 ns |  4.0379 |   8.25 KB |
|               IList_Find_FirstEven |  1,413.9 ns |  36.27 ns |   5.61 ns |  4.0455 |   8.27 KB |
|          Enumerable_Find_FirstEven |  1,418.4 ns |  53.59 ns |  13.92 ns |  4.0455 |   8.27 KB |
|                List_Find_FirstEven |  1,419.8 ns |  29.73 ns |   7.72 ns |  4.0455 |   8.27 KB |
|  ReadOnlyCollection_Find_FirstEven |  1,431.6 ns |  51.34 ns |  13.33 ns |  4.0550 |   8.29 KB |
|                 Enumerable_Add_Int |  1,689.3 ns |  35.92 ns |   9.33 ns |  6.0139 |  12.28 KB |
|                 HashSet_Remove_Int |  9,458.6 ns | 396.55 ns |  61.37 ns | 27.9236 |  57.29 KB |
|                    HashSet_Add_Int |  9,462.6 ns |  47.99 ns |  12.46 ns | 27.9236 |  57.29 KB |
|                   HashSet_Find_Int |  9,608.2 ns | 969.66 ns | 150.06 ns | 27.9236 |  57.29 KB |
|                 LinkedList_Add_Int | 10,958.2 ns | 124.93 ns |  32.44 ns | 22.9950 |  46.96 KB |
|              LinkedList_Remove_Int | 11,037.1 ns | 349.09 ns |  54.02 ns | 22.9645 |  46.91 KB |
|          LinkedList_Find_FirstEven | 11,041.0 ns | 368.72 ns |  95.76 ns | 22.9950 |  46.96 KB |
|              Enumerable_Remove_Int | 11,383.8 ns | 171.53 ns |  44.55 ns |  8.1329 |  16.65 KB |
|          Dictionary_Remove_Key_Int | 38,259.1 ns | 439.62 ns | 114.17 ns | 66.6504 | 138.88 KB |
|   Dictionary_Find_Value_By_Key_Int | 38,315.4 ns | 466.48 ns | 121.14 ns | 66.6504 | 138.88 KB |
| Dictionary_Add_KeyValue_Int_String | 38,459.6 ns | 600.93 ns | 156.06 ns | 66.6504 | 138.92 KB |

#### .NET SDK 7.0.410

**IterationCount=5  WarmupCount=5**

|                             Method |        Mean |       Error |    StdDev |    Gen0 |   Gen1 | Allocated |
|----------------------------------- |------------:|------------:|----------:|--------:|-------:|----------:|
|                    Span_Remove_Int |    402.9 ns |    2.78 ns |  0.72 ns |  0.4807 |      - |   3.93 KB |
|                Span_Find_FirstEven |    404.9 ns |    1.92 ns |  0.50 ns |  0.4807 |      - |   3.93 KB |
|               Array_Find_FirstEven |    436.1 ns |    3.58 ns |  0.55 ns |  0.4845 |      - |   3.96 KB |
|                       Span_Add_Int |    568.2 ns |    1.55 ns |  0.40 ns |  0.9623 |      - |   7.87 KB |
|                      Array_Add_Int |    569.9 ns |    3.02 ns |  0.79 ns |  0.9623 |      - |   7.87 KB |
|                   Array_Remove_Int |    578.7 ns |    4.10 ns |  0.00 ns |  0.9613 |      - |   7.86 KB |
|                      IList_Add_Int |  1,014.0 ns |   31.06 ns |  8.07 ns |  1.0052 | 0.0019 |   8.23 KB |
|                   IList_Remove_Int |  1,014.4 ns |   26.05 ns |  6.76 ns |  1.0052 | 0.0019 |   8.23 KB |
|                    List_Remove_Int |  1,023.0 ns |   29.53 ns |  7.67 ns |  1.0052 | 0.0019 |   8.23 KB |
|                       List_Add_Int |  1,023.3 ns |   13.34 ns |  3.46 ns |  1.0052 | 0.0019 |   8.23 KB |
|         ReadOnlyCollection_Add_Int |  1,025.7 ns |   15.94 ns |  4.14 ns |  1.0090 | 0.0076 |   8.25 KB |
|      ReadOnlyCollection_Remove_Int |  1,024.7 ns |   11.88 ns |  3.09 ns |  1.0090 | 0.0076 |   8.25 KB |
|                List_Find_FirstEven |  1,025.1 ns |   15.66 ns |  2.42 ns |  1.0109 | 0.0038 |   8.27 KB |
|         ReadOnlyCollection_Add_Int |  1,025.4 ns |   14.84 ns |  2.30 ns |  1.0090 | 0.0076 |   8.25 KB |
|               IList_Find_FirstEven |  1,026.7 ns |   21.06 ns |  5.47 ns |  1.0109 | 0.0038 |   8.27 KB |
|          Enumerable_Find_FirstEven |  1,034.1 ns |   18.46 ns |  2.86 ns |  1.0109 | 0.0038 |   8.27 KB |
|                List_Find_FirstEven |  1,035.5 ns |   13.88 ns |  3.61 ns |  1.0109 | 0.0038 |   8.27 KB |
|  ReadOnlyCollection_Find_FirstEven |  1,039.4 ns |   22.35 ns |  5.80 ns |  1.0147 | 0.0057 |   8.29 KB |
|                 Enumerable_Add_Int |  1,689.3 ns |   35.25 ns |  9.15 ns |  1.5030 | 0.0019 |  12.28 KB |
|                   HashSet_Find_Int |  7,749.8 ns |   72.13 ns | 18.73 ns |  6.9885 | 0.3052 |  57.29 KB |
|                 HashSet_Remove_Int |  7,774.2 ns |   59.93 ns | 15.56 ns |  6.9885 | 0.3052 |  57.29 KB |
|                    HashSet_Add_Int |  7,790.0 ns |   91.53 ns | 23.77 ns |  6.9885 | 0.3052 |  57.29 KB |
|              LinkedList_Remove_Int |  9,390.3 ns |  172.20 ns | 44.72 ns |  5.7373 | 0.8850 |  46.91 KB |
|                 LinkedList_Add_Int |  9,394.2 ns |  133.23 ns | 34.60 ns |  5.7373 | 0.8392 |  46.96 KB |
|          LinkedList_Find_FirstEven |  9,405.0 ns |  187.22 ns | 48.62 ns |  5.7373 | 0.8392 |  46.96 KB |
|              Enumerable_Remove_Int | 10,734.4 ns |  133.07 ns | 34.56 ns |  2.0294 | 0.0305 |  16.65 KB |
|   Dictionary_Find_Value_By_Key_Int | 38,259.1 ns |  439.62 ns | 114.17 ns | 66.6504 | 138.88 KB |
|          Dictionary_Remove_Key_Int | 38,315.4 ns |  466.48 ns | 121.14 ns | 66.6504 | 138.88 KB |
| Dictionary_Add_KeyValue_Int_String | 38,459.6 ns |  600.93 ns | 156.06 ns | 66.6504 | 138.92 KB |

#### .NET SDK 8.0.404

**IterationCount=5  WarmupCount=5**

|                             Method |        Mean |     Error |   StdDev |    Gen0 |   Gen1 |   Gen2 | Allocated |
|----------------------------------- |------------:|----------:|---------:|--------:|-------:|-------:|----------:|
|                    Span_Remove_Int |    404.9 ns |   0.92 ns | 0.24 ns |  0.4807 |      - |      - |   3.93 KB |
|                Span_Find_FirstEven |    407.2 ns |   4.15 ns | 1.08 ns |  0.4807 |      - |      - |   3.93 KB |
|               Array_Find_FirstEven |    438.3 ns |   3.67 ns | 0.57 ns |  0.4845 |      - |      - |   3.96 KB |
|                       Span_Add_Int |    571.9 ns |   3.27 ns | 0.85 ns |  0.9623 |      - |      - |   7.87 KB |
|                   Array_Remove_Int |    573.1 ns |   6.02 ns | 0.93 ns |  0.9613 |      - |      - |   7.86 KB |
|                      Array_Add_Int |    578.5 ns |  20.07 ns | 3.11 ns |  0.9623 |      - |      - |   7.87 KB |
|                      IList_Add_Int |  1,006.3 ns |  17.98 ns | 4.67 ns |  1.0052 | 0.0019 |      - |   8.23 KB |
|                   IList_Remove_Int |  1,012.4 ns |  18.58 ns | 4.83 ns |  1.0052 | 0.0019 |      - |   8.23 KB |
|                    List_Remove_Int |  1,013.6 ns |  14.64 ns | 3.80 ns |  1.0052 | 0.0019 |      - |   8.23 KB |
|         ReadOnlyCollection_Add_Int |  1,020.9 ns |  34.72 ns | 9.02 ns |  1.0090 | 0.0076 |      - |   8.25 KB |
|      ReadOnlyCollection_Remove_Int |  1,021.4 ns |  17.89 ns | 4.65 ns |  1.0090 | 0.0076 |      - |   8.25 KB |
|                      IList_Add_Int |  1,035.4 ns |  11.12 ns | 1.72 ns |  1.0052 | 0.0019 |      - |   8.23 KB |
|               IList_Find_FirstEven |  1,035.5 ns |  30.76 ns | 5.99 ns |  1.0052 | 0.0019 |      - |   8.23 KB |
|          Enumerable_Find_FirstEven |  1,046.5 ns |  20.97 ns | 5.45 ns |  1.0052 | 0.0019 |      - |   8.23 KB |
|                List_Find_FirstEven |  1,048.1 ns |   6.99 ns | 1.81 ns |  1.0052 | 0.0019 |      - |   8.23 KB |
|  ReadOnlyCollection_Find_FirstEven |  1,057.4 ns |  20.82 ns | 5.41 ns |  1.0147 | 0.0076 |      - |   8.29 KB |
|                 Enumerable_Add_Int |  1,243.7 ns |  23.67 ns | 3.66 ns |  1.5030 | 0.0019 |      - |  12.28 KB |
|              Enumerable_Remove_Int |  7,390.9 ns | 160.89 ns | 41.78 ns |  2.0294 | 0.0305 |      - |  16.65 KB |
|                 HashSet_Remove_Int |  7,442.0 ns | 100.61 ns | 26.13 ns |  7.0038 | 0.2670 |      - |  57.29 KB |
|                    HashSet_Add_Int |  7,443.4 ns |  35.77 ns | 9.29 ns |  7.0038 | 0.2670 |      - |  57.29 KB |
|                   HashSet_Find_Int |  7,445.7 ns |  31.99 ns | 8.31 ns |  7.0038 | 0.2670 |      - |  57.29 KB |
|              LinkedList_Remove_Int |  9,098.8 ns | 168.41 ns | 26.06 ns |  5.7373 | 0.8698 |      - |  46.91 KB |
|          LinkedList_Find_FirstEven |  9,357.9 ns |  84.39 ns | 21.92 ns |  5.7373 | 0.8545 |      - |  46.96 KB |
|                 LinkedList_Add_Int |  9,358.1 ns | 155.55 ns | 24.07 ns |  5.7373 | 0.8545 |      - |  46.96 KB |
|   Dictionary_Find_Value_By_Key_Int | 24,390.8 ns |  60.14 ns | 15.62 ns | 16.9373 | 2.8076 |      - | 138.88 KB |
| Dictionary_Add_KeyValue_Int_String | 27,182.1 ns | 134.40 ns | 34.90 ns | 16.9373 | 2.8076 |      - | 138.92 KB |
|          Dictionary_Remove_Key_Int | 27,431.4 ns | 310.15 ns | 48.00 ns | 16.9373 | 2.8076 |      - | 138.88 KB |

#### .NET SDK 9.0.101

**IterationCount=5  WarmupCount=5**

|                             Method |        Mean |     Error |    StdDev |    Gen0 | Allocated |
|----------------------------------- |------------:|----------:|----------:|--------:|----------:|
|                    Span_Remove_Int |    407.2 ns |   1.85 ns |  0.29 ns |  0.4807 |   3.93 KB |
|               Array_Find_FirstEven |    410.1 ns |   1.34 ns |  0.35 ns |  0.4807 |   3.93 KB |
|                Span_Find_FirstEven |    411.3 ns |  11.34 ns |  2.95 ns |  0.4807 |   3.93 KB |
|                   Array_Remove_Int |    569.7 ns |   3.20 ns |  0.49 ns |  0.9613 |   7.86 KB |
|                      Array_Add_Int |    572.2 ns |   2.35 ns |  0.36 ns |  0.9623 |   7.87 KB |
|                       Span_Add_Int |    575.0 ns |   1.72 ns |  0.27 ns |  0.9623 |   7.87 KB |
|                   IList_Remove_Int |  1,021.5 ns |  31.31 ns |  4.84 ns |  1.0052 |   8.23 KB |
|                       List_Add_Int |  1,024.5 ns |  21.17 ns |  5.50 ns |  1.0052 |   8.23 KB |
|                    List_Remove_Int |  1,026.8 ns |  12.37 ns |  1.81 ns |  1.0052 |   8.23 KB |
|         ReadOnlyCollection_Add_Int |  1,029.7 ns |  34.72 ns |  9.02 ns |  1.0090 |   8.25 KB |
|      ReadOnlyCollection_Remove_Int |  1,033.4 ns |  18.07 ns |  4.69 ns |  1.0090 |   8.25 KB |
|                      IList_Add_Int |  1,035.4 ns |  11.12 ns |  1.72 ns |  1.0052 |   8.23 KB |
|               IList_Find_FirstEven |  1,035.5 ns |  30.76 ns |  5.99 ns |  1.0052 |   8.23 KB |
|          Enumerable_Find_FirstEven |  1,046.5 ns |  20.97 ns |  5.45 ns |  1.0052 |   8.23 KB |
|                List_Find_FirstEven |  1,048.1 ns |   6.99 ns |  1.81 ns |  1.0052 |   8.23 KB |
|  ReadOnlyCollection_Find_FirstEven |  1,057.4 ns |  20.82 ns |  5.41 ns |  1.0147 |   8.29 KB |
|                 Enumerable_Add_Int |  1,243.7 ns |  23.67 ns |  3.66 ns |  1.5030 |  12.28 KB |
|              Enumerable_Remove_Int |  7,390.9 ns | 160.89 ns | 41.78 ns |  2.0294 |  16.65 KB |
|                 HashSet_Remove_Int |  7,442.0 ns | 100.61 ns | 26.13 ns |  7.0038 |  57.29 KB |
|                    HashSet_Add_Int |  7,443.4 ns |  35.77 ns |  9.29 ns |  7.0038 |  57.29 KB |
|                   HashSet_Find_Int |  7,445.7 ns |  31.99 ns |  8.31 ns |  7.0038 |  57.29 KB |
|              LinkedList_Remove_Int |  9,098.8 ns | 168.41 ns | 26.06 ns |  5.7373 |  46.91 KB |
|          LinkedList_Find_FirstEven |  9,357.9 ns |  84.39 ns | 21.92 ns |  5.7373 |  46.96 KB |
|                 LinkedList_Add_Int |  9,358.1 ns | 155.55 ns | 24.07 ns |  5.7373 |  46.96 KB |
|   Dictionary_Find_Value_By_Key_Int | 24,390.8 ns |  60.14 ns | 15.62 ns | 16.9373 | 138.88 KB |
| Dictionary_Add_KeyValue_Int_String | 27,182.1 ns | 134.40 ns | 34.90 ns | 16.9373 | 138.92 KB |
|          Dictionary_Remove_Key_Int | 27,431.4 ns | 310.15 ns | 48.00 ns | 16.9373 | 138.88 KB |

#### .NET SDK 10.0.100-preview.1.25120.13
| Method                             | Mean        | Error       | StdDev    | Gen0    | Gen1   | Allocated |
|----------------------------------- |------------:|------------:|----------:|--------:|-------:|----------:|
| Span_Remove_Int                    |    421.7 ns |     3.35 ns |   0.87 ns |  0.4807 |      - |   3.93 KB |
| Span_Find_FirstEven                |    423.9 ns |     0.88 ns |   0.23 ns |  0.4807 |      - |   3.93 KB |
| Array_Find_FirstEven               |    427.2 ns |     2.47 ns |   0.64 ns |  0.4807 |      - |   3.93 KB |
| Array_Add_Int                      |    595.8 ns |     1.87 ns |   0.29 ns |  0.9623 |      - |   7.87 KB |
| Array_Remove_Int                   |    596.3 ns |     2.96 ns |   0.77 ns |  0.9613 |      - |   7.86 KB |
| Span_Add_Int                       |    603.1 ns |    17.58 ns |   4.57 ns |  0.9623 |      - |   7.87 KB |
| ReadOnlyCollection_Add_Int         |  1,047.6 ns |     0.63 ns |   0.16 ns |  1.0052 | 0.0019 |   8.23 KB |
| List_Remove_Int                    |  1,047.6 ns |     5.58 ns |   0.86 ns |  1.0052 | 0.0019 |   8.23 KB |
| IList_Remove_Int                   |  1,049.8 ns |    20.18 ns |   3.12 ns |  1.0052 | 0.0019 |   8.23 KB |
| List_Add_Int                       |  1,050.5 ns |     6.28 ns |   1.63 ns |  1.0052 | 0.0019 |   8.23 KB |
| IList_Add_Int                      |  1,052.5 ns |     7.07 ns |   1.84 ns |  1.0052 | 0.0019 |   8.23 KB |
| ReadOnlyCollection_Remove_Int      |  1,058.4 ns |     4.56 ns |   1.19 ns |  1.0052 | 0.0019 |   8.23 KB |
| Enumerable_Find_FirstEven          |  1,059.9 ns |     1.71 ns |   0.44 ns |  1.0052 | 0.0019 |   8.23 KB |
| List_Find_FirstEven                |  1,078.1 ns |    53.57 ns |   8.29 ns |  1.0052 | 0.0019 |   8.23 KB |
| ReadOnlyCollection_Find_FirstEven  |  1,078.6 ns |     1.22 ns |   0.19 ns |  1.0147 | 0.0076 |   8.29 KB |
| IList_Find_FirstEven               |  1,083.7 ns |    60.93 ns |  15.82 ns |  1.0052 | 0.0019 |   8.23 KB |
| Enumerable_Add_Int                 |  1,280.6 ns |    67.28 ns |  17.47 ns |  1.5030 | 0.0019 |  12.28 KB |
| HashSet_Remove_Int                 |  7,455.3 ns |    38.34 ns |   5.93 ns |  7.0038 | 0.2670 |  57.29 KB |
| HashSet_Find_Int                   |  7,466.7 ns |    31.77 ns |   8.25 ns |  7.0038 | 0.2670 |  57.29 KB |
| HashSet_Add_Int                    |  7,484.6 ns |   132.41 ns |  34.39 ns |  7.0038 | 0.2670 |  57.29 KB |
| Enumerable_Remove_Int              |  8,008.9 ns |    66.34 ns |  10.27 ns |  2.0294 | 0.0305 |  16.65 KB |
| LinkedList_Remove_Int              |  9,947.8 ns |    21.07 ns |   5.47 ns |  5.7373 | 0.8698 |  46.91 KB |
| LinkedList_Add_Int                 |  9,986.9 ns |   114.07 ns |  29.62 ns |  5.7373 | 0.8545 |  46.96 KB |
| LinkedList_Find_FirstEven          | 10,196.4 ns | 1,137.57 ns | 295.42 ns |  5.7373 | 0.8545 |  46.96 KB |
| Dictionary_Find_Value_By_Key_Int   | 24,592.1 ns |   108.86 ns |  28.27 ns | 16.9373 | 2.8076 | 138.88 KB |
| Dictionary_Remove_Key_Int          | 24,793.5 ns |    22.97 ns |   3.55 ns | 16.9373 | 2.8076 | 138.88 KB |
| Dictionary_Add_KeyValue_Int_String | 24,878.0 ns |    98.01 ns |  25.45 ns | 16.9373 | 2.8076 | 138.92 KB |

**IterationCount=5  WarmupCount=5**
---
  
### Big O Notation Complexity

Understanding the underlying complexity provides insights into the performance behaviors observed in the benchmarks.

| **Data Structure**         | **Operation** | **Time Complexity (Average)** | **Time Complexity (Worst)** | **Space Complexity** |
|----------------------------|---------------|-------------------------------|-----------------------------|----------------------|
| **Array**                  | Add           | O(1)                          | O(n)                        | O(n)                 |
|                            | Get           | O(1)                          | O(1)                        |                      |
|                            | Remove        | O(n)                          | O(n)                        |                      |
|                            | Find          | O(n)                          | O(n)                        |                      |
| **List**                   | Add           | O(1)                          | O(n)                        | O(n)                 |
|                            | Get           | O(1)                          | O(1)                        |                      |
|                            | Remove        | O(n)                          | O(n)                        |                      |
|                            | Find          | O(n)                          | O(n)                        |                      |
| **LinkedList**             | Add           | O(1)                          | O(1)                        | O(n)                 |
|                            | Get           | O(n)                          | O(n)                        |                      |
|                            | Remove        | O(1)                          | O(n)                        |                      |
|                            | Find          | O(n)                          | O(n)                        |                      |
| **HashSet**                | Add           | O(1)                          | O(n)                        | O(n)                 |
|                            | Get           | O(1)                          | O(n)                        |                      |
|                            | Remove        | O(1)                          | O(n)                        |                      |
|                            | Find          | O(1)                          | O(n)                        |                      |
| **Dictionary**             | Add           | O(1)                          | O(n)                        | O(n)                 |
|                            | Get           | O(1)                          | O(n)                        |                      |
|                            | Remove        | O(1)                          | O(n)                        |                      |
|                            | Find          | O(1)                          | O(n)                        |                      |
| **ReadOnlyCollection**     | Add           | N/A                           | N/A                         | O(n)                 |
|                            | Get           | O(1)                          | O(1)                        |                      |
|                            | Remove        | N/A                           | N/A                         |                      |
|                            | Find          | O(n)                          | O(n)                        |                      |
| **Span**                   | Add           | O(n)                          | O(n)                        | O(n)                 |
|                            | Get           | O(1)                          | O(1)                        |                      |
|                            | Remove        | O(n)                          | O(n)                        |                      |
|                            | Find          | O(n)                          | O(n)                        |                      |

**Note**: For operations that are not supported (e.g., Add and Remove on `ReadOnlyCollection<T>`), the time complexity is marked as **N/A**.

---

## Conclusion

This **BenchmarkDotNet** project provides a comprehensive comparison of various **Common Data Structures** in .NET, focusing on fundamental operations like **Add**, **Get**, **Remove**, and **Find** across different data types (`int`, `string`, and `Person`). By analyzing these benchmarks, developers can make informed decisions about which data structures best suit their application's performance and scalability requirements.

**Key Takeaways**:

- **Operational Trade-offs**: Different data structures offer varying efficiencies for specific operations. For instance, arrays provide O(1) access time but suffer from O(n) removal time, whereas linked lists offer O(1) insertion and removal but have O(n) access time.
  
- **Complex Structures**: Advanced data structures like **HashSet** and **Dictionary** provide constant-time operations but come with higher memory overhead. They are ideal for scenarios requiring fast lookups.
  
- **Memory Consumption**: Some data structures may consume more memory to achieve better time complexities. It's essential to balance memory usage with performance needs based on application constraints.
  
- **BenchmarkDotNet Utility**: Leveraging **BenchmarkDotNet** allows for precise and reliable performance measurements, facilitating a deeper understanding of data structure behaviors in real-world applications.

---


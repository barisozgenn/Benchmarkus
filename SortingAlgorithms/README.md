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
#### .NET SDK 10.0.0

| **Method**                     | **ArraySize** | **Mean**             | **Error**           | **StdDev**          | **Gen0**    | **Allocated** |
|--------------------------- |---------- |-----------------:|----------------:|----------------:|--------:|----------:|

#### .NET SDK 9.0.101

| **Method**                     | **ArraySize** | **Mean**             | **Error**           | **StdDev**          | **Gen0**    | **Allocated** |
|--------------------------- |---------- |-----------------:|----------------:|----------------:|--------:|----------:|
| Int_QuickSort              | 100       |       1,079.4 ns |         1.70 ns |         1.59 ns |  0.0572 |     488 B |
| Int_MergeSort              | 100       |       2,489.8 ns |         9.53 ns |         8.45 ns |  1.0147 |    8488 B |
| Int_TimSort                | 100       |         459.7 ns |         0.48 ns |         0.42 ns |  0.0501 |     424 B |
| Int_HeapSort               | 100       |       1,902.8 ns |         1.80 ns |         1.50 ns |  0.0572 |     488 B |
| Int_BubbleSort             | 100       |       5,904.1 ns |         7.81 ns |         7.31 ns |  0.0534 |     488 B |
| String_QuickSort           | 100       |       3,735.6 ns |         9.07 ns |         7.57 ns |  0.1030 |     888 B |
| String_MergeSort           | 100       |       5,833.4 ns |         5.84 ns |         4.88 ns |  1.3123 |   11016 B |
| String_TimSort             | 100       |       2,823.8 ns |         3.87 ns |         3.43 ns |  0.1030 |     888 B |
| String_HeapSort            | 100       |       6,074.2 ns |        25.05 ns |        23.43 ns |  0.0992 |     888 B |
| String_BubbleSort          | 100       |      26,467.0 ns |       428.55 ns |       379.90 ns |  0.0916 |     888 B |
| Complex_QuickSortByAmount  | 100       |       4,902.9 ns |        12.40 ns |        10.99 ns |  0.0916 |     824 B |
| Complex_MergeSortByAmount  | 100       |       6,247.4 ns |        10.81 ns |         9.59 ns |  1.3046 |   10952 B |
| Complex_TimSortByAmount    | 100       |       3,170.0 ns |         5.45 ns |         4.83 ns |  0.0954 |     824 B |
| Complex_HeapSortByAmount   | 100       |       8,210.0 ns |        57.20 ns |        50.70 ns |  0.0916 |     824 B |
| Complex_BubbleSortByAmount | 100       |      31,382.1 ns |        68.63 ns |        53.58 ns |  0.0610 |     824 B |
| Int_QuickSort              | 5000      |     201,597.9 ns |     2,999.03 ns |     2,805.30 ns |  2.1973 |   20088 B |
| Int_MergeSort              | 5000      |     301,909.0 ns |       273.48 ns |       228.37 ns | 63.9648 |  536072 B |
| Int_TimSort                | 5000      |     144,392.2 ns |     2,792.97 ns |     2,612.54 ns |  2.1973 |   20024 B |
| Int_HeapSort               | 5000      |     473,111.6 ns |     1,652.37 ns |     1,464.78 ns |  1.9531 |   20088 B |
| Int_BubbleSort             | 5000      |  16,045,493.7 ns |    10,301.15 ns |     9,131.70 ns |       - |   20111 B |
| String_QuickSort           | 5000      |     933,071.6 ns |     1,148.63 ns |     1,018.23 ns |  3.9063 |   40089 B |
| String_MergeSort           | 5000      |     994,069.4 ns |     4,005.65 ns |     3,344.90 ns | 91.7969 |  774505 B |
| String_TimSort             | 5000      |     794,027.6 ns |     1,834.61 ns |     1,716.10 ns |  3.9063 |   40089 B |
| String_HeapSort            | 5000      |   1,554,062.8 ns |     2,157.48 ns |     1,912.55 ns |  3.9063 |   40089 B |
| String_BubbleSort          | 5000      | 169,161,768.1 ns | 3,087,787.73 ns | 2,578,442.60 ns |       - |   40333 B |
| Complex_QuickSortByAmount  | 5000      |     729,748.5 ns |     2,335.02 ns |     2,184.18 ns |  3.9063 |   40025 B |
| Complex_MergeSortByAmount  | 5000      |     784,367.3 ns |    10,247.23 ns |     9,083.91 ns | 91.7969 |  774441 B |
| Complex_TimSortByAmount    | 5000      |     520,714.3 ns |       988.00 ns |       924.18 ns |  3.9063 |   40025 B |
| Complex_HeapSortByAmount   | 5000      |   1,300,290.3 ns |     2,551.16 ns |     2,130.33 ns |  3.9063 |   40025 B |
| Complex_BubbleSortByAmount | 5000      | 116,163,844.8 ns |   139,582.70 ns |   116,557.88 ns |       - |   40129 B |

#### .NET SDK 8.0.404

| **Method**                     | **ArraySize** | **Mean**             | **Error**         | **StdDev**        | **Gen0**    | **Allocated** |
|--------------------------- |---------- |-----------------:|--------------:|--------------:|--------:|----------:|
| Int_QuickSort              | 100       |       1,095.5 ns |       4.44 ns |       3.94 ns |  0.0572 |     488 B |
| Int_MergeSort              | 100       |       2,359.0 ns |       3.78 ns |       3.16 ns |  1.0147 |    8488 B |
| Int_TimSort                | 100       |         453.6 ns |       0.59 ns |       0.53 ns |  0.0501 |     424 B |
| Int_HeapSort               | 100       |       1,904.5 ns |       1.57 ns |       1.39 ns |  0.0572 |     488 B |
| Int_BubbleSort             | 100       |       5,940.0 ns |       9.79 ns |       9.16 ns |  0.0534 |     488 B |
| String_QuickSort           | 100       |       3,636.1 ns |       9.21 ns |       8.16 ns |  0.1030 |     888 B |
| String_MergeSort           | 100       |       5,783.8 ns |      28.96 ns |      27.09 ns |  1.3123 |   11016 B |
| String_TimSort             | 100       |       2,541.6 ns |       7.71 ns |       7.21 ns |  0.1030 |     888 B |
| String_HeapSort            | 100       |       6,636.1 ns |      24.88 ns |      23.28 ns |  0.0992 |     888 B |
| String_BubbleSort          | 100       |      29,602.0 ns |     585.32 ns |     601.08 ns |  0.0610 |     888 B |
| Complex_QuickSortByAmount  | 100       |       5,041.9 ns |      31.55 ns |      29.51 ns |  0.0916 |     824 B |
| Complex_MergeSortByAmount  | 100       |       6,182.3 ns |      72.29 ns |      60.37 ns |  1.3046 |   10952 B |
| Complex_TimSortByAmount    | 100       |       3,000.9 ns |      28.50 ns |      26.66 ns |  0.0954 |     824 B |
| Complex_HeapSortByAmount   | 100       |      10,034.1 ns |      16.40 ns |      14.53 ns |  0.0916 |     824 B |
| Complex_BubbleSortByAmount | 100       |      30,452.8 ns |     152.36 ns |     135.06 ns |  0.0610 |     824 B |
| Int_QuickSort              | 5000      |     219,197.7 ns |   3,392.43 ns |   3,173.28 ns |  2.1973 |   20088 B |
| Int_MergeSort              | 5000      |     311,752.0 ns |     585.23 ns |     518.79 ns | 63.9648 |  536072 B |
| Int_TimSort                | 5000      |     143,169.6 ns |   2,763.26 ns |   2,449.56 ns |  2.1973 |   20024 B |
| Int_HeapSort               | 5000      |     469,256.8 ns |   2,307.15 ns |   2,045.23 ns |  1.9531 |   20088 B |
| Int_BubbleSort             | 5000      |  15,798,195.1 ns |  16,026.54 ns |  13,382.88 ns |       - |   20111 B |
| String_QuickSort           | 5000      |     703,314.7 ns |   1,531.56 ns |   1,357.69 ns |  3.9063 |   40089 B |
| String_MergeSort           | 5000      |     798,633.0 ns |   1,104.42 ns |     979.04 ns | 91.7969 |  774505 B |
| String_TimSort             | 5000      |     576,541.5 ns |     980.50 ns |     917.16 ns |  3.9063 |   40089 B |
| String_HeapSort            | 5000      |   1,062,552.6 ns |   1,255.53 ns |     980.23 ns |  3.9063 |   40089 B |
| String_BubbleSort          | 5000      | 111,326,182.4 ns | 368,982.87 ns | 345,146.81 ns |       - |   40333 B |
| Complex_QuickSortByAmount  | 5000      |     721,528.3 ns |   3,418.07 ns |   3,030.03 ns |  3.9063 |   40025 B |
| Complex_MergeSortByAmount  | 5000      |     780,259.7 ns |     478.08 ns |     373.25 ns | 91.7969 |  774441 B |
| Complex_TimSortByAmount    | 5000      |     568,560.2 ns |   1,600.86 ns |   1,336.79 ns |  3.9063 |   40025 B |
| Complex_HeapSortByAmount   | 5000      |   1,287,119.2 ns |   1,768.46 ns |   1,567.69 ns |  3.9063 |   40025 B |
| Complex_BubbleSortByAmount | 5000      | 113,910,361.1 ns | 236,749.85 ns | 209,872.57 ns |       - |   40147 B |

#### .NET SDK 7.0.410

| **Method**                     | **ArraySize** | **Mean**            | **Error**         | **StdDev**          | **Median**           | **Gen0**    | **Allocated** |
|--------------------------- |---------- |-----------------:|----------------:|----------------:|-----------------:|--------:|----------:|
| Int_QuickSort              | 100       |       1,769.5 ns |        11.33 ns |        10.60 ns |       1,767.3 ns |  0.0572 |     488 B |
| Int_MergeSort              | 100       |       3,552.3 ns |         4.98 ns |         4.41 ns |       3,552.1 ns |  1.0147 |    8488 B |
| Int_TimSort                | 100       |         447.3 ns |         0.73 ns |         0.65 ns |         447.2 ns |  0.0501 |     424 B |
| Int_HeapSort               | 100       |       3,100.8 ns |         6.76 ns |         5.99 ns |       3,101.5 ns |  0.0572 |     488 B |
| Int_BubbleSort             | 100       |      12,449.5 ns |        30.47 ns |        28.50 ns |      12,451.4 ns |  0.0458 |     488 B |
| String_QuickSort           | 100       |       5,086.8 ns |        12.12 ns |        10.75 ns |       5,086.0 ns |  0.0992 |     888 B |
| String_MergeSort           | 100       |       7,357.6 ns |        12.01 ns |         9.38 ns |       7,356.0 ns |  1.3123 |   11016 B |
| String_TimSort             | 100       |       4,254.7 ns |         4.05 ns |         3.17 ns |       4,254.9 ns |  0.0992 |     888 B |
| String_HeapSort            | 100       |       9,082.0 ns |       157.24 ns |       154.43 ns |       9,031.9 ns |  0.0916 |     888 B |
| String_BubbleSort          | 100       |      44,548.6 ns |       519.28 ns |       485.74 ns |      44,427.3 ns |  0.0610 |     888 B |
| Complex_QuickSortByAmount  | 100       |       5,735.4 ns |        18.52 ns |        17.32 ns |       5,728.8 ns |  0.0916 |     824 B |
| Complex_MergeSortByAmount  | 100       |       6,940.6 ns |        12.08 ns |        11.30 ns |       6,941.0 ns |  1.3046 |   10952 B |
| Complex_TimSortByAmount    | 100       |       3,498.1 ns |        25.96 ns |        23.01 ns |       3,490.2 ns |  0.0954 |     824 B |
| Complex_HeapSortByAmount   | 100       |       9,498.1 ns |        40.28 ns |        35.70 ns |       9,483.6 ns |  0.0916 |     824 B |
| Complex_BubbleSortByAmount | 100       |      36,036.9 ns |       192.11 ns |       170.30 ns |      36,014.3 ns |  0.0610 |     824 B |
| Int_QuickSort              | 5000      |     290,766.9 ns |       850.01 ns |       795.10 ns |     290,751.1 ns |  1.9531 |   20088 B |
| Int_MergeSort              | 5000      |     382,454.5 ns |       478.52 ns |       424.20 ns |     382,440.6 ns | 63.9648 |  536072 B |
| Int_TimSort                | 5000      |     124,851.3 ns |     2,484.43 ns |     5,856.10 ns |     122,784.6 ns |  2.1973 |   20024 B |
| Int_HeapSort               | 5000      |     437,216.6 ns |       349.73 ns |       292.04 ns |     437,308.8 ns |  1.9531 |   20088 B |
| Int_BubbleSort             | 5000      |  35,105,986.5 ns |    26,782.38 ns |    23,741.89 ns |  35,095,909.8 ns |       - |   20150 B |
| String_QuickSort           | 5000      |   1,141,616.0 ns |     3,926.26 ns |     3,480.53 ns |   1,139,507.9 ns |  3.9063 |   40090 B |
| String_MergeSort           | 5000      |   1,244,779.0 ns |     2,241.72 ns |     1,987.23 ns |   1,244,243.7 ns | 91.7969 |  774506 B |
| String_TimSort             | 5000      |   1,048,199.2 ns |     1,909.56 ns |     1,692.77 ns |   1,047,631.4 ns |  3.9063 |   40090 B |
| String_HeapSort            | 5000      |   1,870,795.2 ns |    11,375.30 ns |    10,083.91 ns |   1,868,257.1 ns |  3.9063 |   40090 B |
| String_BubbleSort          | 5000      | 211,106,123.0 ns | 1,340,053.04 ns | 1,187,922.12 ns | 211,521,430.7 ns |       - |   40400 B |
| Complex_QuickSortByAmount  | 5000      |     760,573.6 ns |       795.39 ns |       664.19 ns |     760,344.5 ns |  3.9063 |   40025 B |
| Complex_MergeSortByAmount  | 5000      |     848,929.7 ns |     5,473.84 ns |     4,852.42 ns |     848,931.4 ns | 91.7969 |  774441 B |
| Complex_TimSortByAmount    | 5000      |     567,972.0 ns |     1,825.23 ns |     1,707.32 ns |     568,198.7 ns |  3.9063 |   40025 B |
| Complex_HeapSortByAmount   | 5000      |   1,200,581.8 ns |     2,322.27 ns |     1,813.08 ns |   1,200,111.5 ns |  3.9063 |   40026 B |
| Complex_BubbleSortByAmount | 5000      | 131,196,636.8 ns | 1,006,524.39 ns |   941,503.54 ns | 130,951,375.0 ns |       - |   40258 B |

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


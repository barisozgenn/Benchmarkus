# Asynchronous & Concurrency Benchmarks

This project is part of the **Benchmarkus** repository and focuses on comparing various **asynchronous** and **concurrency** patterns in .NET. It explores:

- **Async/Await Overhead**  
- **Task Parallel Library (TPL)**  
- **Concurrency Primitives** (locks, semaphores, mutexes, reader-writer locks, and concurrent collections)

By measuring a range of common patterns—such as CPU-bound loops, list insertions, property reads/writes, and thread synchronization constructs—developers gain insights into how different approaches scale in .NET across multiple runtime versions.

---

## 📌 Why These Benchmarks?

1. **Evaluate Async & Await**  
   - Measure potential overhead introduced by `Task.Delay` vs. synchronous `Thread.Sleep` for I/O-bound operations.  
   - Compare CPU-bound work done synchronously vs. via `Task.Run` for real-world scenarios involving parallel processing.

2. **Analyze Task Parallel Library (TPL)**  
   - Compare single-threaded vs. `Parallel.For` vs. PLINQ to see how data partitioning affects performance.  
   - Identify potential gains in multi-core environments vs. overhead of parallel execution.

3. **Compare Concurrency Primitives**  
   - **Lock**, **SemaphoreSlim**, **Mutex**: Evaluate raw overhead for protected shared resources (e.g., counters).  
   - **ConcurrentDictionary**: Assess thread-safe collection usage under parallel insertions.  
   - **ReaderWriterLockSlim**: Observe performance in a mixed read/write scenario.

---

## 📚 What We Are Measuring?

1. **Basic Async vs Sync**  
   - **`CpuBoundSync`** vs. **`CpuBoundAsync`**  
   - **`ProcessPeopleSync`** vs. **`ProcessPeopleAsync`**  
   Showcases blocking vs. non-blocking operations, revealing how `await` can help or hinder performance depending on workload type.

2. **TPL & Parallel Patterns**  
   - **`SumPersonIdsSync`** (Baseline)  
   - **`SumPersonIdsParallelFor`**  
   - **`SumPersonIdsPlinq`**  
   Highlights overhead vs. speedup when parallelizing a summation task.

3. **Concurrency Primitives**  
   - **`LockTest`**, **`SemaphoreTest`**, **`MutexTest`**  
   - **`LockMixedOperations`** vs. **`ReaderWriterLockSlimMixedOperations`**  
   Explores different synchronization mechanisms protecting shared data. Evaluates overhead and concurrency behavior.

4. **Concurrent Collections**  
   - **`ConcurrentDictionaryInsert`**  
   Measures insertion throughput in `ConcurrentDictionary`, reflecting real-world read/write patterns.

---

## 🔥 **Benchmark Results**

> **.NET SDK Versions**: 9.0.101, 8.0.404, 7.0.410, 6.0.428  
> **IterationCount=5**, **WarmupCount=3**  
> **Platform**: Arm64 RyuJIT AdvSIMD (macOS or other ARM64 environments)

Below are the consolidated results, including **Mean** (ns), **StdDev**, **Ratio**, **Rank**, **GC/Memory Allocations**, etc. For clarity, each .NET SDK version’s table is shown.

### .NET SDK 10.0.100-preview.1.25120.13

| Method                              | Mean         | Error         | StdDev       | Ratio    | RatioSD | Rank | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------------ |-------------:|--------------:|-------------:|---------:|--------:|-----:|-------:|-------:|----------:|------------:|
| CpuBoundSync                        |     50.30 ns |      1.043 ns |     0.161 ns |     0.97 |    0.00 |    1 |      - |      - |         - |          NA |
| SumPersonIdsSync                    |     51.88 ns |      0.116 ns |     0.030 ns |     1.00 |    0.00 |    1 |      - |      - |         - |          NA |
| ProcessPeopleAsync                  |    224.53 ns |      4.669 ns |     0.722 ns |     4.33 |    0.01 |    2 |      - |      - |         - |          NA |
| CpuBoundAsync                       |    762.84 ns |     15.986 ns |     4.152 ns |    14.70 |    0.07 |    3 | 0.0324 |      - |     272 B |          NA |
| LockTest                            |    779.09 ns |      2.759 ns |     0.716 ns |    15.02 |    0.01 |    3 |      - |      - |         - |          NA |
| LockMixedOperations                 |  1,367.74 ns |      5.080 ns |     1.319 ns |    26.36 |    0.03 |    4 | 0.1144 | 0.0019 |     959 B |          NA |
| ReaderWriterLockSlimMixedOperations |  2,052.11 ns |      2.357 ns |     0.612 ns |    39.55 |    0.02 |    5 | 0.1144 |      - |     958 B |          NA |
| SumPersonIdsParallelFor             |  2,099.28 ns |    437.947 ns |   113.733 ns |    40.46 |    2.00 |    5 | 0.2975 |      - |    2503 B |          NA |
| SemaphoreTest                       |  2,361.98 ns |      3.890 ns |     1.010 ns |    45.53 |    0.03 |    5 |      - |      - |         - |          NA |
| SumPersonIdsPlinq                   | 12,112.59 ns |    764.660 ns |   198.580 ns |   233.47 |    3.50 |    6 | 0.6638 |      - |    5560 B |          NA |
| ProcessPeopleSync                   | 16,726.93 ns |    356.767 ns |    92.651 ns |   322.41 |    1.64 |    7 |      - |      - |         - |          NA |
| MutexTest                           | 23,125.01 ns |     69.710 ns |    10.788 ns |   445.74 |    0.30 |    8 |      - |      - |         - |          NA |
| ConcurrentDictionaryInsert          | 65,917.92 ns | 12,965.550 ns | 2,006.433 ns | 1,270.58 |   34.37 |    9 | 3.5400 | 0.1221 |   27629 B |          NA |
### .NET SDK 9.0.101

| Method                              | Mean         | Error         | StdDev       | Ratio    | RatioSD | Rank | Completed Work Items | Lock Contentions | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------------ |-------------:|--------------:|-------------:|---------:|--------:|-----:|---------------------:|-----------------:|-------:|-------:|----------:|------------:|
| **CpuBoundSync**                    |   48.79 ns   |   1.392 ns    |   0.361 ns   |   0.97   |  0.01   |  1   |         -           |        -         |  -     |   -    |    -      |    NA       |
| **SumPersonIdsSync**               |   50.55 ns   |   0.955 ns    |   0.248 ns   |   1.00   |  0.01   |  1   |         -           |        -         |  -     |   -    |    -      |    NA       |
| ProcessPeopleAsync                  |   197.64 ns  |   3.578 ns    |   0.554 ns   |   3.91   |  0.02   |  2   |         -           |        -         |  -     |   -    |    -      |    NA       |
| CpuBoundAsync                       |   702.98 ns  |  24.109 ns    |   6.261 ns   |  13.91   |  0.13   |  3   |     1.0004          |        -         | 0.0324 |   -    |  272 B    |    NA       |
| LockTest                            |   764.75 ns  |  11.141 ns    |   1.724 ns   |  15.13   |  0.07   |  3   |         -           |        -         |  -     |   -    |    -      |    NA       |
| LockMixedOperations                 | 1,353.26 ns  |   5.482 ns    |   0.848 ns   |  26.77   |  0.12   |  4   |         -           |        -         | 0.1144 |0.0019  |  958 B    |    NA       |
| SumPersonIdsParallelFor             | 2,019.43 ns  | 186.486 ns    |  48.430 ns   |  39.95   |  0.89   |  5   |     1.7584          |        -         | 0.2975 |   -    | 2,506 B   |    NA       |
| ReaderWriterLockSlimMixedOperations | 2,052.28 ns  |  12.854 ns    |   3.338 ns   |  40.60   |  0.19   |  5   |         -           |        -         | 0.1144 |   -    |  958 B    |    NA       |
| SemaphoreTest                       | 2,318.54 ns  |  48.618 ns    |  12.626 ns   |  45.87   |  0.31   |  5   |         -           |        -         |  -     |   -    |    -      |    NA       |
| SumPersonIdsPlinq                   | 5,424.91 ns  | 395.934 ns    | 102.823 ns   | 107.33   |  1.92   |  6   |     7.0000          |        -         | 0.6561 |   -    | 5,560 B   |    NA       |
| ProcessPeopleSync                   | 16,686.62 ns | 216.763 ns    |  33.544 ns   | 330.14   |  1.60   |  7   |         -           |        -         |  -     |   -    |    -      |    NA       |
| MutexTest                           | 23,310.68 ns | 236.652 ns    |  61.458 ns   | 461.20   |  2.35   |  8   |         -           |        -         |  -     |   -    |    -      |    NA       |
| ConcurrentDictionaryInsert          | 73,617.37 ns | 34,375.756 ns | 8,927.275 ns |1,456.50  |161.37   |  9   |     7.7306          |      3.8573      | 3.5400 |0.1221  | 27,502 B  |    NA       |

### .NET SDK 8.0.404

| Method                              | Mean         | Error        | StdDev       | Ratio    | RatioSD | Rank | Completed Work Items | Lock Contentions | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------------ |-------------:|-------------:|-------------:|---------:|--------:|-----:|---------------------:|-----------------:|-------:|-------:|----------:|------------:|
| **CpuBoundSync**                    |   48.62 ns   |   1.518 ns   |   0.235 ns   |   0.94   |  0.01   |  1   |         -           |        -         |  -     |   -    |    -      |    NA       |
| **SumPersonIdsSync**               |   51.54 ns   |   2.245 ns   |   0.347 ns   |   1.00   |  0.01   |  1   |         -           |        -         |  -     |   -    |    -      |    NA       |
| ProcessPeopleAsync                  |  227.28 ns   |  24.107 ns   |   6.261 ns   |   4.41   |  0.11   |  2   |         -           |        -         |  -     |   -    |    -      |    NA       |
| LockTest                            |  782.29 ns   |   7.505 ns   |   1.949 ns   |  15.18   |  0.10   |  3   |         -           |        -         |  -     |   -    |    -      |    NA       |
| CpuBoundAsync                       |1,215.84 ns   |  42.146 ns   |   6.522 ns   |  23.59   |  0.18   |  4   |     1.0033          |        -         |0.0324  |   -    |  272 B    |    NA       |
| LockMixedOperations                 |1,379.80 ns   |   6.633 ns   |   1.722 ns   |  26.77   |  0.16   |  4   |         -           |        -         |0.1144  |0.0019  |  958 B    |    NA       |
| ReaderWriterLockSlimMixedOperations |2,143.12 ns   |  54.572 ns   |  14.172 ns   |  41.59   |  0.35   |  5   |         -           |        -         |0.1144  |   -    |  959 B    |    NA       |
| SemaphoreTest                       |2,341.75 ns   |  10.126 ns   |   1.567 ns   |  45.44   |  0.28   |  5   |         -           |        -         |  -     |   -    |    -      |    NA       |
| SumPersonIdsParallelFor             |2,349.60 ns   | 209.625 ns   |  54.439 ns   |  45.59   |  1.01   |  5   |     1.5620          |        -         |0.2937  |   -    | 2,474 B   |    NA       |
| SumPersonIdsPlinq                   |9,277.23 ns   | 447.987 ns   | 116.341 ns   | 180.02   |  2.34   |  6   |     7.0000          |        -         |0.6561  |   -    | 5,560 B   |    NA       |
| ProcessPeopleSync                   |17,161.78 ns  | 737.890 ns   | 191.628 ns   | 333.01   |  3.95   |  7   |         -           |        -         |  -     |   -    |    -      |    NA       |
| MutexTest                           |22,973.63 ns  | 228.060 ns   |  35.292 ns   | 445.78   |  2.76   |  8   |         -           |        -         |  -     |   -    |    -      |    NA       |
| ConcurrentDictionaryInsert          |71,949.87 ns  |5,367.322 ns  |1,393.877 ns  |1,396.13  | 26.19   |  9   |     7.9922          |      3.5537      |3.5400  |0.1221  |27,632 B   |    NA       |

### .NET SDK 7.0.410

| Method                              | Mean          | Error         | StdDev       | Ratio    | RatioSD | Rank | Completed Work Items | Lock Contentions | Gen0   | Allocated | Alloc Ratio |
|------------------------------------ |--------------:|--------------:|-------------:|---------:|--------:|-----:|---------------------:|-----------------:|-------:|----------:|------------:|
| **CpuBoundSync**                    |   49.44 ns    |   1.486 ns    |   0.386 ns   |   0.98   |  0.01   |  1   |         -           |        -         |  -     |    -      |     NA      |
| **SumPersonIdsSync**               |   50.22 ns    |   0.244 ns    |   0.063 ns   |   1.00   |  0.00   |  1   |         -           |        -         |  -     |    -      |     NA      |
| ProcessPeopleAsync                  |  213.27 ns    |   1.107 ns    |   0.171 ns   |   4.25   |  0.01   |  2   |         -           |        -         |  -     |    -      |     NA      |
| LockTest                            |  778.54 ns    |   8.116 ns    |   2.108 ns   |  15.50   |  0.04   |  3   |         -           |        -         |  -     |    -      |     NA      |
| CpuBoundAsync                       |1,263.18 ns    |   5.506 ns    |   0.852 ns   |  25.16   |  0.03   |  4   |     1.0011          |        -         |0.0343  |  288 B    |     NA      |
| LockMixedOperations                 |2,299.88 ns    |  29.938 ns    |   4.633 ns   |  45.80   |  0.10   |  5   |         -           |        -         |0.1144  |  958 B    |     NA      |
| SumPersonIdsParallelFor             |2,355.54 ns    |  66.591 ns    |  17.294 ns   |  46.91   |  0.32   |  5   |     1.5586          |        -         |0.2937  |2,452 B    |     NA      |
| SemaphoreTest                       |2,702.70 ns    |  15.248 ns    |   3.960 ns   |  53.82   |  0.10   |  5   |         -           |        -         |  -     |    -      |     NA      |
| ReaderWriterLockSlimMixedOperations |2,886.26 ns    |  11.603 ns    |   3.013 ns   |  57.48   |  0.09   |  5   |         -           |        -         |0.1144  |  958 B    |     NA      |
| SumPersonIdsPlinq                   |9,373.88 ns    | 632.665 ns    | 164.301 ns   | 186.67   |  2.99   |  6   |     7.0000          |        -         |0.6561  |5,560 B    |     NA      |
| ProcessPeopleSync                   |16,887.02 ns   |  94.500 ns    |  14.624 ns   | 336.29   |  0.47   |  7   |         -           |        -         |  -     |    -      |     NA      |
| MutexTest                           |23,173.50 ns   | 301.486 ns    |  78.295 ns   | 461.48   |  1.52   |  8   |         -           |        -         |  -     |    -      |     NA      |
| ConcurrentDictionaryInsert          |106,364.11 ns  |15,018.008 ns  | 3,900.129 ns |2,118.17  | 70.94   |  9   |     9.0211          |      7.4116      |3.2959  |25,839 B   |     NA      |

### .NET SDK 6.0.428

| Method                              | Mean         | Error        | StdDev     | Ratio    | RatioSD | Rank | Completed Work Items | Lock Contentions | Gen0    | Allocated | Alloc Ratio |
|------------------------------------ |-------------:|-------------:|-----------:|---------:|--------:|-----:|---------------------:|-----------------:|--------:|----------:|------------:|
| **CpuBoundSync**                    |   63.41 ns   |   1.529 ns   | 0.397 ns   |   0.94   |  0.01   |  1   |         -           |        -         |   -     |    -      |      NA     |
| **SumPersonIdsSync**               |   67.51 ns   |   0.230 ns   | 0.060 ns   |   1.00   |  0.00   |  1   |         -           |        -         |   -     |    -      |      NA     |
| ProcessPeopleAsync                  |  215.28 ns   |   1.820 ns   | 0.282 ns   |   3.19   |  0.00   |  2   |         -           |        -         |   -     |    -      |      NA     |
| LockTest                            |  988.99 ns   |  10.931 ns   | 1.692 ns   |  14.65   |  0.03   |  3   |         -           |        -         |   -     |    -      |      NA     |
| CpuBoundAsync                       |1,760.35 ns   |  16.493 ns   | 2.552 ns   |  26.08   |  0.04   |  4   |     1.0005          |        -         |0.1373   |  288 B    |      NA     |
| LockMixedOperations                 |2,560.50 ns   |  12.232 ns   | 3.177 ns   |  37.93   |  0.05   |  5   |         -           |        -         |0.4578   |  958 B    |      NA     |
| SumPersonIdsParallelFor             |2,922.94 ns   | 252.473 ns   |65.566 ns   |  43.30   |  0.89   |  5   |     1.5068          |        -         |1.1864   |2,442 B    |      NA     |
| SemaphoreTest                       |2,991.79 ns   |  78.156 ns   |20.297 ns   |  44.32   |  0.28   |  5   |         -           |        -         |   -     |    -      |      NA     |
| ReaderWriterLockSlimMixedOperations |3,248.49 ns   |  32.367 ns   | 8.406 ns   |  48.12   |  0.12   |  5   |         -           |        -         |0.4578   |  958 B    |      NA     |
| SumPersonIdsPlinq                   |8,128.39 ns   |1,146.762 ns  |297.811 ns  | 120.41   |  4.03   |  6   |     7.0000          |        -         |2.7008   |5,560 B    |      NA     |
| ProcessPeopleSync                   |17,161.80 ns  | 241.763 ns   | 37.413 ns  | 254.22   |  0.53   |  7   |         -           |        -         |   -     |    -      |      NA     |
| MutexTest                           |23,899.91 ns  | 281.592 ns   | 43.577 ns  | 354.03   |  0.64   |  8   |         -           |        -         |   -     |    -      |      NA     |
| ConcurrentDictionaryInsert          |95,011.60 ns  |5,033.122 ns  |778.881 ns  |1,407.40  | 10.31   |  9   |     9.1206          |      6.2579      |13.9160  |25,977 B   |      NA     |

---

## 📊 **Analysis of Benchmark Results**

1. **Async vs. Sync**  
   - **Synchronous CPU-bound methods** (`CpuBoundSync`, `SumPersonIdsSync`) remain extremely fast (tens of nanoseconds).  
   - **`ProcessPeopleAsync`** (which simulates light I/O) scales up in cost relative to sync, reflecting async overhead but enabling non-blocking calls in real apps.  
   - **`CpuBoundAsync`** has significantly higher overhead than `CpuBoundSync`—common if you wrap CPU-bound loops in `Task.Run`.

2. **TPL Parallelization**  
   - **`SumPersonIdsParallelFor`** and **`SumPersonIdsPlinq`** can speed up large data processing but may introduce overhead for small data sets or on limited CPU cores.  
   - `SumPersonIdsPlinq` often shows bigger overhead due to partitioning, scheduling, and merges.

3. **Locks & Mutexes**  
   - **`LockTest`** is relatively faster than **`MutexTest`** due to lower kernel-level involvement.  
   - As concurrency or data size increases, the overhead of locking grows quickly.

4. **ReaderWriterLockSlim**  
   - **`ReaderWriterLockSlimMixedOperations`** can outperform a simple lock if reads far outnumber writes.  
   - If writes are frequent (or reads/writes interleave heavily), overhead can approach or exceed that of a regular lock.

5. **Concurrent Collections**  
   - **`ConcurrentDictionaryInsert`** is convenient but can become expensive under heavy contention, as seen in higher mean times and allocations.

---

## ⚠️ **Factors Influencing These Results**

- **CPU Architecture**: x64 vs. Arm64 can have different instruction sets (e.g., **AdvSIMD**).
- **Garbage Collector (GC)**: Large memory allocations or frequent GCs skew timing.  
- **OS Scheduling**: Windows, Linux, and macOS may handle thread pools differently.  
- **.NET Runtime Versions**: Each .NET release refines JIT compilation and concurrency runtime behaviors.

---

## 📝 **Summary of README and Analysis**

- **Introduced the purpose of benchmarking asynchronous and concurrency approaches** (async/await overhead, TPL data parallelism, locks, and concurrency primitives).
- **Displayed multiple .NET runtime results** (6, 7, 8, 9) side by side for **method performance** and **memory usage**.
- **Highlighted key findings**:  
  - Async overhead for CPU-bound tasks.  
  - Parallel/PLINQ partitioning overhead vs. potential gains.  
  - Lock contention and concurrency patterns matter for scaling.  
- **Provided real-world considerations** for environment differences and runtime optimizations.

These insights guide **informed decisions** on how to structure concurrent or asynchronous operations in .NET, balancing code clarity with performance.

---

Happy Benchmarking! Feel free to open an Issue or PR in the [Benchmarkus repo](https://github.com/barisozgenn/Benchmarkus) if you have additional scenarios or improvements to share. 

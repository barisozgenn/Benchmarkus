# LINQs Query Approaches Benchmarks

This project is part of the **Benchmarkus** repository and is dedicated to benchmarking **various LINQ and imperative approaches** in .NET. It measures **declarative (LINQ)** vs. **imperative loops**, **PLINQ**, **SpanLinq**, and **StructLinq**, alongside additional scenarios like **deferred execution** and **complex queries**. The goal is to shed light on **which approach** is better suited for different data-processing tasks based on performance, memory usage, and code clarity.

---

## Why We Do It
1. **Performance Insights**: Many applications rely on LINQ for readability, but sometimes raw loops or alternative libraries (SpanLinq, StructLinq) can be faster.  
2. **Parallelism vs. Sequential**: Compare PLINQ’s parallel overhead vs. manual loops, especially for CPU-bound tasks.  
3. **Memory Footprint**: Examine how each approach allocates memory differently, especially in large or complex queries.  
4. **Deferred Execution**: Highlight how multiple enumerations of the same LINQ query can impact real-world performance.

---

## What We Are Measuring
1. **Summation of Ages**  
   - **Imperative** loops vs. **LINQ** (sequential), **PLINQ**, **SpanLinq**, **StructLinq**.
2. **Filter & Select**  
   - Basic filtering on Person data, comparing LINQ vs. manual loops.  
3. **Complex Queries**  
   - Multiple operators (`Where`, `GroupBy`, `OrderBy`, `SelectMany`, `Skip`, `Take`) vs. equivalent imperative logic.
4. **Deferred Execution**  
   - Show the cost of re-enumerating the same query vs. caching (`ToList()`).

---

## Benchmark Results

Below are consolidated results for **.NET 10.0 Preview** and **.NET 9.0.101**. Tests were run with **IterationCount=5** and **WarmupCount=3**, measuring two input sizes (`N=10` and `N=500`). All times are in **nanoseconds (ns)** unless otherwise noted. Memory allocation is shown in bytes.

### .NET SDK 10.0.100-preview.1.25120.13
#### IterationCount=5  WarmupCount=3  

| Method                        | N   | Mean         | Error        | StdDev       | Ratio  | RatioSD | Rank | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------ |---- |-------------:|-------------:|-------------:|-------:|--------:|-----:|-------:|-------:|----------:|------------:|
| SumOfAges_Imperative          | 10  |     56.90 ns |     0.273 ns |     0.071 ns |   1.00 |    0.00 |    1 |      - |      - |         - |          NA |
| SumOfAges_SpanLinq            | 10  |     76.15 ns |    16.658 ns |     4.326 ns |   1.34 |    0.07 |    2 | 0.0229 |      - |     192 B |          NA |
| SumOfAges_StructLinq          | 10  |     79.16 ns |    15.600 ns |     4.051 ns |   1.39 |    0.07 |    2 | 0.0143 |      - |     120 B |          NA |
| FilterAndSelect_Imperative    | 10  |     94.14 ns |     4.121 ns |     1.070 ns |   1.65 |    0.02 |    2 | 0.0210 |      - |     176 B |          NA |
| SumOfAges_SequentialLinq      | 10  |    107.00 ns |     6.791 ns |     1.051 ns |   1.88 |    0.02 |    2 | 0.0191 |      - |     160 B |          NA |
| DeferredExecution_Cached_Linq | 10  |    167.05 ns |     0.326 ns |     0.085 ns |   2.94 |    0.00 |    3 | 0.0296 |      - |     248 B |          NA |
| FilterAndSum_Imperative       | 10  |    171.66 ns |     3.415 ns |     0.529 ns |   3.02 |    0.01 |    3 |      - |      - |         - |          NA |
| FilterAndSum_SpanLinq         | 10  |    197.29 ns |     0.260 ns |     0.040 ns |   3.47 |    0.00 |    3 | 0.0305 |      - |     256 B |          NA |
| DeferredExecution_Linq        | 10  |    261.58 ns |     4.717 ns |     1.225 ns |   4.60 |    0.02 |    4 | 0.0181 |      - |     152 B |          NA |
| FilterAndSum_StructLinq       | 10  |    264.21 ns |     4.028 ns |     0.623 ns |   4.64 |    0.01 |    4 | 0.0334 |      - |     280 B |          NA |
| AdvancedQuery_Imperative      | 10  |    273.54 ns |     2.574 ns |     0.398 ns |   4.81 |    0.01 |    4 | 0.1664 |      - |    1392 B |          NA |
| FilterAndSum_SequentialLinq   | 10  |    276.83 ns |     8.238 ns |     2.139 ns |   4.86 |    0.03 |    4 | 0.0563 |      - |     472 B |          NA |
| FilterAndSelect_Linq          | 10  |    509.62 ns |     4.945 ns |     0.765 ns |   8.96 |    0.02 |    5 | 0.0315 |      - |     264 B |          NA |
| ComplexQuery_Imperative       | 10  |    818.59 ns |    14.864 ns |     3.860 ns |  14.39 |    0.06 |    6 | 0.2117 |      - |    1776 B |          NA |
| ComplexQuery_Linq             | 10  |  1,421.34 ns |    11.794 ns |     3.063 ns |  24.98 |    0.06 |    7 | 0.3166 |      - |    2664 B |          NA |
| SumOfAges_PLINQ               | 10  |  9,186.57 ns | 3,933.573 ns | 1,021.536 ns | 161.44 |   16.39 |    8 | 0.6561 |      - |    5512 B |          NA |
| FilterAndSum_PLINQ            | 10  |  9,444.01 ns | 3,313.085 ns |   860.398 ns | 165.96 |   13.80 |    8 | 0.9155 |      - |    7704 B |          NA |
|                               |     |              |              |              |        |         |      |        |        |           |             |
| SumOfAges_Imperative          | 500 |    801.27 ns |     6.563 ns |     1.704 ns |   1.00 |    0.00 |    1 |      - |      - |         - |          NA |
| SumOfAges_SpanLinq            | 500 |    980.86 ns |     2.044 ns |     0.531 ns |   1.22 |    0.00 |    1 | 0.4902 |      - |    4112 B |          NA |
| SumOfAges_StructLinq          | 500 |    997.67 ns |     3.991 ns |     1.036 ns |   1.25 |    0.00 |    1 | 0.0134 |      - |     120 B |          NA |
| FilterAndSelect_Imperative    | 500 |  1,506.41 ns |    19.587 ns |     5.087 ns |   1.88 |    0.01 |    2 | 1.0014 |      - |    8384 B |          NA |
| SumOfAges_SequentialLinq      | 500 |  1,533.06 ns |     3.137 ns |     0.815 ns |   1.91 |    0.00 |    2 | 0.0191 |      - |     160 B |          NA |
| DeferredExecution_Cached_Linq | 500 |  6,101.25 ns |    25.315 ns |     3.918 ns |   7.61 |    0.02 |    3 | 0.2594 |      - |    2208 B |          NA |
| FilterAndSum_Imperative       | 500 |  6,600.53 ns |   123.006 ns |    31.944 ns |   8.24 |    0.04 |    3 |      - |      - |         - |          NA |
| FilterAndSum_SpanLinq         | 500 |  7,002.13 ns |   151.106 ns |    39.242 ns |   8.74 |    0.05 |    3 | 0.4959 |      - |    4176 B |          NA |
| FilterAndSum_StructLinq       | 500 |  8,216.63 ns |    29.033 ns |     7.540 ns |  10.25 |    0.02 |    3 | 0.0305 |      - |     280 B |          NA |
| FilterAndSum_SequentialLinq   | 500 |  8,286.10 ns |   233.785 ns |    60.713 ns |  10.34 |    0.07 |    3 | 0.0458 |      - |     472 B |          NA |
| FilterAndSum_PLINQ            | 500 | 11,636.92 ns |   252.890 ns |    39.135 ns |  14.52 |    0.05 |    4 | 0.9155 |      - |    7704 B |          NA |
| DeferredExecution_Linq        | 500 | 11,794.47 ns |    84.248 ns |    21.879 ns |  14.72 |    0.04 |    4 | 0.0153 |      - |     152 B |          NA |
| SumOfAges_PLINQ               | 500 | 13,428.24 ns |   302.293 ns |    78.505 ns |  16.76 |    0.10 |    4 | 0.6561 |      - |    5512 B |          NA |
| FilterAndSelect_Linq          | 500 | 23,482.51 ns |   132.855 ns |    34.502 ns |  29.31 |    0.07 |    5 | 0.3357 |      - |    3040 B |          NA |
| AdvancedQuery_Imperative      | 500 | 24,574.73 ns |   188.985 ns |    49.079 ns |  30.67 |    0.08 |    5 | 5.9204 | 0.2441 |   49608 B |          NA |
| ComplexQuery_Imperative       | 500 | 34,316.90 ns |    81.320 ns |    12.584 ns |  42.83 |    0.08 |    6 | 7.6294 |      - |   63984 B |          NA |
| ComplexQuery_Linq             | 500 | 50,073.59 ns |   309.011 ns |    47.820 ns |  62.49 |    0.13 |    7 | 8.6670 | 0.1221 |   72928 B |          NA |
| AdvancedQuery_Linq            | 500 | 75,119.68 ns |   581.943 ns |   151.129 ns |  93.75 |    0.25 |    8 | 6.8359 | 0.2441 |   57784 B |          NA |

---

### .NET SDK 9.0.101
#### IterationCount=5  WarmupCount=3  

| Method                        | N   | Mean         | Error        | StdDev       | Ratio  | RatioSD | Rank | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------ |---- |-------------:|-------------:|-------------:|-------:|--------:|-----:|-------:|-------:|----------:|------------:|
| SumOfAges_Imperative          | 10  |     56.67 ns |     0.212 ns |     0.055 ns |   1.00 |    0.00 |    1 |      - |      - |         - |          NA |
| SumOfAges_StructLinq          | 10  |     68.99 ns |     0.609 ns |     0.094 ns |   1.22 |    0.00 |    1 | 0.0143 |      - |     120 B |          NA |
| SumOfAges_SpanLinq            | 10  |     72.19 ns |     0.164 ns |     0.025 ns |   1.27 |    0.00 |    1 | 0.0229 |      - |     192 B |          NA |
| SumOfAges_SequentialLinq      | 10  |    104.74 ns |     1.089 ns |     0.283 ns |   1.85 |    0.00 |    2 | 0.0191 |      - |     160 B |          NA |
| FilterAndSelect_Imperative    | 10  |    109.40 ns |     4.169 ns |     0.645 ns |   1.93 |    0.01 |    2 | 0.0210 |      - |     176 B |          NA |
| DeferredExecution_Cached_Linq | 10  |    168.81 ns |     0.992 ns |     0.153 ns |   2.98 |    0.00 |    3 | 0.0296 |      - |     248 B |          NA |
| FilterAndSum_Imperative       | 10  |    173.65 ns |     2.837 ns |     0.737 ns |   3.06 |    0.01 |    3 |      - |      - |         - |          NA |
| FilterAndSum_SpanLinq         | 10  |    198.35 ns |     0.459 ns |     0.119 ns |   3.50 |    0.00 |    3 | 0.0305 |      - |     256 B |          NA |
| FilterAndSum_StructLinq       | 10  |    265.49 ns |     1.624 ns |     0.251 ns |   4.68 |    0.01 |    4 | 0.0334 |      - |     280 B |          NA |
| DeferredExecution_Linq        | 10  |    270.78 ns |     8.040 ns |     2.088 ns |   4.78 |    0.03 |    4 | 0.0181 |      - |     152 B |          NA |
| FilterAndSum_SequentialLinq   | 10  |    279.64 ns |     2.991 ns |     0.463 ns |   4.93 |    0.01 |    4 | 0.0563 |      - |     472 B |          NA |
| AdvancedQuery_Imperative      | 10  |    287.24 ns |     2.480 ns |     0.644 ns |   5.07 |    0.01 |    4 | 0.1664 |      - |    1392 B |          NA |
| FilterAndSelect_Linq          | 10  |    530.66 ns |     3.141 ns |     0.816 ns |   9.36 |    0.02 |    5 | 0.0315 |      - |     264 B |          NA |
| ComplexQuery_Imperative       | 10  |    817.27 ns |     2.943 ns |     0.764 ns |  14.42 |    0.02 |    6 | 0.2117 |      - |    1776 B |          NA |
| ComplexQuery_Linq             | 10  |  1,400.32 ns |     2.207 ns |     0.573 ns |  24.71 |    0.02 |    7 | 0.3166 |      - |    2664 B |          NA |
| FilterAndSum_PLINQ            | 10  |  6,016.54 ns |   220.747 ns |    57.327 ns | 106.16 |    0.93 |    8 | 0.9155 |      - |    7704 B |          NA |
| SumOfAges_PLINQ               | 10  |  7,479.77 ns | 8,259.104 ns | 2,144.863 ns | 131.98 |   34.55 |    9 | 0.6561 |      - |    5512 B |          NA |
|                               |     |              |              |              |        |         |      |        |        |           |             |
| SumOfAges_StructLinq          | 500 |    767.42 ns |     1.727 ns |     0.267 ns |   0.97 |    0.00 |    1 | 0.0143 |      - |     120 B |          NA |
| SumOfAges_Imperative          | 500 |    792.30 ns |     6.934 ns |     1.801 ns |   1.00 |    0.00 |    1 |      - |      - |         - |          NA |
| SumOfAges_SpanLinq            | 500 |  1,000.36 ns |     3.253 ns |     0.503 ns |   1.26 |    0.00 |    2 | 0.4902 |      - |    4112 B |          NA |
| FilterAndSelect_Imperative    | 500 |  1,533.83 ns |    35.359 ns |     5.472 ns |   1.94 |    0.01 |    3 | 1.0014 |      - |    8384 B |          NA |
| SumOfAges_SequentialLinq      | 500 |  1,586.66 ns |     2.019 ns |     0.313 ns |   2.00 |    0.00 |    3 | 0.0191 |      - |     160 B |          NA |
| DeferredExecution_Cached_Linq | 500 |  6,480.15 ns |    40.254 ns |    10.454 ns |   8.18 |    0.02 |    4 | 0.2594 |      - |    2208 B |          NA |
| FilterAndSum_SpanLinq         | 500 |  7,159.36 ns |    19.189 ns |     2.970 ns |   9.04 |    0.02 |    4 | 0.4959 |      - |    4176 B |          NA |
| FilterAndSum_Imperative       | 500 |  7,265.35 ns |    46.730 ns |     7.231 ns |   9.17 |    0.02 |    4 |      - |      - |         - |          NA |
| FilterAndSum_StructLinq       | 500 |  8,518.79 ns |   263.193 ns |    68.350 ns |  10.75 |    0.08 |    4 | 0.0305 |      - |     280 B |          NA |
| FilterAndSum_SequentialLinq   | 500 |  8,534.37 ns |    73.721 ns |    11.408 ns |  10.77 |    0.03 |    4 | 0.0458 |      - |     472 B |          NA |
| DeferredExecution_Linq        | 500 | 11,795.97 ns |    15.904 ns |     4.130 ns |  14.89 |    0.03 |    5 | 0.0153 |      - |     152 B |          NA |
| FilterAndSum_PLINQ            | 500 | 13,659.90 ns | 1,219.669 ns |   316.744 ns |  17.24 |    0.37 |    5 | 0.9155 |      - |    7704 B |          NA |
| SumOfAges_PLINQ               | 500 | 16,671.78 ns |   579.517 ns |    89.681 ns |  21.04 |    0.11 |    5 | 0.6638 |      - |    5512 B |          NA |
| FilterAndSelect_Linq          | 500 | 23,405.58 ns |    38.136 ns |     5.902 ns |  29.54 |    0.06 |    6 | 0.3357 |      - |    3040 B |          NA |
| AdvancedQuery_Imperative      | 500 | 25,436.24 ns |   179.685 ns |    46.664 ns |  32.10 |    0.09 |    6 | 5.9204 | 0.2441 |   49608 B |          NA |
| ComplexQuery_Imperative       | 500 | 34,681.14 ns |   108.622 ns |    28.209 ns |  43.77 |    0.10 |    7 | 7.6294 |      - |   63984 B |          NA |
| ComplexQuery_Linq             | 500 | 50,122.99 ns |   321.200 ns |    83.415 ns |  63.26 |    0.16 |    8 | 8.6670 | 0.1221 |   72928 B |          NA |
| AdvancedQuery_Linq            | 500 | 75,100.02 ns |   220.787 ns |    34.167 ns |  94.79 |    0.20 |    9 | 6.8359 | 0.2441 |   57784 B |          NA |

---

## Observations & Analysis

1. **Imperative Loops**  
   - Often the **fastest** or near the fastest with **lowest allocations** (especially for small data sets).  
   - Straight loops excel at CPU-bound tasks if parallelization overhead isn’t worth it.

2. **SpanLinq / StructLinq**  
   - Both aim for low-allocation, faster-than-LINQ patterns.  
   - **SpanLinq** can have more memory usage if you must `.ToArray()` first.  
   - **StructLinq** typically uses minimal memory but can be slightly slower than SpanLinq in certain cases (or vice versa). Real results vary per scenario.

3. **Sequential LINQ (System.Linq)**  
   - More **allocations** due to enumerators/delegates and typical deferred execution overhead.  
   - Readable but can be **1.5–2x slower** in tight loops.

4. **PLINQ (Parallel LINQ)**  
   - Faster for **large** CPU-bound tasks, but overhead can overshadow benefits for small or mid-size input (N=10 or N=500).  
   - In these benchmarks, PLINQ is often **~10–100x** slower for moderate input sizes due to scheduling overhead.

5. **Deferred Execution**  
   - Re-enumerating a LINQ query multiple times can **significantly** inflate time and allocations.  
   - Caching results (`ToList()`) typically reduces repeated overhead at the cost of some memory.

6. **Complex Queries**  
   - The more operators (e.g., `GroupBy`, `SelectMany`, `Join`), the more overhead a LINQ approach can accumulate.  
   - Imperative approaches often still run faster and allocate less, but the code is more verbose.

---

## Recommendations

1. **Favor Imperative Loops** for **simple** or **critical** CPU-bound tasks if performance is paramount.
2. For advanced or large-scale queries, evaluate **SpanLinq** or **StructLinq** to reduce allocations and potentially improve speed.
3. **Use PLINQ** only when you have **large data** sets, purely CPU-bound operations, and the overhead of creating parallel tasks is offset by multi-core speedups.
4. **Cache** your LINQ queries (`.ToList()`, `.ToArray()`) if you plan to iterate them multiple times; otherwise, you’ll pay for repeated deferred execution.
5. If **readability** is more important than micro-optimizations, standard LINQ is perfectly acceptable, especially for smaller data sets.

---

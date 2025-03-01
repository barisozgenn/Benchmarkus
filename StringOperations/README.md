# StringOperations Benchmarks

This project is part of the **Benchmarkus** repository and is dedicated to benchmarking various string operations in .NET. It uses [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) to measure the performance and memory allocations of common string methods, helping developers understand the trade-offs between different approaches.

## Why We Do It

- **Performance Insights**: Evaluate how different string operations perform, especially in terms of execution time and memory usage.
- **Understanding Immutability**: Analyze the cost of repeated concatenations with immutable strings versus using a mutable approach (StringBuilder).
- **Real-World Scenarios**: Compare everyday operations such as concatenation, substring extraction, search, join/split, and additional operations like replace, to upper case, and trim.

## What We Can Learn

1. **Concatenation Techniques**:  
   - Using the `+` operator  
   - Using `string.Concat`  
   - Using string interpolation  
   - Using `StringBuilder`  
   
2. **Substring Extraction**:  
   - Using `Substring`  
   - Using the C# range operator

3. **Search Operations**:  
   - Using `IndexOf`  
   - Using `Contains`

4. **Join and Split**:  
   - Joining arrays of strings  
   - Splitting a long string into substrings

5. **Mutable vs. Immutable Concatenation**:  
   - Repeated concatenation with `+` vs. using `StringBuilder`

6. **Additional Operations**:  
   - Replacing substrings  
   - Converting to uppercase  
   - Trimming whitespace

## Benchmark Results (Placeholder)

Below are **example** tables for different .NET versions. Update these tables with your **actual** benchmark results after running `dotnet run --configuration Release`.

### .NET 6.0.428
##### IterationCount=5  WarmupCount=3
| Method                              | Mean           | Error          | StdDev        | Ratio    | RatioSD | Rank | Gen0      | Gen1    | Gen2    | Allocated | Alloc Ratio |
|------------------------------------ |---------------:|---------------:|--------------:|---------:|--------:|-----:|----------:|--------:|--------:|----------:|------------:|
| StringContains                      |       8.585 ns |      0.1005 ns |     0.0261 ns |     0.05 |    0.00 |    1 |         - |       - |       - |         - |        0.00 |
| SubstringExtraction                 |      14.920 ns |      0.4097 ns |     0.0634 ns |     0.08 |    0.00 |    2 |    0.1071 |       - |       - |     224 B |        1.12 |
| RangeExtraction                     |      15.183 ns |      0.8575 ns |     0.1327 ns |     0.08 |    0.00 |    2 |    0.1071 |       - |       - |     224 B |        1.12 |
| StringTrimBenchmark                 |      28.187 ns |      0.8620 ns |     0.1334 ns |     0.15 |    0.00 |    3 |    0.0535 |       - |       - |     112 B |        0.56 |
| StringIndexOf                       |      36.346 ns |      0.6976 ns |     0.1079 ns |     0.20 |    0.00 |    4 |         - |       - |       - |         - |        0.00 |
| JoinStrings                         |      44.655 ns |      0.9693 ns |     0.2517 ns |     0.24 |    0.00 |    4 |    0.0612 |       - |       - |     128 B |        0.64 |
| ConcatWithPlus                      |     183.096 ns |      1.4867 ns |     0.2301 ns |     1.00 |    0.00 |    5 |    0.0956 |       - |       - |     200 B |        1.00 |
| ConcatWithInterpolation             |     205.167 ns |      0.7712 ns |     0.1193 ns |     1.12 |    0.00 |    5 |    0.0994 |       - |       - |     208 B |        1.04 |
| ConcatWithStringConcat              |     210.390 ns |      1.9118 ns |     0.4965 ns |     1.15 |    0.00 |    5 |    0.1261 |       - |       - |     264 B |        1.32 |
| ConcatWithStringBuilder             |     244.057 ns |      4.0564 ns |     0.6277 ns |     1.33 |    0.00 |    5 |    0.2103 |       - |       - |     440 B |        2.20 |
| ManyConcatenationsWithStringBuilder |   6,370.066 ns |    125.7754 ns |    32.6635 ns |    34.79 |    0.17 |    6 |    7.1259 |       - |       - |   14904 B |       74.52 |
| StringToUpperBenchmark              |  20,678.283 ns |    605.6841 ns |    93.7303 ns |   112.94 |    0.48 |    7 |   28.5645 | 28.5645 | 28.5645 |   90043 B |      450.21 |
| StringReplaceBenchmark              |  23,897.092 ns |    344.8119 ns |    53.3600 ns |   130.52 |    0.30 |    7 |   28.5645 | 28.5645 | 28.5645 |   90053 B |      450.26 |
| SplitString                         | 108,327.075 ns |  1,723.1591 ns |   266.6608 ns |   591.64 |    1.46 |    8 |  166.3818 |       - |       - |  360032 B |    1,800.16 |
| ManyConcatenations                  | 185,089.986 ns | 11,520.9058 ns | 2,991.9426 ns | 1,010.89 |   15.04 |    9 | 1361.5723 |       - |       - | 2849736 B |   14,248.68 |
### .NET 7.0.410
##### IterationCount=5  WarmupCount=3
| Method                              | Mean           | Error       | StdDev      | Ratio  | RatioSD | Rank | Gen0     | Gen1    | Gen2    | Allocated | Alloc Ratio |
|------------------------------------ |---------------:|------------:|------------:|-------:|--------:|-----:|---------:|--------:|--------:|----------:|------------:|
| StringContains                      |       9.381 ns |   0.6034 ns |   0.1567 ns |   0.06 |    0.00 |    1 |        - |       - |       - |         - |        0.00 |
| RangeExtraction                     |      10.893 ns |   1.1528 ns |   0.1784 ns |   0.07 |    0.00 |    1 |   0.0268 |       - |       - |     224 B |        1.12 |
| SubstringExtraction                 |      10.948 ns |   1.8077 ns |   0.4695 ns |   0.07 |    0.00 |    1 |   0.0268 |       - |       - |     224 B |        1.12 |
| StringTrimBenchmark                 |      24.088 ns |   0.2423 ns |   0.0629 ns |   0.15 |    0.00 |    2 |   0.0134 |       - |       - |     112 B |        0.56 |
| StringIndexOf                       |      31.124 ns |  14.9532 ns |   2.3140 ns |   0.19 |    0.01 |    3 |        - |       - |       - |         - |        0.00 |
| JoinStrings                         |      44.244 ns |   0.4363 ns |   0.0675 ns |   0.28 |    0.00 |    4 |   0.0153 |       - |       - |     128 B |        0.64 |
| ConcatWithPlus                      |     160.552 ns |   2.0889 ns |   0.3233 ns |   1.00 |    0.00 |    5 |   0.0238 |       - |       - |     200 B |        1.00 |
| ConcatWithInterpolation             |     182.136 ns |   3.7578 ns |   0.9759 ns |   1.13 |    0.01 |    5 |   0.0248 |       - |       - |     208 B |        1.04 |
| ConcatWithStringConcat              |     195.672 ns |  20.7478 ns |   3.2107 ns |   1.22 |    0.02 |    5 |   0.0315 |       - |       - |     264 B |        1.32 |
| ConcatWithStringBuilder             |     199.683 ns |   1.3628 ns |   0.2109 ns |   1.24 |    0.00 |    5 |   0.0525 |       - |       - |     440 B |        2.20 |
| ManyConcatenationsWithStringBuilder |   4,955.768 ns | 108.6230 ns |  28.2090 ns |  30.87 |    0.17 |    6 |   1.7776 |  0.0153 |       - |   14904 B |       74.52 |
| StringToUpperBenchmark              |  19,396.327 ns |  80.3474 ns |  12.4339 ns | 120.81 |    0.23 |    7 |  28.5645 | 28.5645 | 28.5645 |   90043 B |      450.21 |
| StringReplaceBenchmark              |  27,132.653 ns | 115.7778 ns |  30.0671 ns | 169.00 |    0.35 |    8 |  28.5645 | 28.5645 | 28.5645 |   90053 B |      450.26 |
| SplitString                         |  77,235.779 ns | 342.7267 ns |  89.0050 ns | 481.07 |    1.00 |    9 |  42.9688 | 10.7422 |       - |  360032 B |    1,800.16 |
| ManyConcatenations                  | 138,437.403 ns | 788.3734 ns | 122.0016 ns | 862.26 |    1.70 |   10 | 340.5762 |  1.9531 |       - | 2849736 B |   14,248.68 |
### .NET 8.0.404
##### IterationCount=5  WarmupCount=3
| Method                              | Mean           | Error         | StdDev      | Ratio  | RatioSD | Rank | Gen0     | Gen1     | Gen2    | Allocated | Alloc Ratio |
|------------------------------------ |---------------:|--------------:|------------:|-------:|--------:|-----:|---------:|---------:|--------:|----------:|------------:|
| StringContains                      |       7.941 ns |     0.0464 ns |   0.0072 ns |   0.06 |    0.00 |    1 |        - |        - |       - |         - |        0.00 |
| SubstringExtraction                 |      10.558 ns |     0.1698 ns |   0.0263 ns |   0.08 |    0.00 |    2 |   0.0268 |        - |       - |     224 B |        1.12 |
| RangeExtraction                     |      10.568 ns |     0.1772 ns |   0.0460 ns |   0.08 |    0.00 |    2 |   0.0268 |        - |       - |     224 B |        1.12 |
| StringTrimBenchmark                 |      20.920 ns |     0.1821 ns |   0.0282 ns |   0.15 |    0.00 |    3 |   0.0134 |        - |       - |     112 B |        0.56 |
| StringIndexOf                       |      28.117 ns |     0.0621 ns |   0.0096 ns |   0.20 |    0.00 |    4 |        - |        - |       - |         - |        0.00 |
| JoinStrings                         |      36.316 ns |     0.5058 ns |   0.1314 ns |   0.26 |    0.00 |    5 |   0.0153 |        - |       - |     128 B |        0.64 |
| ConcatWithPlus                      |     138.766 ns |     0.6341 ns |   0.1647 ns |   1.00 |    0.00 |    6 |   0.0238 |        - |       - |     200 B |        1.00 |
| ConcatWithStringConcat              |     160.143 ns |     0.8082 ns |   0.1251 ns |   1.15 |    0.00 |    6 |   0.0315 |        - |       - |     264 B |        1.32 |
| ConcatWithInterpolation             |     161.138 ns |    21.3590 ns |   5.5469 ns |   1.16 |    0.04 |    6 |   0.0248 |        - |       - |     208 B |        1.04 |
| ConcatWithStringBuilder             |     169.300 ns |     1.8646 ns |   0.2886 ns |   1.22 |    0.00 |    6 |   0.0525 |        - |       - |     440 B |        2.20 |
| ManyConcatenationsWithStringBuilder |   3,335.296 ns |    72.2405 ns |  18.7606 ns |  24.04 |    0.13 |    7 |   1.7586 |   0.0153 |       - |   14712 B |       73.56 |
| StringToUpperBenchmark              |  15,301.067 ns |   511.3905 ns | 132.8065 ns | 110.27 |    0.88 |    8 | 149.9634 | 149.9634 | 24.9939 |   90041 B |      450.20 |
| StringReplaceBenchmark              |  30,989.075 ns | 1,104.9703 ns | 170.9954 ns | 223.32 |    1.12 |    9 | 149.7803 | 149.7803 | 24.9634 |   90181 B |      450.90 |
| SplitString                         |  74,901.426 ns |   421.6540 ns | 109.5022 ns | 539.77 |    0.93 |   10 |  42.9688 |   0.1221 |       - |  360048 B |    1,800.24 |
| ManyConcatenations                  | 134,367.521 ns |   802.4245 ns | 124.1761 ns | 968.31 |    1.32 |   11 | 339.3555 |   1.7090 |       - | 2840456 B |   14,202.28 |
### .NET 9.0.101
##### IterationCount=5  WarmupCount=3
| Method                              | Mean           | Error         | StdDev      | Ratio  | RatioSD | Rank | Gen0     | Gen1    | Gen2    | Allocated | Alloc Ratio |
|------------------------------------ |---------------:|--------------:|------------:|-------:|--------:|-----:|---------:|--------:|--------:|----------:|------------:|
| StringContains                      |       7.647 ns |     0.1744 ns |   0.0270 ns |   0.06 |    0.00 |    1 |        - |       - |       - |         - |        0.00 |
| SubstringExtraction                 |      10.988 ns |     0.2378 ns |   0.0618 ns |   0.08 |    0.00 |    2 |   0.0268 |       - |       - |     224 B |        1.12 |
| RangeExtraction                     |      11.019 ns |     0.1657 ns |   0.0256 ns |   0.08 |    0.00 |    2 |   0.0268 |       - |       - |     224 B |        1.12 |
| StringTrimBenchmark                 |      21.127 ns |     0.2794 ns |   0.0432 ns |   0.16 |    0.00 |    3 |   0.0134 |       - |       - |     112 B |        0.56 |
| StringIndexOf                       |      26.384 ns |     0.0639 ns |   0.0166 ns |   0.20 |    0.00 |    3 |        - |       - |       - |         - |        0.00 |
| JoinStrings                         |      34.786 ns |     0.4201 ns |   0.0650 ns |   0.26 |    0.00 |    4 |   0.0153 |       - |       - |     128 B |        0.64 |
| ConcatWithPlus                      |     131.969 ns |     7.0382 ns |   1.0892 ns |   1.00 |    0.01 |    5 |   0.0238 |       - |       - |     200 B |        1.00 |
| ConcatWithInterpolation             |     144.443 ns |     8.5091 ns |   1.3168 ns |   1.09 |    0.01 |    5 |   0.0248 |       - |       - |     208 B |        1.04 |
| ConcatWithStringConcat              |     144.630 ns |     2.3633 ns |   0.6137 ns |   1.10 |    0.01 |    5 |   0.0238 |       - |       - |     200 B |        1.00 |
| ConcatWithStringBuilder             |     172.577 ns |     1.5380 ns |   0.3994 ns |   1.31 |    0.01 |    5 |   0.0525 |       - |       - |     440 B |        2.20 |
| ManyConcatenationsWithStringBuilder |   3,506.442 ns |   137.4220 ns |  21.2662 ns |  26.57 |    0.24 |    6 |   1.7586 |  0.0153 |       - |   14712 B |       73.56 |
| StringToUpperBenchmark              |   9,569.152 ns |   104.4980 ns |  16.1712 ns |  72.51 |    0.54 |    7 |  28.5645 | 28.5645 | 28.5645 |   90043 B |      450.21 |
| StringReplaceBenchmark              |  25,250.623 ns |   113.7135 ns |  29.5310 ns | 191.35 |    1.41 |    8 |  28.5645 | 28.5645 | 28.5645 |   90053 B |      450.26 |
| SplitString                         |  77,053.460 ns |   591.1775 ns |  91.4854 ns | 583.91 |    4.34 |    9 |  42.9688 | 10.7422 |       - |  360032 B |    1,800.16 |
| ManyConcatenations                  | 125,517.283 ns | 1,309.1108 ns | 339.9719 ns | 951.16 |    7.34 |   10 | 339.3555 |       - |       - | 2840456 B |   14,202.28 |
### .NET SDK 10.0.100-preview.1.25120.13
##### IterationCount=5  WarmupCount=3
| Method                              | Mean           | Error       | StdDev     | Ratio    | RatioSD | Rank | Gen0     | Gen1    | Gen2    | Allocated | Alloc Ratio |
|------------------------------------ |---------------:|------------:|-----------:|---------:|--------:|-----:|---------:|--------:|--------:|----------:|------------:|
| StringContains                      |       7.175 ns |   0.0084 ns |  0.0013 ns |     0.06 |    0.00 |    1 |        - |       - |       - |         - |        0.00 |
| SubstringExtraction                 |      11.155 ns |   1.3219 ns |  0.2046 ns |     0.09 |    0.00 |    2 |   0.0268 |       - |       - |     224 B |        1.12 |
| RangeExtraction                     |      11.160 ns |   0.1857 ns |  0.0482 ns |     0.09 |    0.00 |    2 |   0.0268 |       - |       - |     224 B |        1.12 |
| StringTrimBenchmark                 |      21.603 ns |   0.6026 ns |  0.1565 ns |     0.17 |    0.00 |    3 |   0.0134 |       - |       - |     112 B |        0.56 |
| StringIndexOf                       |      26.523 ns |   0.0405 ns |  0.0063 ns |     0.21 |    0.00 |    3 |        - |       - |       - |         - |        0.00 |
| JoinStrings                         |      34.882 ns |   0.1655 ns |  0.0256 ns |     0.28 |    0.00 |    4 |   0.0153 |       - |       - |     128 B |        0.64 |
| ConcatWithPlus                      |     125.284 ns |   4.5074 ns |  0.6975 ns |     1.00 |    0.01 |    5 |   0.0238 |       - |       - |     200 B |        1.00 |
| ConcatWithInterpolation             |     139.542 ns |   2.1419 ns |  0.3315 ns |     1.11 |    0.01 |    5 |   0.0248 |       - |       - |     208 B |        1.04 |
| ConcatWithStringConcat              |     140.654 ns |   3.5798 ns |  0.9296 ns |     1.12 |    0.01 |    5 |   0.0238 |       - |       - |     200 B |        1.00 |
| ConcatWithStringBuilder             |     158.137 ns |   2.2946 ns |  0.5959 ns |     1.26 |    0.01 |    5 |   0.0525 |       - |       - |     440 B |        2.20 |
| ManyConcatenationsWithStringBuilder |   3,418.972 ns | 176.9926 ns | 45.9644 ns |    27.29 |    0.36 |    6 |   1.7586 |  0.0153 |       - |   14712 B |       73.56 |
| StringToUpperBenchmark              |   9,456.216 ns |  41.9924 ns |  6.4984 ns |    75.48 |    0.38 |    7 |  28.5645 | 28.5645 | 28.5645 |   90043 B |      450.21 |
| StringReplaceBenchmark              |  25,294.098 ns | 467.3835 ns | 72.3281 ns |   201.90 |    1.13 |    8 |  28.5645 | 28.5645 | 28.5645 |   90053 B |      450.26 |
| SplitString                         |  77,755.150 ns | 181.9267 ns | 47.2458 ns |   620.65 |    3.09 |    9 |  42.9688 | 10.7422 |       - |  360032 B |    1,800.16 |
| ManyConcatenations                  | 128,989.863 ns | 268.7170 ns | 69.7850 ns | 1,029.61 |    5.12 |   10 | 339.3555 |  1.7090 |       - | 2840456 B |   14,202.28 |

---

### Observations & Analysis

Based on the benchmark results across different .NET versions, we can observe several key insights regarding string performance:

#### 1. **Fastest Operations**
   - **`StringContains` is the fastest operation** in all tested versions, with an average execution time of **~8 ns**. This is expected, as `Contains` is internally optimized using `IndexOf` and does not create new string objects.
   - **Substring extraction (`Substring` & `Range`)** is also very fast (~10-15 ns). Both approaches allocate memory (~224 B), but the difference in execution time is negligible.

#### 2. **Concatenation Performance**
   - **Using `+` (Plus Operator) is the baseline for comparison.**  
     - In .NET 9, it took **~132 ns**.
   - **`string.Concat` is slightly better (~1-10% improvement).**  
     - In .NET 9, it took **~144 ns**, similar to interpolation.
   - **String interpolation (`$""`) introduces a minor overhead (~1.09x).**  
     - In .NET 9, it took **~144 ns**.
   - **Using `StringBuilder` is slower for small concatenations (~1.3x slower than `+`).**  
     - For small cases, `StringBuilder`'s additional method calls and object creation cause it to be **slower** than `+` and `Concat`.

#### 3. **StringBuilder Performance for Large Concatenations**
   - When performing **many concatenations in a loop**, `StringBuilder` drastically **outperforms** normal string concatenation.
     - `ManyConcatenationsWithStringBuilder` in .NET 9 took **~3,500 ns**, whereas direct concatenation (`ManyConcatenations`) took **~125,000 ns**.
     - This is **35x** faster than direct string concatenation.

#### 4. **Memory Allocation Trends**
   - **Concatenation with `+`, `Concat`, and Interpolation allocate a small amount of memory (~200-264 B).**
   - **`StringBuilder` uses more memory (~440 B per operation) but is better for loops.**
   - **For large concatenations, `ManyConcatenations` allocated ~2.8 MB, whereas `ManyConcatenationsWithStringBuilder` allocated only 14 KB, making it ~200x more memory-efficient.**
   - **String transformation functions like `ToUpper` and `Replace` are extremely expensive in both time and memory.**
     - `ToUpper` and `Replace` allocate **~90 KB per call**.

#### 5. **Expensive Operations**
   - **Splitting strings (`SplitString`) is costly** due to the overhead of allocating multiple string objects.
     - It took **~77,000 ns** in .NET 9 and allocated **360 KB** per call.
   - **`ToUpper` and `Replace` have significant memory overhead (~90 KB allocations).**
   - **Repeated concatenation using `+` in a loop (`ManyConcatenations`) is disastrous.**
     - In .NET 9, it was **950x slower** than simple concatenation and used **14 MB more memory**.

---

### General Recommendations

- **Use `+` or `string.Concat` for short concatenations (≤5 items).**
- **Avoid direct concatenation in loops. Instead, use `StringBuilder`.**
- **For large text manipulations, avoid `Replace` or `ToUpper` unless necessary due to their high allocation cost.**
- **Minimize `string.Split` usage, especially on large text data, since it leads to high memory fragmentation.**
- **Substring operations (`Substring` and `Range`) are efficient but still allocate memory.**
- **For high-performance, memory-efficient scenarios, prefer `Span<char>` for string manipulations (not benchmarked here).**

---

### Conclusion

- **String operations in .NET are highly optimized, but misuse can lead to significant performance hits.**
- **Understanding immutability is crucial**—modifying a string repeatedly creates **new objects in memory**, causing unnecessary allocations.
- **Always measure your use case.** For small, occasional operations, normal concatenation (`+`) is fine. For large workloads, **buffer-based approaches** (like `StringBuilder`) or **Span-based APIs** are preferable.

**Happy Coding! 🚀**


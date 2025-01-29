# JsonSerializationBenchmarks

This project benchmarks JSON **serialization** and **deserialization** for **single objects** and **lists** using both **System.Text.Json** and **Newtonsoft.Json** on **.NET 6,7,8,9,10**. The goal is to compare **performance** (execution time) and **memory allocations** (Gen0, Gen1, Gen2 usage, and total bytes allocated).

## Why We Do It

- **Performance Comparison**: Understand how .NET’s built-in `System.Text.Json` stacks up against the popular `Newtonsoft.Json` library in various scenarios.
- **Scalability Insights**: Measure how serialization and deserialization times scale as we increase the size of the data (e.g., from 10 items to 1000 items in a list).
- **Memory Footprint**: Observe if there are significant differences in allocations between libraries for both small and large payloads.

## What We Can Learn

- **Relative Speed**: Which library is generally faster for single-object vs. list-based scenarios?
- **Allocation Patterns**: Whether large payloads trigger higher Gen0/Gen1/Gen2 collections in one library vs. the other.
- **Runtime Behavior**: How performance changes under .NET 9.0.101 with ARM64 RyuJIT and hardware acceleration (AdvSIMD).

---
## Benchmark Results

Below are the results for **System.Text.Json** and **Newtonsoft.Json** across different scenarios:

1. **Single Object Serialization & Deserialization**  
2. **Reading JSON vs. Creating JSON** (e.g., creating JToken or similar representation)  
3. **Lists** (Array/Collection of objects) with 10 vs. 1000 items  

> **Mean**: Average execution time per operation  
> **Gen0/Gen1/Gen2**: Number of Garbage Collections on respective generations  
> **Allocated**: Total bytes allocated during the operation

#### .NET SDK 9.0.101

| Method                                      | Size | Mean           | Error        | StdDev       | Median         | Gen0     | Gen1     | Gen2     | Allocated |
|-------------------------------------------- |----- |---------------:|-------------:|-------------:|---------------:|---------:|---------:|---------:|----------:|
| SystemTextJson_Serialize_Single             | 1000 |       477.5 ns |      3.10 ns |      2.90 ns |       478.8 ns |   0.1011 |        - |        - |     848 B |
| SystemTextJson_Serialize_Single             | 10   |       484.1 ns |      2.80 ns |      2.62 ns |       482.9 ns |   0.1011 |        - |        - |     848 B |
| SystemTextJson_CreateJson_Single            | 10   |       697.3 ns |      2.56 ns |      2.40 ns |       696.8 ns |   0.7801 |   0.0095 |        - |    6528 B |
| SystemTextJson_CreateJson_Single            | 1000 |       700.0 ns |      4.31 ns |      3.82 ns |       700.0 ns |   0.7801 |   0.0095 |        - |    6528 B |
| Newtonsoft_Serialize_Single                 | 10   |       794.4 ns |      2.04 ns |      1.60 ns |       794.5 ns |   0.2518 |        - |        - |    2112 B |
| Newtonsoft_Serialize_Single                 | 1000 |       811.1 ns |      7.18 ns |      6.72 ns |       810.1 ns |   0.2518 |        - |        - |    2112 B |
| Newtonsoft_CreateJson_Single                | 10   |       871.8 ns |      3.77 ns |      3.14 ns |       870.8 ns |   0.2861 |   0.0010 |        - |    2400 B |
| Newtonsoft_CreateJson_Single                | 1000 |       921.0 ns |      2.93 ns |      2.45 ns |       920.8 ns |   0.2861 |   0.0010 |        - |    2400 B |
| SystemTextJson_Deserialize_Single           | 10   |     1,308.8 ns |      2.33 ns |      2.18 ns |     1,308.1 ns |   0.2327 |        - |        - |    1952 B |
| SystemTextJson_Serialize_Deserialize_Single | 10   |     1,322.3 ns |     25.08 ns |     23.46 ns |     1,310.8 ns |   0.2327 |        - |        - |    1952 B |
| SystemTextJson_Serialize_Deserialize_Single | 1000 |     1,331.3 ns |      5.90 ns |      4.60 ns |     1,330.6 ns |   0.2327 |        - |        - |    1952 B |
| SystemTextJson_Deserialize_Single           | 1000 |     1,363.8 ns |      5.29 ns |      4.42 ns |     1,363.5 ns |   0.2327 |        - |        - |    1952 B |
| SystemTextJson_ReadJson_Single              | 10   |     1,808.5 ns |      2.62 ns |      2.32 ns |     1,808.0 ns |   0.2651 |        - |        - |    2232 B |
| SystemTextJson_ReadJson_Single              | 1000 |     1,844.5 ns |     26.68 ns |     22.28 ns |     1,837.1 ns |   0.2651 |        - |        - |    2232 B |
| Newtonsoft_ReadJson_Single                  | 10   |     2,209.7 ns |      3.32 ns |      2.77 ns |     2,210.7 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_ReadJson_Single                  | 1000 |     2,231.0 ns |     12.99 ns |     11.51 ns |     2,228.5 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_Deserialize_Single               | 10   |     2,246.6 ns |      4.11 ns |      3.64 ns |     2,246.2 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_Serialize_Deserialize_Single     | 1000 |     2,270.5 ns |     20.13 ns |     17.84 ns |     2,267.0 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_Deserialize_Single               | 1000 |     2,279.0 ns |     19.85 ns |     16.57 ns |     2,274.2 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_Serialize_Deserialize_Single     | 10   |     2,286.1 ns |     40.37 ns |     75.82 ns |     2,251.9 ns |   0.6561 |   0.0038 |        - |    5496 B |
| SystemTextJson_Serialize_List               | 10   |     4,975.8 ns |      7.56 ns |      5.90 ns |     4,975.0 ns |   0.6790 |        - |        - |    5728 B |
| Newtonsoft_Serialize_List                   | 10   |     8,431.4 ns |      8.90 ns |      7.89 ns |     8,431.7 ns |   1.9379 |   0.0458 |        - |   16224 B |
| SystemTextJson_Deserialize_List             | 10   |    13,930.0 ns |     18.00 ns |     15.03 ns |    13,929.7 ns |   1.5259 |   0.0153 |        - |   12800 B |
| Newtonsoft_Deserialize_List                 | 10   |    22,703.8 ns |     36.86 ns |     28.78 ns |    22,699.4 ns |   3.1128 |   0.0610 |        - |   26200 B |
| SystemTextJson_Serialize_List               | 1000 |   557,053.5 ns |  6,478.63 ns |  5,409.95 ns |   555,505.4 ns | 142.5781 | 142.5781 | 142.5781 |  580812 B |
| Newtonsoft_Serialize_List                   | 1000 |   960,103.8 ns | 17,623.83 ns | 15,623.07 ns |   957,227.9 ns | 166.0156 | 166.0156 | 166.0156 | 1311640 B |
| SystemTextJson_Deserialize_List             | 1000 | 1,681,786.4 ns | 17,906.93 ns | 14,953.09 ns | 1,685,398.4 ns | 210.9375 | 164.0625 | 132.8125 | 1260955 B |
| Newtonsoft_Deserialize_List                 | 1000 | 2,433,619.6 ns |  6,306.35 ns |  4,923.58 ns | 2,433,960.2 ns | 218.7500 | 164.0625 | 164.0625 | 2082377 B |

#### .NET SDK 8.0.404
| Method                                      | Size | Mean           | Error       | StdDev      | Gen0     | Gen1     | Gen2     | Allocated |
|-------------------------------------------- |----- |---------------:|------------:|------------:|---------:|---------:|---------:|----------:|
| SystemTextJson_Serialize_Single             | 1000 |       513.0 ns |     2.31 ns |     2.05 ns |   0.1011 |        - |        - |     848 B |
| SystemTextJson_Serialize_Single             | 10   |       513.9 ns |     2.68 ns |     2.38 ns |   0.1011 |        - |        - |     848 B |
| SystemTextJson_CreateJson_Single            | 1000 |       718.0 ns |     0.86 ns |     0.72 ns |   0.7792 |   0.0076 |        - |    6520 B |
| SystemTextJson_CreateJson_Single            | 10   |       721.8 ns |    14.08 ns |    13.18 ns |   0.7792 |   0.0086 |        - |    6520 B |
| Newtonsoft_Serialize_Single                 | 1000 |       833.6 ns |     1.10 ns |     0.91 ns |   0.2518 |        - |        - |    2112 B |
| Newtonsoft_CreateJson_Single                | 1000 |       888.8 ns |     4.60 ns |     3.84 ns |   0.2861 |   0.0010 |        - |    2400 B |
| Newtonsoft_CreateJson_Single                | 10   |       893.8 ns |     1.14 ns |     1.01 ns |   0.2861 |   0.0010 |        - |    2400 B |
| Newtonsoft_Serialize_Single                 | 10   |       905.4 ns |    13.47 ns |    11.25 ns |   0.2518 |        - |        - |    2112 B |
| SystemTextJson_Serialize_Deserialize_Single | 10   |     1,422.7 ns |     1.87 ns |     1.46 ns |   0.2327 |        - |        - |    1952 B |
| SystemTextJson_Serialize_Deserialize_Single | 1000 |     1,426.9 ns |     3.07 ns |     2.73 ns |   0.2327 |        - |        - |    1952 B |
| SystemTextJson_Deserialize_Single           | 1000 |     1,430.4 ns |     7.17 ns |     6.36 ns |   0.2327 |        - |        - |    1952 B |
| SystemTextJson_Deserialize_Single           | 10   |     1,484.2 ns |    20.11 ns |    15.70 ns |   0.2327 |        - |        - |    1952 B |
| SystemTextJson_ReadJson_Single              | 1000 |     1,930.8 ns |     2.08 ns |     1.84 ns |   0.2632 |        - |        - |    2232 B |
| SystemTextJson_ReadJson_Single              | 10   |     1,939.3 ns |     9.19 ns |     8.14 ns |   0.2632 |        - |        - |    2232 B |
| Newtonsoft_Deserialize_Single               | 1000 |     2,366.7 ns |     7.76 ns |     6.48 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_Serialize_Deserialize_Single     | 1000 |     2,370.8 ns |     5.74 ns |     4.79 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_Serialize_Deserialize_Single     | 10   |     2,371.2 ns |    12.08 ns |    10.09 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_ReadJson_Single                  | 10   |     2,402.5 ns |     7.67 ns |     7.18 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_Deserialize_Single               | 10   |     2,464.5 ns |    48.11 ns |    47.25 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_ReadJson_Single                  | 1000 |     2,470.7 ns |    49.15 ns |    41.05 ns |   0.6561 |   0.0038 |        - |    5496 B |
| SystemTextJson_Serialize_List               | 10   |     5,597.5 ns |    55.65 ns |    46.47 ns |   0.6790 |        - |        - |    5728 B |
| Newtonsoft_Serialize_List                   | 10   |     8,906.3 ns |    17.64 ns |    14.73 ns |   1.9379 |   0.0458 |        - |   16224 B |
| SystemTextJson_Deserialize_List             | 10   |    15,714.0 ns |    83.59 ns |    69.80 ns |   1.5259 |   0.0305 |        - |   12801 B |
| Newtonsoft_Deserialize_List                 | 10   |    24,102.4 ns |    58.70 ns |    45.83 ns |   3.1128 |   0.0916 |        - |   26200 B |
| SystemTextJson_Serialize_List               | 1000 |   655,873.7 ns | 9,218.01 ns | 7,697.45 ns | 172.8516 | 171.8750 | 166.0156 |  716357 B |
| Newtonsoft_Serialize_List                   | 1000 | 1,004,226.7 ns | 4,002.99 ns | 3,548.55 ns | 332.0313 | 332.0313 | 123.0469 | 1311833 B |
| SystemTextJson_Deserialize_List             | 1000 | 1,735,809.0 ns | 1,821.23 ns | 1,614.47 ns | 292.9688 | 259.7656 | 201.1719 | 1472212 B |
| Newtonsoft_Deserialize_List                 | 1000 | 2,478,589.8 ns | 9,613.89 ns | 8,992.84 ns | 386.7188 | 386.7188 | 128.9063 | 2082373 B |

#### .NET SDK 7.0.410
| Method                                      | Size | Mean           | Error        | StdDev      | Gen0     | Gen1     | Gen2     | Allocated |
|-------------------------------------------- |----- |---------------:|-------------:|------------:|---------:|---------:|---------:|----------:|
| SystemTextJson_Serialize_Single             | 1000 |       539.1 ns |      1.04 ns |     0.97 ns |   0.1011 |        - |        - |     848 B |
| SystemTextJson_Serialize_Single             | 10   |       544.3 ns |      0.82 ns |     0.72 ns |   0.1011 |        - |        - |     848 B |
| SystemTextJson_CreateJson_Single            | 10   |       793.4 ns |      0.72 ns |     0.60 ns |   0.7792 |   0.0143 |        - |    6520 B |
| SystemTextJson_CreateJson_Single            | 1000 |       795.6 ns |      0.50 ns |     0.42 ns |   0.7792 |   0.0143 |        - |    6520 B |
| Newtonsoft_Serialize_Single                 | 10   |     1,199.7 ns |      3.81 ns |     3.38 ns |   0.2518 |        - |        - |    2112 B |
| Newtonsoft_Serialize_Single                 | 1000 |     1,228.4 ns |      1.68 ns |     1.49 ns |   0.2518 |        - |        - |    2112 B |
| Newtonsoft_CreateJson_Single                | 1000 |     1,245.1 ns |      1.64 ns |     1.53 ns |   0.2861 |        - |        - |    2400 B |
| Newtonsoft_CreateJson_Single                | 10   |     1,259.2 ns |      2.71 ns |     2.11 ns |   0.2861 |        - |        - |    2400 B |
| SystemTextJson_Deserialize_Single           | 1000 |     1,619.2 ns |      2.50 ns |     2.22 ns |   0.2289 |        - |        - |    1920 B |
| SystemTextJson_Serialize_Deserialize_Single | 10   |     1,621.4 ns |      5.29 ns |     4.69 ns |   0.2289 |        - |        - |    1920 B |
| SystemTextJson_Serialize_Deserialize_Single | 1000 |     1,626.4 ns |      2.76 ns |     2.45 ns |   0.2289 |        - |        - |    1920 B |
| SystemTextJson_Deserialize_Single           | 10   |     1,644.8 ns |     10.23 ns |     9.07 ns |   0.2289 |        - |        - |    1920 B |
| SystemTextJson_ReadJson_Single              | 1000 |     2,095.0 ns |      1.94 ns |     1.51 ns |   0.2594 |        - |        - |    2200 B |
| SystemTextJson_ReadJson_Single              | 10   |     2,137.2 ns |      2.26 ns |     2.00 ns |   0.2594 |        - |        - |    2200 B |
| Newtonsoft_ReadJson_Single                  | 1000 |     3,570.6 ns |      5.40 ns |     4.51 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_ReadJson_Single                  | 10   |     3,592.7 ns |      9.08 ns |     7.09 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_Deserialize_Single               | 10   |     3,628.4 ns |     12.27 ns |    10.24 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_Deserialize_Single               | 1000 |     3,634.8 ns |     37.60 ns |    31.39 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_Serialize_Deserialize_Single     | 1000 |     3,636.5 ns |      6.14 ns |     5.44 ns |   0.6561 |   0.0038 |        - |    5496 B |
| Newtonsoft_Serialize_Deserialize_Single     | 10   |     3,757.4 ns |      8.06 ns |     7.14 ns |   0.6561 |   0.0038 |        - |    5496 B |
| SystemTextJson_Serialize_List               | 10   |     5,995.2 ns |     10.65 ns |     9.44 ns |   0.6790 |        - |        - |    5728 B |
| Newtonsoft_Serialize_List                   | 10   |    12,768.6 ns |     53.69 ns |    47.59 ns |   1.9379 |   0.0610 |        - |   16224 B |
| SystemTextJson_Deserialize_List             | 10   |    17,644.0 ns |     30.17 ns |    28.22 ns |   1.5259 |   0.0305 |        - |   12768 B |
| Newtonsoft_Deserialize_List                 | 10   |    36,193.7 ns |    142.60 ns |   126.41 ns |   3.1128 |   0.0610 |        - |   26200 B |
| SystemTextJson_Serialize_List               | 1000 |   686,186.6 ns |  1,933.20 ns | 1,713.73 ns | 142.5781 | 142.5781 | 142.5781 |  580736 B |
| Newtonsoft_Serialize_List                   | 1000 | 1,415,624.3 ns | 10,118.51 ns | 9,464.86 ns | 166.0156 | 166.0156 | 166.0156 | 1311665 B |
| SystemTextJson_Deserialize_List             | 1000 | 1,964,445.4 ns |  4,286.75 ns | 3,346.81 ns | 214.8438 | 175.7813 | 136.7188 | 1260371 B |
| Newtonsoft_Deserialize_List                 | 1000 | 3,745,629.6 ns |  9,147.67 ns | 7,638.72 ns | 218.7500 | 164.0625 | 164.0625 | 2082365 B |

#### .NET SDK 6.0.428
| Method                                      | Size | Mean           | Error        | StdDev       | Gen0     | Gen1     | Gen2     | Allocated  |
|-------------------------------------------- |----- |---------------:|-------------:|-------------:|---------:|---------:|---------:|-----------:|
| SystemTextJson_Serialize_Single             | 1000 |       641.6 ns |      0.87 ns |      0.81 ns |   0.4930 |        - |        - |    1.01 KB |
| SystemTextJson_Serialize_Single             | 10   |       646.4 ns |      1.96 ns |      1.53 ns |   0.4930 |        - |        - |    1.01 KB |
| SystemTextJson_CreateJson_Single            | 1000 |       995.2 ns |      2.99 ns |      2.50 ns |   3.1281 |        - |        - |     6.4 KB |
| SystemTextJson_CreateJson_Single            | 10   |     1,002.0 ns |      5.07 ns |      4.49 ns |   3.1281 |        - |        - |     6.4 KB |
| Newtonsoft_Serialize_Single                 | 10   |     1,408.3 ns |      6.55 ns |      5.47 ns |   1.0090 |        - |        - |    2.06 KB |
| Newtonsoft_Serialize_Single                 | 1000 |     1,420.9 ns |      5.96 ns |      4.98 ns |   1.0090 |        - |        - |    2.06 KB |
| Newtonsoft_CreateJson_Single                | 1000 |     1,492.8 ns |      8.76 ns |      7.77 ns |   1.1463 |        - |        - |    2.34 KB |
| Newtonsoft_CreateJson_Single                | 10   |     1,495.3 ns |      6.16 ns |      5.46 ns |   1.1463 |        - |        - |    2.34 KB |
| SystemTextJson_Deserialize_Single           | 1000 |     1,894.6 ns |      6.38 ns |      5.33 ns |   1.0033 |        - |        - |    2.05 KB |
| SystemTextJson_Serialize_Deserialize_Single | 1000 |     1,898.5 ns |      4.35 ns |      4.07 ns |   1.0033 |        - |        - |    2.05 KB |
| SystemTextJson_Serialize_Deserialize_Single | 10   |     1,911.3 ns |      2.04 ns |      1.81 ns |   1.0033 |        - |        - |    2.05 KB |
| SystemTextJson_Deserialize_Single           | 10   |     1,924.7 ns |     17.11 ns |     14.29 ns |   1.0052 |        - |        - |    2.05 KB |
| SystemTextJson_ReadJson_Single              | 10   |     2,423.1 ns |      6.00 ns |      5.01 ns |   1.1368 |        - |        - |    2.33 KB |
| SystemTextJson_ReadJson_Single              | 1000 |     2,450.7 ns |     13.83 ns |     11.55 ns |   1.1368 |        - |        - |    2.33 KB |
| Newtonsoft_Deserialize_Single               | 10   |     4,233.7 ns |      8.37 ns |      7.42 ns |   2.6245 |        - |        - |    5.37 KB |
| Newtonsoft_ReadJson_Single                  | 1000 |     4,249.9 ns |      9.57 ns |      8.96 ns |   2.6245 |        - |        - |    5.37 KB |
| Newtonsoft_ReadJson_Single                  | 10   |     4,256.3 ns |     29.17 ns |     25.86 ns |   2.6245 |        - |        - |    5.37 KB |
| Newtonsoft_Serialize_Deserialize_Single     | 10   |     4,272.1 ns |     33.24 ns |     25.95 ns |   2.6245 |        - |        - |    5.37 KB |
| Newtonsoft_Deserialize_Single               | 1000 |     4,276.5 ns |      6.24 ns |      5.21 ns |   2.6245 |        - |        - |    5.37 KB |
| Newtonsoft_Serialize_Deserialize_Single     | 1000 |     4,296.6 ns |     22.64 ns |     20.07 ns |   2.6245 |        - |        - |    5.37 KB |
| SystemTextJson_Serialize_List               | 10   |     6,690.6 ns |      7.95 ns |      6.64 ns |   2.8229 |        - |        - |    5.77 KB |
| Newtonsoft_Serialize_List                   | 10   |    14,634.4 ns |     48.98 ns |     45.82 ns |   7.7515 |        - |        - |   15.84 KB |
| SystemTextJson_Deserialize_List             | 10   |    20,375.9 ns |     15.22 ns |     14.24 ns |   6.1646 |        - |        - |   12.65 KB |
| Newtonsoft_Deserialize_List                 | 10   |    41,845.0 ns |     55.31 ns |     46.19 ns |  12.5122 |        - |        - |   25.59 KB |
| SystemTextJson_Serialize_List               | 1000 |   739,347.1 ns |    548.40 ns |    457.94 ns | 143.5547 | 142.5781 | 142.5781 |  567.32 KB |
| Newtonsoft_Serialize_List                   | 1000 | 1,553,564.2 ns |  5,870.65 ns |  5,491.41 ns | 277.3438 | 166.0156 | 166.0156 |  1280.9 KB |
| SystemTextJson_Deserialize_List             | 1000 | 2,180,464.5 ns |  3,657.95 ns |  3,421.65 ns | 347.6563 | 250.0000 | 144.5313 |  1231.1 KB |
| Newtonsoft_Deserialize_List                 | 1000 | 4,403,012.9 ns | 12,513.29 ns | 10,449.17 ns | 570.3125 | 250.0000 | 164.0625 | 2033.61 KB |

---

## Observations & Takeaways

1. **System.Text.Json vs. Newtonsoft.Json**  
   - **System.Text.Json** tends to be faster and allocate less in most scenarios shown here, especially for **smaller payloads**.  
   - For **larger lists** (1000 items), the difference becomes more pronounced, where `System.Text.Json` remains faster and more memory-efficient than `Newtonsoft.Json`.

2. **Serialization vs. Deserialization**  
   - Deserialization is consistently more expensive than serialization for both libraries. This is common as parsing JSON and constructing objects often involves more overhead than producing JSON from in-memory data.

3. **List Size Impact**  
   - Going from 10 to 1000 items in a list *dramatically* increases runtime and allocations for both libraries. `System.Text.Json` shows comparatively lower increases, reflecting better memory usage under larger loads.

4. **Read vs. Create JSON**  
   - Methods that *read* JSON (e.g., `ReadJson`) or *create* JSON objects in memory (e.g., `CreateJson`) can incur additional overhead. The table shows that these methods allocate more memory, especially for `Newtonsoft.Json`.

---

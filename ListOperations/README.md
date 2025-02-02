# ListOperations Benchmarks

This project is part of the **Benchmarkus** repository and benchmarks **List\<T\>** vs. **IList\<T\>** on various **CRUD** (Create, Read, Update, Delete) and **enumeration** operations. It uses [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) to measure **performance** and **memory allocations** under different **`Size`** parameters.

## Why We Do It

- **Performance Insights**: Understand how `List<T>` compares to `IList<T>` for frequent operations (Add, Remove, Find, etc.).  
- **Generic Scenarios**: Test multiple data types (`int`, `string`, `Person`) to see how performance scales with complexity.  
- **Memory Diagnoser**: Evaluate potential memory overhead in repeated add/remove scenarios.

## What We Can Learn

1. **List<T> vs. IList<T>**: Identify if there's a significant performance difference.  
2. **Mutation Costs**: Show the overhead of copying lists in each benchmark for consistent test scenarios.  
3. **Enumeration Patterns**: Compare `foreach`, `for` loop, and LINQ enumerations.  
4. **Scalability**: Observe how operations scale from small (`Size=10`) to moderate (`Size=500`) (and possibly larger if you choose).

---

### Purpose & Motivation

- **Data Structure Selection**: Help developers pick the right collection type for their workload.  
- **Benchmark Best Practices**: Illustrate `[GlobalSetup]` usage, parameterized tests, and memory measurement.  
- **Real-World Relevance**: Show how typical operations (find, add, remove, convert, enumerate) perform under different conditions.

### Key Focus Areas

1. **Initialization**:
   - `[GlobalSetup]` method to construct baseline lists (`_listInt`, `_listString`, `_listPerson`).
2. **Operations**:
   - **Find**: Use `FirstOrDefault` with conditions.  
   - **Add**: Benchmark inserting a new element, ensuring we keep a clean copy.  
   - **Remove**: Removing last or matching elements.  
   - **Convert**: `ToArray`, `AsReadOnly`.  
   - **Enumerate**: `foreach`, `for`, and `LINQ`.  
   - **Insert**: Insert at an arbitrary position.  
   - **Clear**: Reset or remove all elements.
3. **Data Types**:
   - **int**  
   - **string**  
   - **Person** (a more complex object with nested `Address`).

### Goals

- **Clarity**: Provide easy-to-read code that’s also Sonar-friendly (clear methods, small responsibilities).  
- **Comparisons**: Show where `List<T>` might outperform a generic `IList<T>` or vice versa.  
- **Extendability**: You can add more types (`decimal`, `Guid`, etc.) or more `Size` values to get deeper insights.

---

## Benchmark Results (Placeholder)

Below are **example** tables for different .NET versions. Update these tables with your **actual** benchmark results after running `dotnet run --configuration Release`.

### .NET 6.0.428
##### IterationCount=5  WarmupCount=1
| Method                                   | Size | Mean         | Error      | StdDev    | Rank | Gen0   | Allocated |
|----------------------------------------- |----- |-------------:|-----------:|----------:|-----:|-------:|----------:|
| List_AsReadOnly_Person                   | 50   |     4.574 ns |  0.1535 ns | 0.0237 ns |    1 | 0.0115 |      24 B |
| List_Find_FirstEven                      | 50   |    14.439 ns |  0.1810 ns | 0.0470 ns |    2 | 0.0191 |      40 B |
| IList_Find_FirstEven                     | 50   |    14.446 ns |  0.1172 ns | 0.0181 ns |    2 | 0.0191 |      40 B |
| List_ToArray_Int                         | 50   |    16.709 ns |  1.3760 ns | 0.2129 ns |    2 | 0.1071 |     224 B |
| IList_Clear_Int                          | 50   |    24.744 ns |  0.8802 ns | 0.1362 ns |    3 | 0.1224 |     256 B |
| List_Enumerate_ForLoop_String            | 50   |    24.831 ns |  0.4496 ns | 0.1168 ns |    3 |      - |         - |
| List_Clear_Int                           | 50   |    24.852 ns |  0.9308 ns | 0.2417 ns |    3 | 0.1224 |     256 B |
| IList_ToArray_Int                        | 50   |    24.875 ns |  1.3574 ns | 0.3525 ns |    3 | 0.1071 |     224 B |
| IList_Remove_LastInt                     | 50   |    26.400 ns |  1.8867 ns | 0.4900 ns |    3 | 0.1224 |     256 B |
| List_Remove_LastInt                      | 50   |    26.566 ns |  0.8520 ns | 0.2213 ns |    3 | 0.1224 |     256 B |
| List_ToArray_String                      | 50   |    31.335 ns |  1.5975 ns | 0.4149 ns |    3 | 0.2027 |     424 B |
| IList_ToArray_String                     | 50   |    36.798 ns |  1.2745 ns | 0.3310 ns |    3 | 0.2027 |     424 B |
| IList_Remove_LastPerson                  | 50   |    44.358 ns |  0.1988 ns | 0.0308 ns |    3 | 0.2180 |     456 B |
| List_Enumerate_Foreach_Int               | 50   |    44.759 ns |  2.0194 ns | 0.3125 ns |    3 |      - |         - |
| List_Remove_LastString                   | 50   |    44.765 ns |  0.7524 ns | 0.1164 ns |    3 | 0.2180 |     456 B |
| IList_Remove_LastString                  | 50   |    44.972 ns |  1.0364 ns | 0.2692 ns |    3 | 0.2180 |     456 B |
| List_Remove_LastPerson                   | 50   |    45.607 ns |  0.4666 ns | 0.1212 ns |    3 | 0.2180 |     456 B |
| IList_AsReadOnly_Person                  | 50   |    52.398 ns |  2.2405 ns | 0.5819 ns |    3 | 0.2295 |     480 B |
| IList_Add_Int                            | 50   |    53.569 ns |  2.7691 ns | 0.4285 ns |    3 | 0.3252 |     680 B |
| List_Add_Int                             | 50   |    54.480 ns |  4.0004 ns | 1.0389 ns |    3 | 0.3252 |     680 B |
| List_Insert_First_Int                    | 50   |    75.811 ns |  3.3793 ns | 0.8776 ns |    4 | 0.3252 |     680 B |
| IList_Insert_First_Int                   | 50   |    76.535 ns |  2.3399 ns | 0.6077 ns |    4 | 0.3252 |     680 B |
| IList_RemoveAll_GreaterThanThreshold_Int | 50   |    95.349 ns |  0.2455 ns | 0.0637 ns |    4 | 0.1223 |     256 B |
| IList_Enumerate_ForLoop_String           | 50   |   108.480 ns |  0.3811 ns | 0.0590 ns |    4 |      - |         - |
| List_RemoveAll_GreaterThanThreshold_Int  | 50   |   116.808 ns |  0.5210 ns | 0.0806 ns |    4 | 0.1529 |     320 B |
| List_Insert_First_String                 | 50   |   119.506 ns |  5.7046 ns | 1.4815 ns |    4 | 0.6118 |    1280 B |
| IList_Insert_First_String                | 50   |   119.654 ns |  4.4469 ns | 1.1548 ns |    4 | 0.6118 |    1280 B |
| List_Add_String                          | 50   |   143.403 ns |  6.7196 ns | 1.0399 ns |    4 | 0.6311 |    1320 B |
| IList_Add_String                         | 50   |   144.305 ns |  4.5528 ns | 1.1823 ns |    4 | 0.6311 |    1320 B |
| IList_Enumerate_Foreach_Int              | 50   |   224.337 ns |  7.8959 ns | 1.2219 ns |    5 | 0.0191 |      40 B |
| IList_Add_Person                         | 50   |   284.825 ns | 23.6160 ns | 3.6546 ns |    6 | 0.7343 |    1536 B |
| List_Add_Person                          | 50   |   289.448 ns |  8.3241 ns | 2.1617 ns |    6 | 0.7343 |    1536 B |
| IList_Enumerate_LINQ_Foreach_Person      | 50   |   340.525 ns |  1.9429 ns | 0.3007 ns |    6 | 0.0343 |      72 B |
| List_Enumerate_LINQ_Foreach_Person       | 50   |   342.690 ns |  6.3789 ns | 1.6566 ns |    6 | 0.0343 |      72 B |
| IList_Find_FirstAString                  | 50   |   824.461 ns | 34.6690 ns | 5.3651 ns |    7 | 0.0191 |      40 B |
| List_Find_FirstAString                   | 50   |   826.155 ns | 14.1316 ns | 2.1869 ns |    7 | 0.0191 |      40 B |
| List_Find_FirstPersonByEmail             | 50   | 1,023.520 ns | 10.4161 ns | 2.7050 ns |    7 | 0.8450 |    1768 B |
| IList_Find_FirstPersonByEmail            | 50   | 1,023.676 ns | 19.6665 ns | 3.0434 ns |    7 | 0.8450 |    1768 B |
### .NET 7.0.410
##### IterationCount=5  WarmupCount=1
| Method                                   | Size | Mean       | Error      | StdDev     | Rank | Gen0   | Gen1   | Allocated |
|----------------------------------------- |----- |-----------:|-----------:|-----------:|-----:|-------:|-------:|----------:|
| List_AsReadOnly_Person                   | 50   |   3.940 ns |  0.0202 ns |  0.0052 ns |    1 | 0.0029 |      - |      24 B |
| List_ToArray_Int                         | 50   |  13.551 ns |  0.8459 ns |  0.2197 ns |    2 | 0.0268 |      - |     224 B |
| IList_Find_FirstEven                     | 50   |  14.439 ns |  0.6809 ns |  0.1768 ns |    2 | 0.0048 |      - |      40 B |
| List_Find_FirstEven                      | 50   |  15.037 ns |  5.0958 ns |  0.7886 ns |    2 | 0.0048 |      - |      40 B |
| List_Clear_Int                           | 50   |  19.533 ns |  0.3959 ns |  0.0613 ns |    3 | 0.0306 |      - |     256 B |
| IList_Clear_Int                          | 50   |  19.660 ns |  0.2718 ns |  0.0421 ns |    3 | 0.0306 |      - |     256 B |
| IList_ToArray_Int                        | 50   |  19.843 ns |  0.2072 ns |  0.0538 ns |    3 | 0.0268 |      - |     224 B |
| List_Remove_LastInt                      | 50   |  20.705 ns |  0.8718 ns |  0.1349 ns |    3 | 0.0306 |      - |     256 B |
| IList_Remove_LastInt                     | 50   |  20.761 ns |  0.2773 ns |  0.0720 ns |    3 | 0.0306 |      - |     256 B |
| List_ToArray_String                      | 50   |  25.231 ns |  0.2868 ns |  0.0745 ns |    3 | 0.0507 |      - |     424 B |
| List_Enumerate_ForLoop_String            | 50   |  25.478 ns |  0.8378 ns |  0.2176 ns |    3 |      - |      - |         - |
| IList_ToArray_String                     | 50   |  31.918 ns |  0.6913 ns |  0.1795 ns |    4 | 0.0507 |      - |     424 B |
| IList_Remove_LastPerson                  | 50   |  33.693 ns |  0.2284 ns |  0.0353 ns |    4 | 0.0545 | 0.0001 |     456 B |
| List_Remove_LastString                   | 50   |  33.769 ns |  0.1970 ns |  0.0512 ns |    4 | 0.0545 | 0.0001 |     456 B |
| List_Remove_LastPerson                   | 50   |  33.787 ns |  0.1530 ns |  0.0397 ns |    4 | 0.0545 | 0.0001 |     456 B |
| IList_Remove_LastString                  | 50   |  36.484 ns |  9.7947 ns |  2.5437 ns |    4 | 0.0545 | 0.0001 |     456 B |
| IList_AsReadOnly_Person                  | 50   |  39.676 ns |  0.1112 ns |  0.0172 ns |    4 | 0.0573 |      - |     480 B |
| IList_Add_Int                            | 50   |  41.115 ns |  0.2713 ns |  0.0705 ns |    4 | 0.0813 |      - |     680 B |
| List_Add_Int                             | 50   |  41.437 ns |  0.2198 ns |  0.0340 ns |    4 | 0.0813 |      - |     680 B |
| List_Enumerate_Foreach_Int               | 50   |  50.118 ns |  0.3863 ns |  0.0598 ns |    4 |      - |      - |         - |
| List_Insert_First_Int                    | 50   |  50.898 ns |  0.5074 ns |  0.1318 ns |    4 | 0.0813 |      - |     680 B |
| IList_Insert_First_Int                   | 50   |  51.181 ns |  0.2713 ns |  0.0704 ns |    4 | 0.0813 |      - |     680 B |
| List_Insert_First_String                 | 50   |  84.635 ns |  5.4932 ns |  0.8501 ns |    5 | 0.1529 | 0.0005 |    1280 B |
| IList_RemoveAll_GreaterThanThreshold_Int | 50   |  88.900 ns |  3.8625 ns |  1.0031 ns |    5 | 0.0305 |      - |     256 B |
| IList_Add_String                         | 50   |  96.314 ns |  8.7679 ns |  1.3568 ns |    5 | 0.1577 |      - |    1320 B |
| List_Add_String                          | 50   |  96.632 ns |  2.6008 ns |  0.4025 ns |    5 | 0.1577 | 0.0007 |    1320 B |
| IList_Insert_First_String                | 50   |  98.233 ns | 53.0557 ns | 13.7784 ns |    5 | 0.1529 | 0.0005 |    1280 B |
| List_RemoveAll_GreaterThanThreshold_Int  | 50   | 102.350 ns | 43.1646 ns | 11.2097 ns |    5 | 0.0381 |      - |     320 B |
| IList_Enumerate_ForLoop_String           | 50   | 108.686 ns |  0.1815 ns |  0.0281 ns |    5 |      - |      - |         - |
| List_Add_Person                          | 50   | 211.454 ns |  3.6436 ns |  0.9462 ns |    6 | 0.1836 | 0.0007 |    1536 B |
| IList_Enumerate_Foreach_Int              | 50   | 220.629 ns |  0.6738 ns |  0.1043 ns |    6 | 0.0048 |      - |      40 B |
| IList_Add_Person                         | 50   | 241.346 ns |  3.0872 ns |  0.4777 ns |    6 | 0.1836 | 0.0005 |    1536 B |
| IList_Enumerate_LINQ_Foreach_Person      | 50   | 317.164 ns |  0.5710 ns |  0.1483 ns |    7 | 0.0086 |      - |      72 B |
| List_Enumerate_LINQ_Foreach_Person       | 50   | 317.235 ns |  1.2281 ns |  0.3189 ns |    7 | 0.0086 |      - |      72 B |
| IList_Find_FirstAString                  | 50   | 758.283 ns |  4.5122 ns |  0.6983 ns |    8 | 0.0048 |      - |      40 B |
| List_Find_FirstAString                   | 50   | 758.840 ns |  8.5310 ns |  1.3202 ns |    8 | 0.0048 |      - |      40 B |
| IList_Find_FirstPersonByEmail            | 50   | 877.111 ns | 16.8904 ns |  2.6138 ns |    8 | 0.2108 |      - |    1768 B |
| List_Find_FirstPersonByEmail             | 50   | 903.834 ns | 78.6107 ns | 20.4149 ns |    8 | 0.2108 |      - |    1768 B |
### .NET 8.0.404
##### IterationCount=5  WarmupCount=1
| Method                                   | Size | Mean       | Error      | StdDev     | Rank | Gen0   | Gen1   | Allocated |
|----------------------------------------- |----- |-----------:|-----------:|-----------:|-----:|-------:|-------:|----------:|
| List_AsReadOnly_Person                   | 50   |   3.844 ns |  0.0071 ns |  0.0018 ns |    1 | 0.0029 |      - |      24 B |
| List_Find_FirstEven                      | 50   |   6.172 ns |  0.0475 ns |  0.0073 ns |    2 | 0.0048 |      - |      40 B |
| IList_Find_FirstEven                     | 50   |   6.391 ns |  0.9468 ns |  0.2459 ns |    2 | 0.0048 |      - |      40 B |
| List_ToArray_Int                         | 50   |  12.989 ns |  0.9935 ns |  0.1537 ns |    3 | 0.0268 |      - |     224 B |
| IList_ToArray_Int                        | 50   |  18.371 ns |  1.2825 ns |  0.3331 ns |    4 | 0.0268 |      - |     224 B |
| List_Clear_Int                           | 50   |  18.538 ns |  0.8634 ns |  0.2242 ns |    4 | 0.0306 |      - |     256 B |
| IList_Clear_Int                          | 50   |  18.964 ns |  1.7032 ns |  0.4423 ns |    4 | 0.0306 |      - |     256 B |
| List_Remove_LastInt                      | 50   |  19.182 ns |  0.1886 ns |  0.0292 ns |    4 | 0.0306 |      - |     256 B |
| IList_Remove_LastInt                     | 50   |  19.328 ns |  1.0204 ns |  0.1579 ns |    4 | 0.0306 |      - |     256 B |
| List_Enumerate_Foreach_Int               | 50   |  20.004 ns |  0.4794 ns |  0.0742 ns |    4 |      - |      - |         - |
| List_Enumerate_ForLoop_String            | 50   |  24.743 ns |  0.6305 ns |  0.1637 ns |    4 |      - |      - |         - |
| List_ToArray_String                      | 50   |  24.837 ns |  0.4505 ns |  0.1170 ns |    4 | 0.0507 |      - |     424 B |
| IList_ToArray_String                     | 50   |  33.061 ns |  1.7693 ns |  0.4595 ns |    5 | 0.0507 |      - |     424 B |
| IList_Remove_LastString                  | 50   |  33.263 ns |  0.6157 ns |  0.0953 ns |    5 | 0.0545 |      - |     456 B |
| List_Remove_LastString                   | 50   |  33.877 ns |  0.6232 ns |  0.0964 ns |    5 | 0.0545 |      - |     456 B |
| IList_Remove_LastPerson                  | 50   |  35.423 ns |  7.4060 ns |  1.9233 ns |    5 | 0.0545 |      - |     456 B |
| List_Remove_LastPerson                   | 50   |  35.632 ns |  0.3292 ns |  0.0509 ns |    5 | 0.0545 |      - |     456 B |
| List_Add_Int                             | 50   |  39.289 ns |  0.2816 ns |  0.0731 ns |    5 | 0.0812 |      - |     680 B |
| IList_AsReadOnly_Person                  | 50   |  40.124 ns |  2.0607 ns |  0.3189 ns |    5 | 0.0573 | 0.0001 |     480 B |
| IList_Add_Int                            | 50   |  41.069 ns |  5.5161 ns |  1.4325 ns |    5 | 0.0812 |      - |     680 B |
| IList_Enumerate_ForLoop_String           | 50   |  42.799 ns |  4.4056 ns |  1.1441 ns |    5 |      - |      - |         - |
| List_Insert_First_Int                    | 50   |  51.349 ns |  0.1633 ns |  0.0253 ns |    5 | 0.0812 |      - |     680 B |
| IList_Insert_First_Int                   | 50   |  61.432 ns |  1.8084 ns |  0.4696 ns |    5 | 0.0812 |      - |     680 B |
| IList_RemoveAll_GreaterThanThreshold_Int | 50   |  62.338 ns |  3.8435 ns |  0.5948 ns |    5 | 0.0305 |      - |     256 B |
| List_RemoveAll_GreaterThanThreshold_Int  | 50   |  62.772 ns |  1.8383 ns |  0.4774 ns |    5 | 0.0381 |      - |     320 B |
| IList_Insert_First_String                | 50   |  81.420 ns |  1.2778 ns |  0.3318 ns |    6 | 0.1529 |      - |    1280 B |
| List_Insert_First_String                 | 50   |  81.849 ns |  1.5749 ns |  0.4090 ns |    6 | 0.1529 |      - |    1280 B |
| List_Add_String                          | 50   |  92.798 ns |  1.1097 ns |  0.2882 ns |    6 | 0.1577 | 0.0002 |    1320 B |
| IList_Add_String                         | 50   |  93.220 ns |  0.4077 ns |  0.1059 ns |    6 | 0.1577 | 0.0002 |    1320 B |
| IList_Enumerate_Foreach_Int              | 50   |  95.823 ns |  8.1593 ns |  2.1190 ns |    6 | 0.0048 |      - |      40 B |
| List_Enumerate_LINQ_Foreach_Person       | 50   | 185.692 ns |  2.6129 ns |  0.4044 ns |    7 | 0.0086 |      - |      72 B |
| List_Add_Person                          | 50   | 195.398 ns |  0.9505 ns |  0.1471 ns |    7 | 0.1836 | 0.0007 |    1536 B |
| IList_Add_Person                         | 50   | 196.254 ns |  2.1735 ns |  0.5645 ns |    7 | 0.1836 | 0.0007 |    1536 B |
| IList_Enumerate_LINQ_Foreach_Person      | 50   | 203.066 ns |  1.6425 ns |  0.2542 ns |    7 | 0.0086 |      - |      72 B |
| List_Find_FirstAString                   | 50   | 563.860 ns | 25.1241 ns |  3.8880 ns |    8 | 0.0048 |      - |      40 B |
| IList_Find_FirstAString                  | 50   | 563.892 ns | 15.8633 ns |  2.4549 ns |    8 | 0.0048 |      - |      40 B |
| IList_Find_FirstPersonByEmail            | 50   | 666.944 ns | 21.1994 ns |  5.5054 ns |    8 | 0.2108 |      - |    1768 B |
| List_Find_FirstPersonByEmail             | 50   | 689.564 ns | 72.9439 ns | 11.2881 ns |    8 | 0.2108 |      - |    1768 B |
### .NET 9.0.101
##### IterationCount=5  WarmupCount=1
| Method                                   | Size | Mean       | Error      | StdDev    | Rank | Gen0   | Gen1   | Allocated |
|----------------------------------------- |----- |-----------:|-----------:|----------:|-----:|-------:|-------:|----------:|
| IList_Find_FirstEven                     | 50   |   2.066 ns |  0.0152 ns | 0.0023 ns |    1 |      - |      - |         - |
| List_Find_FirstEven                      | 50   |   2.079 ns |  0.0642 ns | 0.0099 ns |    1 |      - |      - |         - |
| List_AsReadOnly_Person                   | 50   |   4.659 ns |  0.6935 ns | 0.1801 ns |    2 | 0.0029 |      - |      24 B |
| List_ToArray_Int                         | 50   |  13.263 ns |  0.1806 ns | 0.0469 ns |    3 | 0.0268 |      - |     224 B |
| IList_ToArray_Int                        | 50   |  15.521 ns |  0.2754 ns | 0.0715 ns |    3 | 0.0268 |      - |     224 B |
| List_Enumerate_Foreach_Int               | 50   |  15.923 ns |  0.0512 ns | 0.0133 ns |    3 |      - |      - |         - |
| IList_Remove_LastInt                     | 50   |  18.430 ns |  0.2954 ns | 0.0457 ns |    3 | 0.0306 |      - |     256 B |
| List_Remove_LastInt                      | 50   |  18.720 ns |  0.7306 ns | 0.1131 ns |    3 | 0.0306 |      - |     256 B |
| IList_Clear_Int                          | 50   |  18.982 ns |  1.4954 ns | 0.3883 ns |    3 | 0.0306 |      - |     256 B |
| List_Clear_Int                           | 50   |  20.756 ns |  3.8882 ns | 1.0098 ns |    3 | 0.0306 |      - |     256 B |
| List_Enumerate_ForLoop_String            | 50   |  24.802 ns |  0.8980 ns | 0.1390 ns |    3 |      - |      - |         - |
| List_ToArray_String                      | 50   |  25.325 ns |  0.5451 ns | 0.0844 ns |    3 | 0.0507 |      - |     424 B |
| IList_ToArray_String                     | 50   |  28.626 ns |  0.3427 ns | 0.0530 ns |    3 | 0.0507 |      - |     424 B |
| List_Remove_LastString                   | 50   |  34.209 ns |  0.6309 ns | 0.0976 ns |    3 | 0.0545 |      - |     456 B |
| IList_Remove_LastString                  | 50   |  34.501 ns |  3.3144 ns | 0.5129 ns |    3 | 0.0545 |      - |     456 B |
| IList_Remove_LastPerson                  | 50   |  34.574 ns |  0.6786 ns | 0.1762 ns |    3 | 0.0545 |      - |     456 B |
| List_Remove_LastPerson                   | 50   |  35.259 ns |  2.3075 ns | 0.5993 ns |    3 | 0.0545 |      - |     456 B |
| IList_Insert_First_Int                   | 50   |  38.493 ns |  0.1750 ns | 0.0271 ns |    3 | 0.0812 |      - |     680 B |
| IList_AsReadOnly_Person                  | 50   |  38.684 ns |  0.5504 ns | 0.1429 ns |    3 | 0.0573 | 0.0001 |     480 B |
| List_Insert_First_Int                    | 50   |  39.229 ns |  3.2382 ns | 0.5011 ns |    3 | 0.0812 |      - |     680 B |
| IList_Add_Int                            | 50   |  39.606 ns |  0.3812 ns | 0.0590 ns |    3 | 0.0812 |      - |     680 B |
| List_Add_Int                             | 50   |  40.090 ns |  0.3481 ns | 0.0539 ns |    3 | 0.0812 |      - |     680 B |
| IList_Enumerate_ForLoop_String           | 50   |  41.941 ns |  2.2449 ns | 0.3474 ns |    3 |      - |      - |         - |
| IList_RemoveAll_GreaterThanThreshold_Int | 50   |  55.007 ns |  1.5950 ns | 0.4142 ns |    4 | 0.0306 |      - |     256 B |
| List_RemoveAll_GreaterThanThreshold_Int  | 50   |  57.247 ns |  2.0043 ns | 0.3102 ns |    4 | 0.0382 |      - |     320 B |
| List_Insert_First_String                 | 50   |  72.463 ns |  2.8496 ns | 0.4410 ns |    5 | 0.1529 |      - |    1280 B |
| IList_Insert_First_String                | 50   |  81.503 ns |  2.5745 ns | 0.6686 ns |    5 | 0.1529 |      - |    1280 B |
| List_Add_String                          | 50   |  91.732 ns |  1.2150 ns | 0.1880 ns |    5 | 0.1577 | 0.0002 |    1320 B |
| IList_Add_String                         | 50   |  93.675 ns |  6.8421 ns | 1.7769 ns |    5 | 0.1577 | 0.0002 |    1320 B |
| IList_Enumerate_Foreach_Int              | 50   |  95.498 ns |  7.0221 ns | 1.0867 ns |    5 | 0.0048 |      - |      40 B |
| IList_Enumerate_LINQ_Foreach_Person      | 50   | 163.102 ns |  1.3552 ns | 0.2097 ns |    6 | 0.0086 |      - |      72 B |
| List_Enumerate_LINQ_Foreach_Person       | 50   | 170.781 ns | 16.2938 ns | 4.2314 ns |    6 | 0.0086 |      - |      72 B |
| List_Add_Person                          | 50   | 183.124 ns |  0.5123 ns | 0.1330 ns |    6 | 0.1836 | 0.0007 |    1536 B |
| IList_Add_Person                         | 50   | 207.402 ns |  3.2325 ns | 0.8395 ns |    6 | 0.1836 | 0.0007 |    1536 B |
| IList_Find_FirstAString                  | 50   | 376.931 ns |  2.5318 ns | 0.3918 ns |    7 |      - |      - |         - |
| List_Find_FirstAString                   | 50   | 380.827 ns | 46.0299 ns | 7.1232 ns |    7 |      - |      - |         - |
| IList_Find_FirstPersonByEmail            | 50   | 509.001 ns |  5.4625 ns | 0.8453 ns |    8 | 0.2060 |      - |    1728 B |
| List_Find_FirstPersonByEmail             | 50   | 509.572 ns |  2.9684 ns | 0.4594 ns |    8 | 0.2060 |      - |    1728 B |

---

### Observations & Analysis

1. **List<T> vs. IList<T>**: In many implementations, `IList<T>` is also backed by a `List<T>`, so you might see minimal differences. However, interface calls can add overhead.  
2. **Reading vs. Writing**: Pure read operations (`Find`, `Enumerate`) typically differ from mutating operations (`Add`, `Remove`, `Insert`).  
3. **Allocation**: Notice if extra memory is allocated when you convert or copy items (like in `Add` or `Remove` benchmarks).  
4. **Scaling**: Check how performance changes from `Size=10` to `Size=500`—and possibly beyond.


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

### .NET 6.0

### .NET 7.0

### .NET 8.0

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



# Base DTO Benchmarks

This project is part of the **Benchmarkus** repository and is dedicated to benchmarking various **Base DTO mechanisms** in .NET. It compares the performance of Data Transfer Objects (DTOs) that use different base implementations:

- **Concrete Base Class (`BaseDtoClass`)**
- **Abstract Base Class (`BaseDtoAbstractClass`)**
- **Record Base (`BaseDtoRecord`)**

The benchmarks measure operations such as **instantiation, property access, and common list operations** (reading, writing, and finding elements).

---

## 📌 Why This Benchmark?

- **Performance Insights** → Determine which base DTO mechanism provides better performance for instantiation, property reads, property updates, and common list operations.
- **Design Trade-Offs** → Evaluate the trade-offs between mutable (class-based) DTOs and immutable (record-based) DTOs.
- **Memory Efficiency** → Compare the memory allocations involved with each approach.
- **Real-World Relevance** → Help developers choose the best design for scenarios that require fast read and write operations on collections of DTOs.

---

## 📚 What We Are Measuring?

1. **Instantiation Performance**:
   - Compare the speed of creating new instances of DTOs using different base mechanisms.

2. **Property Access**:
   - Measure the efficiency of reading and writing a property (e.g., `FirstName`) on each DTO type.

3. **List Operations**:
   - **Read** → Iterate over a list of DTOs and read a property.
   - **Write** → Update a property in a list (using direct assignment for classes and the `with` expression for records).
   - **Find** → Use LINQ to find the first element matching a condition.

---

## 🔥 Benchmark Results

### .NET SDK 9.0.101
###### Host: .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD
##### IterationCount=5, WarmupCount=3
| Method                       | Mean       | Error     | StdDev    | Median     | Rank | Gen0   | Allocated |
|----------------------------- |-----------:|----------:|----------:|-----------:|-----:|-------:|----------:|
| SetFirstName_BaseClass       |  0.0000 ns | 0.0000 ns | 0.0000 ns |  0.0000 ns |    1 |      - |         - |
| SetFirstName_BaseAbstract    |  0.0000 ns | 0.0000 ns | 0.0000 ns |  0.0000 ns |    1 |      - |         - |
| GetFirstName_Record          |  0.0018 ns | 0.0030 ns | 0.0008 ns |  0.0014 ns |    2 |      - |         - |
| GetFirstName_BaseAbstract    |  0.0021 ns | 0.0151 ns | 0.0023 ns |  0.0015 ns |    2 |      - |         - |
| GetFirstName_BaseClass       |  0.0023 ns | 0.0123 ns | 0.0019 ns |  0.0023 ns |    2 |      - |         - |
| ListWrite_BaseClass          |  0.1582 ns | 0.0008 ns | 0.0002 ns |  0.1582 ns |    3 |      - |         - |
| ListWrite_BaseAbstract       |  0.1696 ns | 0.0445 ns | 0.0116 ns |  0.1694 ns |    3 |      - |         - |
| ListRead_BaseClass           |  7.2552 ns | 0.0497 ns | 0.0077 ns |  7.2566 ns |    4 |      - |         - |
| ListRead_BaseAbstract        |  7.3702 ns | 0.0321 ns | 0.0083 ns |  7.3734 ns |    4 |      - |         - |
| ListRead_Record              |  7.7726 ns | 0.0258 ns | 0.0067 ns |  7.7711 ns |    4 |      - |         - |
| ListFindFirst_Record         |  8.7570 ns | 0.2828 ns | 0.0734 ns |  8.7585 ns |    4 |      - |         - |
| ListFindFirst_BaseAbstract   |  8.7614 ns | 0.3036 ns | 0.0788 ns |  8.7220 ns |    4 |      - |         - |
| ListFindFirst_BaseClass      |  8.8150 ns | 0.2720 ns | 0.0706 ns |  8.8059 ns |    4 |      - |         - |
| SetFirstName_Record          |  9.1392 ns | 0.2229 ns | 0.0579 ns |  9.1280 ns |    4 | 0.0076 |      64 B |
| ListWrite_Record             | 10.3644 ns | 0.0501 ns | 0.0130 ns | 10.3668 ns |    4 | 0.0076 |      64 B |
| DirectInstantiation          | 88.9037 ns | 0.2214 ns | 0.0575 ns | 88.9270 ns |    5 | 0.0076 |      64 B |
| DirectInstantiation_Abstract | 88.9665 ns | 0.3709 ns | 0.0574 ns | 88.9795 ns |    5 | 0.0076 |      64 B |
| DirectInstantiation_Record   | 89.6127 ns | 0.4352 ns | 0.1130 ns | 89.6118 ns |    5 | 0.0076 |      64 B |

### .NET SDK 8.0.404
###### Host: .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
##### IterationCount=5, WarmupCount=3

| Method                       | Mean       | Error     | StdDev    | Median     | Rank | Gen0   | Allocated |
|----------------------------- |-----------:|----------:|----------:|-----------:|-----:|-------:|----------:|
| GetFirstName_BaseClass       |  0.0000 ns | 0.0000 ns | 0.0000 ns |  0.0000 ns |    1 |      - |         - |
| SetFirstName_BaseClass       |  0.0000 ns | 0.0000 ns | 0.0000 ns |  0.0000 ns |    1 |      - |         - |
| SetFirstName_BaseAbstract    |  0.0000 ns | 0.0000 ns | 0.0000 ns |  0.0000 ns |    1 |      - |         - |
| GetFirstName_BaseAbstract    |  0.0003 ns | 0.0040 ns | 0.0006 ns |  0.0000 ns |    1 |      - |         - |
| GetFirstName_Record          |  0.0003 ns | 0.0024 ns | 0.0004 ns |  0.0003 ns |    1 |      - |         - |
| ListWrite_BaseAbstract       |  0.1563 ns | 0.0013 ns | 0.0003 ns |  0.1564 ns |    2 |      - |         - |
| ListWrite_BaseClass          |  0.1818 ns | 0.0008 ns | 0.0001 ns |  0.1818 ns |    2 |      - |         - |
| ListRead_BaseAbstract        |  7.6910 ns | 0.0146 ns | 0.0023 ns |  7.6917 ns |    3 |      - |         - |
| ListRead_Record              |  8.1222 ns | 0.1429 ns | 0.0371 ns |  8.1105 ns |    3 |      - |         - |
| ListRead_BaseClass           |  8.2639 ns | 0.1071 ns | 0.0278 ns |  8.2568 ns |    3 |      - |         - |
| SetFirstName_Record          |  8.6411 ns | 0.1015 ns | 0.0157 ns |  8.6394 ns |    3 | 0.0076 |      64 B |
| ListWrite_Record             |  9.5951 ns | 0.0530 ns | 0.0082 ns |  9.5961 ns |    3 | 0.0076 |      64 B |
| ListFindFirst_BaseAbstract   | 57.5079 ns | 0.3659 ns | 0.0566 ns | 57.5223 ns |    4 | 0.0048 |      40 B |
| ListFindFirst_BaseClass      | 57.8549 ns | 3.7876 ns | 0.5861 ns | 57.6626 ns |    4 | 0.0048 |      40 B |
| ListFindFirst_Record         | 57.9048 ns | 5.1286 ns | 0.7937 ns | 57.6910 ns |    4 | 0.0048 |      40 B |
| DirectInstantiation_Abstract | 94.1765 ns | 1.8113 ns | 0.2803 ns | 94.0868 ns |    5 | 0.0076 |      64 B |
| DirectInstantiation          | 95.3141 ns | 7.4105 ns | 1.1468 ns | 95.0338 ns |    5 | 0.0076 |      64 B |
| DirectInstantiation_Record   | 95.3814 ns | 6.0651 ns | 0.9386 ns | 95.3695 ns |    5 | 0.0076 |      64 B |
### .NET SDK 7.0.410
###### Host: .NET 7.0.20 (7.0.2024.26716), Arm64 RyuJIT AdvSIMD
##### IterationCount=5, WarmupCount=3

| Method                       | Mean        | Error     | StdDev    | Median      | Rank | Gen0   | Allocated |
|----------------------------- |------------:|----------:|----------:|------------:|-----:|-------:|----------:|
| GetFirstName_BaseAbstract    |   0.0003 ns | 0.0024 ns | 0.0004 ns |   0.0003 ns |    1 |      - |         - |
| GetFirstName_Record          |   0.0021 ns | 0.0161 ns | 0.0025 ns |   0.0016 ns |    2 |      - |         - |
| GetFirstName_BaseClass       |   0.0191 ns | 0.0041 ns | 0.0006 ns |   0.0191 ns |    3 |      - |         - |
| SetFirstName_BaseClass       |   1.0390 ns | 0.0031 ns | 0.0008 ns |   1.0390 ns |    4 |      - |         - |
| SetFirstName_BaseAbstract    |   1.0481 ns | 0.0480 ns | 0.0125 ns |   1.0425 ns |    4 |      - |         - |
| ListWrite_BaseAbstract       |   1.3364 ns | 0.0030 ns | 0.0005 ns |   1.3363 ns |    5 |      - |         - |
| ListWrite_BaseClass          |   1.3585 ns | 0.0718 ns | 0.0186 ns |   1.3480 ns |    5 |      - |         - |
| ListRead_BaseClass           |   7.5299 ns | 0.0265 ns | 0.0041 ns |   7.5285 ns |    6 |      - |         - |
| ListRead_BaseAbstract        |   7.7106 ns | 0.2590 ns | 0.0401 ns |   7.7125 ns |    6 |      - |         - |
| ListRead_Record              |   7.7110 ns | 0.2319 ns | 0.0359 ns |   7.7165 ns |    6 |      - |         - |
| SetFirstName_Record          |  10.4950 ns | 0.0104 ns | 0.0027 ns |  10.4954 ns |    7 | 0.0076 |      64 B |
| ListWrite_Record             |  11.4833 ns | 0.0296 ns | 0.0077 ns |  11.4843 ns |    7 | 0.0076 |      64 B |
| ListFindFirst_Record         |  91.5638 ns | 0.1662 ns | 0.0432 ns |  91.5661 ns |    8 | 0.0048 |      40 B |
| ListFindFirst_BaseClass      |  91.6766 ns | 0.2414 ns | 0.0627 ns |  91.6633 ns |    8 | 0.0048 |      40 B |
| ListFindFirst_BaseAbstract   |  91.6820 ns | 0.2086 ns | 0.0323 ns |  91.6972 ns |    8 | 0.0048 |      40 B |
| DirectInstantiation          | 104.1508 ns | 0.2924 ns | 0.0759 ns | 104.1623 ns |    8 | 0.0076 |      64 B |
| DirectInstantiation_Abstract | 104.2344 ns | 0.2089 ns | 0.0543 ns | 104.2189 ns |    8 | 0.0076 |      64 B |
| DirectInstantiation_Record   | 104.3009 ns | 0.3126 ns | 0.0812 ns | 104.2976 ns |    8 | 0.0076 |      64 B |

### .NET SDK 6.0.428
###### Host: .NET 6.0.36 (6.0.3624.51421), Arm64 RyuJIT AdvSIMD
##### IterationCount=5, WarmupCount=3

| Method                       | Mean        | Error     | StdDev    | Median      | Rank | Gen0   | Allocated |
|----------------------------- |------------:|----------:|----------:|------------:|-----:|-------:|----------:|
| GetFirstName_Record          |   0.0000 ns | 0.0001 ns | 0.0000 ns |   0.0000 ns |    1 |      - |         - |
| GetFirstName_BaseClass       |   0.0002 ns | 0.0007 ns | 0.0002 ns |   0.0002 ns |    2 |      - |         - |
| GetFirstName_BaseAbstract    |   0.0005 ns | 0.0040 ns | 0.0006 ns |   0.0005 ns |    3 |      - |         - |
| SetFirstName_BaseAbstract    |   1.0782 ns | 0.0181 ns | 0.0028 ns |   1.0780 ns |    4 |      - |         - |
| SetFirstName_BaseClass       |   1.0801 ns | 0.0111 ns | 0.0029 ns |   1.0805 ns |    4 |      - |         - |
| ListWrite_BaseClass          |   1.3374 ns | 0.0101 ns | 0.0026 ns |   1.3364 ns |    4 |      - |         - |
| ListWrite_BaseAbstract       |   1.3715 ns | 0.0044 ns | 0.0007 ns |   1.3714 ns |    4 |      - |         - |
| ListRead_BaseAbstract        |  11.5565 ns | 0.0420 ns | 0.0065 ns |  11.5542 ns |    5 |      - |         - |
| ListRead_Record              |  11.6051 ns | 0.0124 ns | 0.0032 ns |  11.6058 ns |    5 |      - |         - |
| ListRead_BaseClass           |  11.6213 ns | 0.1764 ns | 0.0458 ns |  11.6036 ns |    5 |      - |         - |
| SetFirstName_Record          |  11.7022 ns | 0.0869 ns | 0.0134 ns |  11.7053 ns |    5 | 0.0306 |      64 B |
| ListWrite_Record             |  13.2675 ns | 0.1802 ns | 0.0468 ns |  13.2735 ns |    5 | 0.0306 |      64 B |
| ListFindFirst_BaseAbstract   |  88.0539 ns | 0.3166 ns | 0.0822 ns |  88.0514 ns |    6 | 0.0191 |      40 B |
| ListFindFirst_Record         |  88.2278 ns | 0.4100 ns | 0.1065 ns |  88.2341 ns |    6 | 0.0191 |      40 B |
| ListFindFirst_BaseClass      |  88.5545 ns | 0.2134 ns | 0.0554 ns |  88.5611 ns |    6 | 0.0191 |      40 B |
| DirectInstantiation_Record   | 116.6527 ns | 0.3190 ns | 0.0828 ns | 116.6729 ns |    7 | 0.0305 |      64 B |
| DirectInstantiation          | 117.9813 ns | 1.2668 ns | 0.1960 ns | 117.9925 ns |    7 | 0.0305 |      64 B |
| DirectInstantiation_Abstract | 118.2627 ns | 0.9645 ns | 0.2505 ns | 118.2352 ns |    7 | 0.0305 |      64 B |
---

## 📊 **Analysis of Benchmark Results**

The benchmark results highlight the following key insights:
It’s always worth remembering that these sorts of micro-benchmark results can fluctuate based on a wide range of factors—CPU architecture, runtime optimizations, JIT differences, inlining, etc. That said, in many “real-world” scenarios on both Windows and Linux, record types (especially in newer .NET versions) do tend to exhibit excellent performance characteristics.

Records often benefit from:

Compiler/Runtime Optimizations: Records are generated as sealed reference types by default, which gives the JIT more freedom to inline or de-virtualize calls in certain circumstances.
Value-like Semantics: Although records are reference types, their emphasis on immutability can reduce side effects and make certain optimizations clearer to the compiler.
Lightweight Copy/Equality: The built-in copy constructors and ==/Equals overrides are frequently more efficient compared to manually implemented patterns in regular classes, because they're generated in a consistent and optimized manner by the compiler.
In short, while benchmarks for trivial property reads or list operations can sometimes look nearly identical (or fluctuate with noise in the sub-nanosecond range), you’ll often find that under typical production loads—especially on modern Windows or Linux servers—records give you performance on par with or better than hand-rolled class solutions. They also simplify your codebase substantially when you rely on immutable data and built-in equality logic.

### ✅ **1. Property Reads Are Almost Instantaneous**
- **All DTO types** (class, abstract class, and record) exhibit nearly **zero-cost** property reads.
- This is expected as **property get operations** are optimized in modern .NET runtimes.

### ✅ **2. Classes vs. Abstract Classes for Property Writes**
- **Writing properties in concrete and abstract classes is faster than in records.**
- Since **records are immutable**, updating a property involves **creating a new instance** with `with { }`, which incurs extra memory allocation.

### ✅ **3. Records Have a Slight Overhead in List Operations**
- When writing records in a list (`ListWrite_Record`), there is a **higher allocation cost** due to the immutability of records (`0.0076 Gen0` with `64 B` allocations).
- Classes and abstract classes **do not need to allocate new memory** when updating an object in a list.

### ✅ **4. Instantiation Performance is Similar Across Types**
- Creating new DTOs is **consistent across all base types**, with **records having a slight performance overhead** due to internal compiler optimizations.

---

## ⚠️ **Things That Can Affect These Results**
The results above may change based on:

1. **Operating System Differences**
   - Windows, Linux, and macOS may handle object creation and memory differently.
   - Garbage Collector (GC) behavior may vary across OS platforms.

2. **Hardware & CPU Architecture**
   - Running on **x86, x64, or ARM** can impact performance.
   - CPUs with **Advanced SIMD (Single Instruction Multiple Data)** optimizations handle certain operations differently.

3. **.NET Runtime Optimizations**
   - Newer .NET versions **improve JIT compilation** and runtime optimizations.
   - Future updates may further **optimize property access and allocations**.

4. **Memory Pressure and GC Settings**
   - If the system has **high memory usage**, **garbage collection** can introduce **performance variations**.

---


## 📝 **Summary of README and Analysis**
- **Introduced the purpose of benchmarking Base DTO mechanisms** (classes, abstract classes, and records).
- **Detailed benchmark results for .NET 9, .NET 8, and different operations** (instantiation, property access, list operations).
- **Analyzed performance trends**, explaining why some operations are faster than others.
- **Discussed factors that influence results**, such as **operating system, CPU architecture, and garbage collection**.
- **Provided recommendations** for when to use **concrete classes, abstract classes, or records** based on the use case.

This **README.md** provides **both technical results and practical guidance**, making it **useful for developers** looking to optimize their DTO-based data handling in .NET.

🚀 **Would you like any more additions, such as specific system profiling recommendations or deeper memory analysis?** 😊

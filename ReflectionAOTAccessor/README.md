# ReflectionBenchmarks

This project is part of the **Benchmarkus** repository and focuses on benchmarking various reflection-based operations compared to direct (JIT) operations on a sample `Person` class. The benchmarks measure the performance and memory allocations of operations such as instantiation, property get, and property set using both direct (compiled) code and reflection.

## Why We Do It

- **Performance Insights**: Understand the overhead introduced by reflection compared to direct operations.
- **Optimizing Reflection Usage**: Identify scenarios where reflection is acceptable versus where direct code is significantly more efficient.
- **Memory Impact**: Compare the memory allocations of direct versus reflection‑based property accesses and instantiation.
- **Informed Decision Making**: Help developers decide whether to use reflection or direct code based on performance and memory trade-offs in real-world applications.

## What We Can Learn

1. **Instantiation Overhead**:
   - Compare direct instantiation using the `new` operator with instantiation via `Activator.CreateInstance`.
2. **Property Get Operations**:
   - Measure the speed and memory impact of retrieving a property value directly versus using reflection.
3. **Property Set Operations**:
   - Evaluate the performance differences when setting a property directly versus via reflection.
4. **.NET Version Comparison**:
   - Observe how improvements in the .NET runtime affect the performance of reflection and direct operations.

## Benchmark Results (Placeholder)

Below are example benchmark result tables for different .NET SDK versions. Update these tables with your actual results after running the benchmarks using `dotnet run --configuration Release`.

### .NET SDK 9.0.101
##### IterationCount=5, WarmupCount=3
| Method                  | Mean       | Error     | StdDev    | Rank | Gen0   | Allocated |
|-------------------------|-----------:|----------:|----------:|-----:|-------:|----------:|
| DirectPropertySet       |     0.0000 ns | 0.0000 ns | 0.0000 ns |    1 |      - |         - |
| DirectPropertyGet       |     0.0078 ns | 0.0172 ns | 0.0045 ns |    2 |      - |         - |
| ReflectionPropertyGet   |     6.5290 ns | 0.0710 ns | 0.0110 ns |    3 |      - |         - |
| ReflectionPropertySet   |    10.5370 ns | 0.0938 ns | 0.0243 ns |    4 |      - |         - |
| ReflectionInstantiation |    72.4543 ns | 0.4855 ns | 0.0751 ns |    5 | 0.0238 |     200 B |
| DirectInstantiation     |    74.1971 ns | 0.1173 ns | 0.0181 ns |    5 | 0.0277 |     232 B |

### .NET SDK 8.0.404
##### IterationCount=5, WarmupCount=3
| Method                  | Mean       | Error     | StdDev    | Rank | Gen0   | Allocated |
|-------------------------|-----------:|----------:|----------:|-----:|-------:|----------:|
| DirectPropertySet       |     0.0000 ns | 0.0000 ns | 0.0000 ns |    1 |      - |         - |
| DirectPropertyGet       |     0.0023 ns | 0.0070 ns | 0.0011 ns |    2 |      - |         - |
| ReflectionPropertyGet   |     6.4977 ns | 0.0479 ns | 0.0074 ns |    3 |      - |         - |
| ReflectionPropertySet   |    11.0749 ns | 0.0659 ns | 0.0102 ns |    4 |      - |         - |
| ReflectionInstantiation |    79.0003 ns | 0.4551 ns | 0.0704 ns |    5 | 0.0238 |     200 B |
| DirectInstantiation     |    83.2401 ns | 0.4230 ns | 0.1099 ns |    5 | 0.0277 |     232 B |

### .NET SDK 7.0.410
##### IterationCount=5, WarmupCount=3
| Method                  | Mean       | Error     | StdDev    | Rank | Gen0   | Allocated |
|-------------------------|-----------:|----------:|----------:|-----:|-------:|----------:|
| DirectPropertyGet       |     0.0036 ns | 0.0060 ns | 0.0009 ns |    1 |      - |         - |
| DirectPropertySet       |     1.0330 ns | 0.0115 ns | 0.0030 ns |    2 |      - |         - |
| ReflectionPropertyGet   |     7.0910 ns | 0.0217 ns | 0.0056 ns |    3 |      - |         - |
| ReflectionPropertySet   |    16.8018 ns | 0.0814 ns | 0.0211 ns |    4 |      - |         - |
| ReflectionInstantiation |    89.3296 ns | 0.6016 ns | 0.1562 ns |    5 | 0.0238 |     200 B |
| DirectInstantiation     |    95.0387 ns | 0.4734 ns | 0.1229 ns |    5 | 0.0277 |     232 B |

### .NET SDK 6.0.428
##### IterationCount=5, WarmupCount=3
| Method                  | Mean        | Error     | StdDev    | Rank | Gen0   | Allocated |
|-------------------------|------------:|----------:|----------:|-----:|-------:|----------:|
| DirectPropertyGet       |     0.0263 ns | 0.0599 ns | 0.0093 ns |    1 |      - |         - |
| DirectPropertySet       |     1.0756 ns | 0.0183 ns | 0.0048 ns |    2 |      - |         - |
| ReflectionPropertyGet   |    45.4005 ns | 0.1237 ns | 0.0191 ns |    3 |      - |         - |
| ReflectionPropertySet   |    67.0508 ns | 0.5984 ns | 0.1554 ns |    4 |      - |         - |
| ReflectionInstantiation |   113.9527 ns | 0.9906 ns | 0.2573 ns |    5 | 0.0956 |     200 B |
| DirectInstantiation     |   116.9224 ns | 0.9883 ns | 0.2567 ns |    5 | 0.1109 |     232 B |

---

## Conclusion

These benchmarks illustrate the cost associated with using reflection versus direct access in .NET. Key takeaways include:

- **Direct property access and instantiation are significantly faster** than their reflection-based counterparts.
- **Reflection incurs a measurable overhead**, especially in property get and set operations.
- **Memory allocations** differ slightly between the approaches, with reflection-based instantiation and property access incurring slightly higher costs.
- For high-performance scenarios, use reflection sparingly and prefer direct code when possible.

This project helps developers better understand the trade-offs of using reflection in their applications and encourages more informed decisions about when to use reflection versus direct code.

**Happy Benchmarking!**

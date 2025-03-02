# Benchmarkus <img src="https://img.shields.io/badge/.NET-6-blueviolet" alt=".NET 6 Badge" /> <img src="https://img.shields.io/badge/.NET-7-blueviolet" alt=".NET 7 Badge" /> <img src="https://img.shields.io/badge/.NET-8-blueviolet" alt=".NET 8 Badge" /> <img src="https://img.shields.io/badge/.NET-9-blueviolet" alt=".NET 9 Badge" /> <img src="https://img.shields.io/badge/.NET-10-blueviolet" alt=".NET 10 Badge" /> <img src="https://img.shields.io/badge/BenchmarkDotNet-%E2%9A%A1%20-lightgrey" alt="BenchmarkDotNet Badge" />  <img src="https://img.shields.io/badge/Status-Experimental-yellow" alt="Status: Experimental" /> 
## Overview

| [![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=for-the-badge)](https://github.com/barisozgenn/Benchmarkus/pulls)           | Overview                                                                              |
|-----------------------------|------------------------------------------------------------------------------------------|
|<img src="https://repository-images.githubusercontent.com/899894888/4373c416-d471-4469-8aed-ddfb5f49d001" alt="Benchmarkus by Baris Ozgen Hobby experiements"> |**Benchmarkus** is a performance-focused experimental project by [barisozgenn](https://github.com/barisozgenn). It leverages **.NET** (6, 7, 8, 9, 10) and **BenchmarkDotNet** to explore how various coding patterns, framework features, runtime behaviors, and system-level optimizations influence application performance. The goal is to help developers discover insights and best practices to build faster, more efficient .NET applications.|
### Key Objectives
- **Analyze Different Approaches:** Compare memory usage, throughput, allocation rates, and timing differences across multiple implementations (e.g., record vs. abstract class).  
- **Evaluate Patterns & Techniques:** Investigate how common architectural patterns or coding idioms perform under real-world and synthetic workloads.  
- **Discover Optimizations:** Pinpoint subtle coding changes that significantly impact runtime efficiency, from micro-optimizations to broad architectural improvements. Identify subtle changes that impact runtime efficiency, from micro-optimizations to improvements in asynchronous code or data processing strategies.

---

## Repository Structure

| Project                                                                                               | Description                                                                              |
|-------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------|
| **[AsyncSyncTPL](https://github.com/barisozgenn/Benchmarkus/tree/main/AsyncSyncTPL)**    | Async/await overhead, TPL (Task Parallel Library), and various concurrency primitives.  |
| **[BaseRecordAbstractDtos](https://github.com/barisozgenn/Benchmarkus/tree/main/BaseRecordAbstractDtos)**    | Benchmarks comparing record types, base classes, and abstract classes for data models.  |
| **[CollectionOperations](https://github.com/barisozgenn/Benchmarkus/tree/main/CollectionOperations)**        | Various operations on collections (sorting, searching, filtering, etc.).               |
| **[Common](https://github.com/barisozgenn/Benchmarkus/tree/main/Common)**                                 | Shared utilities, extensions, and helpers used across multiple benchmark projects.       |
| **[DataStructureOperations](https://github.com/barisozgenn/Benchmarkus/tree/main/DataStructureOperations)**  | Benchmarks focusing on core data structures like lists, dictionaries, etc.              |
| **[DynamicClassGeneration](https://github.com/barisozgenn/Benchmarkus/tree/main/DynamicClassGeneration)**    | Reflection-based dynamic types and runtime code generation performance tests.            |
| **[GuardNullCheckerAttributes](https://github.com/barisozgenn/Benchmarkus/tree/main/GuardNullCheckerAttributes)** | Null-check and guard-clause attribute experiments for safer, more robust code.      |
| **[JsonOperations](https://github.com/barisozgenn/Benchmarkus/tree/main/JsonOperations)**                   | Benchmarks assessing JSON operations (System.Text vs Newtonsoft) performance.                 |
| **[LINQsQueryApproaches](https://github.com/barisozgenn/Benchmarkus/tree/main/LINQsQueryApproaches)**       | LINQ, PLINQ, SpanLinq, StructLinq, imperative loops comparisons.                         |
| **[ListOperations](https://github.com/barisozgenn/Benchmarkus/tree/main/ListOperations)**                   | Performance comparisons using different List<T> manipulation strategies.                 |
| **[ModelMapping](https://github.com/barisozgenn/Benchmarkus/tree/main/ModelMapping)**                       | Assessing overhead of various object-to-object mapping patterns (e.g., AutoMapper).      |
| **[ReflectionAOTAccessor](https://github.com/barisozgenn/Benchmarkus/tree/main/ReflectionAOTAccessor)**     | Exploring reflection, AOT scenarios, and advanced dynamic method calls.                 |
| **[SortingAlgorithms](https://github.com/barisozgenn/Benchmarkus/tree/main/SortingAlgorithms)**             | Traditional sorting algorithms (e.g., QuickSort, MergeSort) compared head-to-head.       |
| **[StringOperations](https://github.com/barisozgenn/Benchmarkus/tree/main/StringOperations)**               | String manipulation, concatenation, parsing, and related benchmarks.                     |
| **[UnmanagedTypesOperations](https://github.com/barisozgenn/Benchmarkus/tree/main/UnmanagedTypesOperations)**| Experiments with unmanaged memory, span usage, and low-level .NET performance.           |

## Upcoming Benchmark Areas & .NET 10 Enhancements

| Project                                      | Description                                                                                                                                                                           |
|----------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **[AsyncEnhancements](#)**                   | Investigate advanced asynchronous patterns and the latest async improvements introduced in .NET 10.                                                                                     |
| **[MemoryOptimizedCollections](#)**          | Benchmark high-performance collections leveraging .NET 10's runtime optimizations and memory management improvements.                                                                 |
| **[SourceGenerators](#)**                    | Evaluate the performance impact of source generators and code analysis enhancements, particularly as they mature in .NET 10.                                                                |
| **[MinimalAPIsAdvanced](#)**                 | Compare the performance and scalability of .NET 10's new Minimal APIs against traditional approaches in web and microservices.                                                            |
| **[CloudNativePatterns](#)**                 | Explore microservice and cloud-native design patterns, including enhancements in gRPC, HTTP/3, and container-optimized runtimes.                                                         |
| **[MemoryAndGCTuning](#)**                   | Analyze memory allocation patterns, compare different Garbage Collector (GC) modes (server vs. workstation), and benchmark high-performance types like Span<T> and Memory<T>.         |
| **[SerializationDataTransfer](#)**           | Extend JSON benchmarks by exploring alternative serialization formats (e.g., Protobuf, MessagePack) and comparing custom serialization techniques with traditional approaches.     |
| **[DynamicExpressionOperations](#)**         | Benchmark the construction and compilation of expression trees and dynamically generated lambda expressions versus their statically compiled counterparts.                         |
| **[FrameworkAPIBenchmarks](#)**              | Analyze performance differences between data access strategies like EF Core, Dapper, and other micro-ORMs, along with benchmarking .NET Minimal APIs and microservice endpoints.    |
| **[NewLanguageAndRuntime](#)**               | Benchmark advanced C# features (pattern matching, switch expressions) and assess .NET runtime improvements across versions, including JIT enhancements and hardware intrinsics.     |
| **[RealWorldEndToEndScenarios](#)**          | Create benchmarks simulating realistic application workloads (e.g., web request handling, microservice orchestration, data processing pipelines) and evaluate cross-platform differences. |

> **Note:** These projects are planned for future releases and will help expand **Benchmarkus** into a comprehensive performance exploration toolkit, keeping it aligned with the latest .NET 10 features and beyond.

---
## What’s Inside

- **Broad Performance Coverage**  
  From simple operations (like basic arithmetic, string manipulation, or data transfers) to more advanced architectural patterns (such as object mappers, dynamic code generation, or specialized data structures), **Benchmarkus** offers a wide array of performance scenarios. This coverage helps you understand how different strategies hold up under various loads, data sets, and runtime conditions.

- **Methodology & Best Practices**  
  Each benchmark follows a carefully structured approach to measurement, isolating the code under test to produce meaningful and reproducible results. The repository demonstrates the importance of proper warmup, iteration counts, and avoidance of confounding factors (like JIT caching) to ensure you can trust the data collected. Additionally, it encourages best practices such as parameterization, consistent environment setups, and systematic reporting of results.

- **Dynamic Experimentation**  
  Whether you want to experiment with new coding patterns, test the effects of feature toggles, or compare multiple object creation strategies, **Benchmarkus** offers a dynamic playground. You can easily modify or add benchmarks to explore new ideas without committing to a single approach, giving you the freedom to explore .NET’s capabilities in a controlled environment.

---

## Goals

- **Practical Insights**  
  By diving deep into real-world performance scenarios, the benchmarks in **Benchmarkus** illuminate which coding patterns offer the best tradeoffs. Rather than relying on abstract theory or guesswork, you’ll see concrete numbers on memory usage, throughput, and CPU time, helping you decide what may (or may not) be more efficient.

- **Informed Decision-Making**  
  Data-driven insights are crucial when choosing between competing design patterns, libraries, or runtime features. **Benchmarkus** aims to reduce the guesswork by providing quantitative evidence to support or refute assumptions. Developers can leverage these results to guide architectural decisions, refactor priorities, or technology selections with more confidence.

- **Community Involvement**  
  **Benchmarkus** invites contributions from the broader .NET community. By sharing test cases, optimization techniques, or novel approaches, everyone benefits from a richer dataset and more robust comparisons. The repository’s collaborative nature fosters collective experimentation and learning, ensuring that knowledge is continuously updated and refined.

---

## Why Benchmarkus?

1. **Broad Performance Coverage**  
   Covers everything from data structures and collection operations to reflection and dynamic class generation.

2. **Methodology & Best Practices**  
   Encourages systematic measurement, proper environment setup, and reproducible results via BenchmarkDotNet.

3. **Dynamic Experimentation**  
   Allows developers to add or modify benchmarks easily, testing new .NET features, patterns, or libraries.

4. **Community Involvement**  
   Contributions and pull requests are welcome! Share your scenarios, code patterns, or optimization ideas.

---

## Contributing
- **Pull Requests:** PRs are always welcome. Please ensure benchmarks produce deterministic results and follow standard best practices for measurement.
- **Issues & Feedback:** Use the [issue tracker](https://github.com/barisozgenn/Benchmarkus/issues) to report bugs, request new benchmarks, or share any feedback.

---
## Benchmark Environment
All benchmarks in this repository are run with **BenchmarkDotNet v0.14.0** on:
- **macOS Sequoia 15.3** (24D60) \[Darwin 24.3.0\]
- **Apple M2**, 1 CPU, 8 logical and 8 physical cores, **Arm64 RyuJIT AdvSIMD**  

**Note:** Results may vary on different operating systems or hardware configurations or benchmark configurations.

---
## License
This project is licensed under the [MIT License](LICENSE).

---

## Stay Connected
- **GitHub:** [barisozgenn](https://github.com/barisozgenn)  
- **YouTube:** [@barisozgen](https://youtube.com/@barisozgen)

---

Happy benchmarking!

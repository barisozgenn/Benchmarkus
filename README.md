# Benchmarkus <img src="https://img.shields.io/badge/.NET-6-blueviolet" alt=".NET 6 Badge" /> <img src="https://img.shields.io/badge/.NET-7-blueviolet" alt=".NET 7 Badge" /> <img src="https://img.shields.io/badge/.NET-8-blueviolet" alt=".NET 8 Badge" /> <img src="https://img.shields.io/badge/.NET-9-blueviolet" alt=".NET 9 Badge" /> <img src="https://img.shields.io/badge/BenchmarkDotNet-%E2%9A%A1%20-lightgrey" alt="BenchmarkDotNet Badge" /> <img src="https://img.shields.io/badge/Status-Experimental-yellow" alt="Status: Experimental" />

[![Build](https://img.shields.io/github/actions/workflow/status/barisozgenn/Benchmarkus/build.yml?style=for-the-badge&color=brightgreen)](https://github.com/barisozgenn/Benchmarkus/actions)
[![License](https://img.shields.io/github/license/barisozgenn/Benchmarkus.svg?style=for-the-badge&color=blue)](https://github.com/barisozgenn/Benchmarkus/blob/main/LICENSE)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=for-the-badge)](https://github.com/barisozgenn/Benchmarkus/pulls)

---

## Overview
**Benchmarkus** is a performance-focused experimental project by [barisozgenn](https://github.com/barisozgenn). It leverages **.NET** (6, 7, 8, 9) and **BenchmarkDotNet** to explore how various coding patterns, framework features, runtime behaviors, and system-level optimizations influence application performance. The goal is to help developers discover insights and best practices to build faster, more efficient .NET applications.

### Key Objectives
- **Analyze Different Approaches:** Compare memory usage, throughput, allocation rates, and timing differences across multiple implementations (e.g., record vs. abstract class).  
- **Evaluate Patterns & Techniques:** Investigate how common architectural patterns or coding idioms perform under real-world and synthetic workloads.  
- **Discover Optimizations:** Pinpoint subtle coding changes that significantly impact runtime efficiency, from micro-optimizations to broad architectural improvements. Identify subtle changes that impact runtime efficiency, from micro-optimizations to improvements in asynchronous code or data processing strategies.

---

## Repository Structure

| Folder/Project              | Description                                                                              |
|-----------------------------|------------------------------------------------------------------------------------------|
| **BaseRecordAbstractDtos**  | Benchmarks comparing record types, base classes, and abstract classes for data models.  |
| **CollectionOperations**    | Various operations on collections (sorting, searching, filtering, etc.).               |
| **Common**                  | Shared utilities, extensions, and helpers used across multiple benchmark projects.       |
| **DataStructureOperations** | Benchmarks focusing on core data structures like lists, dictionaries, etc.              |
| **DynamicClassGeneration**  | Reflection-based dynamic types and runtime code generation performance tests.            |
| **GuardNullCheckerAttributes** | Null-check and guard-clause attribute experiments for safer, more robust code.      |
| **JsonOperations**          | Benchmarks assessing JSON serialization and deserialization performance.                 |
| **ListOperations**          | Performance comparisons using different List<T> manipulation strategies.                 |
| **ModelMapping**            | Assessing overhead of various object-to-object mapping patterns (e.g., AutoMapper).      |
| **ReflectionAOTAccessor**   | Exploring reflection, AOT scenarios, and advanced dynamic method calls.                 |
| **SortingAlgorithms**       | Traditional sorting algorithms (e.g., QuickSort, MergeSort) compared head-to-head.       |
| **StringOperations**        | String manipulation, concatenation, parsing, and related benchmarks.                     |
| **UnmanagedTypesOperations**| Experiments with unmanaged memory, span usage, and low-level .NET performance.           |

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

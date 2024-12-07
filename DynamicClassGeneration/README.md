# DynamicClassGeneration

**DynamicClassGeneration** is a sub-project within [Benchmarkus](https://github.com/barisozgenn/Benchmarkus/). It focuses on exploring and evaluating different approaches to runtime code generation, dynamic type creation, and method invocation techniques within the .NET ecosystem.

### Purpose & Motivation

Modern .NET applications often require dynamic behavior—ranging from generating code on the fly to extending application capabilities at runtime. Traditional reflection-based methods can be flexible, but may incur performance costs. **DynamicClassGeneration** aims to:

- **Investigate Alternatives:** Compare reflection-heavy approaches (e.g., `AssemblyBuilder`, `System.Reflection.Emit`) with other strategies like Roslyn-based code generation.
- **Assess Performance Impact:** Use benchmarks to measure how different dynamic generation methods affect execution time, memory usage, and overall efficiency.
- **Offer Practical Insights:** Provide guidance on when to choose a particular approach based on empirical data, rather than assumptions.

### Key Focus Areas

1. **Roslyn Integration:**  
   Explore how leveraging Roslyn’s compiler services enables in-memory code compilation and on-the-fly type creation.

2. **Reflection vs. Delegates vs. Factories:**  
   Benchmark various techniques for instantiating objects and invoking methods, ranging from full reflection calls to pre-compiled factory delegates.

3. **Realistic Scenarios:**  
   Consider both micro-benchmarks (e.g., measuring overhead of creating a single object) and more complex scenarios (like dynamically generating entire sets of classes).

### Goals

- **Better Decision-Making:**  
  Help us as developers choose the most suitable runtime type-generation method for their scenarios by providing actual performance data and analysis.
  
- **Demystifying Complexity:**  
  Clarify the trade-offs and break down the complexity behind different dynamic code generation strategies.
  
- **Contributions & Evolution:**  
  Invite community contributions to expand the range of benchmarks, integrate new techniques, or refine existing tests as the .NET ecosystem evolves.

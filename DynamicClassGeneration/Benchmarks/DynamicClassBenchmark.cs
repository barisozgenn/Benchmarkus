using System;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Benchmarkus.DynamicGeneration;

namespace Benchmarkus.DynamicGeneration.Benchmarks
{
    /// <summary>
    /// A combined benchmark that covers:
    /// - Dynamic class creation and instantiation
    /// - Reflection-based invocation vs. cached delegate invocation
    /// 
    /// We compile a dynamic type at runtime and then measure the cost of:
    /// 1. Creating instances repeatedly
    /// 2. Reusing a previously created instance
    /// 3. Invoking a method via reflection
    /// 4. Invoking a method via a cached delegate
    /// </summary>
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [SimpleJob(warmupCount:5, iterationCount:20)]
    public class DynamicClassBenchmark
    {
        private const string SourceCode = @"
using System;
namespace DynamicNamespace
{
    public class GeneratedType
    {
        public int Add(int x, int y) => x + y;
    }
}
";

        private Assembly? _assembly;
        private object? _instance;
        private Func<int, int, int>? _cachedDelegate;

        [GlobalSetup]
        public void Setup()
        {
            // Compile the source code to an in-memory assembly
            _assembly = DynamicClassGenerator.CompileSourceToAssembly(SourceCode);
            if (_assembly == null)
                throw new InvalidOperationException("Failed to compile dynamic code.");

            // Create a single instance for reuse
            _instance = DynamicClassGenerator.CreateInstance(_assembly, "DynamicNamespace.GeneratedType");
            if (_instance == null)
                throw new InvalidOperationException("Failed to create instance of the generated type.");

            // Prepare the cached delegate for invocation
            var method = _instance.GetType().GetMethod("Add", new[] { typeof(int), typeof(int) });
            if (method == null)
                throw new InvalidOperationException("The 'Add' method was not found on the generated type.");

            _cachedDelegate = (Func<int, int, int>)method.CreateDelegate(typeof(Func<int, int, int>), _instance);
        }

        // ---------------------
        // Creation Benchmarks
        // ---------------------

        [Benchmark]
        public object CreateInstance_OneTime()
        {
            // Each call compiles and creates a new instance (expensive operation)
            var asm = DynamicClassGenerator.CompileSourceToAssembly(SourceCode);
            return DynamicClassGenerator.CreateInstance(asm!, "DynamicNamespace.GeneratedType")!;
        }

        [Benchmark]
        public object ReuseInstance()
        {
            // Return the already created instance (minimal overhead)
            return _instance!;
        }

        // ---------------------
        // Invocation Benchmarks
        // ---------------------

        [Benchmark]
        public int ReflectionInvoke()
        {
            // Use reflection each time we invoke the method
            var result = DynamicClassInvoker.InvokeMethodByName(_instance!, "Add", 5, 10);
            return (int)result!;
        }

        [Benchmark]
        public int DelegateInvoke()
        {
            // Use the cached delegate to invoke the method (faster than reflection)
            return _cachedDelegate!(5, 10);
        }
    }
}
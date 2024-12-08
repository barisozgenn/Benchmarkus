using System;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Benchmarkus.DynamicGeneration;

namespace Benchmarkus.DynamicGeneration.Benchmarks
{
    /// <summary>
    /// Benchmarks focusing on the invocation cost of a dynamically generated method.
    /// Compares reflection-based invocation vs. cached delegate invocation.
    /// </summary>
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [SimpleJob(warmupCount:5, iterationCount:20)]
    public class DynamicInvocationBenchmark
    {
        private const string SourceCode = @"
using System;
namespace DynamicNamespace
{
    public class GeneratedType
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
";

        private object? _instance;
        private Func<int, int, int>? _cachedDelegate;

        [GlobalSetup]
        public void Setup()
        {
            var asm = DynamicClassGenerator.CompileSourceToAssembly(SourceCode);
            _instance = DynamicClassGenerator.CreateInstance(asm!, "DynamicNamespace.GeneratedType");
            if (_instance == null)
                throw new InvalidOperationException("Failed to create instance.");

            // Initialize the delegate here so it's ready for DelegateInvoke
            var method = _instance.GetType().GetMethod("Add", new[] { typeof(int), typeof(int) });
            if (method == null)
                throw new InvalidOperationException("The 'Add' method was not found on the generated type.");

            _cachedDelegate = (Func<int, int, int>)method.CreateDelegate(typeof(Func<int, int, int>), _instance);
        }

        [Benchmark]
        public int ReflectionInvoke()
        {
            var result = DynamicClassInvoker.InvokeMethodByName(_instance!, "Add", 5, 10);
            return (int)result!;
        }

        [Benchmark]
        public int DelegateInvoke()
        {
            // _cachedDelegate should no longer be null since it's set in Setup()
            return _cachedDelegate!(5, 10);
        }
    }
}

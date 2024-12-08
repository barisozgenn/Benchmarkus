using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarkus.DynamicGeneration.Benchmarks
{
    /// <summary>
    /// Benchmarks comparing different ways of generating and instantiating types at runtime.
    /// We use dynamic code generation via Roslyn vs. other strategies (if implemented).
    /// </summary>
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class DynamicCreationBenchmark
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

        private object? _generatedInstance;

        [GlobalSetup]
        public void Setup()
        {
            var asm = DynamicClassGenerator.CompileSourceToAssembly(SourceCode);
            if (asm == null)
            {
                throw new InvalidOperationException("Failed to compile dynamic code.");
            }

            _generatedInstance = DynamicClassGenerator.CreateInstance(asm, "DynamicNamespace.GeneratedType");
            if (_generatedInstance == null)
            {
                throw new InvalidOperationException("Failed to create instance of the generated type.");
            }
        }

        [Benchmark]
        public object CreateInstance_OneTime()
        {
            var asm = DynamicClassGenerator.CompileSourceToAssembly(SourceCode);
            return DynamicClassGenerator.CreateInstance(asm!, "DynamicNamespace.GeneratedType")!;
        }

        [Benchmark]
        public object ReuseInstance()
        {
            // Just return the already created instance to measure base overhead
            return _generatedInstance!;
        }
    }
}
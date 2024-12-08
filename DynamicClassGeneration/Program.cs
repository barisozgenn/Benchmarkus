using BenchmarkDotNet.Running;
using Benchmarkus.DynamicGeneration.Benchmarks;

Console.WriteLine("Hello, World!");

// Run a single benchmark class:
//BenchmarkRunner.Run<DynamicCreationBenchmark>();

// If you want to run multiple benchmark classes, you can call them separately:
// BenchmarkRunner.Run<DynamicInvocationBenchmark>();

// Or run all benchmarks in an assembly:
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

//Running steps:
//dotnet restore
//dotnet build
//dotnet run -c Release --project ./DynamicClassGeneration/DynamicClassGeneration.csproj
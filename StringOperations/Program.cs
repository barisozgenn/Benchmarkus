// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using StringOperations.Benchmarks;

Console.WriteLine("Hello, World!");
BenchmarkRunner.Run<StringBenchmarks>();
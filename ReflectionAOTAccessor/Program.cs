// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using ReflectionAOTAccessor;

Console.WriteLine("Hello, World!");
BenchmarkRunner.Run<ReflectionBenchmarks>();
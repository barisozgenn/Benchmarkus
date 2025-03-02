// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using LINQsQueryApproaches;

Console.WriteLine("Hello, World!");
BenchmarkRunner.Run<LINQsQueryBenchmarks>();
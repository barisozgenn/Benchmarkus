// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Benchmarkus.AsyncSyncTPL;

Console.WriteLine("Hello, World!");
BenchmarkRunner.Run<AsyncSyncTPLBenchmarks>();
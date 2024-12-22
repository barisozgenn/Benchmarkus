// See https://aka.ms/new-console-template for more information
//dotnet add SortingAlgorithms/SortingAlgorithms.csproj package BenchmarkDotNet
//cd SortingAlgorithms/
//dotnet run -c Release
using BenchmarkDotNet.Running;
using Benchmarkus.SortingAlgorithms;

Console.WriteLine("Hello, World!");
BenchmarkRunner.Run<SortingAlgorithmsBenchmarks>();
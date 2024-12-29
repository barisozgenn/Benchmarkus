// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using CollectionOperations.Benchmarks;

Console.WriteLine("Hello, World!");
var summary = BenchmarkRunner.Run<CollectionBenchmark>();
//dotnet add package BenchmarkDotNet --version 0.13.5
//dotnet --list-sdks
//dotnet new globaljson --sdk-version 7.0.200
/*
{
  "sdk": {
    "version": "6.0.428",
    "rollForward": "latestPatch"
  }
}
*/
//Running steps:
//dotnet restore
//dotnet build
//dotnet run -c Release
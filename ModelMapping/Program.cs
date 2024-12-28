// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using ModelMapping;

Console.WriteLine("Starting benchmarks...");
var summary = BenchmarkRunner.Run<MapperBenchmarks>();
Console.WriteLine("Benchmarks completed.");
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

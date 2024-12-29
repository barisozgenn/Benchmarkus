// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using DataStructureOperations.Benchmarks;

Console.WriteLine("Hello, World!");
var summary = BenchmarkRunner.Run<DataStructureBenchmark>();
//dotnet --list-sdks
//dotnet new globaljson --sdk-version 6.0.428
/*
{
  "sdk": {
    "version": "6.0.428",
    "rollForward": "latestPatch"
  }
}*/
//dotnet add package BenchmarkDotNet
//Running steps:
//dotnet restore
//dotnet build
//dotnet run -c Release --project ./DynamicClassGeneration/DynamicClassGeneration.csproj
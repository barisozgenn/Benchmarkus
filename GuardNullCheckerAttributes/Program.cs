// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using GuardNullCheckerAttributes;

Console.WriteLine("Hello, World!");
var summary = BenchmarkRunner.Run<GuardNullCheckerAttributesBenchmarks>();

using UnmanagedTypesOperations;
using BenchmarkDotNet.Running;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
BenchmarkRunner.Run<AllocationUnManagedTypesBenchmarks>();

// Display sizes of unmanaged struct generics
AllocationUnManagedTypesBenchmarks.DisplayUnmanagedStructSize<SomeVariableTypeGeneric<int>>();
AllocationUnManagedTypesBenchmarks.DisplayUnmanagedStructSize<SomeVariableTypeGeneric<double>>();
AllocationUnManagedTypesBenchmarks.DisplayUnmanagedStructSize<SomeVariableTypeGeneric<float>>();
AllocationUnManagedTypesBenchmarks.DisplayUnmanagedStructSize<SomeVariableTypeGeneric<long>>();
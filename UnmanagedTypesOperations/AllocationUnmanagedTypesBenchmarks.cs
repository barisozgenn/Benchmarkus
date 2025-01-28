using BenchmarkDotNet.Attributes;
using UnmanagedTypesOperations;
[MemoryDiagnoser] 
public class AllocationUnManagedTypesBenchmarks
{
    private const int LoopCount = 1_00;

    // 1) Single allocations

    [Benchmark]
    public int[] AllocateIntArrayOnce()
    {
        return new int[1000];
    }

    [Benchmark]
    public string AllocateStringOnce()
    {
        // Allocate a random 1k-char string
        return new string('a', 1000);
    }

    [Benchmark]
    public bool[] AllocateBoolArrayOnce()
    {
        return new bool[1000];
    }

    [Benchmark]
    public decimal[] AllocateDecimalArrayOnce()
    {
        return new decimal[1000];
    }

    [Benchmark]
    public SomeVariableTypeGeneric<double> AllocateUnmanagedStructOnce()
    {
        // A single struct with double X & Y
        var val = new SomeVariableTypeGeneric<double>
        {
            X = 123.456,
            Y = 789.012
        };
        return val;
    }

    // 2) Allocations in a loop

    [Benchmark]
    public void AllocateIntArrayInLoop()
    {
        for (int i = 0; i < LoopCount; i++)
        {
            var arr = new int[1000];
        }
    }

    [Benchmark]
    public void AllocateStringInLoop()
    {
        for (int i = 0; i < LoopCount; i++)
        {
            // Each loop iteration creates a new string
            var str = new string('a', 1000);
        }
    }

    [Benchmark]
    public void AllocateBoolArrayInLoop()
    {
        for (int i = 0; i < LoopCount; i++)
        {
            var arr = new bool[1000];
        }
    }

    [Benchmark]
    public void AllocateDecimalArrayInLoop()
    {
        for (int i = 0; i < LoopCount; i++)
        {
            var arr = new decimal[1000];
        }
    }

    [Benchmark]
    public void AllocateUnmanagedStructInLoop()
    {
        for (int i = 0; i < LoopCount; i++)
        {
            var val = new SomeVariableTypeGeneric<double> { X = 0.1, Y = 0.2 };
        }
    }

    // 3) Utility method to see how big these unmanaged generics are (similar to your example)
    // If you want to allow unsafe method you need to allow <AllowUnsafeBlocks>true</AllowUnsafeBlocks> in your .csproj file
    public static unsafe void DisplayUnmanagedStructSize<T>() where T : unmanaged
    {
        Console.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes");
    }
}

using System;
using System.Reflection;
using Ardalis.GuardClauses;
using BenchmarkDotNet.Attributes;
using Common.Models;

namespace GuardNullCheckerAttributes;

/// <summary>
/// Benchmark suite to compare:
/// 1) No reflection approach (direct 'if' check or Ardalis Guard).
/// 2) Reflection-based attribute approach (Ardalis or non-Ardalis).
///
/// This helps us measure overhead of reflection and different guard strategies.
/// </summary>
[MemoryDiagnoser]

public class GuardNullCheckerAttributesBenchmarks
{
    // Test data
    private Person? _personNull;
    private Person _personNotNull;

    public GuardNullCheckerAttributesBenchmarks()
    {
        // Initialize a valid, non-null Person
        _personNotNull = new Person
        {
            Id = 1,
            FirstName = "Baris",
            LastName = "test",
            BirthDate = DateTime.Now.AddYears(-30),
            Email = "Baris.doe@example.com",
            Addresses = new List<Address>
                {
                    new Address { Id = 101, PersonId = "1", Country = "USA", City = "NYC" }
                }
        };

        // Initialize a null Person for negative scenarios
        _personNull = null;
    }

    // ------------------------------------------------
    // A) Direct "If" Check (Baseline)
    // ------------------------------------------------

    [Benchmark]
    public void IfCheck_Null()
    {
        ProcessIfCheck(_personNull);
    }

    [Benchmark]
    public void IfCheck_NotNull()
    {
        ProcessIfCheck(_personNotNull);
    }

    /// <summary>
    /// Traditional if-based null check.
    /// </summary>
    private void ProcessIfCheck(Person? person)
    {
        if (person == null)
        {
            throw new ArgumentNullException(nameof(person));
        }
        // Minimal logic, e.g., setting a property
        person.FirstName = "IfCheckChanged";
    }

    // ------------------------------------------------
    // B) Direct Ardalis Guard (Baseline)
    // ------------------------------------------------

    [Benchmark]
    public void ArdalisCheck_Null()
    {
        ProcessArdalisGuardCheck(_personNull);
    }

    [Benchmark]
    public void ArdalisCheck_NotNull()
    {
        ProcessArdalisGuardCheck(_personNotNull);
    }

    /// <summary>
    /// Using Ardalis.GuardClauses directly.
    /// </summary>
    private void ProcessArdalisGuardCheck(Person? person)
    {
        Guard.Against.Null(person, nameof(person));
        // Minimal logic
        person.FirstName = "ArdalisChanged";
    }

    // ------------------------------------------------
    // C) Reflection + [CheckNullValueWithArdalisAttribute]
    // ------------------------------------------------
    // We create separate benchmarks that call a wrapper 
    // to do reflection checks.

    [Benchmark]
    public void ReflectionArdalisCheck_Null()
    {
        // We'll pass the name of the method with the attribute
        InvokeWithReflection(nameof(ProcessPersonArdalisAttribute), _personNull);
    }

    [Benchmark]
    public void ReflectionArdalisCheck_NotNull()
    {
        InvokeWithReflection(nameof(ProcessPersonArdalisAttribute), _personNotNull);
    }

    /// <summary>
    /// Method decorated with [CheckNullValueWithArdalisAttribute].
    /// Reflection will see this attribute and use Guard.Against.Null() automatically.
    /// </summary>
    [CheckNullValueWithArdalis]
    private void ProcessPersonArdalisAttribute(Person? person)
    {
        // Some minimal business logic
        if (person != null)
        {
            person.LastName = "ReflectionArdalisChanged";
        }
    }

    // ------------------------------------------------
    // D) Reflection + [CheckNullValueWithoutArdalisAttribute]
    // ------------------------------------------------

    [Benchmark]
    public void ReflectionNoArdalisCheck_Null()
    {
        InvokeWithReflection(nameof(ProcessPersonNoArdalisAttribute), _personNull);
    }

    [Benchmark]
    public void ReflectionNoArdalisCheck_NotNull()
    {
        InvokeWithReflection(nameof(ProcessPersonNoArdalisAttribute), _personNotNull);
    }

    /// <summary>
    /// Method decorated with [CheckNullValueWithoutArdalisAttribute].
    /// Reflection will see this attribute and do a simple if(...) check.
    /// </summary>
    [CheckNullValueWithoutArdalis]
    private void ProcessPersonNoArdalisAttribute(Person? person)
    {
        // Additional minimal business logic
        if (person != null)
        {
            person.LastName = "ReflectionNoArdalisChanged";
        }
    }

    // ------------------------------------------------
    // Reflection "middleware": checks if the target
    // method has one of our custom attributes, then
    // applies the appropriate check.
    // ------------------------------------------------

    private void InvokeWithReflection(string methodName, Person? person)
    {
        // Retrieve the method via reflection
        MethodInfo? targetMethod = typeof(GuardNullCheckerAttributesBenchmarks)
            .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

        if (targetMethod == null)
            throw new InvalidOperationException($"Method '{methodName}' not found via reflection.");

        // Check if [CheckNullValueWithArdalisAttribute] is present
        var withArdalisAttr = targetMethod.GetCustomAttribute<CheckNullValueWithArdalisAttribute>();
        // Check if [CheckNullValueWithoutArdalisAttribute] is present
        var withoutArdalisAttr = targetMethod.GetCustomAttribute<CheckNullValueWithoutArdalisAttribute>();

        if (withArdalisAttr != null)
        {
            // Use Ardalis.Guard to check for null
            Guard.Against.Null(person, nameof(person));
        }
        else if (withoutArdalisAttr != null)
        {
            // Use a normal 'if' check for null
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
        }

        // Invoke the actual method
        targetMethod.Invoke(this, new object?[] { person });
    }
}
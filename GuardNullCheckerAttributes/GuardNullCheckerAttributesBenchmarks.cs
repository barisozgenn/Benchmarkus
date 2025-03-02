using System;
using System.Reflection;
using Ardalis.GuardClauses;
using BenchmarkDotNet.Attributes;
using Common.Models;

namespace GuardNullCheckerAttributes
{
    /// <summary>
    /// Benchmark suite to compare:
    /// 1) No reflection approach (direct 'if' check or Ardalis Guard).
    /// 2) Reflection-based attribute approach (Ardalis or non-Ardalis).
    /// 
    /// Includes additional properties in the attributes (LogIfNull, Message) to demonstrate
    /// how "some logic" can be toggled at runtime via reflection.
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
        // A) Direct "If" Check 
        // ------------------------------------------------

        [Benchmark]
        public void IfCheck_Null_Throw()
        {
            try
            {
                ProcessIfCheck(_personNull);
            }
            catch
            {
                // Swallow exception so BenchmarkDotNet can measure
            }
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
            person.FirstName = "IfCheckChanged";
        }

        // ------------------------------------------------
        // B) Direct Ardalis Guard
        // ------------------------------------------------

        [Benchmark]
        public void ArdalisCheck_Null_Throw()
        {
            try
            {
                ProcessArdalisGuardCheck(_personNull);
            }
            catch
            {
                // Swallow exception for benchmark measurement
            }
        }

        [Benchmark]
        public void ArdalisCheck_NotNull()
        {
            ProcessArdalisGuardCheck(_personNotNull);
        }

        private void ProcessArdalisGuardCheck(Person? person)
        {
            Guard.Against.Null(person, nameof(person));
            person.FirstName = "ArdalisChanged";
        }

        // ------------------------------------------------
        // C) Reflection + [CheckNullValueWithArdalisAttribute]
        // ------------------------------------------------

        [Benchmark]
        public void ReflectionArdalisCheck_Null_Throw()
        {
            try
            {
                InvokeWithReflection(nameof(ProcessPersonArdalisAttribute), _personNull);
            }
            catch
            {
                // Swallow exception for benchmark measurement
            }
        }

        [Benchmark]
        public void ReflectionArdalisCheck_NotNull()
        {
            InvokeWithReflection(nameof(ProcessPersonArdalisAttribute), _personNotNull);
        }

        [CheckNullValueWithArdalis(Message = "Person was null (Ardalis)", LogIfNull = true)]
        private void ProcessPersonArdalisAttribute(Person? person)
        {
            // The reflection step calls Guard.Against.Null() if the attribute is present and person is null
            if (person != null)
            {
                person.LastName = "ReflectionArdalisChanged";
            }
        }

        // ------------------------------------------------
        // D) Reflection + [CheckNullValueWithoutArdalisAttribute]
        // ------------------------------------------------

        [Benchmark]
        public void ReflectionNoArdalisCheck_Null_Throw()
        {
            try
            {
                InvokeWithReflection(nameof(ProcessPersonNoArdalisAttribute), _personNull);
            }
            catch
            {
                // Swallow exception for benchmark measurement
            }
        }

        [Benchmark]
        public void ReflectionNoArdalisCheck_NotNull()
        {
            InvokeWithReflection(nameof(ProcessPersonNoArdalisAttribute), _personNotNull);
        }

        [CheckNullValueWithoutArdalis(Message = "Person was null (NoArdalis)", LogIfNull = false)]
        private void ProcessPersonNoArdalisAttribute(Person? person)
        {
            if (person != null)
            {
                person.LastName = "ReflectionNoArdalisChanged";
            }
        }

        // ------------------------------------------------
        // Reflection "middleware": checks if the target
        // method has one of our custom attributes, then
        // applies the appropriate null check.
        // ------------------------------------------------
        private void InvokeWithReflection(string methodName, Person? person)
        {
            MethodInfo? targetMethod = typeof(GuardNullCheckerAttributesBenchmarks)
                .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (targetMethod == null)
                throw new InvalidOperationException($"Method '{methodName}' not found.");

            // Identify which custom attribute we have
            var withArdalisAttr = targetMethod.GetCustomAttribute<CheckNullValueWithArdalisAttribute>();
            var withoutArdalisAttr = targetMethod.GetCustomAttribute<CheckNullValueWithoutArdalisAttribute>();

            if (withArdalisAttr != null)
            {
                if (person == null)
                {
                    if (withArdalisAttr.LogIfNull)
                    {
                        Console.WriteLine($"[WithArdalisAttr] {withArdalisAttr.Message}");
                    }

                    // Use Ardalis.Guard to throw
                    Guard.Against.Null(person, withArdalisAttr.Message);
                }
            }
            else if (withoutArdalisAttr != null)
            {
                if (person == null)
                {
                    if (withoutArdalisAttr.LogIfNull)
                    {
                        Console.WriteLine($"[NoArdalisAttr] {withoutArdalisAttr.Message}");
                    }
                    // Throw a normal ArgumentNullException
                    throw new ArgumentNullException(nameof(person), withoutArdalisAttr.Message);
                }
            }

            // Actual method invocation
            targetMethod.Invoke(this, new object?[] { person });
        }
    }
}
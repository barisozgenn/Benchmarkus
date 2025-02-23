using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Common.Models;

namespace ReflectionAOTAccessor
{
    /// <summary>
    /// Benchmarks comparing direct (JIT) versus reflection‑based operations
    /// on the Person class. This includes instantiation, property get, and property set.
    /// </summary>
    [MemoryDiagnoser] // Track memory allocations
    [Orderer(SummaryOrderPolicy.FastestToSlowest)] // Sorts results from fastest to slowest
    [RankColumn] // Adds a 'Rank' column in the results table
    [SimpleJob(warmupCount: 3, iterationCount: 5)] // Configures the job
    public class ReflectionBenchmarks
    {
        // Declare as non-nullable since we assign them in GlobalSetup.
        private Type personType = typeof(Person);
        private Person directPerson = new Person();
        private PropertyInfo firstNameProperty = typeof(Person).GetProperty("FirstName")!;

        /// <summary>
        /// Global setup initializes the Person type and creates a sample instance.
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            // Retrieve the Type for Person using reflection.
            personType = typeof(Person);

            // Create a sample Person directly.
            directPerson = new Person
            {
                Id = 1,
                FirstName = "Baris",
                LastName = "Baris",
                BirthDate = DateTime.Now.AddYears(-30),
                Email = "baris.baris@benchmarkus.test.url.com",
                Addresses = new System.Collections.Generic.List<Address>
                {
                    new Address
                    {
                        Id = 1,
                        PersonId = "1",
                        Country = "TR",
                        City = "IST"
                    }
                }
            };

            // Cache the PropertyInfo for "FirstName" to use in the reflection benchmarks.
            firstNameProperty = personType.GetProperty("FirstName")!;
        }

        #region Instantiation Benchmarks

        /// <summary>
        /// Directly instantiates a Person using the new operator.
        /// </summary>
        [Benchmark(Baseline = true)]
        public Person DirectInstantiation()
        {
            return new Person
            {
                Id = 2,
                FirstName = "Ozgen",
                LastName = "Baris",
                BirthDate = DateTime.Now.AddYears(-25),
                Email = "ozgen.baris@test.benchmarkus.com",
                Addresses = new System.Collections.Generic.List<Address>
                {
                    new Address { Id = 2, PersonId = "2", Country = "UK", City = "London" }
                }
            };
        }

        /// <summary>
        /// Instantiates a Person using reflection (Activator.CreateInstance).
        /// After creation, sets several properties via direct assignment.
        /// </summary>
        [Benchmark]
        public Person ReflectionInstantiation()
        {
            // Use personType directly since it is non-null.
            var obj = (Person)Activator.CreateInstance(personType)!;
            // Set properties directly after instantiation.
            obj.Id = 3;
            obj.FirstName = "Baris";
            obj.LastName = "Ozgen";
            obj.BirthDate = DateTime.Now.AddYears(-40);
            obj.Email = "baris.test@test.com";
            obj.Addresses.Add(new Address { Id = 3, PersonId = "3", Country = "USA", City = "NYC" });
            return obj;
        }

        #endregion

        #region Property Get Benchmarks

        /// <summary>
        /// Directly gets the FirstName property from a Person instance.
        /// </summary>
        [Benchmark(Baseline = true)]
        public string DirectPropertyGet()
        {
            return directPerson.FirstName;
        }

        /// <summary>
        /// Gets the FirstName property from a Person instance via reflection.
        /// </summary>
        [Benchmark]
        public string ReflectionPropertyGet()
        {
            return (string)firstNameProperty.GetValue(directPerson)!;
        }

        #endregion

        #region Property Set Benchmarks

        /// <summary>
        /// Directly sets the FirstName property on a Person instance.
        /// </summary>
        [Benchmark(Baseline = true)]
        public void DirectPropertySet()
        {
            directPerson.FirstName = "UpdatedDirect";
        }

        /// <summary>
        /// Sets the FirstName property on a Person instance via reflection.
        /// </summary>
        [Benchmark]
        public void ReflectionPropertySet()
        {
            firstNameProperty.SetValue(directPerson, "UpdatedReflection");
        }

        #endregion
    }
}

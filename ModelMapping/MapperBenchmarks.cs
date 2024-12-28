using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using AutoMapper;
using BenchmarkDotNet.Configs;

namespace ModelMapping
{
    /// <summary>
    /// Benchmark class to compare AutoMapper vs. manual mapping performance.
    /// </summary>
    [MemoryDiagnoser] // Enables memory allocation diagnostics
    [Orderer(SummaryOrderPolicy.FastestToSlowest)] // Orders results from fastest to slowest
    public class MapperBenchmarks
    {
        private IMapper _mapper; // AutoMapper instance, initialized in GlobalSetup
        private List<Person> _people; // Sample data list, initialized in GlobalSetup

        /// <summary>
        /// Setup method executed once per benchmark run to initialize data and mapper.
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            // Initialize AutoMapper with the defined profile
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper = config.CreateMapper();

            // Generate a large list of Person objects for mapping
            _people = GenerateSamplePeople(100_000);
        }

        /// <summary>
        /// Benchmark method using AutoMapper to map Person to PersonDto.
        /// </summary>
        [Benchmark(Baseline = true)] // Marks this method as the baseline for comparison
        public List<PersonDto> AutoMapperMapping()
        {
            var mappedList = new List<PersonDto>(_people.Count);
            foreach (var person in _people)
            {
                // Use AutoMapper to map each Person to PersonDto
                var dto = _mapper.Map<PersonDto>(person);
                mappedList.Add(dto);
            }
            return mappedList;
        }

        /// <summary>
        /// Benchmark method using manual mapping to map Person to PersonDto.
        /// </summary>
        [Benchmark]
        public List<PersonDto> ManualMapping()
        {
            var mappedList = new List<PersonDto>(_people.Count);
            foreach (var person in _people)
            {
                // Manually map each property from Person to PersonDto
                var dto = new PersonDto
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    BirthDate = person.BirthDate,
                    Email = person.Email,
                    Addresses = person.Addresses // Directly assign the Addresses list
                };
                mappedList.Add(dto);
            }
            return mappedList;
        }

        /// <summary>
        /// Generates a list of Person objects with sample data.
        /// </summary>
        /// <param name="count">Number of Person objects to generate.</param>
        /// <returns>List of Person objects.</returns>
        private List<Person> GenerateSamplePeople(int count)
        {
            var list = new List<Person>(count);
            var rand = new Random(42); // Fixed seed for reproducibility
            for (int i = 0; i < count; i++)
            {
                // Generate a list of addresses for each person
                var addresses = new List<Address>
                {
                    new Address
                    {
                        Id = i * 10 + 1,
                        PersonId = i.ToString(),
                        Country = "Country" + rand.Next(1, 100),
                        City = "City" + rand.Next(1, 1000)
                    },
                    new Address
                    {
                        Id = i * 10 + 2,
                        PersonId = i.ToString(),
                        Country = "Country" + rand.Next(1, 100),
                        City = "City" + rand.Next(1, 1000)
                    }
                };

                list.Add(new Person
                {
                    Id = i,
                    FirstName = "FirstName" + i,
                    LastName = "LastName" + i,
                    BirthDate = DateTime.Now.AddDays(-rand.Next(10_000)),
                    Email = $"user{i}@example.com",
                    Addresses = addresses
                });
            }
            return list;
        }
    }
}
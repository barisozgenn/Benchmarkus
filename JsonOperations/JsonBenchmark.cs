using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Common.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace JsonOperations.Benchmarks
{
    /// <summary>
    /// Benchmark class to evaluate the performance of Newtonsoft.Json vs System.Text.Json.
    /// </summary>
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class JsonBenchmark
    {
        /// <summary>
        /// The number of elements to include in the list during benchmarks.
        /// Adjust this value to balance between benchmark accuracy and execution time.
        /// </summary>
        [Params(10, 1000)]
        public int Size { get; set; }

        /// <summary>
        /// A sample Person object to serialize/deserialize.
        /// </summary>
        private Person samplePerson;

        /// <summary>
        /// A list of Person objects to serialize/deserialize.
        /// </summary>
        private List<Person> sampleList;

        /// <summary>
        /// Initialize sample data before each benchmark iteration.
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            samplePerson = new Person
            {
                Id = 1,
                FirstName = "Baris",
                LastName = "Ozgen",
                BirthDate = new DateTime(1990, 1, 1),
                Email = "baris.ozgen@test-baris-test.com",
                Addresses = new List<Address>
                {
                    new Address { Id = 1, PersonId = "1", Country = "USA", City = "New York" },
                    new Address { Id = 2, PersonId = "1", Country = "USA", City = "Los Angeles" }
                }
            };

            sampleList = new List<Person>();
            for (int i = 0; i < Size; i++)
            {
                sampleList.Add(new Person
                {
                    Id = i + 1,
                    FirstName = $"Baris{i + 1}",
                    LastName = $"Ozgen{i + 1}",
                    BirthDate = DateTime.Now.AddDays(-i),
                    Email = $"user{i + 1}@test-baris-test.com",
                    Addresses = new List<Address>
                    {
                        new Address { Id = i * 10 + 1, PersonId = (i + 1).ToString(), Country = "Country" + (i % 100), City = "City" + (i % 1000) },
                        new Address { Id = i * 10 + 2, PersonId = (i + 1).ToString(), Country = "Country" + ((i + 1) % 100), City = "City" + ((i + 1) % 1000) }
                    }
                });
            }
        }

        #region Newtonsoft.Json Benchmarks

        /// <summary>
        /// Serialize a single Person object using Newtonsoft.Json.
        /// </summary>
        [Benchmark]
        public string Newtonsoft_Serialize_Single()
        {
            return JsonConvert.SerializeObject(samplePerson);
        }

        /// <summary>
        /// Deserialize a single Person object using Newtonsoft.Json.
        /// </summary>
        [Benchmark]
        public Person Newtonsoft_Deserialize_Single()
        {
            string json = JsonConvert.SerializeObject(samplePerson);
            return JsonConvert.DeserializeObject<Person>(json);
        }

        /// <summary>
        /// Serialize a list of Person objects using Newtonsoft.Json.
        /// </summary>
        [Benchmark]
        public string Newtonsoft_Serialize_List()
        {
            return JsonConvert.SerializeObject(sampleList);
        }

        /// <summary>
        /// Deserialize a list of Person objects using Newtonsoft.Json.
        /// </summary>
        [Benchmark]
        public List<Person> Newtonsoft_Deserialize_List()
        {
            string json = JsonConvert.SerializeObject(sampleList);
            return JsonConvert.DeserializeObject<List<Person>>(json);
        }

        /// <summary>
        /// Read a Person object from a JSON string using Newtonsoft.Json's JsonReader.
        /// </summary>
        [Benchmark]
        public Person Newtonsoft_ReadJson_Single()
        {
            string json = JsonConvert.SerializeObject(samplePerson);
            using (var reader = new JsonTextReader(new System.IO.StringReader(json)))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                return serializer.Deserialize<Person>(reader);
            }
        }

        /// <summary>
        /// Create a JSON string from a Person object using Newtonsoft.Json's JsonWriter.
        /// </summary>
        [Benchmark]
        public string Newtonsoft_CreateJson_Single()
        {
            using (var stringWriter = new System.IO.StringWriter())
            using (var writer = new JsonTextWriter(stringWriter))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(writer, samplePerson);
                return stringWriter.ToString();
            }
        }

        #endregion

        #region System.Text.Json Benchmarks

        /// <summary>
        /// Serialize a single Person object using System.Text.Json.
        /// </summary>
        [Benchmark]
        public string SystemTextJson_Serialize_Single()
        {
            return System.Text.Json.JsonSerializer.Serialize(samplePerson);
        }

        /// <summary>
        /// Deserialize a single Person object using System.Text.Json.
        /// </summary>
        [Benchmark]
        public Person SystemTextJson_Deserialize_Single()
        {
            string json = System.Text.Json.JsonSerializer.Serialize(samplePerson);
            return System.Text.Json.JsonSerializer.Deserialize<Person>(json);
        }

        /// <summary>
        /// Serialize a list of Person objects using System.Text.Json.
        /// </summary>
        [Benchmark]
        public string SystemTextJson_Serialize_List()
        {
            return System.Text.Json.JsonSerializer.Serialize(sampleList);
        }

        /// <summary>
        /// Deserialize a list of Person objects using System.Text.Json.
        /// </summary>
        [Benchmark]
        public List<Person> SystemTextJson_Deserialize_List()
        {
            string json = System.Text.Json.JsonSerializer.Serialize(sampleList);
            return System.Text.Json.JsonSerializer.Deserialize<List<Person>>(json);
        }

        /// <summary>
        /// Read a Person object from a JSON string using System.Text.Json's Utf8JsonReader.
        /// </summary>
        [Benchmark]
        public Person SystemTextJson_ReadJson_Single()
        {
            string json = System.Text.Json.JsonSerializer.Serialize(samplePerson);
            var bytes = System.Text.Encoding.UTF8.GetBytes(json);
            var reader = new System.Text.Json.Utf8JsonReader(bytes);
            return System.Text.Json.JsonSerializer.Deserialize<Person>(ref reader);
        }

        /// <summary>
        /// Create a JSON string from a Person object using System.Text.Json's Utf8JsonWriter.
        /// </summary>
        [Benchmark]
        public string SystemTextJson_CreateJson_Single()
        {
            using (var stream = new System.IO.MemoryStream())
            using (var writer = new System.Text.Json.Utf8JsonWriter(stream))
            {
                System.Text.Json.JsonSerializer.Serialize(writer, samplePerson);
                writer.Flush();
                return System.Text.Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        #endregion

        #region Mixed Operations

        /// <summary>
        /// Serialize and then deserialize a single Person object using Newtonsoft.Json.
        /// </summary>
        [Benchmark]
        public Person Newtonsoft_Serialize_Deserialize_Single()
        {
            string json = JsonConvert.SerializeObject(samplePerson);
            return JsonConvert.DeserializeObject<Person>(json);
        }

        /// <summary>
        /// Serialize and then deserialize a single Person object using System.Text.Json.
        /// </summary>
        [Benchmark]
        public Person SystemTextJson_Serialize_Deserialize_Single()
        {
            string json = System.Text.Json.JsonSerializer.Serialize(samplePerson);
            return System.Text.Json.JsonSerializer.Deserialize<Person>(json);
        }

        #endregion
    }
}
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Common.Models;

namespace Benchmarkus.BaseDtoBenchmarks
{
    /// <summary>
    /// Benchmarks comparing different Base DTO mechanisms for instantiation,
    /// property access, and common list operations (read, write, find-first).
    /// The DTOs under test are:
    /// - PersonDtoWithBaseClass (concrete base class)
    /// - PersonDtoWithBaseAbstractClass (abstract base class)
    /// - PersonDtoWithBaseRecord (record base)
    /// </summary>
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [SimpleJob(warmupCount: 3, iterationCount: 5)]
    public class BaseDtoBenchmarks
    {
        // Single instance benchmarks
        private PersonDtoWithBaseClass? dtoWithBaseClass;
        private PersonDtoWithBaseAbstractClass? dtoWithBaseAbstract;
        private PersonDtoWithBaseRecord? dtoWithBaseRecord;

        // List benchmarks
        private List<PersonDtoWithBaseClass>? listBaseClass;
        private List<PersonDtoWithBaseAbstractClass>? listBaseAbstract;
        private List<PersonDtoWithBaseRecord>? listBaseRecord;

        [GlobalSetup]
        public void Setup()
        {
            // Initialize single instances for property benchmarks
            dtoWithBaseClass = new PersonDtoWithBaseClass
            {
                Id = 1,
                CreatedDate = DateTime.Now,
                FirstName = "Baris",
                LastName = "Ozgen",
                BirthDate = DateTime.Now.AddYears(-30),
                Email = "baris.ozgen@benchmarkus.com"
            };

            dtoWithBaseAbstract = new PersonDtoWithBaseAbstractClass
            {
                Id = 2,
                CreatedDate = DateTime.Now,
                FirstName = "Ozgen",
                LastName = "Baris",
                BirthDate = DateTime.Now.AddYears(-25),
                Email = "ozgen.baris@benchmarkus.com"
            };

            dtoWithBaseRecord = new PersonDtoWithBaseRecord
            {
                Id = 3,
                CreatedDate = DateTime.Now,
                FirstName = "Bariss",
                LastName = "Bariss",
                BirthDate = DateTime.Now.AddYears(-35),
                Email = "bariss.bariss@benchmarkus.com"
            };

            // Initialize lists with 10 items each for list benchmarks
            int count = 10;
            listBaseClass = new List<PersonDtoWithBaseClass>(count);
            listBaseAbstract = new List<PersonDtoWithBaseAbstractClass>(count);
            listBaseRecord = new List<PersonDtoWithBaseRecord>(count);

            for (int i = 0; i < count; i++)
            {
                listBaseClass.Add(new PersonDtoWithBaseClass
                {
                    Id = i,
                    CreatedDate = DateTime.Now,
                    FirstName = "Baris" + i,
                    LastName = "Ozgen" + i,
                    BirthDate = DateTime.Now.AddYears(-20 - i),
                    Email = $"baris{i}@benchmarkus.com"
                });

                listBaseAbstract.Add(new PersonDtoWithBaseAbstractClass
                {
                    Id = i,
                    CreatedDate = DateTime.Now,
                    FirstName = "Baris" + i,
                    LastName = "Ozgen" + i,
                    BirthDate = DateTime.Now.AddYears(-20 - i),
                    Email = $"baris{i}@benchmarkus.com"
                });

                listBaseRecord.Add(new PersonDtoWithBaseRecord
                {
                    Id = i,
                    CreatedDate = DateTime.Now,
                    FirstName = "Baris" + i,
                    LastName = "Ozgen" + i,
                    BirthDate = DateTime.Now.AddYears(-20 - i),
                    Email = $"baris{i}@benchmarkus.com"
                });
            }
        }

        #region Instantiation Benchmarks

        [Benchmark]
        [BenchmarkCategory("Instantiation")]
        public PersonDtoWithBaseClass DirectInstantiation()
        {
            return new PersonDtoWithBaseClass
            {
                Id = 11,
                CreatedDate = DateTime.Now,
                FirstName = "Direct",
                LastName = "Instantiation",
                BirthDate = DateTime.Now.AddYears(-30),
                Email = "direct@benchmarkus.com"
            };
        }

        [Benchmark]
        [BenchmarkCategory("Instantiation")]
        public PersonDtoWithBaseAbstractClass DirectInstantiation_Abstract()
        {
            return new PersonDtoWithBaseAbstractClass
            {
                Id = 12,
                CreatedDate = DateTime.Now,
                FirstName = "Direct",
                LastName = "Abstract",
                BirthDate = DateTime.Now.AddYears(-25),
                Email = "abstract@benchmarkus.com"
            };
        }

        [Benchmark]
        [BenchmarkCategory("Instantiation")]
        public PersonDtoWithBaseRecord DirectInstantiation_Record()
        {
            return new PersonDtoWithBaseRecord
            {
                Id = 13,
                CreatedDate = DateTime.Now,
                FirstName = "Direct",
                LastName = "Record",
                BirthDate = DateTime.Now.AddYears(-35),
                Email = "record@benchmarkus.com"
            };
        }

        #endregion

        #region Property Get Benchmarks

        [Benchmark]
        [BenchmarkCategory("PropertyGet")]
        public string GetFirstName_BaseClass()
        {
            return dtoWithBaseClass.FirstName;
        }

        [Benchmark]
        [BenchmarkCategory("PropertyGet")]
        public string GetFirstName_BaseAbstract()
        {
            return dtoWithBaseAbstract.FirstName;
        }

        [Benchmark]
        [BenchmarkCategory("PropertyGet")]
        public string GetFirstName_Record()
        {
            return dtoWithBaseRecord.FirstName;
        }

        #endregion

        #region Property Set Benchmarks

        [Benchmark]
        [BenchmarkCategory("PropertySet")]
        public void SetFirstName_BaseClass()
        {
            dtoWithBaseClass.FirstName = "UpdatedBaseClass";
        }

        [Benchmark]
        [BenchmarkCategory("PropertySet")]
        public void SetFirstName_BaseAbstract()
        {
            dtoWithBaseAbstract.FirstName = "UpdatedBaseAbstract";
        }

        [Benchmark]
        [BenchmarkCategory("PropertySet")]
        public void SetFirstName_Record()
        {
            // For records, simulate update using 'with'
            dtoWithBaseRecord = dtoWithBaseRecord with { FirstName = "UpdatedRecord" };
        }

        #endregion

        #region List Read Benchmarks

        [Benchmark]
        [BenchmarkCategory("ListRead")]
        public int ListRead_BaseClass()
        {
            int totalLength = 0;
            foreach (var item in listBaseClass)
            {
                totalLength += item.FirstName.Length;
            }
            return totalLength;
        }

        [Benchmark]
        [BenchmarkCategory("ListRead")]
        public int ListRead_BaseAbstract()
        {
            int totalLength = 0;
            foreach (var item in listBaseAbstract)
            {
                totalLength += item.FirstName.Length;
            }
            return totalLength;
        }

        [Benchmark]
        [BenchmarkCategory("ListRead")]
        public int ListRead_Record()
        {
            int totalLength = 0;
            foreach (var item in listBaseRecord)
            {
                totalLength += item.FirstName.Length;
            }
            return totalLength;
        }

        #endregion

        #region List Write Benchmarks

        [Benchmark]
        [BenchmarkCategory("ListWrite")]
        public void ListWrite_BaseClass()
        {
            if (listBaseClass.Count > 0)
                listBaseClass[0].FirstName = "ListUpdatedBaseClass";
        }

        [Benchmark]
        [BenchmarkCategory("ListWrite")]
        public void ListWrite_BaseAbstract()
        {
            if (listBaseAbstract.Count > 0)
                listBaseAbstract[0].FirstName = "ListUpdatedBaseAbstract";
        }

        [Benchmark]
        [BenchmarkCategory("ListWrite")]
        public void ListWrite_Record()
        {
            if (listBaseRecord.Count > 0)
                listBaseRecord[0] = listBaseRecord[0] with { FirstName = "ListUpdatedRecord" };
        }

        #endregion

        #region List Find Benchmarks

        [Benchmark]
        [BenchmarkCategory("ListFind")]
        public PersonDtoWithBaseClass ListFindFirst_BaseClass()
        {
            return listBaseClass.FirstOrDefault(item => item.FirstName == "baris50");
        }

        [Benchmark]
        [BenchmarkCategory("ListFind")]
        public PersonDtoWithBaseAbstractClass ListFindFirst_BaseAbstract()
        {
            return listBaseAbstract.FirstOrDefault(item => item.FirstName == "baris50");
        }

        [Benchmark]
        [BenchmarkCategory("ListFind")]
        public PersonDtoWithBaseRecord ListFindFirst_Record()
        {
            return listBaseRecord.FirstOrDefault(item => item.FirstName == "baris50");
        }

        #endregion
    }
}
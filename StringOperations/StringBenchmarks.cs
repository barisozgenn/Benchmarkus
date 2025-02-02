using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace StringOperations.Benchmarks
{
    /// <summary>
    /// Benchmarks various string operations to understand their performance
    /// in terms of execution time and memory allocations.
    /// 
    /// This suite includes:
    ///  - Different concatenation approaches: + operator, string.Concat, interpolation, and StringBuilder.
    ///  - Substring extraction: using Substring and the range operator.
    ///  - Search operations: IndexOf and Contains.
    ///  - Join and Split operations.
    ///  - Comparing many concatenations using direct concatenation vs. StringBuilder.
    ///  - Additional benchmarks: string.Replace, ToUpper, and Trim.
    /// </summary>
    [MemoryDiagnoser] // Tracks memory allocation for each benchmark
    [Orderer(SummaryOrderPolicy.FastestToSlowest)] // Sorts results from fastest to slowest
    [RankColumn] // Adds a 'Rank' column in the results table
    [SimpleJob(warmupCount:3, iterationCount:5)] // Configures the job
    public class StringBenchmarks
    {
        private string shortString;
        private string longString;
        private string[] words;

        /// <summary>
        /// Global setup for the benchmarks.
        /// Initializes a short string, a long string, and an array of words.
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            shortString = "Hello World";
            // Build a long string by repeating a sentence 1000 times.
            longString = string.Concat(Enumerable.Repeat("The quick brown fox jumps over the lazy dog. ", 1000));
            // Array of words for join and split operations.
            words = new string[] { "Apple", "Banana", "Cherry", "Date", "Elderberry", "Fig", "Grape" };
        }

        #region Concatenation Benchmarks

        /// <summary>
        /// Concatenates strings using the + operator.
        /// </summary>
        [Benchmark(Baseline = true)]
        public string ConcatWithPlus()
        {
            string result = "Hello" + " " + "World" + " " + DateTime.Now.ToString("o");
            return result;
        }

        /// <summary>
        /// Concatenates strings using string.Concat.
        /// </summary>
        [Benchmark]
        public string ConcatWithStringConcat()
        {
            return string.Concat("Hello", " ", "World", " ", DateTime.Now.ToString("o"));
        }

        /// <summary>
        /// Concatenates strings using string interpolation.
        /// </summary>
        [Benchmark]
        public string ConcatWithInterpolation()
        {
            return $"Hello {' '}World {' '}{DateTime.Now.ToString("o")}";
        }

        /// <summary>
        /// Concatenates strings using a StringBuilder.
        /// </summary>
        [Benchmark]
        public string ConcatWithStringBuilder()
        {
            var sb = new StringBuilder();
            sb.Append("Hello");
            sb.Append(" ");
            sb.Append("World");
            sb.Append(" ");
            sb.Append(DateTime.Now.ToString("o"));
            return sb.ToString();
        }

        #endregion

        #region Substring and Slicing

        /// <summary>
        /// Extracts a substring using the Substring method.
        /// </summary>
        [Benchmark]
        public string SubstringExtraction()
        {
            return longString.Substring(50, 100);
        }

        /// <summary>
        /// Extracts a substring using the C# 8 range operator.
        /// </summary>
        [Benchmark]
        public string RangeExtraction()
        {
            return longString[50..150];
        }

        #endregion

        #region Search Operations

        /// <summary>
        /// Searches for the index of a substring using IndexOf.
        /// </summary>
        [Benchmark]
        public int StringIndexOf()
        {
            return longString.IndexOf("fox");
        }

        /// <summary>
        /// Checks if the long string contains a specified substring.
        /// </summary>
        [Benchmark]
        public bool StringContains()
        {
            return longString.Contains("lazy");
        }

        #endregion

        #region Join and Split Operations

        /// <summary>
        /// Joins an array of words into a single string.
        /// </summary>
        [Benchmark]
        public string JoinStrings()
        {
            return string.Join(", ", words);
        }

        /// <summary>
        /// Splits the long string into an array of substrings based on spaces.
        /// </summary>
        [Benchmark]
        public string[] SplitString()
        {
            return longString.Split(' ');
        }

        #endregion

        #region Concatenation in Loops (Immutable vs. Mutable)

        /// <summary>
        /// Concatenates numbers to a string in a loop using direct concatenation.
        /// This approach creates many temporary strings.
        /// </summary>
        [Benchmark]
        public string ManyConcatenations()
        {
            string result = "";
            for (int i = 0; i < 1000; i++)
            {
                result += i.ToString();
            }
            return result;
        }

        /// <summary>
        /// Concatenates numbers to a string in a loop using StringBuilder.
        /// This is more efficient for many concatenations.
        /// </summary>
        [Benchmark]
        public string ManyConcatenationsWithStringBuilder()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 1000; i++)
            {
                sb.Append(i);
            }
            return sb.ToString();
        }

        #endregion

        #region Additional Benchmarks

        /// <summary>
        /// Replaces occurrences of "fox" with "cat" in the long string.
        /// </summary>
        [Benchmark]
        public string StringReplaceBenchmark()
        {
            return longString.Replace("fox", "cat");
        }

        /// <summary>
        /// Converts the long string to uppercase.
        /// </summary>
        [Benchmark]
        public string StringToUpperBenchmark()
        {
            return longString.ToUpper();
        }

        /// <summary>
        /// Trims leading and trailing whitespace from a padded short string.
        /// </summary>
        [Benchmark]
        public string StringTrimBenchmark()
        {
            string padded = "    " + shortString + "    ";
            return padded.Trim();
        }

        #endregion
    }
}

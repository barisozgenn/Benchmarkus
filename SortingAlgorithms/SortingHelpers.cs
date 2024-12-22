#region SortingHelpersFile
using System;

namespace Benchmarkus.SortingAlgorithms
{
    #region SortingHelpers
    /// <summary>
    /// Provides helper methods to generate test data for sorting.
    /// </summary>
    public static class SortingHelpers
    {
        #region GenerateRandomIntArray
        /// <summary>
        /// Generates an array of random integers.
        /// </summary>
        /// <param name="size">The number of elements in the array.</param>
        /// <param name="seed">Optional seed for repeatable random generation.</param>
        /// <returns>An integer array filled with random values.</returns>
        public static int[] GenerateRandomIntArray(int size, int seed = 0)
        {
            Random random = (seed == 0) ? new Random() : new Random(seed);
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(int.MinValue, int.MaxValue);
            }
            return array;
        }
        #endregion

        #region GenerateRandomStringArray
        /// <summary>
        /// Generates an array of random strings (example includes "Baris Ozgen" references).
        /// </summary>
        /// <param name="size">Number of string entries.</param>
        /// <param name="seed">Optional random seed.</param>
        /// <returns>An array of random strings.</returns>
        public static string[] GenerateRandomStringArray(int size, int seed = 0)
        {
            Random random = (seed == 0) ? new Random() : new Random(seed);
            string[] array = new string[size];
            for (int i = 0; i < size; i++)
            {
                // Using a random length for variety
                int length = random.Next(5, 15);
                array[i] = GenerateRandomString(length, random) + " Baris Ozgen";
            }
            return array;
        }
        #endregion

        #region GenerateRandomTransactions
        /// <summary>
        /// Generates an array of random transactions (a complex type).
        /// </summary>
        /// <param name="size">Number of transaction objects to create.</param>
        /// <param name="seed">Optional random seed.</param>
        /// <returns>An array of Transaction objects.</returns>
        public static Transaction[] GenerateRandomTransactions(int size, int seed = 0)
        {
            Random random = (seed == 0) ? new Random() : new Random(seed);
            Transaction[] transactions = new Transaction[size];

            for (int i = 0; i < size; i++)
            {
                transactions[i] = new Transaction
                {
                    Id = i + 1,
                    Name = GenerateRandomString(random.Next(3, 8), random) + " Baris Ozgen",
                    Amount = (decimal)(random.NextDouble() * 10000), // random up to 10,000
                    Date = DateTime.Now.AddDays(-random.Next(0, 365)) // random date within last year
                };
            }
            return transactions;
        }
        #endregion

        #region GenerateRandomString
        /// <summary>
        /// Helper method to generate a single random string of given length.
        /// </summary>
        /// <param name="length">The length of the string to generate.</param>
        /// <param name="random">Random instance to use.</param>
        /// <returns>A random string with uppercase/lowercase letters.</returns>
        private static string GenerateRandomString(int length, Random random)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] buffer = new char[length];
            for (int i = 0; i < length; i++)
            {
                buffer[i] = chars[random.Next(chars.Length)];
            }
            return new string(buffer);
        }
        #endregion
    }
    #endregion
}
#endregion
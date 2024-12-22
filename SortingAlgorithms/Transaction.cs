#region TransactionFile
namespace Benchmarkus.SortingAlgorithms
{
    #region TransactionModel
    /// <summary>
    /// Represents a simple fintech transaction model.
    /// </summary>
    public class Transaction
    {
        #region Fields
        /// <summary>
        /// Unique ID of the transaction.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name or description of the transaction.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The transaction amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The date/time the transaction took place.
        /// </summary>
        public DateTime Date { get; set; }
        #endregion
    }
    #endregion
}
#endregion
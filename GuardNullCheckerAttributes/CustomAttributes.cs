namespace GuardNullCheckerAttributes
{
    /// <summary>
    /// Indicates this method's parameters should be checked for null
    /// using Ardalis.GuardClauses before the method body executes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CheckNullValueWithArdalisAttribute : Attribute
    {
        /// <summary>
        /// Whether to log a console message if the argument is null.
        /// </summary>
        public bool LogIfNull { get; set; }

        /// <summary>
        /// Custom message to display/log if the argument is null.
        /// </summary>
        public string Message { get; set; } = "Value cannot be null (Ardalis)";

        public CheckNullValueWithArdalisAttribute() { }
    }

    /// <summary>
    /// Indicates this method's parameters should be checked for null
    /// using a basic 'if' statement before the method body executes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CheckNullValueWithoutArdalisAttribute : Attribute
    {
        /// <summary>
        /// Whether to log a console message if the argument is null.
        /// </summary>
        public bool LogIfNull { get; set; }

        /// <summary>
        /// Custom message to display/log if the argument is null.
        /// </summary>
        public string Message { get; set; } = "Value cannot be null (NoArdalis)";

        public CheckNullValueWithoutArdalisAttribute() { }
    }
}
using System;
namespace GuardNullCheckerAttributes;

/// <summary>
    /// Indicates this method's parameters should be checked for null
    /// using Ardalis.GuardClauses before the method body executes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CheckNullValueWithArdalisAttribute : Attribute
    {
        // For demonstration only.
        // In real scenarios, you might rely on AOP or source generators.
    }

    /// <summary>
    /// Indicates this method's parameters should be checked for null
    /// using a basic 'if' statement before the method body executes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CheckNullValueWithoutArdalisAttribute : Attribute
    {
        // Similarly for demonstration.
    }
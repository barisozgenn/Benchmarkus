using System;

namespace Benchmarkus.DynamicGeneration
{
    /// <summary>
    /// A utility class that invokes a method by name on a given instance.
    /// This can be used to compare invocation strategies (reflection, delegates, etc.).
    /// </summary>
    public static class DynamicClassInvoker
    {
        public static object? InvokeMethodByName(object instance, string methodName, params object[] parameters)
        {
            var method = instance.GetType().GetMethod(methodName);
            return method?.Invoke(instance, parameters);
        }
    }
}
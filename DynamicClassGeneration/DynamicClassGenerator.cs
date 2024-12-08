using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Benchmarkus.DynamicGeneration
{
    public static class DynamicClassGenerator
    {
        /// <summary>
        /// Compiles the given C# source code into an in-memory assembly.
        /// Returns the assembly if successful, otherwise null.
        /// </summary>
        public static Assembly? CompileSourceToAssembly(string sourceCode)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            // Add references for commonly used assemblies.
            var references = new List<MetadataReference>
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
            };

            var compilation = CSharpCompilation.Create(
                assemblyName: "DynamicAssembly_" + Guid.NewGuid().ToString("N"),
                syntaxTrees: new[] { syntaxTree },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
            );

            using var ms = new MemoryStream();
            var result = compilation.Emit(ms);

            if (!result.Success)
            {
                // If compilation fails, you can inspect result.Diagnostics for detailed error information.
                return null;
            }

            ms.Seek(0, SeekOrigin.Begin);
            return Assembly.Load(ms.ToArray());
        }

        /// <summary>
        /// Creates an instance of the specified type from the provided assembly.
        /// Returns null if the type cannot be found or instantiated.
        /// </summary>
        public static object? CreateInstance(Assembly assembly, string typeName)
        {
            var type = assembly.GetType(typeName);
            return type != null ? Activator.CreateInstance(type) : null;
        }
    }
}
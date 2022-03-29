using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.WinForms.Designer.SDK.CodeGen;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Xunit;

namespace PowerTools.UnitTests
{
    public class EndpointGeneratorTest
    {
        [Fact]
        public void SimpleCodeGenTest()
        {
            string userSource = @"

using System;

namespace Microsoft.WinForms.Designer.SDK.CodeGen
{
    public class GenerateEndpointAttribute : Attribute
    {
    }
}

namespace MyCode
{
    using Microsoft.WinForms.Designer.SDK.CodeGen;

    public class Foo
    {
        public Guid IDContact { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NoOfChildren { get; set; }
    }

    [FormsController(typeof(Foo))]
    public partial class TestFormsController : ViewControllerBase
    {
        private double _foo;

        [ViewControllerProperty] private string _firstName;
        [ViewControllerProperty(""LastName"")] private string _lstName;

        public string FooProperty {get; set;}
    }
}
";
            Compilation comp = CreateCompilation(userSource);
            var newComp = RunGenerators(comp, out var generatorDiags, new EndpointGenerator());

            Assert.Empty(generatorDiags);
            var diagnostic = newComp.GetDiagnostics();
            Assert.Empty(diagnostic);
        }

        private static Compilation CreateCompilation(string source) => CSharpCompilation.Create(
           assemblyName: "compilation",
           syntaxTrees: new[] { CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(LanguageVersion.Preview)) },
           references: new[] { MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location) },
           options: new CSharpCompilationOptions(OutputKind.ConsoleApplication)
       );

        private static GeneratorDriver CreateDriver(Compilation compilation, params ISourceGenerator[] generators) => CSharpGeneratorDriver.Create(
            generators: ImmutableArray.Create(generators),
            additionalTexts: ImmutableArray<AdditionalText>.Empty,
            parseOptions: (CSharpParseOptions)compilation.SyntaxTrees.First().Options,
            optionsProvider: null
        );

        private static Compilation RunGenerators(Compilation compilation, out ImmutableArray<Diagnostic> diagnostics, params ISourceGenerator[] generators)
        {
            CreateDriver(compilation, generators).RunGeneratorsAndUpdateCompilation(compilation, out var updatedCompilation, out diagnostics);
            return updatedCompilation;
        }
    }
}

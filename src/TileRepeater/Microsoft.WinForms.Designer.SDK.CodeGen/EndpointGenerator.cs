using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Microsoft.WinForms.Designer.SDK.CodeGen
{
    [Generator]
    public class EndpointGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new EndpointSyntaxReceiver());
        }
        
        public void Execute(GeneratorExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }

    internal class EndpointSyntaxReceiver : ISyntaxReceiver
    {
        internal List<(
            ClassDeclarationSyntax classDeclaration,
            AttributeSyntax classAttribute,
            SyntaxTree syntaxTree,
            Dictionary<FieldDeclarationSyntax, AttributeSyntax> fieldLookup)> foundModelClasses = new();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is InterfaceDeclarationSyntax interfaceDeclaration && 
                interfaceDeclaration.AttributeLists.Count > 0)
            {
                //if (classDeclaration.BaseList?.Types.Count == 1)
                //{
                //    if (classDeclaration.BaseList.Types[0] is SimpleBaseTypeSyntax baseType &&
                //        baseType.Type is GenericNameSyntax genericType &&
                //        genericType.Identifier.Text == AutoLayoutGen.AutoLayoutFormsControllerBase)
                //    {
                //        var templateType = genericType.TypeArgumentList.Arguments[0] as IdentifierNameSyntax;
                //        foundModelClasses.Add((classDeclaration, templateType));
                //    }
                //}

                var attribute = interfaceDeclaration
                    .AttributeLists
                    .SelectMany(lists => lists.Attributes)
                    .FirstOrDefault(attribute => ((IdentifierNameSyntax)attribute.Name).Identifier.ValueText == "GenerateEndpoint");

                if (attribute is not null)
                {
                    var memberDictionary = new Dictionary<MemberDeclarationSyntax, AttributeSyntax>();
                    //foundModelClasses.Add((classDeclaration, attribute, syntaxNode.SyntaxTree, fieldDictionary));

                    foreach (var nodeItem in interfaceDeclaration.ChildNodes())
                    {
                        if (nodeItem is MemberDeclarationSyntax memberDeclaration)
                        {
                            //var fieldAttribute = fieldDeclaration
                            //    .AttributeLists
                            //    .SelectMany(lists => lists.Attributes)
                            //    .FirstOrDefault(attribute => ((IdentifierNameSyntax)attribute.Name).Identifier.ValueText == "ViewControllerProperty");

                            //if (fieldAttribute is not null)
                            //{
                            //    fieldDictionary.Add(fieldDeclaration, fieldAttribute);
                            //}
                        }
                    }
                }
            }
        }
    }
}

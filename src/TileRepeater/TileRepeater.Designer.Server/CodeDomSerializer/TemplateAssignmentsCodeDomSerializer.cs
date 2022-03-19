using Microsoft.DotNet.DesignTools.Serialization;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;

namespace WinForms.Tiles.Serialization
{
    internal class TemplateAssignmentsCodeDomSerializer : CollectionCodeDomSerializer
    {
        private int s_variableOccuranceCounter = 1;

        protected override object SerializeCollection(
            IDesignerSerializationManager manager,
            CodeExpression targetExpression,
            Type targetType,
            ICollection originalCollection,
            ICollection valuesToSerialize)
        {
            if (Debugger.IsAttached)
                Debugger.Break();

            if (manager.Context.Current is ExpressionContext expressionContext)
            {
                CodeStatementCollection statementCollection = new();

                // This is the left-side assignment target, we want to generate.
                // And it describes the current context, for which we need the
                // object generation. Like:
                // this.tileRepeater1.TemplateAssignmentProperty
                var contextExpression = expressionContext.Expression;

                string collectionName = $"templateAssignmentItems{s_variableOccuranceCounter++}";

                CodeVariableDeclarationStatement collectionDeclStatement = new(
                    new CodeTypeReference(nameof(TemplateAssignmentItems)),
                    collectionName,
                    new CodeObjectCreateExpression(new CodeTypeReference(nameof(TemplateAssignmentItems))));

                statementCollection.Add(collectionDeclStatement);

                foreach (var item in valuesToSerialize)
                {
                    if (item is TemplateAssignmentItem templateAssignmentItem)
                    {
                        //  Type.GetType("templateType");
                        CodeMethodInvokeExpression getTypeInvokeTemplateTypeExpression = new(
                            new CodeTypeReferenceExpression(nameof(Type)),
                            nameof(Type.GetType),
                            new CodePrimitiveExpression(
                                templateAssignmentItem.TemplateAssignment!.TemplateType!.AssemblyQualifiedName));

                        // Type.GetType("tileContentTime");
                        CodeMethodInvokeExpression getTypeInvokeTileContentTypeExpression = new(
                            new CodeTypeReferenceExpression(nameof(Type)),
                            nameof(Type.GetType),
                            new CodePrimitiveExpression(
                                templateAssignmentItem.TemplateAssignment!.TileContentControlType!.AssemblyQualifiedName));

                        // new TemplateAssignment(templateType1, tileContentType1);
                        CodeObjectCreateExpression templateAssignmentCreateExpression = new(
                            new CodeTypeReference($"{TemplateAssignmentCodeDomSerializer.TemplateAssignmentNamespace}.{nameof(TemplateAssignment)}"),
                            getTypeInvokeTemplateTypeExpression,
                            getTypeInvokeTileContentTypeExpression);

                        CodeObjectCreateExpression templateAssignmentItemCreateExpression = new(
                            new CodeTypeReference($"{TemplateAssignmentCodeDomSerializer.TemplateAssignmentNamespace}.{nameof(TemplateAssignmentItem)}"),
                            new CodePrimitiveExpression(templateAssignmentItem.TemplateAssignmentName),
                            templateAssignmentCreateExpression);

                        List<CodeExpression> addStatementParams = new();
                        addStatementParams.Add(templateAssignmentItemCreateExpression);

                        CodeMethodInvokeExpression addMethodStatement = new(
                            new CodeVariableReferenceExpression(collectionName),
                            nameof(TemplateAssignmentItems.Add),
                            addStatementParams.ToArray());

                        statementCollection.Add(addMethodStatement);
                    }
                }

                if (valuesToSerialize?.Count > 0)
                {
                    // {codeExpression} = new TemplateAssignment(templateType1, tileContentType1);
                    CodeAssignStatement contextAssignmentStatement = new(
                        contextExpression,
                        new CodeVariableReferenceExpression(collectionName));

                    statementCollection.Add(contextAssignmentStatement);

                    return statementCollection;
                }
            }

            return base.SerializeCollection(
                manager, 
                targetExpression, 
                targetType, 
                originalCollection, 
                valuesToSerialize!);
        }
    }
}

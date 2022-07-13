using Microsoft.DotNet.DesignTools.Serialization;
using System.CodeDom;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;

namespace CustomControlLibrary.Designer.Server.Serialization
{
    internal class CustomPropertyStoreCodeDomSerializer : CodeDomSerializer
    {
        private int s_variableOccuranceCounter = 1;

        internal const string CustomPropertyStoreNamespace = "CustomControlLibrary";

        public override object Serialize(
            IDesignerSerializationManager manager,
            object value)
        {
            if (Debugger.IsAttached)
                Debugger.Break();

            if (manager.Context.Current is ExpressionContext expressionContext)
            {
                CustomPropertyStore propertyStore = (CustomPropertyStore)value;

                // This is the left-side assignment target, we want to generate.
                // And it describes the current context, for which we need the
                // object generation. Like:
                // this.tileRepeater1.TemplateAssignmentProperty
                var contextExpression = expressionContext.Expression;

                CodeStatementCollection statements = new();

                // Now, we want to generate:
                //    Type templateType1 = Type.GetType("templateType");
                //    Type tileContentType1 = Type.GetType("tileContentTime");
                //    {codeExpression} = new TemplateAssignment(templateType1, tileContentType1);

                //    CustomPropertyStore customPropertyStore1=new CustomPropertyStore.
                //    customPropertyStore1.SomeMustHaveId = 12
                //    customPropertyStore1.DateCreated = 12
                //    customPropertyStore1.ListOfString = 12
                //    customPropertyStore1.CustomEnumValue = 123                

                // We define the locale variables upfront.
                string customPropertyVariableName = $"customPropertyStore{s_variableOccuranceCounter++}";

                // CustomPropertyStore customPropertyStore1;
                CodeVariableDeclarationStatement customPropertyVarDeclStatement = new(
                    new CodeTypeReference(nameof(CustomPropertyStore)),
                    customPropertyVariableName);

                // We need the variable reference a few times later:
                var customPropertyReference = new CodeVariableReferenceExpression(customPropertyVariableName);

                // new CustomPropertyStore();
                CodeObjectCreateExpression customPropertyCreateExpression = new(
                    new CodeTypeReference(typeof(CustomPropertyStore)));

                // customPropertyStore1.SomeMustHaveId
                CodePropertyReferenceExpression someMustHaveIdProperty = new(
                    customPropertyReference,
                    nameof(CustomPropertyStore.SomeMustHaveId));

                // customPropertyStore1.SomeMustHaveId = {SomeMustHaveIdValue};
                CodeAssignStatement someMustHaveAssignStatement = new(
                    someMustHaveIdProperty,
                    new CodePrimitiveExpression(propertyStore.SomeMustHaveId));

                // {codeExpression} = new CustomPropertyStore();
                CodeAssignStatement contextAssignmentStatement = new(
                    contextExpression, customPropertyCreateExpression);

                statements.AddRange(new CodeStatementCollection
                {
                    customPropertyVarDeclStatement,
                    someMustHaveAssignStatement,
                    contextAssignmentStatement
                });

                return statements;
            };

            var baseResult = base.Serialize(manager, value);
            return baseResult;
        }
    }
}

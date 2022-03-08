using Microsoft.DotNet.DesignTools.Serialization;
using System;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;

namespace WinForms.Tiles.Serialization
{
    internal class TemplateAssignmentCodeDomSerializer : CodeDomSerializer
    {
        private int s_variableOccuranceCounter = 1;

        public override CodeStatementCollection SerializeMember(IDesignerSerializationManager manager, object owningObject, MemberDescriptor member)
        {
            if (Debugger.IsAttached)
                Debugger.Break();

            return base.SerializeMember(manager, owningObject, member);
        }

        public override object Serialize(
            IDesignerSerializationManager manager, 
            object value)
        {
            if (Debugger.IsAttached)
                Debugger.Break();

            if (manager.Context.Current is ExpressionContext expressionContext)
            {
                // This is the left-side assignment target, we want to generate.
                // And it describes the current context, for which we need the
                // object generation. Like:
                // this.tileRepeater1.TemplateAssignmentProperty
                var codeExpression = expressionContext.Expression;

                CodeStatementCollection statements = new CodeStatementCollection();
                // Let's get the actual typed instance first.
                TemplateAssignment templateAssignment = (TemplateAssignment)value;

                // Now, we want to generate:
                //    var templateType1 = Type.GetType("templateType");
                //    var tileContentType1 = Type.GetType("tileContentTime");
                //    TemplateAssignment templateAssignment1 = new TemplateAssignment(templateType1, tileContentType1);
                //    {codeExpression} = templateAssignment1;



            };


            var baseResult = base.Serialize(manager, value);
            return baseResult;
        }
    }
}

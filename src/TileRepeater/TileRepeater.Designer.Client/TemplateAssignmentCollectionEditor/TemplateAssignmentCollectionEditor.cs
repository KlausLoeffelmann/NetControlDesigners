using Microsoft.DotNet.DesignTools.Client.Editors;
using Microsoft.DotNet.DesignTools.Client.Proxies;
using System;
using System.ComponentModel;
using System.Diagnostics;
using WinForms.Tiles.ClientServerProtocol;

namespace WinForms.Tiles.Designer.Client
{
    internal partial class TemplateAssignmentCollectionEditor : CollectionEditor
    {
        public TemplateAssignmentCollectionEditor(Type collectionType)
            : base(collectionType)
        {
            if (Debugger.IsAttached)
                Debugger.Break();
        }

        public override object? EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (Debugger.IsAttached)
                Debugger.Break();

            var returnValue = base.EditValue(context, provider, value);

            if (Debugger.IsAttached)
                Debugger.Break();

            return returnValue;
        }

        protected override string Name => CollectionEditorNames.TemplateAssignmentCollectionEditor;

        protected override ICollectionForm CreateCollectionForm(ObjectProxy viewModel)
            => new CollectionForm(this, new TemplateAssignmentCollectionFormClient(viewModel));
    }
}

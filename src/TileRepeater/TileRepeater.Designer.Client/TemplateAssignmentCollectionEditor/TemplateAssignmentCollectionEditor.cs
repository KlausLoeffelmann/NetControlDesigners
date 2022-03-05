using Microsoft.DotNet.DesignTools.Client.Editors;
using Microsoft.DotNet.DesignTools.Client.Proxies;
using System;
using WinForms.Tiles.ClientServerProtocol;

namespace WinForms.Tiles.Designer.Client
{
    internal partial class TemplateAssignmentCollectionEditor : CollectionEditor
    {
        public TemplateAssignmentCollectionEditor(Type collectionType)
            : base(collectionType)
        {
        }

        protected override string Name => CollectionEditorNames.TemplateAssignmentCollectionEditor;

        protected override ICollectionForm CreateCollectionForm(ObjectProxy viewModel)
            => new CollectionForm(this, new TemplateAssignmentCollectionFormClient(viewModel));
    }
}

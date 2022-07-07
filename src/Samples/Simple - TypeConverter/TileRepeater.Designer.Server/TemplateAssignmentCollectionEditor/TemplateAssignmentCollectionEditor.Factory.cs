using Microsoft.DotNet.DesignTools.Editors;
using System;
using WinForms.Tiles.ClientServerProtocol;

namespace WinForms.Tiles.Designer.Server.TemplateAssignmentCollectionEditor
{
    internal partial class TemplateAssignmentCollectionEditor
    {
        [ExportCollectionEditorFactory(CollectionEditorNames.TemplateAssignmentCollectionEditor)]
        private class Factory : CollectionEditorFactory<TemplateAssignmentCollectionEditor>
        {
            protected override TemplateAssignmentCollectionEditor CreateCollectionEditor(IServiceProvider serviceProvider, Type collectionType)
                => new(serviceProvider, collectionType);
        }
    }
}

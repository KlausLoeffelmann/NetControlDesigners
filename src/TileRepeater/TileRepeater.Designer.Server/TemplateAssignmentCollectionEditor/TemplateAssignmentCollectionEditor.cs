using Microsoft.DotNet.DesignTools.Editors;
using System;
using WinForms.Tiles;

namespace WinForms.Tiles.Designer.Server.TemplateAssignmentCollectionEditor
{
    internal partial class TemplateAssignmentCollectionEditor : CollectionEditor
    {
        public TemplateAssignmentCollectionEditor(IServiceProvider serviceProvider, Type collectionType)
                : base(serviceProvider, collectionType)
        {
        }

        protected override CollectionEditorViewModel CreateCollectionViewModel()
            => new ViewModel(this);

        protected override string GetDisplayText(object value)
        {
            if (value is not TemplateAssignment templateAssignment)
            {
                return base.GetDisplayText(value);
            }

            return templateAssignment.ToString();

        }
    }
}
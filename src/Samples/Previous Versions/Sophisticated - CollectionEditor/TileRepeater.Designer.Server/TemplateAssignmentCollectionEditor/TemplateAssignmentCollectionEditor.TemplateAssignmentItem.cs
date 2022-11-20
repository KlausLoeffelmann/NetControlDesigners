using System;
using WinForms.Tiles.ClientServerProtocol.DataTransport;

namespace WinForms.Tiles.Designer.Server.TemplateAssignmentCollectionEditor
{
    internal partial class TemplateAssignmentCollectionEditor
    {
        private class TemplateAssignmentCollectionItem
        {
            public TemplateAssignmentItem TemplateAssignmentItem { get; }

            public TemplateAssignmentCollectionItem(TemplateAssignmentItem templateAssignmentItem)
            {
                TemplateAssignmentItem = templateAssignmentItem ?? throw new ArgumentNullException(nameof(templateAssignmentItem));
            }

            public override string ToString()
            {
                return TemplateAssignmentItem.ToString()!;
            }

            public TemplateAssignmentItemData ToData()
                => new(TemplateAssignmentItem, TemplateAssignmentItem.ToString()!);
        }
    }
}

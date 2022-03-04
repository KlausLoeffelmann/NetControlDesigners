using System;
using TileRepeater.ClientServerProtocol.DataTransport;
using WinForms.Tiles;

namespace TileRepeater.Designer.Server.TemplateAssignmentCollectionEditor
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

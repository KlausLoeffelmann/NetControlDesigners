using System;
using TileRepeater.ClientServerProtocol.DataTransport;
using WinForms.Tiles;

namespace TileRepeater.Designer.Server.TemplateAssignmentCollectionEditor
{
    internal partial class TemplateAssignmentCollectionEditor
    {
        private class TemplateAssignmentItem
        {
            public TemplateAssignment TemplateAssignment { get; }

            public TemplateAssignmentItem(TemplateAssignment templateAssignment)
            {
                TemplateAssignment = templateAssignment ?? throw new ArgumentNullException(nameof(templateAssignment));
            }

            public override string ToString()
            {
                return TemplateAssignment.ToString()!;
            }

            public TemplateAssignmentItemData ToData()
                => new(TemplateAssignment, TemplateAssignment.ToString()!);
        }
    }
}

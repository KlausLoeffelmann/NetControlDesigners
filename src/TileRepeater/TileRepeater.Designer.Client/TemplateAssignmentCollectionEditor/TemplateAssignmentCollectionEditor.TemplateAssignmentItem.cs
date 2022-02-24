using Microsoft.DotNet.DesignTools.Client.Proxies;
using System;
using System.Diagnostics.CodeAnalysis;
using TileRepeater.ClientServerProtocol.DataTransport;

namespace TileRepeater.Designer.Client
{
    internal partial class TemplateAssignmentCollectionEditor
    {
        private class TemplateAssignmentItem
        {
            [AllowNull]
            public ObjectProxy TemplateAssignmentProxy { get; }

            [AllowNull]
            public string Text { get; }

            private TemplateAssignmentItem(ObjectProxy templateAssignmentProxy, string text)
            {
                TemplateAssignmentProxy = TemplateAssignmentProxy ?? throw new ArgumentNullException(nameof(templateAssignmentProxy));
                Text = text ?? throw new ArgumentNullException(nameof(text));
            }

            public override string ToString()
                => Text;

            internal static TemplateAssignmentItem FromData(TemplateAssignmentItemData itemData)
                => new((ObjectProxy)itemData.TemplateAssignment, itemData.Text);
        }
    }
}

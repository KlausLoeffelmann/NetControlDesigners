﻿using Microsoft.DotNet.DesignTools.Client.Proxies;
using System;
using System.Diagnostics.CodeAnalysis;
using WinForms.Tiles.ClientServerProtocol.DataTransport;

namespace WinForms.Tiles.Designer.Client
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
                TemplateAssignmentProxy = templateAssignmentProxy ?? throw new ArgumentNullException(nameof(templateAssignmentProxy));
                Text = text ?? throw new ArgumentNullException(nameof(text));
            }

            public override string ToString()
                => Text;

            internal static TemplateAssignmentItem FromData(TemplateAssignmentItemData itemData)
                => new((ObjectProxy)itemData.TemplateAssignment, itemData.Text);
        }
    }
}

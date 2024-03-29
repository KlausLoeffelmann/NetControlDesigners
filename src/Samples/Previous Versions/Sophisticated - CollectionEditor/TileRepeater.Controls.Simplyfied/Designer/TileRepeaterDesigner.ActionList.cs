﻿using Microsoft.DotNet.DesignTools.Designers;
using Microsoft.DotNet.DesignTools.Designers.Actions;
using System.ComponentModel;
using WinForms.Tiles.Simplified;
using static WinForms.Tiles.Simplified.SimpleTileRepeater;

namespace WinForms.Tiles.Simplified.Designer
{
    internal partial class SimpleTileRepeaterDesigner
    {
        private class ActionList : DesignerActionList
        {
            private const string Behavior = nameof(Behavior);
            private const string Data = nameof(Data);

            private readonly ComponentDesigner _designer;

            public ActionList(SimpleTileRepeaterDesigner designer)
                : base(designer.Component)
            {
                _designer = designer;
            }

            public bool AutoLayoutOnResize
            {
                get => ((SimpleTileRepeater)Component!).AutoLayoutOnResize;

                // This won't work, since the PropertyBrowser wouldn't get updated.
                // set => ((TileRepeater)Component!).AutoLayoutOnResize = value;

                // Do this instead:
                set =>
                    TypeDescriptor.GetProperties(Component!)[nameof(AutoLayoutOnResize)]!
                        .SetValue(Component, value);
            }

            public TileContentTemplate? ContentTemplate
            {
                get => ((SimpleTileRepeater)Component!).ContentTemplate;

                set =>
                    TypeDescriptor.GetProperties(Component!)[nameof(ContentTemplate)]!
                        .SetValue(Component, value);
            }

            [AttributeProvider(typeof(IListSource))]
            public object? DataSource
            {
                get => ((SimpleTileRepeater)Component!).DataSource;
                set =>
                    TypeDescriptor.GetProperties(Component!)[nameof(DataSource)]!
                        .SetValue(Component, value);
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection actionItems = new();

                actionItems.Add(new DesignerActionHeaderItem(Behavior));
                actionItems.Add(new DesignerActionHeaderItem(Data));

                actionItems.Add(new DesignerActionPropertyItem(
                    nameof(AutoLayoutOnResize),
                    "Automatic layout on resize",
                    Behavior,
                    "Determines, that the tiles get layouted automatically, when the TileRepeater gets resized."));

                actionItems.Add(new DesignerActionPropertyItem(
                    nameof(ContentTemplate),
                    "TileContent control",
                    Behavior,
                    "Determines the TileContent based user control which is used to render each data item."));


                actionItems.Add(new DesignerActionPropertyItem(
                    nameof(DataSource),
                    "DataSource",
                    Data,
                    "Sets the collection with the DataSource types which maps and bind to the TileContent UserControls at runtime."));

                return actionItems;
            }
        }
    }
}

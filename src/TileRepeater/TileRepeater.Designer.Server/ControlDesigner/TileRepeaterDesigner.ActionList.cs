using Microsoft.DotNet.DesignTools.Designers.Actions;
using System.ComponentModel;

namespace WinForms.Tiles.Designer.Server
{
    internal partial class TileRepeaterDesigner
    {
        private class ActionList : DesignerActionList
        {
            private const string Behavior = nameof(Behavior);

            public ActionList(TileRepeaterDesigner designer)
                : base(designer.Component)
            {
            }

            public bool AutoLayoutOnResize
            {
                get => ((TileRepeater)Component!).AutoLayoutOnResize;

                // This won't work, since the PropertyBrowser wouldn't get updated.
                // set => ((TileRepeater)Component!).AutoLayoutOnResize = value;

                // Do this instead:
                set =>
                    TypeDescriptor.GetProperties(Component!)[nameof(AutoLayoutOnResize)]!
                        .SetValue(Component, value);
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection actionItems = new();

                actionItems.Add(new DesignerActionHeaderItem(Behavior));

                actionItems.Add(new DesignerActionPropertyItem(
                    nameof(AutoLayoutOnResize),
                    "Automatic layout on resize",
                    Behavior,
                    "Determines, that the tiles get layouted automatically, when the TileRepeater gets resized."));

                return actionItems;
            }
        }
    }
}

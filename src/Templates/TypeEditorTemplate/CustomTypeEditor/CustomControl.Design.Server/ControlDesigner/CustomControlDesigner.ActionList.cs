using Microsoft.DotNet.DesignTools.Designers;
using Microsoft.DotNet.DesignTools.Designers.Actions;
using System.ComponentModel;

namespace CustomControl.Designer.Server
{
    internal partial class CustomControlDesigner
    {
        private class ActionList : DesignerActionList
        {
            private const string Behavior = nameof(Behavior);

            private readonly ComponentDesigner _designer;

            public ActionList(CustomControlDesigner designer)
                : base(designer.Component)
            {
                _designer = designer;
            }

            public CustomPropertyStore? CustomProperty
            {
                get => ((CustomControl?)Component)?.CustomProperty;

                // This won't work, since the PropertyBrowser wouldn't get updated.
                //set
                //{
                //    if (Component is { } component)
                //    {
                //        ((CustomControl)component).CustomProperty = value;
                //    }
                //}

                // Do this instead:
                set
                {
                    if (Component is { } component)
                    {
                        TypeDescriptor.GetProperties(component)[nameof(CustomProperty)]?.SetValue(component, value);
                    }
                }
            }

            public void InvokeCustomTypeEditor()
                => _designer.InvokePropertyEditor(nameof(CustomControl.CustomProperty));

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection actionItems = new();

                actionItems.Add(new DesignerActionHeaderItem(Behavior));

                actionItems.Add(new DesignerActionPropertyItem(
                    nameof(CustomProperty),
                    "CustomProperty definition",
                    Behavior,
                    "Controls the values of the CustomProperty Definition."));

                actionItems.Add(new DesignerActionMethodItem(
                    this,
                    nameof(InvokeCustomTypeEditor),
                    "Invokes the custom TypeEditor...",
                    true));

                return actionItems;
            }
        }
    }
}

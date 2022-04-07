using Microsoft.DotNet.DesignTools.Designers;
using Microsoft.DotNet.DesignTools.Designers.Actions;
using static WinForms.Tiles.Simplified.SimpleTileRepeater;

namespace WinForms.Tiles.Simplified.Designer
{
    internal partial class SimpleTileRepeaterDesigner : ControlDesigner
    {
        private const string NotDefinedText = 
            $"No assignments.\n" +
            $"Please set the {nameof(SimpleTileRepeater.ContentTemplate)} property\n" +
            $"for Data Template selection assignments.";

        private const int DescriptionOffset = 5;

        public override DesignerActionListCollection ActionLists
            => new()
            {
                new ActionList(this)
            };

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);

            // Let's draw what ever type assignments we have into the control,
            // so the Developer always sees, what Data Template Selection there
            // is at runtime.

            if (((SimpleTileRepeater)Control).ContentTemplate is TileContentTemplate contentTemplate)
            {
                pe.Graphics.DrawString(
                    NotDefinedText,
                    Control.Font,
                    new SolidBrush(Control.ForeColor),
                    new PointF(DescriptionOffset, DescriptionOffset));
            }

            pe.Graphics.DrawString(
                NotDefinedText,
                Control.Font,
                new SolidBrush(Control.ForeColor),
                new PointF(DescriptionOffset, DescriptionOffset));
        }
    }
}

using Microsoft.DotNet.DesignTools.Designers;
using Microsoft.DotNet.DesignTools.Designers.Actions;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControl.Designer.Server
{
    internal partial class CustomControlDesigner : ControlDesigner
    {
        public override DesignerActionListCollection ActionLists
            => new()
        {
            new ActionList(this)
        };

        protected override void OnPaintAdornments(PaintEventArgs paintEventArgs)
        {
            base.OnPaintAdornments(paintEventArgs);

            // If you want to paint custom adorner or other GDI+ based content,
            // use the paintEventArgs' Graphics methods to render it.

            // We just drawing frame around the ClientRectangle with dotted brush...
            if (!(SelectionService?.GetComponentSelected(Control) ?? false))
            {
                using var pen = new Pen(Control.ForeColor);
                //...if the control is not currently selected.
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                using var brush = new SolidBrush(Control.ForeColor);

                var clientRect = Control.ClientRectangle;
                clientRect.Inflate(-1, -1);

                paintEventArgs.Graphics.DrawRectangle(pen, clientRect);
            }
        }
    }
}

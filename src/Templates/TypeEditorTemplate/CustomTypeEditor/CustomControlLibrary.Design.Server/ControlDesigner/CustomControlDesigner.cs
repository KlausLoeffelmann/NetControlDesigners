using Microsoft.DotNet.DesignTools.Designers;
using Microsoft.DotNet.DesignTools.Designers.Actions;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControlLibrary.Designer.Server
{
    /// <summary>
    /// The control designer of the CustomControl.
    /// </summary>
    internal partial class CustomControlDesigner : ControlDesigner
    {
        /// <summary>
        /// Attaches the Action lists to the Control Designer.
        /// </summary>
        /// <remarks>
        /// Note: Action lists for the out-of-process Designer can be implemented exactly as they would be for the in-process 
        /// Designer. The control designer has to be compiled against the Winforms Designer Extensibility SDK, and ActionList related 
        /// classes must come from the <see cref="Microsoft.DotNet.DesignTools.Designers.Actions"/> namespace.
        /// TODO: For further information about ActionLists, please refer to ...
        /// </remarks>
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

            // Drawing the frame around the ClientRectangle with a dotted brush...
            if (!(SelectionService?.GetComponentSelected(Control) ?? false))
            {
                using var pen = new Pen(Control.ForeColor);

                // ...if the control is not currently selected.
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                using var brush = new SolidBrush(Control.ForeColor);

                var clientRect = Control.ClientRectangle;
                clientRect.Inflate(-1, -1);

                paintEventArgs.Graphics.DrawRectangle(pen, clientRect);
            }
        }
    }
}

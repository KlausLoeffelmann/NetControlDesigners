using Microsoft.DotNet.DesignTools.Designers;

namespace RootDesignerDemo;

public partial class ShapeRootDesigner
{
    // RootDesignerView is a simple control that will be displayed 
    // in the designer window.
    private class SampleRootDesignerView : RootDesignerView
    {
        private ShapeRootDesigner _designer;

        public SampleRootDesignerView(ShapeRootDesigner designer)
        {
            _designer = designer;
            BackColor = Color.Blue;
            Font = new Font(Font.FontFamily.Name, 24.0f);
            LogInfo("Initialize SampleRootDesignerView.");
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            // Draws the name of the component in large letters.
            pe.Graphics.DrawString(_designer.Component.Site.Name, Font, Brushes.Yellow, ClientRectangle);
        }
    }
}

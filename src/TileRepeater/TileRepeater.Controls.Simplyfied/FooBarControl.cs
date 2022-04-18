using System.ComponentModel;

namespace TileRepeater.Controls.Simplified
{
    public class FooBarControl : Control
    {
        [Editor("System.Drawing.Design.ColorEditor", "System.Drawing.Design.UITypeEditor")]
        public Color SpecialColor { get; set; }

        [Editor("System.Windows.Forms.Design.FileNameEditor", "System.Drawing.Design.UITypeEditor")]
        public string? Filename { get; set; }
    }
}

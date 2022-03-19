using Microsoft.DotNet.DesignTools.Designers;
using Microsoft.DotNet.DesignTools.Designers.Actions;
using System.Windows.Forms;

namespace WinForms.Tiles.Designer.Server
{
    internal partial class TileRepeaterDesigner : ControlDesigner
    {
        public override DesignerActionListCollection ActionLists
            => new DesignerActionListCollection
            {
                new ActionList(this)
            };

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);
        }
    }
}

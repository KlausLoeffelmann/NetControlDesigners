using WinForms.Tiles;

namespace TileRepeaterDemo.TileTemplates
{
    public partial class LandscapeImageContent : ImageContent
    {
        public LandscapeImageContent() : base() => InitializeComponent();

        protected override Size BaseDefaultSize => new Size(266, 200);
    }
}

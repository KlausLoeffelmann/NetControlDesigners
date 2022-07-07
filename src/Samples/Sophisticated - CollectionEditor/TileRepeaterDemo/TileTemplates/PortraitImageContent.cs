namespace TileRepeaterDemo.TileTemplates
{
    public partial class PortraitImageContent : ImageContent
    {
        public PortraitImageContent() : base() => InitializeComponent();

        protected override Size BaseDefaultSize => new Size(150, 200);
    }
}

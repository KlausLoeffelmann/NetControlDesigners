using WinForms.Tiles;

namespace TileRepeaterDemo.TileTemplates
{
    public partial class ImageContent : TileContent
    {
        private TileSize _tileSize = TileSize.Medium;

        public ImageContent()
        {
            InitializeComponent();
            BindingSourceComponent = _genericPictureItemBindingSource;
        }

        public TileSize TileSize
        {
            get => _tileSize;
            set
            {
                if (!Equals(_tileSize, value))
                {
                    _tileSize = value;
                    OnTileSizeChanged(EventArgs.Empty);
                }
            }
        }

        protected virtual void OnTileSizeChanged(EventArgs e)
        { }

        protected virtual Size BaseDefaultSize => new Size(200, 200);

        public override Size GetPreferredSize(Size proposedSize)

            // TODO: Take DPI into account.
            => BaseDefaultSize * (int)TileSize;

        public override async Task LoadAsync()
        {
            await _imageLoaderComponent.LoadImageAsync();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // TODO: Paint.
        }

        public override void DisposeContent()
        {
            _imageLoaderComponent.DisposeImage();
        }
    }
}

using WinForms.Tiles;

namespace TileRepeaterDemo.TileTemplates
{
    public partial class ImageContent : TileContent
    {
        public ImageContent()
        {
            InitializeComponent();
            BindingSourceComponent = _genericPictureItemBindingSource;
        }
    }
}

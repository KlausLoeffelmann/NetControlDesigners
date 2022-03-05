namespace WinForms.Tiles
{
    public partial class TileContent : UserControl
    {
        protected const int DefaultSelectionFramePadding = 20;

        public TileContent()
        {
            InitializeComponent();
        }

        public virtual bool IsSeparator => false;

        public virtual Padding SelectionFramePadding
            => new(DefaultSelectionFramePadding);

        public BindingSource? BindingSourceComponent { get; set; }
    }
}

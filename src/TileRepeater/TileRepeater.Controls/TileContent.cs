using System.ComponentModel;

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

        public virtual async Task LoadAsync()
        {
            await Task.Delay(0);
            IsLoaded = true;
        }

        [Browsable(false)]
        public bool IsLoaded { get; private set; }

        public virtual void DisposeContent()
        { }
    }
}

using System.ComponentModel;

namespace WinForms.Tiles.Simplified
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

        public async Task LoadContentAsync() 
            => IsContentLoaded = await LoadContentCoreAsync();

        protected virtual async Task<bool> LoadContentCoreAsync() 
            => await Task.FromResult(false);

        [Browsable(false)]
        public bool IsContentLoaded { get; private set; }

        public virtual void DisposeContent()
        { }
    }
}

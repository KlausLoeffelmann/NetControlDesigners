using System.ComponentModel;
using System.Diagnostics;

namespace WinForms.Tiles
{
    public partial class Tile : UserControl
    {
        private const int SelectionFramePadding = 20;
        private bool _isInParentClientArea;

        public Tile()
        {
            InitializeComponent();
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var size=TileContent.GetPreferredSize(proposedSize);
            size += new Size(Padding.Left, Padding.Top) + 
                new Size(Padding.Right, Padding.Bottom);

            return size;
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);

            IsInParentClientArea =
                !(Bottom < 0 ||
                Top > ParentForVirtualization!.ClientSize.Height ||
                Right < 0 ||
                Left > ParentForVirtualization.ClientSize.Width);
        }

        public virtual bool IsInParentClientArea
        {
            get => _isInParentClientArea;
            set
            {
                if (_isInParentClientArea!=value)
                {
                    _isInParentClientArea = value;
                    OnIsInParentClientAreaChanged();
                }
            }
        }

        protected virtual async void OnIsInParentClientAreaChanged()
        {
            Debug.Print($"{Tag}'s visibility changed:{IsInParentClientArea} - {Location} - {((TileRepeater)Parent)?.VerticalScroll.Value}");

            if (IsInParentClientArea)
            {
                if (Parent is null)
                {
                    ParentForVirtualization!.SuspendNextTileLayout(nameof(Parent));
                    ParentForVirtualization!.SuspendNextTileLayout(nameof(Bounds));
                    ParentForVirtualization!.Controls.Add(this);
                }
            }
            else
            {
                if (Parent is not null && !(Tag is bool))
                {
                    ParentForVirtualization!.SuspendNextTileLayout(nameof(Parent));
                    ParentForVirtualization!.Controls.Remove(this);
                }
            }

            if (TileContent is not null && IsInParentClientArea && !TileContent.IsContentLoaded)
            {
                try
                {
                    // This is a fire-and-forget,
                    // so we need to catch a potential
                    // exception of the async content load
                    // and just swallow it.
                    await TileContent.LoadContentAsync();
                }
                catch (Exception)
                {
                }
            }
        }

        internal TileRepeater ParentForVirtualization { get; set; }

        public TileContent TileContent
        {
            get
            {
                if (_contentPanel.Controls.Count == 0)
                {
                    _contentPanel.Controls.Add(new TileContent()
                    {
                        Dock = DockStyle.Fill,
                    });
                }

                return (_contentPanel.Controls[0] as TileContent)!;
            }
            set
            {
                if (_contentPanel.Controls.Count > 0)
                {
                    _contentPanel.Controls.Clear();
                }

                var tileContent = value;
                tileContent.Dock = DockStyle.Fill;
                tileContent.Enabled = true;

                _contentPanel.Controls.Add(tileContent);
            }
        }
    }
}

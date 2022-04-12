using System.Collections;
using System.ComponentModel;
using WinForms.Tiles.Simplified.Designer;

namespace WinForms.Tiles.Simplified
{
    [Designer(typeof(SimpleTileRepeaterDesigner)),
     System.ComponentModel.ComplexBindingProperties("DataSource")]
    public partial class SimpleTileRepeater : Panel
    {
        private const string AutoLayoutResizeDescription =
            "Gets or sets a value which determines, if the " +
            "Layout should be recalculated on resizing automatically.";

        private const string ContentTemplateDescription =
            "Gets or sets the TileContent based UserControl which will be instantiated for " +
            "and bound to every item in the data source collection. ";

        private const string DataSourceDescription = 
            "Gets or sets the data source for the TileRepeater control.";

        private IBindingList? _dataSource;
        private Action? _listUnbinder;

        private int _previousListCount;

        public SimpleTileRepeater()
        {
            base.AutoScroll = true;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
         EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoScroll { get => true; set => base.AutoScroll = true; }

        /// <summary>
        /// Gets or sets a value which determines, if the Layout should be recalculated on resizing automatically.
        /// </summary>
        [DefaultValue(false),
         Description(AutoLayoutResizeDescription)]
        public bool AutoLayoutOnResize { get; set; }

        [Description(ContentTemplateDescription)]
        public TileContentTemplate? ContentTemplate { get; set; }

        private bool ShouldSerializeContentTemplate()
            => ContentTemplate is not null;

        private void ResetContentTemplate()
            => ContentTemplate = null;

        /// <summary>
        /// Gets or sets the data source for the TileRepeater control.
        /// </summary>
        [Description(DataSourceDescription)]
        [AttributeProvider(typeof(IListSource)),
         Bindable(true)]
        public object? DataSource
        {
            get => _dataSource;

            set
            {
                if (!object.Equals(value, _dataSource))
                {
                    _listUnbinder?.Invoke();
                    _dataSource = value switch
                    {
                        null => null,
                        IBindingList bindingList => WireBindingList(bindingList),
                        _ => throw new ArgumentException(
                            nameof(DataSource),
                            "DataSource must be of type IBindingList"),
                    };
                }

                GenerateContent();
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            if (IsAncestorSiteInDesignMode)
            {
                PopulateDesignerContent();
            }
        }

        private void PopulateDesignerContent()
            => Controls.Clear();

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);

            if (AutoLayoutOnResize)
            {
                PerformLayout();
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            if ((levent.AffectedControl is Tile && levent.AffectedProperty == nameof(Parent)) ||
                (!AutoLayoutOnResize &&
                 levent.AffectedControl is SimpleTileRepeater &&
                 levent.AffectedProperty == nameof(DisplayRectangle)) || AutoLayoutOnResize)
            {
                LayoutInternal();
            }

            base.OnLayout(levent);
        }

        private IBindingList WireBindingList(IBindingList bindingList)
        {
            bindingList.ListChanged += BindingList_ListChanged;
            _listUnbinder = new Action(() => bindingList.ListChanged -= BindingList_ListChanged);
            return bindingList;
        }

        private void BindingList_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (sender is IList list)
            {
                if (list.Count != _previousListCount)
                {
                    _previousListCount = list.Count;
                    GenerateContent();
                }
            }
        }

        private void GenerateContent()
        {
            SuspendLayout();
            Controls.Clear();

            if (_dataSource is null ||
                ContentTemplate is null)
            {
                ResumeLayout();
                return;
            }

            foreach (var item in _dataSource)
            {
                var tileControl = GetTemplateControlInstance(item.GetType());
                tileControl!.TileContent.BindingSourceComponent!.DataSource = item;
                Controls.Add(tileControl);
            }

            ResumeLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _listUnbinder?.Invoke();
            }

            base.Dispose(disposing);
        }

        private void LayoutInternal()
        {
            if (Controls.Count == 0)
            {
                return;
            }

            Control lastControl = Controls[0];

            lastControl.Visible = true;
            lastControl.Tag = true;

            int currentX = Padding.Left;
            int currentY = Padding.Top;
            int maxRowHeight = 0;
            int tilesInRow = 1;

            foreach (Control control in Controls)
            {
                // We only touching Tile controls.
                if (control is Tile tileControl)
                {
                    tileControl.Size = control.PreferredSize;

                    if (tileControl.TileContent.IsSeparator)
                    {
                        currentY += maxRowHeight;
                        currentX = Padding.Left;
                        maxRowHeight = 0;

                        tileControl.Left = currentX;
                        tileControl.Top = currentY;

                        currentY += tileControl.Margin.Top+tileControl.Height+tileControl.Margin.Bottom;
                    }
                    else
                    {
                        if (currentX + tileControl.Margin.Left + tileControl.Width + tileControl.Margin.Right > ClientSize.Width &&
                            tilesInRow > 1)
                        {
                            currentY += maxRowHeight;
                            currentX = Padding.Left;
                            maxRowHeight = 0;
                            tilesInRow = 1;
                        }

                        tileControl.Left = currentX;
                        tileControl.Top = currentY;

                        currentX += tileControl.Margin.Left + tileControl.Width + tileControl.Margin.Right;
                        
                        maxRowHeight = Math.Max(
                            maxRowHeight,
                            tileControl.Margin.Top + tileControl.Height + tileControl.Margin.Bottom);


                        lastControl = tileControl;
                        tilesInRow++;
                    }
                }
            }

            lastControl.Visible = true;
            lastControl.Tag = true;
        }

        private Tile? GetTemplateControlInstance(Type templateType)
        {
            Tile tileControl = new();

            TileContent tileContentInstance;

            try
            {
                tileContentInstance = (TileContent)Activator.CreateInstance(ContentTemplate!.TileContentType!)!;
                tileContentInstance.Size = tileContentInstance.PreferredSize;
            }
            catch (Exception)
            {
                // TODO: If the Activator threw, we need to have an error control here.
                tileContentInstance = new TileContent() { BackColor = Color.Red };
            }

            tileControl.TileContent = tileContentInstance;
            return tileControl;
        }
    }
}

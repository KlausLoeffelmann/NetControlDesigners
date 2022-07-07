using System.Collections;
using System.ComponentModel;

namespace WinForms.Tiles
{
    [Designer("TileRepeaterDesigner"),
     System.ComponentModel.ComplexBindingProperties("DataSource")]
    public partial class TileRepeater : Panel
    {
        private const string AutoLayoutResizeDescription =
            "Gets or sets a value which determines, if the " +
            "Layout should be recalculated on resizing automatically.";

        private const string TemplateTypesDescription =
            "Gets or sets the collection of type assignments, which determines based on the item type " +
            "in the data source what TileContent based type UserControl should be used for rendering " +
            "the data on binding.";

        private const string DataSourceDescription = 
            "Gets or sets the data source for the TileRepeater control.";

        private TemplateAssignmentItems? _templateAssignments;

        private IBindingList? _dataSource;
        private Action? _listUnbinder;

        private int _previousListCount;

        public TileRepeater()
        {
            _templateAssignments = new TemplateAssignmentItems();
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

        /// <summary>
        /// Gets or sets the collection of type assignments, which determines based on the item type 
        /// in the data source what TileContent based type UserControl should be used for rendering 
        /// the data on binding.
        /// </summary>
        [Description(TemplateTypesDescription)]
        public TemplateAssignmentItems? TemplateTypes
        {
            get => _templateAssignments;
            set => _templateAssignments = value;
        }

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
                 levent.AffectedControl is TileRepeater &&
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
                TemplateTypes is null)
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

                        if (tileControl.TileContent.RequestFarSideAnchoring)
                        {
                            tileControl.Width = Right -
                                (Padding.Right + Padding.Left +
                                 tileControl.Margin.Left + tileControl.Margin.Right +
                                 SystemInformation.VerticalScrollBarWidth);

                            tileControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                        }

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
            // Get TileContentControl based on type:
            var tileContentType = TemplateTypes?
                .Where(item => item.TemplateAssignment!.TemplateType == templateType)?
                .FirstOrDefault()?.TemplateAssignment?.TileContentControlType;

            Tile tileControl = new();

            TileContent tileContentInstance;

            try
            {
                tileContentInstance = (TileContent)Activator.CreateInstance(tileContentType!)!;
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

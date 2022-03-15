using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

namespace WinForms.Tiles
{
    [System.ComponentModel.ComplexBindingProperties("DataSource")]
    public partial class TileRepeater : Panel
    {
        private const int DefaultMaxColumn = 3;
        private TemplateAssignmentItems? _templateAssignments;

        private object? _dataSource;
        private int _maxColumn = DefaultMaxColumn;
        private Action? _listUnbinder;

        private int _previousListCount;
        private Tile? _templateControlInstance;

        public TileRepeater()
        {
            _templateAssignments = new TemplateAssignmentItems();
            AutoScroll = true;
        }

        public TemplateAssignmentItems? TemplateTypes
        {
            get => _templateAssignments;
            set
            {
                _templateAssignments = value;
            }
        }

        [AttributeProvider(typeof(IListSource)),
         Bindable(true)]
        public object? DataSource
        {
            get { return _dataSource; }
            set
            {
                if (!object.Equals(value, _dataSource))
                {
                    _listUnbinder?.Invoke();
                    _dataSource = value switch
                    {
                        var x when x is null => null,
                        INotifyCollectionChanged collectionChange => collectionChange,
                        IBindingList bindingList => WireBindingList(bindingList),
                        _ => throw new ArgumentException(
                            nameof(DataSource),
                            "DataSource must be of type IListSource or INotifyCollectionChanged"),
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
        {
            Controls.Clear();
            if (_templateAssignments is not null)
            {
                for (int count = 0; count < MaxColumn + 1; count++)
                {
                    //var control = GetTemplateControlInstance();
                    //Controls.Add(control);
                }
            }

            LayoutInternal();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (IsHandleCreated && IsAncestorSiteInDesignMode)
            {
                var bgPen = new Pen(ForeColor, 2);
                var bgBrush = new SolidBrush(BackColor);
                e.Graphics.DrawRectangle(bgPen, ClientRectangle);
                var tmpControlString = TemplateTypes is null
                    ? "(none defined)"
                    : "Multiple Types Defines.";

                e.Graphics.DrawString($"TemplateControl:{tmpControlString}", Font, bgBrush, 10, 10);
            }
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

            object? actualBindingSource;

            if (_dataSource is BindingSource bindingSource)
            {
                actualBindingSource = bindingSource.List;
            }
            else
            {
                actualBindingSource = _dataSource;
            }

            if (actualBindingSource is not IBindingList dataSourceAsBindingList || TemplateTypes is null)
            {
                ResumeLayout();
                return;
            }

            foreach (var item in dataSourceAsBindingList)
            {
                var tileControl = GetTemplateControlInstance(item.GetType());
                tileControl!.TileContent.BindingSourceComponent!.DataSource = item;
                Controls.Add(tileControl);
            }

            LayoutInternal();
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

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);

            SuspendLayout();
            LayoutInternal();
            ResumeLayout(false);
        }

        private void LayoutInternal()
        {
            // Layout the controls
            if (_templateControlInstance is null)
            {
                return;
            }

            int currentX = _templateControlInstance.Margin.Left;
            int currentY = _templateControlInstance.Margin.Top;
            int xIncrease = _templateControlInstance.Margin.Left + _templateControlInstance.Margin.Right + _templateControlInstance.Width;
            int yIncrease = _templateControlInstance.Margin.Top + _templateControlInstance.Margin.Bottom + _templateControlInstance.Height;
            int controlCounter = 0;

            foreach (Control control in Controls)
            {
                control.Left = currentX;
                control.Top = currentY;
                currentX += xIncrease;

                if (controlCounter++ == (MaxColumn - 1) || currentX + _templateControlInstance.Width > ClientSize.Width)
                {
                    controlCounter = 0;
                    currentY += yIncrease;
                    currentX = _templateControlInstance.Margin.Left;
                }
            }
        }

        //public UserControlTemplate? TemplateControl
        //{
        //    get { return _templateControl; }
        //    set
        //    {
        //        if (!object.Equals(value, _templateControl))
        //        {
        //            _templateControl = value;
        //            if (_templateControl is null)
        //            {
        //                Controls.Clear();
        //                _templateControlInstance = null;
        //                return;
        //            }

        //            _templateControlInstance = GetTemplateControlInstance();
        //            //if (_templateControlInstance?.BindingSourceComponent is null)
        //            //{
        //            //    throw new ArgumentException("Please make sure that the TemplateControl's " +
        //            //        "BindingSourceComponent property is set up for populating " +
        //            //        "the template control via data binding.");
        //            //}

        //            if (IsHandleCreated && IsAncestorSiteInDesignMode)
        //            {
        //                PopulateDesignerContent();
        //            }
        //            else
        //            {
        //                GenerateContent();
        //            }
        //        }
        //    }
        //}

        //private void ResetTemplateControl()
        //{
        //    TemplateControl = null;
        //}

        [DefaultValue(DefaultMaxColumn)]
        public int MaxColumn
        {
            get => _maxColumn;

            set
            {
                if (value is < 0 or > 10)
                {
                    throw new ArgumentException("Value must be between 0 and 10.");
                }

                _maxColumn = value;
            }
        }

        private Tile? GetTemplateControlInstance(Type templateType)
        {
            // Get TileContentControl based on type:
            var tileContentType = TemplateTypes?
                .Where(item => item.TemplateAssignment!.TemplateType == templateType)?
                .FirstOrDefault()?.TemplateAssignment?.TileContentControlType;

            Tile tileControl = new Tile();

            TileContent tileContentInstance;

            try
            {
                tileContentInstance = (TileContent)Activator.CreateInstance(tileContentType!)!;
            }
            catch (Exception)
            {
                // TODO: If the Activater threw, we need to have an error control here.
                tileContentInstance = new TileContent() { BackColor = Color.Red };
            }

            tileControl.TileContent = tileContentInstance;
            return tileControl;
        }
    }
}

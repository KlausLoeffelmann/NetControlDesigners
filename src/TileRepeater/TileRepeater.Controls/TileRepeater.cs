using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace WinForms.Tiles
{
    [System.ComponentModel.ComplexBindingProperties("DataSource")]
    public partial class TileRepeater : Panel
    {
        private TemplateAssignmentItems? _templateAssignments;

        private object? _dataSource;
        private Action? _listUnbinder;

        private int _previousListCount;
        private Tile? _templateControlInstance;
        private bool _layoutCached;

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
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            _layoutCached = false;
            PerformLayout();
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

        protected override void OnLayout(LayoutEventArgs levent)
        {
            if (!_layoutCached)
            {
                LayoutInternal();
                _layoutCached = true;
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
            _layoutCached = false;
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

            int currentX = lastControl.Margin.Left;
            int currentY = lastControl.Margin.Top;
            int yIncrease = lastControl.Margin.Top + lastControl.Margin.Bottom + lastControl.Height;

            foreach (Control control in Controls)
            {
                control.Left = currentX;
                control.Top = currentY;
                currentX += lastControl.Margin.Left + lastControl.Width + lastControl.Margin.Right;

                if (currentX > ClientSize.Width)
                {
                    currentY += yIncrease;
                    currentX = lastControl.Margin.Left;
                }

                lastControl = control;
            }

            AutoScrollMargin = new Size(
                lastControl.Left + lastControl.Width, 
                lastControl.Top + lastControl.Height);
            this.VScroll = true;
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
                tileContentInstance.Size = tileContentInstance.PreferredSize;
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

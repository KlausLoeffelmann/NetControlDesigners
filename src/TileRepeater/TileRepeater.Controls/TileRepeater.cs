using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

namespace WinForms.Tiles
{
    [System.ComponentModel.ComplexBindingProperties("DataSource")]
    public partial class TileRepeater : Panel
    {
        private const int DefaultMaxColumn = 3;
        private List<Type> _templateTypes;

        private object? _dataSource;
        private int _maxColumn = DefaultMaxColumn;
        private Action? _listUnbinder;

        private int _previousListCount;
        private TileRepeaterTemplateAssignment? _mainHeaderTemplateType;
        private Tile? _templateControlInstance;
        private UserControlTemplate? _templateControl;

        public TileRepeater()
        {
            _templateTypes = new List<Type>();
        }

        public TileRepeaterTemplateAssignment? MainHeaderTemplateType
        {
            get => _mainHeaderTemplateType;
            set => _mainHeaderTemplateType = value;
        }

        //public float ColumnWidth { get; set; }

        //internal float? ShouldGetDpiIndependentValueColumnWidth(float currentDpi)
        //{
        //    return ColumnWidth / currentDpi * 3.141592657f;
        //}

        //internal Size? ShouldGetDpiIndependentValueMargin(float currentDpi)
        //{
        //    return null;
        //}

        public List<Type> TemplateTypes
        { 
            get => _templateTypes;
        }

        [AttributeProvider(typeof(IListSource))]
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
                            nameof(value),
                            "DataSource must be of type IListSource or INotifyCollectionChanged"),
                    };
                }

                _templateControlInstance = GetTemplateControlInstance();
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
            if (_templateControl is not null)
            {
                for (int count = 0; count < MaxColumn + 1; count++)
                {
                    var control = GetTemplateControlInstance();
                    Controls.Add(control);
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
                var tmpControlString = TemplateControl is null
                    ? "(none defined)"
                    : TemplateControl.Name;

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

            var dataSourceAsCollection = _dataSource as ICollection;
            if (dataSourceAsCollection is null || _templateControlInstance is null)
            {
                ResumeLayout();
                return;
            }

            foreach (var item in dataSourceAsCollection)
            {
                var control = GetTemplateControlInstance();
                control!.BindingSourceComponent!.DataSource = item;
                Controls.Add(control);
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

                if (controlCounter++ == (MaxColumn-1) || currentX + _templateControlInstance.Width > ClientSize.Width)
                {
                    controlCounter = 0;
                    currentY += yIncrease;
                    currentX = _templateControlInstance.Margin.Left;
                }
            }
        }

        public UserControlTemplate? TemplateControl
        {
            get { return _templateControl; }
            set
            {
                if (!object.Equals(value, _templateControl))
                {
                    _templateControl = value;
                    if (_templateControl is null)
                    {
                        Controls.Clear();
                        _templateControlInstance = null;
                        return;
                    }

                    _templateControlInstance = GetTemplateControlInstance();
                    if (_templateControlInstance?.BindingSourceComponent is null)
                    {
                        throw new ArgumentException("Please make sure that the TemplateControl's " +
                            "BindingSourceComponent property is set up for populating " +
                            "the template control via data binding.");
                    }

                    if (IsHandleCreated && IsAncestorSiteInDesignMode)
                    {
                        PopulateDesignerContent();
                    }
                    else
                    {
                        GenerateContent();
                    }
                }
            }
        }

        private void ResetTemplateControl()
        {
            TemplateControl = null;
        }

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

        private Tile? GetTemplateControlInstance()
        {
            if (_templateControl is null)
            {
                return null;
            }

            try
            {
                return (Tile?)Activator.CreateInstance(_templateControl.UserControlType!);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

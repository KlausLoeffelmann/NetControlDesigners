namespace WinForms.Tiles
{
    public class TileRepeaterTemplateAssignment
    {
        private Type _templateType;
        private Tile _dataSourceUserControl;

        public TileRepeaterTemplateAssignment(Type templateType, Tile dataSourceUserControl)
        {
            _templateType = templateType;
            _dataSourceUserControl = dataSourceUserControl;
        }

        public Type TemplateType
        {
            get => _templateType;
            set => _templateType = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Tile DataSourceUserControl
        {
            get => _dataSourceUserControl;
            set => _dataSourceUserControl = value ?? throw new ArgumentException(nameof(value));
        }
    }
}


using System.ComponentModel;
using System.Drawing.Design;

namespace WinForms.Tiles
{
    [Editor("TemplateAssignmentEditor", typeof(UITypeEditor))]
    public class TemplateAssignment
    {
        private Type? _templateType;
        private Type? _tileContentControlType;

        public TemplateAssignment(Type? templateType, Type? tileContentControlType)
        {
            _templateType = templateType;
            _tileContentControlType = tileContentControlType;
        }

        public Type? TemplateType
        {
            get => _templateType;
            set => _templateType = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Type? TileContentControlType
        {
            get => _tileContentControlType;
            set => _tileContentControlType = value ?? throw new ArgumentException(nameof(value));
        }
    }
}

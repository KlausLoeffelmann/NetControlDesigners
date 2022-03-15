using WinForms.Tiles;

namespace TileRepeaterDemo.TileTemplates
{
    public partial class GroupSeperatorContent : TileContent
    {
        public GroupSeperatorContent()
        {
            InitializeComponent();
            BindingSourceComponent = _genericTemplateItemBindingSource;
        }

        public override bool IsSeparator => true;
    }
}

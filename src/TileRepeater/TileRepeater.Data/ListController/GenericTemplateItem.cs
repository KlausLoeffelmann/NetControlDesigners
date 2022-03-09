using System;
using TileRepeater.Data.Base;


namespace TileRepeater.Data.ListController
{
    public class GenericTemplateItem : BindableBase
    {
        private string? _label;

        public GenericTemplateItem() : this(null)
        {
        }

        public GenericTemplateItem(IServiceProvider? serviceProvider) : base(serviceProvider)
        {
        }

        public string? Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }
    }
}

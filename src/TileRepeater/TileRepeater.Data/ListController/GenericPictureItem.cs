using System;
using TileRepeater.Data.Base;

namespace TileRepeater.Data.ListController
{
    internal class GenericPictureItem : BindableBase
    {
        private string? _imageFilename;

        public GenericPictureItem() : base(null)
        {
        }

        public GenericPictureItem(IServiceProvider? serviceProvider) : base(serviceProvider)
        {
        }

        public string? Filename
        {
            get => _imageFilename;
            set => SetProperty(ref _imageFilename, value);
        }
    }
}

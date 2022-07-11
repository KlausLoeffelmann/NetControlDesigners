using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using TileRepeater.Data.Base;
using TileRepeater.Data.Image;

namespace TileRepeater.Data.ListController
{
    public class UIController : BindableBase
    {
        // We limit the scenario for jpegs for now.
        //private const string DefaultFileSearchPattern = "*.bmp|*.png|*.jpg|*.jpeg|*.gif|*.ico|*.tif|*.tiff|*.raw|*.arw|*.heic|*.nef|*.cr2";
        private const string DefaultFileSearchPattern = "*.jpg|*.jpeg";

        private static readonly string[] s_defaultFileSearchPattern;

        static UIController()
        {
            s_defaultFileSearchPattern = DefaultFileSearchPattern.Replace("*", "").Split('|');
        }

        public UIController() : base(null)
        {
        }

        public UIController(IServiceProvider? serviceProvider) : base(serviceProvider)
        {
        }

        private BindingList<GenericPictureItem>? _pictureItems;

        public BindingList<GenericPictureItem>? PictureItems
        {
            get => _pictureItems;
            set => SetProperty(ref _pictureItems, value);
        }

        public static BindingList<GenericPictureItem>? GetSimplePictureTemplateItemsFromFolder(
            string filePath,
            SearchOption searchOption = SearchOption.AllDirectories)
        {
            DirectoryInfo directoryInfo = new(filePath);
            BindingList<GenericPictureItem>? pictureItems = new();

            var filesInPath = directoryInfo.GetFiles("*.*", searchOption)
                .Where(file => s_defaultFileSearchPattern.Any(extension => extension == file.Extension))
                .OrderByDescending(file => file.LastWriteTime)
                .ToList();

            if (filesInPath.Count == 0)
            {
                return pictureItems;
            }

            foreach (var file in filesInPath)
            {
                var imageMetaData = file.GetImageMetaData();
                if (imageMetaData is not null)
                {
                    pictureItems.Add(new GenericPictureItem(imageMetaData.Value));
                }
            }

            return pictureItems;
        }
    }
}

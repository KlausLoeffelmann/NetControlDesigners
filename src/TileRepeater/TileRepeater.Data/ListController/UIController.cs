using MetadataExtractor;
using MetadataExtractor.Formats.Jpeg;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using TileRepeater.Data.Base;

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

        private BindingList<GenericTemplateItem>? _pictureFileList;

        public BindingList<GenericTemplateItem>? PictureFileList
        {
            get => _pictureFileList;
            set => SetProperty(ref _pictureFileList, value);
        }

        public static BindingList<GenericTemplateItem>? GetPictureTemplateItemsFromFolder(
            string filePath,
            SearchOption searchOption = SearchOption.AllDirectories)
        {
            DirectoryInfo directoryInfo = new(filePath);
            BindingList<GenericTemplateItem>? pictureItems = new();

            var filesInPath = directoryInfo.GetFiles("*.*", searchOption)
                .Where(file => s_defaultFileSearchPattern.Any(extension => extension == file.Extension))
                .OrderByDescending(file => file.LastWriteTime)
                .ToList();

            if (filesInPath.Count == 0)
            {
                return pictureItems;
            }

            DateTime currentDate = filesInPath[0].LastWriteTime;

            foreach (var file in filesInPath)
            {
                var fileDate = file.LastWriteTime;

                // Grouping by months is hardwired. Should be enough for demo purposes.
                if ($"{currentDate.Year}{currentDate.Month}" != $"{fileDate.Year}{fileDate.Month}")
                {
                    currentDate = fileDate;
                    pictureItems.Add(new GenericTemplateItem()
                    {
                        Label = $"Pictures of {currentDate:MMMM}, {currentDate:yyyy}"
                    });
                }

                var directories = ImageMetadataReader.ReadMetadata(file.FullName);
                var jpegDir = directories.OfType<JpegDirectory>().FirstOrDefault();

                // For simplicity, we concentrate of JPEGs for now.
                if (jpegDir is null) continue;

                var height = jpegDir.GetImageHeight();
                var width = jpegDir.GetImageWidth();
                var dateTaken = file.LastWriteTime;

                GenericTemplateItem itemToAdd;

                if (height > width)
                {
                    itemToAdd = new PortraitPictureItem(width, height, file.FullName)
                    { DateTaken = dateTaken };
                }
                else
                {
                    itemToAdd = new LandscapePictureItem(width, height, file.FullName)
                    { DateTaken = dateTaken };
                }

                itemToAdd.Label = file.Name;
                pictureItems.Add(itemToAdd);
            }

            return pictureItems;
        }
    }
}

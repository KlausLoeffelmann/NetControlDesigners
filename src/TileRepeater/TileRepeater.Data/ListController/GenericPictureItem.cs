using MetadataExtractor;
using MetadataExtractor.Formats.Jpeg;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace TileRepeater.Data.ListController
{
    public class GenericPictureItem : GenericTemplateItem
    {
        private Tag? _metaDataTag;
        private string? _filename;
        private int _width;
        private int _height;
        private DateTime? _dateTaken;

        private const string DefaultFileSearchPattern = "*.bmp|*.png|*.jpg|*.jpeg|*.gif|*.ico|*.tif|*.tiff|*.raw|*.arw|*.heic|*.nef|*.cr2";
        private static readonly string[] s_defaultFileSearchPattern;

        static GenericPictureItem()
        {
            s_defaultFileSearchPattern = DefaultFileSearchPattern.Replace("*", "").Split('|');
        }

        public GenericPictureItem() : base(null)
        {
        }

        public string? Filename
        {
            get => _filename;
            set => SetProperty(ref _filename, value);
        }

        public Tag? MetadataTag
        {
            get => _metaDataTag;
            set => SetProperty(ref _metaDataTag, value);
        }

        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        public DateTime? DateTaken
        {
            get => _dateTaken;
            set => SetProperty(ref _dateTaken, value);
        }

        public static ObservableCollection<GenericTemplateItem>? GetPicsFromFolder(string filePath, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            DirectoryInfo directoryInfo = new(filePath);
            ObservableCollection<GenericTemplateItem>? pictureItems = new();

            var filesInPath = directoryInfo.GetFiles("*.*", searchOption)
                .Where(file => s_defaultFileSearchPattern.Any(extension => extension == file.Extension))
                .ToList();

            foreach (var file in filesInPath)
            {
                var directories = ImageMetadataReader.ReadMetadata(file.FullName);
                var jpegDir = directories.OfType<JpegDirectory>().FirstOrDefault();

                // For simplicity, we concentrate of JPEGs for now.
                if (jpegDir is null) continue;

                var height = jpegDir.GetImageHeight();
                var width = jpegDir.GetImageWidth();
                var dateTaken = file.CreationTime;

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
                Debug.Print($"{file.Name} - {height}");
            }

            return pictureItems;
        }
    }
}

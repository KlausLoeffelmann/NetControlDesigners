using TileRepeater.Data.ListController;

namespace TileRepeaterDemo
{
    public partial class TileRepeaterTestForm : Form
    {
        private List<GenericTemplateItem>? pictureDataSource;
        private string? _pathToPictures;

        public TileRepeaterTestForm()
        {
            InitializeComponent();
        }

        private void SetPathToImageFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new()
            {
                Description = "Open Path to Images",
                UseDescriptionForTitle = true
            };

            var dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                _pathToPictures = folderBrowserDialog.SelectedPath;
                _imagePathStatusLabel.Text = _pathToPictures;
                pictureDataSource = GenericPictureItem.GetPictureTemplateItemsFromFolder(_pathToPictures);
                _pictureTileRepeater.DataSource = pictureDataSource;
            }
        }
    }
}

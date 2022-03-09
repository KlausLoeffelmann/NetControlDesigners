using TileRepeater.Data.ListController;

namespace TileRepeaterDemo
{
    public partial class TileRepeaterTestForm : Form
    {
        public TileRepeaterTestForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = GenericPictureItem.GetPicsFromFolder("C:\\Users\\klaus\\OneDrive\\OneDrive camera roll\\2013");
        }
    }
}
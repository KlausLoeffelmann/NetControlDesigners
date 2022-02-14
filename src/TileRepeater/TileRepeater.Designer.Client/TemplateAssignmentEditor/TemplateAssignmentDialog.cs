using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TileRepeater.Designer.Client
{
    internal partial class TemplateAssignmentDialog : Form
    {
        private readonly Font _boldFont;

        public const string DialogFont = nameof(DialogFont);

        public TemplateAssignmentDialog(
            IServiceProvider serviceProvider,
            TemplateAssignmentViewModelClient viewModel)
        {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            ViewModelClient = viewModel ?? throw new ArgumentNullException(nameof(viewModel));

            InitializeComponent();
            PopulateContent();

            IUIService uiService = ServiceProvider.GetRequiredService<IUIService>();
            Font = (Font)uiService.Styles[DialogFont];
            _boldFont = new Font(this.Font, FontStyle.Bold);
        }

        private void PopulateContent()
        {
            _selectTileTemplateControlComboBox.DataSource =
                ViewModelClient.TileServerTypes
                    .Select((tileTypeItem) => new ListBoxTypeItem(tileTypeItem))
                    .ToList();

            _selectBindingSourceTemplateTypeListBox.DataSource =
                ViewModelClient.TemplateServerTypes
                    .Select((tileTypeItem) => new ListBoxTypeItem(tileTypeItem))
                    .ToList();
        }

        public IServiceProvider ServiceProvider { get; }
        public TemplateAssignmentViewModelClient ViewModelClient { get; set; }
        public ITypeDescriptorContext? Context { get; set; }
        public IDesignerHost? Host { get; set; }
        public bool IsDirty { get; private set; }
    }
}

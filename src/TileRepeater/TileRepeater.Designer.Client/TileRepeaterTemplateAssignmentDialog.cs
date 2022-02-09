using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TileRepeater.Designer.Client
{
    internal partial class TileRepeaterTemplateAssignmentDialog : Form
    {
        private readonly Font _boldFont;

        public const string DialogFont = nameof(DialogFont);

        public TileRepeaterTemplateAssignmentDialog(
            IServiceProvider serviceProvider,
            TileRepeaterTemplateAssignmentViewModelClient viewModel)
        {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            ViewModelClient = viewModel ?? throw new ArgumentNullException(nameof(viewModel));

            InitializeComponent();

            IUIService uiService = ServiceProvider.GetRequiredService<IUIService>();
            Font = (Font)uiService.Styles[DialogFont];
            _boldFont = new Font(this.Font, FontStyle.Bold);
        }

        public IServiceProvider ServiceProvider { get; }

        public TileRepeaterTemplateAssignmentViewModelClient ViewModelClient { get; set; }
        public ITypeDescriptorContext? Context { get; set; }
        public IDesignerHost? Host { get; set; }
        public bool IsDirty { get; private set; }
    }
}

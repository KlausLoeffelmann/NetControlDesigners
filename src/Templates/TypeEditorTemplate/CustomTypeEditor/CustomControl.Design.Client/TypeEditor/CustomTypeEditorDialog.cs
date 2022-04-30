using CustomControl.ClientServerCommunication.DataTransport;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;

namespace CustomControl.Designer.Client
{
    internal partial class CustomTypeEditorDialog : Form
    {
        public CustomTypeEditorDialog(IServiceProvider provider, CustomTypeEditorViewModelClient viewModelClient)
        {
            Provider = provider;
            ViewModelClient = viewModelClient;
            
            InitializeComponent();

            _customEnumValueListBox.Items.AddRange(
                Enum.GetValues(typeof(CustomEnumClientVersion))
                .Cast<string>()
                .ToArray());

            _customEnumValueListBox.SelectedIndex = 0;
        }

        public IServiceProvider? Provider { get; }
        public CustomTypeEditorViewModelClient? ViewModelClient { get; set; }
        public ITypeDescriptorContext? Context { get; set; }
        public IDesignerHost? Host { get; set; }

        public CustomPropertyStoreData? PropertyStoreData
        {
            get => new(
                _requiredIdTextBox.Text,
                _dateCreated.Value,
                _listOfStringTextBox.Lines,
                (byte)_customEnumValueListBox.SelectedIndex);

            set
            {
                _requiredIdTextBox.Text = value?.SomeMustHaveId;
                _dateCreated.Value = value?.DateCreated ?? DateTime.Now.Date;
                _listOfStringTextBox.Lines = value?.ListOfStrings;
                _customEnumValueListBox.SelectedIndex = value?.CustomEnumValue ?? 0;
            }
        }
    }
}

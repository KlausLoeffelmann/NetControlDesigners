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
        CustomPropertyStoreData? _propertyStore;

        public CustomTypeEditorDialog(IServiceProvider provider, CustomTypeEditorViewModelClient viewModelClient)
        {
            Provider = provider;
            ViewModelClient = viewModelClient;

            InitializeComponent();

            _customEnumValueListBox.Items.AddRange(
                Enum.GetValues(typeof(CustomEnumClientVersion))
                .Cast<CustomEnumClientVersion>()
                .Select(enumValue => enumValue.ToString())
                .ToArray());

            _customEnumValueListBox.SelectedIndex = 0;
        }

        public IServiceProvider? Provider { get; }
        public CustomTypeEditorViewModelClient? ViewModelClient { get; set; }
        public ITypeDescriptorContext? Context { get; set; }
        public IDesignerHost? Host { get; set; }

        public CustomPropertyStoreData? PropertyStoreData
        {
            get => _propertyStore;

            set
            {
                _requiredIdTextBox.Text = value?.SomeMustHaveId;
                _dateCreated.Value = value?.DateCreated ?? DateTime.Now.Date;
                _listOfStringTextBox.Lines = value?.ListOfStrings;
                _customEnumValueListBox.SelectedIndex = value?.CustomEnumValue ?? 0;
            }
        }

        // In this dialog, the OK button is set as the Form's accept button,
        // the Cancel button is set as the Form's Cancel button.
        // The OK button's dialog result is set to OK.
        // Now, assigning a DialogResult value to a modal Form's DialogResult property,
        // automatically also causes OnValidating to run, and if its CancelEventArgs
        // are not set to Cancel, the modal Form closes automatically.
        // There is no need to write any code for that, expect the validating.
        // We don't need to handle the OK click event, nor Cancel click.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (DialogResult == DialogResult.OK)
            {
                ViewModelClient?.ExecuteOkCommand();
            }
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_requiredIdTextBox.Text))
                {
                    _errorProvider.SetError(_requiredIdTextBox, "Please enter some valid ID value (alphanumerical).");
                    e.Cancel = true;
                    return;
                }

                _errorProvider.SetError(_requiredIdTextBox, null);


                if (_dateCreated.Value > DateTime.Now)
                {
                    _errorProvider.SetError(_requiredIdTextBox, "Date can't be in the future.");
                    e.Cancel = true;
                    return;
                }

                _errorProvider.SetError(_requiredIdTextBox, null);

                _propertyStore = new(
                    _requiredIdTextBox.Text,
                    _dateCreated.Value,
                    _listOfStringTextBox.Lines,
                    (byte)_customEnumValueListBox.SelectedIndex);
            }
            finally
            {
                if (e.Cancel)
                {
                    _propertyStore = null;
                }
            }
        }
    }
}

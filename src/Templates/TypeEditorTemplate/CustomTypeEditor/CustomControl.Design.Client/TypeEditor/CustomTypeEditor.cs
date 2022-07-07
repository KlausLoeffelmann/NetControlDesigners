using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CustomControl.Designer.Client
{
    public class CustomTypeEditor : UITypeEditor
    {
        CustomTypeEditorDialog? _customTypeEditorDialog;

        public override object? EditValue(
            ITypeDescriptorContext context,
            IServiceProvider provider,
            object? value)
        {
            if (provider is null)
            {
                return value;
            }

            var editorService = provider.GetRequiredService<IWindowsFormsEditorService>();
            var designerHost = provider.GetRequiredService<IDesignerHost>();

            // value now holds the proxy of the CustomPropertyStore object the user wants to edit.
            var viewModelClient = CustomTypeEditorViewModelClient.Create(provider, value);

            _customTypeEditorDialog ??= new CustomTypeEditorDialog(provider, viewModelClient);
            _customTypeEditorDialog.Context = context;
            _customTypeEditorDialog.Host = designerHost;

            var dialogResult = editorService.ShowDialog(_customTypeEditorDialog);
            if (dialogResult == DialogResult.OK)
            {
                // By now, the UI of the Editor has instructed its (client-side) ViewModel
                // to run the value-updating code: It passes the entered data to the server, which
                // in turn updates the server-side ViewModel. The ViewModelClient's PropertyStore
                // property retrieves the value (as a proxy object) directly from the server-side
                // ViewModel.
                value = viewModelClient.PropertyStore;
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            => UITypeEditorEditStyle.Modal;
    }
}

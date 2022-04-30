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

            // value now holds the proxy of the TemplateAssignment object which is edited.
            var viewModelClient = CustomTypeEditorViewModelClient.Create(provider, value);

            _customTypeEditorDialog ??= new CustomTypeEditorDialog(provider, viewModelClient);
            _customTypeEditorDialog.Context = context;
            _customTypeEditorDialog.Host = designerHost;
            _customTypeEditorDialog.ViewModelClient = viewModelClient;

            // We don't need to do anything, since the Dialog has already set the
            // property server-side.
            var dialogResult = editorService.ShowDialog(_customTypeEditorDialog);
            if (dialogResult == DialogResult.OK)
            {
                value = viewModelClient.PropertyStoreData;
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            => UITypeEditorEditStyle.Modal;
    }
}

using Microsoft.DotNet.DesignTools.Client.Proxies;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TileRepeater.Designer.Client
{
    internal class TemplateAssignmentEditor : UITypeEditor
    {
        private TemplateAssignmentDialog? _templateAssignmentDialog;

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider is null)
            {
                return value;
            }

            var editorService = provider.GetRequiredService<IWindowsFormsEditorService>();
            var designerHost = provider.GetRequiredService<IDesignerHost>();

            var viewModelClient = TemplateAssignmentViewModelClient.Create(provider, value);

            _templateAssignmentDialog ??= new TemplateAssignmentDialog(provider, viewModelClient);
            _templateAssignmentDialog.Context = context;
            _templateAssignmentDialog.Host = designerHost;
            _templateAssignmentDialog.ViewModelClient = viewModelClient;

            var result = editorService.ShowDialog(_templateAssignmentDialog);
            if (result == DialogResult.OK)
            {

            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            => UITypeEditorEditStyle.Modal;
    }
}


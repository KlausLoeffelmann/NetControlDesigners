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

            // When the User sets up a series of Bindings for DataSources for which BindingSource components 
            // have not been created yet, then every first usage of a project datasource _causes_ a BindingSource 
            // component to be created. Should the user then cancel the Dialog, those creations have to be rolled back.
            using DesignerTransaction transaction = designerHost.CreateTransaction();

            editorService.ShowDialog(_templateAssignmentDialog);

            if (_templateAssignmentDialog.IsDirty)
            {
                Debug.Assert(context.Instance is ObjectProxy objectProxy
                    && objectProxy.TypeIdentity.FullName == "System.Windows.Forms.ControlBindingsCollection");

                // Since the bindings may have changed, the properties listed in the 
                // properties window need to be refreshed.
                //TypeDescriptor.Refresh(((ObjectProxy)context.Instance).
                //    GetPropertyValue<IComponent>(nameof(ControlBindingsCollection.BindableComponent)));

                transaction.Commit();
            }
            else
            {
                transaction.Cancel();
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            => UITypeEditorEditStyle.Modal;
    }
}


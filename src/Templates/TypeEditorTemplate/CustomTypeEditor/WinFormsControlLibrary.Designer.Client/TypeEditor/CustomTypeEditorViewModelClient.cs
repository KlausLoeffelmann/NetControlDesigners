using Microsoft.DotNet.DesignTools.Client.Proxies;
using Microsoft.DotNet.DesignTools.Client.Views;
using WinForms.Tiles.Designer.Protocol;

namespace WinFormsControlLibrary.Designer.Client.TypeEditor
{
    internal class CustomTypeEditorViewModelClient : ViewModelClient
    {
        [ExportViewModelClientFactory(ViewModelNames.CustomTypeEditorViewModel)]
        private class Factory : ViewModelClientFactory<CustomTypeEditorViewModelClient>
        {
            protected override CustomTypeEditorViewModelClient CreateViewModelClient(ObjectProxy? viewModel)
                => new(viewModel);
        }

        public CustomTypeEditorViewModelClient(ObjectProxy? viewModel) : base(viewModel)
        {
        }
    }
}

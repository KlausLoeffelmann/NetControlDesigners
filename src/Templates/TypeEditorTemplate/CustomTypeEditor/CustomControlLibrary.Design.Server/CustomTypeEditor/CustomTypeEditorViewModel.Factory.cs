using CustomControlLibrary.ClientServerCommunication;
using Microsoft.DotNet.DesignTools.ViewModels;
using System;

namespace CustomControlLibrary.Designer.Server
{
    internal partial class CustomTypeEditorViewModel
    {
        /// <summary>
        /// Factory class which generates the CustomTypeEditorViewModel.
        /// </summary>
        [ExportViewModelFactory(ViewModelNames.CustomTypeEditorViewModel)]
        private class Factory : ViewModelFactory<CustomTypeEditorViewModel>
        {
            protected override CustomTypeEditorViewModel CreateViewModel(IServiceProvider provider)
                => new(provider);
        }
    }
}

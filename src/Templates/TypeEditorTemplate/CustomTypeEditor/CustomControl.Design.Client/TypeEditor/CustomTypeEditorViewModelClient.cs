using CustomControl.ClientServerCommunication;
using CustomControl.ClientServerCommunication.DataTransport;
using CustomControl.ClientServerCommunication.Endpoints;
using Microsoft.DotNet.DesignTools.Client;
using Microsoft.DotNet.DesignTools.Client.Proxies;
using Microsoft.DotNet.DesignTools.Client.Views;
using System;
using System.Diagnostics;

namespace CustomControl.Designer.Client
{
    internal class CustomTypeEditorViewModelClient : ViewModelClient
    {
        CustomPropertyStoreData? _propertyStoreData;

        [ExportViewModelClientFactory(ViewModelNames.CustomTypeEditorViewModel)]
        private class Factory : ViewModelClientFactory<CustomTypeEditorViewModelClient>
        {
            protected override CustomTypeEditorViewModelClient CreateViewModelClient(ObjectProxy? viewModel)
                => new(viewModel);
        }

        public CustomTypeEditorViewModelClient(ObjectProxy? viewModel) : base(viewModel)
        {
            if (viewModel is null)
            {
                throw new NullReferenceException(nameof(viewModel));
            }
        }

        /// <summary>
        ///  Creates an instance of this ViewModelClient and initializes it with the ServerTypes 
        ///  from which the Data Sources can be generated.
        /// </summary>
        /// <param name="session">
        ///  The designer session to create the ViewModelClient server side.
        /// </param>
        /// <returns>
        ///  The ViewModelClient for controlling the NewObjectDataSource dialog.
        /// </returns>
        public static CustomTypeEditorViewModelClient Create(
            IServiceProvider provider,
            object? customPropertyStoreProxy)
        {
            var session = provider.GetRequiredService<DesignerSession>();
            var client = provider.GetRequiredService<IDesignToolsClient>();

            var response = client.SendRequest<CreateCustomTypeEditorViewModelResponse>(
                new CreateCustomTypeEditorViewModelRequest(
                    session.Id,
                    customPropertyStoreProxy));

            var viewModel = (ObjectProxy)response.ViewModel!;

            var clientViewModel = provider.CreateViewModelClient<CustomTypeEditorViewModelClient>(viewModel);
            clientViewModel.Initialize(response.PropertyStoreData);

            return clientViewModel;
        }

        private void Initialize(CustomPropertyStoreData? propertyStoreData)
        {
            PropertyStoreData = propertyStoreData;
        }

        internal void ExecuteOkCommand()
        {
            if (Debugger.IsAttached)
                Debugger.Break();

            Client!.SendRequest(new CustomTypeEditorOKClickRequest(ViewModelProxy, PropertyStoreData));
        }

        public CustomPropertyStoreData? PropertyStoreData { get; set; }
    }
}

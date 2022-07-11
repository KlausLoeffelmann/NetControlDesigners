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
    /// <summary>
    /// Client-side implementation of the ViewModel to control the TypeEditor UI.
    /// </summary>
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
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }

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

        // Executes the OK Command when the user has clicked the OK Button:
        // It takes the _propertyStoreData, sends it to the Server along the the ViewModelProxy,
        // so the Server can access it. The Server then creates the actual PropertyStore object 
        // from the passed Data (remember: the client cannot do that, since it doesn't know about the
        // CustomPropertyStore type which only exists server-side!), and stores it in its PropertyStore property.
        // Now, when the TypeEditor continues with the codeflow in EditValue, it get's the updated Value to return to
        // the property grid from this client-side ViewModel, namely from it's PropertyStore property. This property
        // in turn uses the ViewModelProxy to call the server and get the Proxy of the Value from the server-side
        // ViewModel, which our OKClickHandler has _just_ updates server-side and is therefore up-to-date!
        internal void ExecuteOkCommand()
        {
            if (Debugger.IsAttached)
                Debugger.Break();

            Client!.SendRequest(new CustomTypeEditorOKClickRequest(ViewModelProxy, PropertyStoreData));
        }

        // Get, when the TypeEditor's UI need to be update its controls to show the content of the custom property.
        // Set, when the validation of the Data which was just entered by the User passed.
        internal CustomPropertyStoreData? PropertyStoreData { get; set; }

        /// <summary>
        /// Returns the Proxy of the server-side ViewModel's PropertyStore property.
        /// </summary>
        public Object? PropertyStore

            // See also comment on ExecuteOKCommand.
            => ViewModelProxy!.GetPropertyValue(nameof(PropertyStore));
    }
}

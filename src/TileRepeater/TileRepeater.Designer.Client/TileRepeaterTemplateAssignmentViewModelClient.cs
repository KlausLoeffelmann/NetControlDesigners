using Microsoft.DotNet.DesignTools.Client;
using Microsoft.DotNet.DesignTools.Client.Proxies;
using Microsoft.DotNet.DesignTools.Client.Views;
using System;
using System.Collections.Generic;
using TileRepeater.ClientServerProtocol;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace TileRepeater.Designer.Client
{
    internal partial class TileRepeaterTemplateAssignmentViewModelClient : ViewModelClient
    {
        private TileRepeaterTemplateAssignmentViewModelClient(ObjectProxy? viewModel)
            : base(viewModel)
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
        public static TileRepeaterTemplateAssignmentViewModelClient Create(
            IServiceProvider provider,
            object tileRepeaterTemplateAssignmentProxy)
        {
            var session = provider.GetRequiredService<DesignerSession>();
            var client = provider.GetRequiredService<IDesignToolsClient>();

            var createViewModelEndpoint = client.Protocol.GetEndpoint<CreateTemplateTypesViewModelEndpoint>().GetSender(client);
            var response = createViewModelEndpoint.SendRequest(new CreateTemplateTypesViewModelRequest(session.Id, tileRepeaterTemplateAssignmentProxy));
            var viewModel = (ObjectProxy)response.ViewModel!;
            var clientViewModel = provider.CreateViewModelClient<TileRepeaterTemplateAssignmentViewModelClient>(viewModel);

            return clientViewModel;
        }

        private void Initialize(TypeInfoData[] serverTypes)
        {
            ServerTypes = serverTypes;
        }

        /// <summary>
        ///  Contains the types which have been discovered by the Server Process.
        /// </summary>
        public TypeInfoData[] ServerTypes { get; private set; } = null!;

        internal void ExecuteOkCommand(
            List<TypeInfoData> newTypes,
            List<TypeInfoData> typesToDelete)
        {
        }
    }
}
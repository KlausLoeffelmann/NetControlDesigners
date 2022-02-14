using Microsoft.DotNet.DesignTools.Client;
using Microsoft.DotNet.DesignTools.Client.Proxies;
using Microsoft.DotNet.DesignTools.Client.Views;
using System;
using System.Collections.Generic;
using TileRepeater.ClientServerProtocol;
using WinForms.Tiles.Designer.Protocol;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace TileRepeater.Designer.Client
{
    internal partial class TemplateAssignmentViewModelClient : ViewModelClient
    {
        [ExportViewModelClientFactory(ViewModelNames.TemplateAssignmentViewModel)]
        private class Factory : ViewModelClientFactory<TemplateAssignmentViewModelClient>
        {
            protected override TemplateAssignmentViewModelClient CreateViewModelClient(ObjectProxy? viewModel)
                => new(viewModel);
        }

        private TemplateAssignmentViewModelClient(ObjectProxy? viewModel)
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
        public static TemplateAssignmentViewModelClient Create(
            IServiceProvider provider,
            object tileRepeaterTemplateAssignmentProxy)
        {
            var session = provider.GetRequiredService<DesignerSession>();
            var client = provider.GetRequiredService<IDesignToolsClient>();

            var createViewModelEndpoint = client.Protocol.GetEndpoint<CreateTemplateAssignmentViewModelEndpoint>().GetSender(client);

            var response = createViewModelEndpoint.SendRequest(new CreateTemplateAssignmentViewModelRequest(session.Id, tileRepeaterTemplateAssignmentProxy));
            var viewModel = (ObjectProxy)response.ViewModel!;

            var clientViewModel = provider.CreateViewModelClient<TemplateAssignmentViewModelClient>(viewModel);
            clientViewModel.Initialize(response.TemplateServerTypes, response.TileServerTypes);

            return clientViewModel;
        }

        private void Initialize(TypeInfoData[] templateServerTypes, TypeInfoData[] tileServerTypes)
        {
            TemplateServerTypes = templateServerTypes;
            TileServerTypes = tileServerTypes;
        }

        /// <summary>
        ///  Contains the types which have been discovered by the Server Process.
        /// </summary>
        public TypeInfoData[] TemplateServerTypes { get; private set; } = null!;

        /// <summary>
        ///  Contains the tile-based types which have been discovered by the Server Process.
        /// </summary>
        public TypeInfoData[] TileServerTypes { get; private set; } = null!;


        internal void ExecuteOkCommand(
            List<TypeInfoData> newTypes,
            List<TypeInfoData> typesToDelete)
        {
        }
    }
}

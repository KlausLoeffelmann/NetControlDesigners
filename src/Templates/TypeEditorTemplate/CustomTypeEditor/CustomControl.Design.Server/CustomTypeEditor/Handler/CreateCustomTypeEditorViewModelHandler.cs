using CustomControl.ClientServerCommunication.Endpoints;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace CustomControl.Designer.Server.Handlers
{
    [ExportRequestHandler(EndpointNames.CreateCustomTypeEditorViewModel)]
    internal class CreateCustomTypeEditorViewModelHandler 
        : RequestHandler<CreateCustomTypeEditorViewModelRequest, CreateCustomTypeEditorViewModelResponse>
    {
        public override CreateCustomTypeEditorViewModelResponse HandleRequest(CreateCustomTypeEditorViewModelRequest request)
        {
            var designerHost = GetDesignerHost(request.SessionId);

            var viewModel = CreateViewModel<CustomTypeEditorViewModel>(designerHost);

            return viewModel.Initialize(request.TileRepeaterProxy!);
        }
    }
}

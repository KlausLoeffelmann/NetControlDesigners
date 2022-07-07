using CustomControl.ClientServerCommunication.Endpoints;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace CustomControl.Designer.Server.Handlers
{
    /// <summary>
    /// The handler for the CreateCustomTypeEditorViewModel endpointer. Actually creates the ViewModel and returns
    /// it via its request class.
    /// </summary>
    [ExportRequestHandler(EndpointNames.CreateCustomTypeEditorViewModel)]
    internal class CreateCustomTypeEditorViewModelHandler 
        : RequestHandler<CreateCustomTypeEditorViewModelRequest, CreateCustomTypeEditorViewModelResponse>
    {
        public override CreateCustomTypeEditorViewModelResponse HandleRequest(CreateCustomTypeEditorViewModelRequest request)
        {
            // Get's the respective DesignerHost over the sessionId, which has been passed by the client.
            var designerHost = GetDesignerHost(request.SessionId);

            // Creates the ViewModel, and passes the DesignerHost.
            var viewModel = CreateViewModel<CustomTypeEditorViewModel>(designerHost);
            
            // The ViewModel then initializes and then wraps itself into the response class
            // so it can be returned to the client.
            return viewModel.Initialize(request.CustomControlProxy!);
        }
    }
}

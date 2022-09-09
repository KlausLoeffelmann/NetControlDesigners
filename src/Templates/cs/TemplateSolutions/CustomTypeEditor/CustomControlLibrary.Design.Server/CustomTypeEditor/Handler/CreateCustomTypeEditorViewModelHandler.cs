using CustomControlLibrary.ClientServerCommunication;
using CustomControlLibrary.ClientServerCommunication.Endpoints;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace CustomControlLibrary.Designer.Server.Handlers
{
    /// <summary>
    /// The handler for the CreateCustomTypeEditorViewModel endpoint. 
    /// This actually creates the ViewModel and returns it via its request class.
    /// </summary>
    [ExportRequestHandler(EndpointNames.CreateCustomTypeEditorViewModel)]
    internal class CreateCustomTypeEditorViewModelHandler 
        : RequestHandler<CreateCustomTypeEditorViewModelRequest, CreateCustomTypeEditorViewModelResponse>
    {
        public override CreateCustomTypeEditorViewModelResponse HandleRequest(CreateCustomTypeEditorViewModelRequest request)
        {
            // Gets the respective DesignerHost of the sessionId, which has been passed by the client.
            var designerHost = GetDesignerHost(request.SessionId);

            // Creates the ViewModel and passes the DesignerHost.
            var viewModel = CreateViewModel<CustomTypeEditorViewModel>(designerHost);
            
            // The ViewModel then initializes and wraps itself into the response class
            // so it can be returned to the client.
            return viewModel.Initialize(request.CustomControlProxy!);
        }
    }
}

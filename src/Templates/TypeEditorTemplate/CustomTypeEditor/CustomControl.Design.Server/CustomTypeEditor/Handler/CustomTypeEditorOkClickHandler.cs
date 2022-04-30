using CustomControl.ClientServerCommunication.Endpoints;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace CustomControl.Designer.Server.Handlers
{
    [ExportRequestHandler(EndpointNames.CustomTypeEditorEditorOKClick)]
    internal class CustomTypeEditorOkClickHandler : RequestHandler<CustomTypeEditorOKClickRequest, CustomTypeEditorOKClickResponse>
    {
        public override CustomTypeEditorOKClickResponse HandleRequest(CustomTypeEditorOKClickRequest request)
        {
            var viewModel = (CustomTypeEditorViewModel)request.ViewModel;
            viewModel.OKClick();

            return CustomTypeEditorOKClickResponse.Empty;
        }
    }
}

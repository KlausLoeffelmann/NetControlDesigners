using CustomControl.ClientServerCommunication.Endpoints;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System.Linq;

namespace CustomControl.Designer.Server.Handlers
{
    [ExportRequestHandler(EndpointNames.CustomTypeEditorEditorOKClick)]
    internal class CustomTypeEditorOkClickHandler : RequestHandler<CustomTypeEditorOKClickRequest, CustomTypeEditorOKClickResponse>
    {
        public override CustomTypeEditorOKClickResponse HandleRequest(CustomTypeEditorOKClickRequest request)
        {
            // We're getting the ViewModel passed via the endpoint's request class.
            var viewModel = (CustomTypeEditorViewModel)request.ViewModel;

            // Data is complete: we're performing the OKClick server-side.
            viewModel.OKClick(request.PropertyStoreData);

            // Nothing really to return, just honoring the conventions.
            return CustomTypeEditorOKClickResponse.Empty;
        }
    }
}

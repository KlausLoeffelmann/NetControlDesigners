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
            var viewModel = (CustomTypeEditorViewModel)request.ViewModel;
            viewModel.PropertyStore = new(
                request.PropertyStoreData.SomeMustHaveId,
                request.PropertyStoreData.DateCreated,
                request.PropertyStoreData.ListOfStrings?.ToList(),
                (CustomEnum) request.PropertyStoreData.CustomEnumValue);

            viewModel.OKClick();

            return CustomTypeEditorOKClickResponse.Empty;
        }
    }
}

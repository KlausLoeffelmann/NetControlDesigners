using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace TileRepeater.Designer.Server.TemplateAssignmentCollectionEditor.Handler
{
    [ExportRequestHandler(EndpointNames.AddTemplateAssignmentItem)]
    internal class AddPersonItemHandler : RequestHandler<AddTemplateAssignmentItemRequest, AddTemplateAssignmentItemResponse>
    {
        public override AddTemplateAssignmentItemResponse HandleRequest(AddTemplateAssignmentItemRequest request)
        {
            var viewModel = (TemplateAssignmentCollectionEditor.ViewModel)request.ViewModel;
            var item = viewModel.AddItem();

            return new AddTemplateAssignmentItemResponse(item);
        }
    }
}

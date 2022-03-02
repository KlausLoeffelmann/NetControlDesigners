using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace TileRepeater.Designer.Server.TemplateAssignmentCollectionEditor.Handler
{
    [ExportRequestHandler(EndpointNames.GetUpdatedTemplateAssignmentItem)]
    internal class GetUpdatedPersonItemHandler : RequestHandler<GetUpdatedTemplateAssignmentItemRequest, GetUpdatedTemplateAssignmentItemResponse>
    {
        public override GetUpdatedTemplateAssignmentItemResponse HandleRequest(GetUpdatedTemplateAssignmentItemRequest request)
        {
            var viewModel = (TemplateAssignmentCollectionEditor.ViewModel)request.ViewModel;
            var item = viewModel.GetItem(request.Index);

            return new GetUpdatedTemplateAssignmentItemResponse(item);
        }
    }
}

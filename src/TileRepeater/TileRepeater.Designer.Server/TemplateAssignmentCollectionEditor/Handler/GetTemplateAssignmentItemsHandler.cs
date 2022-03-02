using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace TileRepeater.Designer.Server.TemplateAssignmentCollectionEditor.Handler
{
    [ExportRequestHandler(EndpointNames.GetTemplateAssignmentItems)]
    internal class GetTemplateAssignmentItemsHandler 
        : RequestHandler<GetTemplateAssignmentItemsRequest, GetTemplateAssignmentItemsResponse>
    {
        public override GetTemplateAssignmentItemsResponse HandleRequest(GetTemplateAssignmentItemsRequest request)
        {
            var viewModel = (TemplateAssignmentCollectionEditor.ViewModel)request.ViewModel;
            var items = viewModel.GetItems();

            return new GetTemplateAssignmentItemsResponse(items);
        }
    }
}

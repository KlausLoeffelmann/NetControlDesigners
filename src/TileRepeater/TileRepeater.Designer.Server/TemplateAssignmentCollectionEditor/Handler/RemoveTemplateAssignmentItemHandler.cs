using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using TileRepeater.Designer.Server.TemplateAssignmentCollectionEditor;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace Server.Handlers
{
    [ExportRequestHandler(EndpointNames.RemoveTemplateAssignmentItem)]
    internal class RemovePersonItemHandler : RequestHandler<RemoveTemplateAssignmentItemRequest, RemoveTemplateAssignmentItemResponse>
    {
        public override RemoveTemplateAssignmentItemResponse HandleRequest(RemoveTemplateAssignmentItemRequest request)
        {
            var viewModel = (TemplateAssignmentCollectionEditor.ViewModel)request.ViewModel;
            viewModel.RemoveItem(request.Index);

            return RemoveTemplateAssignmentItemResponse.Empty;
        }
    }
}

using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Server.TemplateAssignmentCollectionEditor.Handler
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

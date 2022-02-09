using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace TileRepeater.Designer.Server.Handlers
{
    [ExportRequestHandler(EndpointNames.CreateTemplateTypesViewModel)]
    internal class CreateTemplateTypesViewModelHandler 
        : RequestHandler<CreateTemplateTypesViewModelRequest, CreateTemplateTypesViewModelResponse>
    {
        public override CreateTemplateTypesViewModelResponse HandleRequest(CreateTemplateTypesViewModelRequest request)
        {
            var designerHost = GetDesignerHost(request.SessionId);

            var viewModel = CreateViewModel<TileRepeaterTemplateAssignmentViewModel>(designerHost);

            return viewModel.Initialize();
        }
    }
}

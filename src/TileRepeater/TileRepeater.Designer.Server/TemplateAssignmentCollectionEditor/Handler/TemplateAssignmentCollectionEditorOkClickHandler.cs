using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Server.TemplateAssignmentCollectionEditor.Handler
{
    [ExportRequestHandler(EndpointNames.TemplateAssignmentCollectionEditorOKClick)]
    internal class TemplateAssignmentCollectionEditorOkClickHandler : RequestHandler<TemplateAssignmentCollectionEditorOKClickRequest, TemplateAssignmentCollectionEditorOKClickResponse>
    {
        public override TemplateAssignmentCollectionEditorOKClickResponse HandleRequest(TemplateAssignmentCollectionEditorOKClickRequest request)
        {
            var viewModel = (TemplateAssignmentCollectionEditor.ViewModel)request.ServerViewModel;
            viewModel.OKClick();

            return TemplateAssignmentCollectionEditorOKClickResponse.Empty;
        }
    }
}

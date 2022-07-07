using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System.Diagnostics;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Server.TemplateAssignmentCollectionEditor.Handler
{
    [ExportRequestHandler(EndpointNames.TemplateAssignmentCollectionEditorOKClick)]
    internal class TemplateAssignmentCollectionEditorOkClickHandler : RequestHandler<TemplateAssignmentCollectionEditorOKClickRequest, TemplateAssignmentCollectionEditorOKClickResponse>
    {
        public override TemplateAssignmentCollectionEditorOKClickResponse HandleRequest(TemplateAssignmentCollectionEditorOKClickRequest request)
        {
            if (Debugger.IsAttached) 
                Debugger.Break();
            
            var viewModel = (TemplateAssignmentCollectionEditor.ViewModel)request.ServerViewModel;
            viewModel.OKClick();

            return TemplateAssignmentCollectionEditorOKClickResponse.Empty;
        }
    }
}

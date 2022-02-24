using System.Composition;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    [Shared]
    [ExportEndpoint]
    public class TemplateAssignmentEditorOKClickEndpoint : Endpoint<TemplateAssignmentEditorOKClickRequest, OKClickResponse>
    {
        public override string Name => EndpointNames.TemplateAssignmentEditorOKClick;

        protected override TemplateAssignmentEditorOKClickRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override OKClickResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}

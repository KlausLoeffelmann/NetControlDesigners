using System.Composition;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    [Shared]
    [ExportEndpoint]
    public class TemplateAssignmentCollectionEditorOKClickEndpoint : Endpoint<TemplateAssignmentCollectionEditorOKClickRequest, TemplateAssignmentCollectionEditorOKClickResponse>
    {
        public override string Name => EndpointNames.TemplateAssignmentCollectionEditorOKClick;

        protected override TemplateAssignmentCollectionEditorOKClickRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override TemplateAssignmentCollectionEditorOKClickResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}

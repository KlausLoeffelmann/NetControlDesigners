using System.Composition;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    [Shared]
    [ExportEndpoint]
    public class RemoveTemplateAssignmentItemEndpoint : Endpoint<RemoveTemplateAssignmentItemRequest, RemoveTemplateAssignmentItemResponse>
    {
        public override string Name => EndpointNames.RemoveTemplateAssignmentItem;

        protected override RemoveTemplateAssignmentItemRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override RemoveTemplateAssignmentItemResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}

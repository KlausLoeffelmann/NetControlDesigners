using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System.Composition;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    [Shared]
    [ExportEndpoint]
    public class GetUpdatedTemplateAssignmentItemEndpoint : Endpoint<GetUpdatedTemplateAssignmentItemRequest, GetUpdatedTemplateAssignmentItemResponse>
    {
        public override string Name => EndpointNames.GetUpdatedTemplateAssignmentItem;

        protected override GetUpdatedTemplateAssignmentItemRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override GetUpdatedTemplateAssignmentItemResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}

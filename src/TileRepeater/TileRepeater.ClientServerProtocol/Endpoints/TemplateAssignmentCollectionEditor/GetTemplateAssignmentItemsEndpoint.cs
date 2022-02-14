using System.Composition;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    [Shared]
    [ExportEndpoint]
    public class GetTemplateAssignmentItemsEndpoint : Endpoint<GetTemplateAssignmentItemsRequest, GetTemplateAssignmentItemsResponse>
    {
        public override string Name => EndpointNames.GetTemplateAssignmentItems;

        protected override GetTemplateAssignmentItemsRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override GetTemplateAssignmentItemsResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}

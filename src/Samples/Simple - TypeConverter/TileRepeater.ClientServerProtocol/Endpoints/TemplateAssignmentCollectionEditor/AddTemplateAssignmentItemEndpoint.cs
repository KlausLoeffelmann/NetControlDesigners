using System.Composition;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    [Shared]
    [ExportEndpoint]
    public class AddTemplateAssignmentItemEndpoint : Endpoint<AddTemplateAssignmentItemRequest, AddTemplateAssignmentItemResponse>
    {
        public override string Name => EndpointNames.AddTemplateAssignmentItem;

        protected override AddTemplateAssignmentItemRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override AddTemplateAssignmentItemResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}

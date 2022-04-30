using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System.Composition;

namespace CustomControl.ClientServerCommunication.Endpoints
{
    [Shared]
    [ExportEndpoint]
    public class CustomTypeEditorOKClickEndpoint : Endpoint<CustomTypeEditorOKClickRequest, CustomTypeEditorOKClickResponse>
    {
        public override string Name => EndpointNames.CustomTypeEditorEditorOKClick;

        protected override CustomTypeEditorOKClickRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override CustomTypeEditorOKClickResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}

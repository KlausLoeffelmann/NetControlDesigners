using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System.Composition;

namespace CustomControl.ClientServerCommunication.Endpoints
{
    [Shared]
    [ExportEndpoint]
    public class CreateCustomTypeEditorViewModelEndpoint 
        : Endpoint<CreateCustomTypeEditorViewModelRequest, CreateCustomTypeEditorViewModelResponse>
    {
        public override string Name => EndpointNames.CreateCustomTypeEditorViewModel;

        protected override CreateCustomTypeEditorViewModelRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override CreateCustomTypeEditorViewModelResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}

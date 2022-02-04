using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System.Composition;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    [Shared]
    [ExportEndpoint]
    public class CreateTemplateTypesViewModelEndpoint 
        : Endpoint<CreateTemplateTypesViewModelRequest, CreateTemplateTypesViewModelResponse>
    {
        public override string Name => EndpointNames.CreateTemplateTypesViewModel;

        protected override CreateTemplateTypesViewModelRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override CreateTemplateTypesViewModelResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}

using Microsoft.DotNet.DesignTools.Protocol;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System.ComponentModel;
using System.Composition;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    [Shared]
    [ExportEndpoint]
    public class CreateTemplateAssignmentViewModelEndpoint 
        : Endpoint<CreateTemplateAssignmentViewModelRequest, CreateTemplateAssignmentViewModelResponse>,
          ICreateTemplateAssignmentViewModelEndpoint
    {
        public override string Name => EndpointNames.CreateTemplateAssignmentViewModel;

        protected override CreateTemplateAssignmentViewModelRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override CreateTemplateAssignmentViewModelResponse CreateResponse(IDataPipeReader reader)
            => new(reader);

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ICreateTemplateAssignmentViewModelEndpoint.Response SendRequest(
            IRequestSender client, 
            SessionId sessionId, 
            object? templateAssignmentProxy)
        {
            var request = new CreateTemplateAssignmentViewModelRequest(sessionId, templateAssignmentProxy);
            return this.GetSender(client).SendRequest(request);
        }
    }

    //public static class CreateTemplateAssignmentViewModelEndpointExtension
    //{
    //    public static ICreateTemplateAssignmentViewModelEndpoint.Response SendCreateTemplateAssignmentViewModelRequest(
    //        this IRequestSender client,
    //        SessionId sessionId,
    //        object? templateAssignmentProxy)
    //    {
    //        var request = new CreateTemplateAssignmentViewModelRequest(sessionId, templateAssignmentProxy);
            

    //    }
    //}
}

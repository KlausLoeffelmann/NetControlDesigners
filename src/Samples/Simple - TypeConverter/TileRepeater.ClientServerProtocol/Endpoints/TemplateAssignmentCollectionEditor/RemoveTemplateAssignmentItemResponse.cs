using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class RemoveTemplateAssignmentItemResponse : Response.Empty
    {
        public new static RemoveTemplateAssignmentItemResponse Empty { get; } = new RemoveTemplateAssignmentItemResponse();

        private RemoveTemplateAssignmentItemResponse()
        {
        }

        public RemoveTemplateAssignmentItemResponse(IDataPipeReader reader)
            : base(reader)
        {
        }
    }
}

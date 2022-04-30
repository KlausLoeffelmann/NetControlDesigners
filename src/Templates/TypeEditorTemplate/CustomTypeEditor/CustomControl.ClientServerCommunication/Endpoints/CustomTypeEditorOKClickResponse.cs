using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace CustomControl.ClientServerCommunication.Endpoints
{
    public class CustomTypeEditorOKClickResponse : Response.Empty
    {
        public static new CustomTypeEditorOKClickResponse Empty { get; } = new CustomTypeEditorOKClickResponse();

        private CustomTypeEditorOKClickResponse()
        {
        }

        public CustomTypeEditorOKClickResponse(IDataPipeReader reader)
            : base(reader)
        {
        }
    }
}

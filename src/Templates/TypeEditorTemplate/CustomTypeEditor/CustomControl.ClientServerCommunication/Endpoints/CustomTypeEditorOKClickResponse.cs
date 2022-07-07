using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace CustomControl.ClientServerCommunication.Endpoints
{
    /// <summary>
    /// Response class for this endpoint. We're not returning any relevant data, but still need
    /// this class to meet the infrastructure conventions.
    /// </summary>
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

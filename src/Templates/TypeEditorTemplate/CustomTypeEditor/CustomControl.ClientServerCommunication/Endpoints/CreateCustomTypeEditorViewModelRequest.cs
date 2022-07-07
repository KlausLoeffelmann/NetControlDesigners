using Microsoft.DotNet.DesignTools.Protocol;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System;

namespace CustomControl.ClientServerCommunication.Endpoints
{
    /// <summary>
    /// Request class for the CreateCustomTypeEditorViewModel endpoint, passing the necessary context 
    /// (SessionId, proxy of the CustomControl) from the Client to the Server.
    /// </summary>
    public class CreateCustomTypeEditorViewModelRequest : Request
    {
        public SessionId SessionId { get; private set; }
        public object? CustomControlProxy { get; private set; }

        public CreateCustomTypeEditorViewModelRequest() { }

        public CreateCustomTypeEditorViewModelRequest(SessionId sessionId, object? customControlProxy)
        {
            SessionId = sessionId.IsNull ? throw new ArgumentNullException(nameof(sessionId)) : sessionId;
            CustomControlProxy = customControlProxy;
        }

        public CreateCustomTypeEditorViewModelRequest(IDataPipeReader reader) : base(reader) { }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            SessionId = reader.ReadSessionId(nameof(SessionId));
            CustomControlProxy = reader.ReadObject(nameof(CustomControlProxy));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.Write(nameof(SessionId), SessionId);
            writer.WriteObject(nameof(CustomControlProxy), CustomControlProxy);
        }
    }
}

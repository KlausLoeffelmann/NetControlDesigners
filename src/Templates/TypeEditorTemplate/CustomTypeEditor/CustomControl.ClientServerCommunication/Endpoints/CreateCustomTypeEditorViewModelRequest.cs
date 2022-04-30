using Microsoft.DotNet.DesignTools.Protocol;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System;

namespace CustomControl.ClientServerCommunication.Endpoints
{
    public class CreateCustomTypeEditorViewModelRequest : Request
    {
        public SessionId SessionId { get; private set; }
        public object? TileRepeaterProxy { get; private set; }

        public CreateCustomTypeEditorViewModelRequest() { }

        public CreateCustomTypeEditorViewModelRequest(SessionId sessionId, object? templateAssignmentProxy)
        {
            SessionId = sessionId.IsNull ? throw new ArgumentNullException(nameof(sessionId)) : sessionId;
            TileRepeaterProxy = templateAssignmentProxy;
        }

        public CreateCustomTypeEditorViewModelRequest(IDataPipeReader reader) : base(reader) { }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            SessionId = reader.ReadSessionId(nameof(SessionId));
            TileRepeaterProxy = reader.ReadObject(nameof(TileRepeaterProxy));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.Write(nameof(SessionId), SessionId);
            writer.WriteObject(nameof(TileRepeaterProxy), TileRepeaterProxy);
        }
    }
}

using System;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class OKClickResponse : Response.Empty
    {
        public static new OKClickResponse Empty { get; } = new OKClickResponse();

        private OKClickResponse()
        {
        }

        public OKClickResponse(IDataPipeReader reader)
            : base(reader)
        {
        }
    }
}

using System;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class TemplateAssignmentCollectionEditorOKClickResponse : Response.Empty
    {
        public static new TemplateAssignmentCollectionEditorOKClickResponse Empty { get; } = new TemplateAssignmentCollectionEditorOKClickResponse();

        private TemplateAssignmentCollectionEditorOKClickResponse()
        {
        }

        public TemplateAssignmentCollectionEditorOKClickResponse(IDataPipeReader reader)
            : base(reader)
        {
        }
    }
}

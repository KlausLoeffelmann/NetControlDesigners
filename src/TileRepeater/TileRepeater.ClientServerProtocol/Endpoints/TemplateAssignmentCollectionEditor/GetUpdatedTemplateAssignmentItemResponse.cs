using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class GetUpdatedTemplateAssignmentItemResponse : Response
    {
        [AllowNull]
        public TemplateAssignmentItemData Item { get; private set; }

        private GetUpdatedTemplateAssignmentItemResponse()
        {
        }

        public GetUpdatedTemplateAssignmentItemResponse(TemplateAssignmentItemData item)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
        }

        public GetUpdatedTemplateAssignmentItemResponse(IDataPipeReader reader)
            : base(reader)
        {
        }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            Item = reader.ReadDataPipeObject<TemplateAssignmentItemData>(nameof(Item));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteDataPipeObject(nameof(Item), Item);
        }
    }
}

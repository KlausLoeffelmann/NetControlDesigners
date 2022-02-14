using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class GetTemplateAssignmentItemsResponse : Response
    {
        [AllowNull]
        public TemplateAssignmentItemData[] Items { get; private set; }

        private GetTemplateAssignmentItemsResponse()
        {
        }

        public GetTemplateAssignmentItemsResponse(TemplateAssignmentItemData[] items)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public GetTemplateAssignmentItemsResponse(IDataPipeReader reader)
            : base(reader)
        {
        }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            Items = reader.ReadDataPipeObjectArray<TemplateAssignmentItemData>(nameof(Items));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteDataPipeObjectArray(nameof(Items), Items);
        }
    }
}

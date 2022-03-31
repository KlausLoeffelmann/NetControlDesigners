using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System;
using System.Diagnostics.CodeAnalysis;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class GetUpdatedTemplateAssignmentItemRequest : Request
    {
        [AllowNull]
        public object ViewModel { get; private set; }
        public int Index { get; private set; }

        public GetUpdatedTemplateAssignmentItemRequest(object? viewModel, int index)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            Index = index;
        }

        public GetUpdatedTemplateAssignmentItemRequest(IDataPipeReader reader)
            : base(reader)
        {
        }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            ViewModel = reader.ReadObject(nameof(ViewModel));
            Index = reader.ReadInt32(nameof(Index));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteObject(nameof(ViewModel), ViewModel);
            writer.Write(nameof(Index), Index);
        }
    }
}

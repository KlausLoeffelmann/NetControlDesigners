using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class RemoveTemplateAssignmentItemRequest : Request
    {
        [AllowNull]
        public object ViewModel { get; private set; }

        [AllowNull]
        public int Index { get; private set; }

        public RemoveTemplateAssignmentItemRequest(object? viewModel, int index)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            Index = index;
        }

        public RemoveTemplateAssignmentItemRequest(IDataPipeReader reader)
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

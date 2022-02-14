using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class TemplateAssignmentCollectionEditorOKClickRequest : Request
    {
        [AllowNull]
        public object ViewModel { get; private set; }

        public TemplateAssignmentCollectionEditorOKClickRequest(object? viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public TemplateAssignmentCollectionEditorOKClickRequest(IDataPipeReader reader)
            : base(reader)
        {
        }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            ViewModel = reader.ReadObject(nameof(ViewModel));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteObject(nameof(ViewModel), ViewModel);
        }
    }
}

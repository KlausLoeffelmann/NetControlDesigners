using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System;
using System.Diagnostics.CodeAnalysis;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class TemplateAssignmentCollectionEditorOKClickRequest : Request
    {
        [AllowNull]
        public object ServerViewModel { get; private set; }

        public TemplateAssignmentCollectionEditorOKClickRequest(object? serverViewModel)
        {
            ServerViewModel = serverViewModel ?? throw new ArgumentNullException(nameof(serverViewModel));
        }

        public TemplateAssignmentCollectionEditorOKClickRequest(IDataPipeReader reader)
            : base(reader)
        {
        }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            ServerViewModel = reader.ReadObject(nameof(ServerViewModel));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteObject(nameof(ServerViewModel), ServerViewModel);
        }
    }
}

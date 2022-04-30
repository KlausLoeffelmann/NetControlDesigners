using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CustomControl.ClientServerCommunication.Endpoints
{
    public class CustomTypeEditorOKClickRequest : Request
    {
        [AllowNull]
        public object ViewModel { get; private set; }

        public CustomTypeEditorOKClickRequest(object viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public CustomTypeEditorOKClickRequest(IDataPipeReader reader)
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

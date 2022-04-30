using CustomControl.ClientServerCommunication.DataTransport;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CustomControl.ClientServerCommunication.Endpoints
{
    public class CreateCustomTypeEditorViewModelResponse : Response
    {
        [AllowNull]
        public object ViewModel { get; private set; }

        [AllowNull]
        public CustomPropertyStoreData PropertyStoreData { get; set; }

        public CreateCustomTypeEditorViewModelResponse() { }

        public CreateCustomTypeEditorViewModelResponse(
            object viewModel,
            CustomPropertyStoreData propertyStoreData)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            PropertyStoreData = propertyStoreData ?? throw new ArgumentNullException(nameof(propertyStoreData));
        }

        public CreateCustomTypeEditorViewModelResponse(IDataPipeReader reader) : base(reader) { }

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

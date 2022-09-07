using CustomControlLibrary.ClientServerCommunication.DataTransport;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CustomControlLibrary.ClientServerCommunication.Endpoints
{
    /// <summary>
    ///  Response class, answering the request for that Endpoint. This transports the requested data (Proxy of
    ///  the server-side ViewModel and the data of the custom property type 'PropertyStore') back to the client.
    /// </summary>
    public class CreateCustomTypeEditorViewModelResponse : Response
    {
        [AllowNull]
        public object ViewModel { get; private set; }

        public CustomPropertyStoreData? PropertyStoreData { get; set; }

        public CreateCustomTypeEditorViewModelResponse() { }

        public CreateCustomTypeEditorViewModelResponse(
            object viewModel,
            CustomPropertyStoreData? propertyStoreData)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            PropertyStoreData = propertyStoreData;
        }

        public CreateCustomTypeEditorViewModelResponse(IDataPipeReader reader) : base(reader) { }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            ViewModel = reader.ReadObject(nameof(ViewModel));
            PropertyStoreData = reader.ReadDataPipeObjectOrNull<CustomPropertyStoreData>(nameof(PropertyStoreData));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteObject(nameof(ViewModel), ViewModel);
            writer.WriteDataPipeObjectIfNotNull<CustomPropertyStoreData>(nameof(PropertyStoreData), PropertyStoreData!);
        }
    }
}

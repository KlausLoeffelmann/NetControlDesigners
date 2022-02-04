using System;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using TileRepeater.ClientServerProtocol;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class CreateTemplateTypesViewModelResponse : Response
    {
        public object? ViewModel { get; private set; }
        public TypeInfoData[]? ServerTypes { get; private set; }
        public CreateTemplateTypesViewModelResponse() { }

        public CreateTemplateTypesViewModelResponse(object viewModel, TypeInfoData[] serverTypes)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            ServerTypes = serverTypes ?? throw new ArgumentNullException(nameof(serverTypes));
        }

        public CreateTemplateTypesViewModelResponse(IDataPipeReader reader) : base(reader) { }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            ViewModel = reader.ReadObject(nameof(ViewModel));
            ServerTypes = reader.ReadDataPipeObjectArray<TypeInfoData>(nameof(ServerTypes));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteObject(nameof(ViewModel), ViewModel);
            writer.WriteDataPipeObjectArray(nameof(ServerTypes), ServerTypes);
        }
    }
}

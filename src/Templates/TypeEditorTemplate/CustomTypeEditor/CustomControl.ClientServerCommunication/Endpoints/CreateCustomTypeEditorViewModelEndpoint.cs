using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System.Composition;

namespace CustomControl.ClientServerCommunication.Endpoints
{
    /// <summary>
    /// Endpoint for the method to create the CustomTypeEditor's ViewModel.
    /// </summary>
    /// <remarks>
    /// 'ViewModel' in this context is a class which holds the logic/properties to control the UI. There is a 
    /// server-side and a client-side part of that ViewModel. The server-side provides the logic based on the actual
    /// types of the CustomTypeEditor running in the context of the custom control's TFM. It communicates to the 
    /// client-side ViewModel, which then controls the client-side hosted UI running in the context of 
    /// Visual Studio.
    /// For every Endpoint there is a Request class and a Response class for transporting the necessary data
    /// in the respective context. There is also an additional Endpoint Handler, which holds the code that executes the actual
    /// functionality of that endpoint. Request and Response are in the Communications assembly, the actual Handler is 
    /// part of the server-side implementation of the CustomControl, along with the actual Control Designer and the 
    /// server-side ViewModel.
    /// </remarks>
    [Shared]
    [ExportEndpoint]
    public class CreateCustomTypeEditorViewModelEndpoint 
        : Endpoint<CreateCustomTypeEditorViewModelRequest, CreateCustomTypeEditorViewModelResponse>
    {
        public override string Name => EndpointNames.CreateCustomTypeEditorViewModel;

        protected override CreateCustomTypeEditorViewModelRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override CreateCustomTypeEditorViewModelResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}

using CustomControl.ClientServerCommunication.DataTransport;
using CustomControl.ClientServerCommunication.Endpoints;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using Microsoft.DotNet.DesignTools.ViewModels;
using System;
using System.Linq;

namespace CustomControl.Designer.Server
{
    internal partial class CustomTypeEditorViewModel : ViewModel
    {

        public CustomTypeEditorViewModel(IServiceProvider provider)
            : base(provider)
        {
        }

        public CreateCustomTypeEditorViewModelResponse Initialize(object propertyStoreObject)
        {
            var propertyStore = (CustomPropertyStore)propertyStoreObject;

            return new CreateCustomTypeEditorViewModelResponse(
                this,
                propertyStore is null
                ? null
                : new CustomPropertyStoreData(
                     propertyStore.SomeMustHaveId,
                     propertyStore.DateCreated,
                     propertyStore.ListOfStrings?.ToArray(),
                     (byte)propertyStore.CustomEnumValue));
        }

        internal void OKClick(CustomPropertyStoreData propertyStoreData)
        {
            // We're constructing the actual PropertyStore content based
            // on the data that the user edited and the View sent to the server.

            PropertyStore = new(
                propertyStoreData.SomeMustHaveId,
                propertyStoreData.DateCreated,
                propertyStoreData.ListOfStrings?.ToList(),
                (CustomEnum)propertyStoreData.CustomEnumValue);

            // So, the server-side ViewModel now holds the edited, commited result.
            // The question now is: How does the ViewModel property find the way back
            // to the control?
            // That's been done client-side: On the client, the client-side ViewModel holds the reference to the this
            // PropertyStore property over a ProxyObject. When the User clicks OK in the editor, that codeflow is
            // returned to the client-side part of the TypeEditor. That is, where the assignment from this ViewModel
            // to the actual Property of the Control happens.
        }

        public CustomPropertyStore? PropertyStore { get; set; }
    }
}

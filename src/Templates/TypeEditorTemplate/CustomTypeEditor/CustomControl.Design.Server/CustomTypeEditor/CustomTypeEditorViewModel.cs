using CustomControl.ClientServerCommunication.DataTransport;
using CustomControl.ClientServerCommunication.Endpoints;
using Microsoft.DotNet.DesignTools.ViewModels;
using System;

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
                new CustomPropertyStoreData(
                    propertyStore.SomeMustHaveId,
                    propertyStore.DateCreated,
                    propertyStore.ListOfStrings!.ToArray(),
                    (byte)propertyStore.CustomEnumValue));
        }

        // When we reach this, TemplateQualifiedTypename as well as
        // TileContentQualifiedTypename have been set by the Client-
        // viewmodel (see there).
        internal void OKClick()
        {
            // Create a new Instance of the CustomPropertyStore:
            PropertyStore = null;
        }

        public CustomPropertyStore? PropertyStore { get; set; }
    }
}

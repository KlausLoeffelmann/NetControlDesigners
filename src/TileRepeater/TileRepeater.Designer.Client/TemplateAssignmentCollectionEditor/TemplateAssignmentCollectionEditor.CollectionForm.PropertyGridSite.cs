using System;
using System.ComponentModel;

namespace TileRepeater.Designer.Client
{
    internal partial class TemplateAssignmentCollectionEditor
    {
        partial class CollectionForm
        {
            private class PropertyGridSite : ISite
            {
                private readonly IServiceProvider _serviceProvider;

                public IComponent Component { get; }

                public PropertyGridSite(IServiceProvider serviceProvider, IComponent component)
                {
                    _serviceProvider = serviceProvider;
                    Component = component;
                }

                public IContainer? Container => null;
                public bool DesignMode => false;

                public string? Name
                {
                    get => null;
                    set { }
                }

                public object GetService(Type serviceType)
                    => _serviceProvider.GetService(serviceType);
            }
        }
    }
}

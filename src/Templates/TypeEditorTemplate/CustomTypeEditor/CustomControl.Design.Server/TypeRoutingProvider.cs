using Microsoft.DotNet.DesignTools.TypeRouting;
using System.Collections.Generic;

namespace CustomControl.Designer.Server
{
    /// <summary>
    /// Class holding the TypeRoutings for resolving the control designer type on the server.
    /// </summary>
    [ExportTypeRoutingDefinitionProvider]
    internal class TypeRoutingProvider : TypeRoutingDefinitionProvider
    {
        public override IEnumerable<TypeRoutingDefinition> GetDefinitions()
            => new[]
            {
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Designer,
                    nameof(CustomControlDesigner),
                    typeof(CustomControlDesigner))
            };
    }
}

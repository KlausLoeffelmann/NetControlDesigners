using System.Collections.Generic;
using Microsoft.DotNet.DesignTools.TypeRouting;

namespace WinForms.Tiles.Designer.Server
{
    [ExportTypeRoutingDefinitionProvider]
    internal class TypeRoutingProvider : TypeRoutingDefinitionProvider
    {
        public override IEnumerable<TypeRoutingDefinition> GetDefinitions()
            => new[]
            {
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Designer, 
                    nameof(TileRepeaterDesigner), 
                    typeof(TileRepeaterDesigner))
            };
    }
}

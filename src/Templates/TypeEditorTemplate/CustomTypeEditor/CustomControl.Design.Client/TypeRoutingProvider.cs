using CustomControl.Designer.Client;
using Microsoft.DotNet.DesignTools.Client.TypeRouting;
using System.Collections.Generic;
using WinForms.Tiles.Designer.Protocol;

namespace CustomControl.Designer.Server
{
    [ExportTypeRoutingDefinitionProvider]
    internal class TypeRoutingProvider : TypeRoutingDefinitionProvider
    {
        public override IEnumerable<TypeRoutingDefinition> GetDefinitions()
            => new[]
            {
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Editor,
                    nameof(EditorNames.CustomTypeEditor),
                    typeof(CustomTypeEditor)),
            };
    }
}

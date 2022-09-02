﻿using CustomControlLibrary.Designer.Client;
using Microsoft.DotNet.DesignTools.Client.TypeRouting;
using System.Collections.Generic;
using WinForms.Tiles.Designer.Protocol;

namespace CustomControlLibrary.Designer.Server
{
    /// <summary>
    ///  Class holding the TypeRoutings for resolving the control designer type on the client.
    /// </summary>
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

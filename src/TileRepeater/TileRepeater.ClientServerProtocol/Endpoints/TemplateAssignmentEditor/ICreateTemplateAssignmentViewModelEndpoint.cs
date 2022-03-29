using Microsoft.DotNet.DesignTools.Protocol;
using System.Diagnostics.CodeAnalysis;
using WinForms.Tiles.ClientServerProtocol;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public interface IEndpointTemplate
    {
        string Name { get; }
    }

    public interface ICreateTemplateAssignmentViewModelEndpoint : IEndpointTemplate
    {
        public interface Request
        {
            SessionId SessionId { get; }
            public object? TileRepeaterProxy { get; }
        }

        public interface Response
        {
            [AllowNull]
            object ViewModel { get; }

            [AllowNull]
            TypeInfoData[] TemplateServerTypes { get; }

            [AllowNull]
            TypeInfoData[] TileServerTypes { get; }
        }
    }
}

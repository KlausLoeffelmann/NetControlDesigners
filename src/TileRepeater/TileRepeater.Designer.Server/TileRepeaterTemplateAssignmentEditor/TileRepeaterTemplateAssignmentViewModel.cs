using Microsoft.DotNet.DesignTools.ViewModels;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using TileRepeater.ClientServerProtocol;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace TileRepeater.Designer.Server
{
    internal partial class TileRepeaterTemplateAssignmentViewModel : ViewModel
    {
        private ITypeDiscoveryService? _typeResolutionService;
        private const string SystemNamespace = "System";

        private static readonly string[] s_systemAssembliesFilter = new[]
        {
            "Accessibility",
            "System.Private.",
            "System.Formats.Asn1",
            "Microsoft.Dotnet.DesignTools.",
        };

        private static readonly string[] s_systemNamespaceFilter = new[]
        {
            $"{SystemNamespace}.",
            "Microsoft."
        };

        public TileRepeaterTemplateAssignmentViewModel(IServiceProvider provider)
            : base(provider)
        {
        }

        public CreateTemplateTypesViewModelResponse Initialize()
        {
            TypeList = GetTypelist();
            return new CreateTemplateTypesViewModelResponse(this, TypeList);
        }

        public TypeInfoData[] TypeList { get; private set; } = null!;

        private TypeInfoData[] GetTypelist()
        {
            _typeResolutionService ??= GetRequiredService<ITypeDiscoveryService>();

            var types = _typeResolutionService.GetTypes(typeof(object), true)
                .Cast<Type>()

                .Where(typeItem => !typeItem.IsAbstract && !typeItem.IsInterface &&
                                   !typeItem.IsEnum && typeItem.IsPublic && !typeItem.IsGenericType &&

                                   // We have a few assemblies, whose types we NEVER want.
                                   !s_systemAssembliesFilter.Any(notWantedPrefix => typeItem.Assembly.FullName!.StartsWith(notWantedPrefix)))

                .Select(typeItem => new TypeInfoData(
                    typeItem.Assembly.FullName!,
                    typeItem.Namespace ?? string.Empty,
                    typeItem.FullName!,
                    typeItem.AssemblyQualifiedName!,
                    typeof(INotifyPropertyChanged).IsAssignableFrom(typeItem),
                    typeItem.Name))
                .OrderBy(typeItem => typeItem.Namespace)
                .ThenBy(typeItem => typeItem.Name);

            return types.ToArray();
        }
    }
}

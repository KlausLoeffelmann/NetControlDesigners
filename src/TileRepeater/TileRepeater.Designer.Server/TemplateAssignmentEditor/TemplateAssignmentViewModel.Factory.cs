using Microsoft.DotNet.DesignTools.ViewModels;
using System;
using WinForms.Tiles.Designer.Protocol;

namespace TileRepeater.Designer.Server
{
    internal partial class TemplateAssignmentViewModel
    {
        [ExportViewModelFactory(ViewModelNames.TemplateAssignmentViewModel)]
        private class Factory : ViewModelFactory<TemplateAssignmentViewModel>
        {
            protected override TemplateAssignmentViewModel CreateViewModel(IServiceProvider provider)
                => new(provider);
        }
    }
}

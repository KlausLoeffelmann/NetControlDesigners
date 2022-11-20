using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;

namespace WinForms.Tiles
{
    [Editor("TemplateAssignmentCollectionEditor", typeof(UITypeEditor)),
     DesignerSerializer("WinForms.Tiles.Serialization.TemplateAssignmentsCodeDomSerializer",
            "Microsoft.DotNet.DesignTools.Serialization.CodeDomSerializer")]
    public class TemplateAssignmentItems : List<TemplateAssignmentItem>
    {
    }
}

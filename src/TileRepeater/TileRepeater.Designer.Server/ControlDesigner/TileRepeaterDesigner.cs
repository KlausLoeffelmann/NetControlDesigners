using Microsoft.DotNet.DesignTools.Designers;
using Microsoft.DotNet.DesignTools.Designers.Actions;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace WinForms.Tiles.Designer.Server
{
    internal partial class TileRepeaterDesigner : ControlDesigner
    {
        private const string NotDefinedText = $"No assignments.\nPlease set the {nameof(TileRepeater.TemplateTypes)} property\nfor Data Template selection assignments.";
        private const int DescriptionOffset = 5;

        public override DesignerActionListCollection ActionLists
            => new DesignerActionListCollection
            {
                new ActionList(this)
            };

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);

            // Let's draw what ever type assignments we have into the control,
            // so the Developer always sees, what Data Template Selection there
            // is at runtime.
            var stringsToRender = GetAssignmentTypesStrings();

            if (stringsToRender is not null)
            {
                var leftSideString = string.Join(
                    '\n',
                    stringsToRender
                        .Select(item => item.templateTypeStrings)
                        .ToArray());

                var rightSideString = string.Join(
                    '\n',
                    stringsToRender
                        .Select(item => item.tileContentTypeStrings)
                        .ToArray());

                var leftSideSize = pe.Graphics.MeasureString(leftSideString, Control.Font);
                var rightSideSize = pe.Graphics.MeasureString(rightSideString, Control.Font);

                pe.Graphics.DrawString(
                    leftSideString,
                    Control.Font,
                    new SolidBrush(Control.ForeColor),
                    new PointF(DescriptionOffset, DescriptionOffset));

                // Draw Arrow:
                var linePen = new Pen(Control.ForeColor, 4);
                linePen.EndCap = LineCap.ArrowAnchor;

                PointF lineStartingPoint = new(
                    leftSideSize.Width + DescriptionOffset * 2,
                    leftSideSize.Height / 2);

                PointF lineEndingPoint = lineStartingPoint + new SizeF(50, 0);

                pe.Graphics.DrawLine(
                    linePen,
                    lineStartingPoint,
                    lineEndingPoint);

                PointF rightTextStartingPoint = lineEndingPoint + new SizeF(DescriptionOffset * 2, 0);

                pe.Graphics.DrawString(
                    rightSideString,
                    Control.Font,
                    new SolidBrush(Control.ForeColor),
                    rightTextStartingPoint);

                return;
            }

            var textSize = pe.Graphics.MeasureString(NotDefinedText, Control.Font);


        }

        private List<(string templateTypeStrings, string tileContentTypeStrings)>? GetAssignmentTypesStrings()
        {
            if (((TileRepeater)Control).TemplateTypes is { } templateTypes &&
                templateTypes.Count > 0)
            {
                List<(string, string)> result = new();
                foreach (var templateType in templateTypes)
                {
                    result.Add(
                        (templateType.TemplateAssignment!.TemplateType!.ToString(),
                        templateType.TemplateAssignment!.TileContentControlType!.ToString()));
                }

                return result;
            }

            return null;
        }
    }
}

﻿using Microsoft.DotNet.DesignTools.Designers;
using Microsoft.DotNet.DesignTools.Designers.Actions;
using System.Collections;
using static WinForms.Tiles.Simplified.SimpleTileRepeater;

namespace WinForms.Tiles.Simplified.Designer
{
    internal partial class SimpleTileRepeaterDesigner : ControlDesigner
    {
        private const string NotDefinedText = 
            $"No assignments.\n" +
            $"Please set the {nameof(SimpleTileRepeater.ContentTemplate)} property\n" +
            $"for Data Template selection assignments.";

        private const int DescriptionOffset = 10;

        public override DesignerActionListCollection ActionLists
            => new()
            {
                new ActionList(this)
            };

        protected override void PreFilterEvents(IDictionary events)
        {
            base.PreFilterEvents(events);
        }

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);

            var tileRepeater = (SimpleTileRepeater)Control;

            string genericAdornmentText = 
                $"{nameof(SimpleTileRepeater)}: " +
                $"{tileRepeater.Name}\n";

            // Let's draw what ever type assignments we have into the control,
            // so the Developer always sees, what TileContent there
            // is at runtime.
            if (tileRepeater.ContentTemplate is TileContentTemplate contentTemplate)
            {
                pe.Graphics.DrawString(
                    genericAdornmentText +
                    $"{nameof(SimpleTileRepeater.ContentTemplate)}: {contentTemplate.TileContentType!.Name}",
                    Control.Font,
                    new SolidBrush(Control.ForeColor),
                    new PointF(DescriptionOffset, DescriptionOffset));

                return;
            }

            pe.Graphics.DrawString(
                genericAdornmentText+NotDefinedText,
                Control.Font,
                new SolidBrush(Control.ForeColor),
                new PointF(DescriptionOffset, DescriptionOffset));
        }
    }
}

﻿using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using WinForms.Tiles.Designer;
using WinForms.Tiles.Serialization;

namespace WinForms.Tiles
{
    [Editor(typeof(TemplateAssignmentEditor), typeof(UITypeEditor)),
     DesignerSerializer(typeof(TemplateAssignmentCodeDomSerializer),
                        typeof(CodeDomSerializer))]
    public class TemplateAssignment
    {
        private Type? _templateType;
        private Type? _tileContentControlType;

        private const string TypeNullString = "- - -";

        public TemplateAssignment(Type? templateType, Type? tileContentControlType)
        {
            _templateType = templateType;
            _tileContentControlType = tileContentControlType;
        }

        public Type? TemplateType
        {
            get => _templateType;
            set => _templateType = value ?? throw new ArgumentNullException(nameof(TemplateType));
        }

        public Type? TileContentControlType
        {
            get => _tileContentControlType;
            set => _tileContentControlType = value ?? throw new ArgumentException(nameof(TileContentControlType));
        }

        public override string ToString()
        {
            return $"{NullableTypeName(TemplateType)}/{NullableTypeName(TileContentControlType)}";

            static string NullableTypeName(Type? type)
                => $"{(type is null ? TypeNullString : type.Name)}";
        }
    }
}

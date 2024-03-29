﻿using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace WinForms.Tiles.Simplified
{
    public partial class SimpleTileRepeater
    {
        public class TileContentConverter : TypeConverter
        {
            private Dictionary<string, TileContentTemplate>? _userControlTypes;

            public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
                => destinationType == typeof(string);

            public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
                => sourceType == typeof(string);

            public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
            {
                if (destinationType == typeof(string))
                {
                    if (value is null)
                    {
                        return "(none)";
                    }

                    return value.ToString()!;
                }
                
                return base.ConvertTo(context, culture, value, destinationType);
            }

            public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
            {
                if (_userControlTypes?.TryGetValue((string)value, out var userControlTemplate) ?? false)
                {
                    return userControlTemplate;
                }

                return null;
            }

            public override StandardValuesCollection? GetStandardValues(ITypeDescriptorContext? context)
            {
                if (context?.TryGetService<ITypeDiscoveryService>(out var discoveryService) ?? false)
                {
                    _userControlTypes = discoveryService.GetTypes(
                        typeof(TileContent),
                        excludeGlobalTypes: false)
                            .Cast<Type>()
                            .Select(item => new TileContentTemplate(item))
                            .ToDictionary(item => item.ToString());
                }
                else
                {
                    // No type discovery service, fall back to this assembly.
                    _userControlTypes = Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(typeItem => typeof(TileContent).IsAssignableFrom(typeItem))
                        .Select(item => new TileContentTemplate(item))
                        .ToDictionary(item => item.ToString());
                }

                return new StandardValuesCollection(_userControlTypes.Values);
            }

            public override bool GetStandardValuesSupported(ITypeDescriptorContext? context)
                => true;
        }
    }
}

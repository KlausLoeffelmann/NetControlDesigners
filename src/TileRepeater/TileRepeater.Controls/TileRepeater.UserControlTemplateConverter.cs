using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace WinForms.Tiles
{
    public partial class TileRepeater
    {
        public class TileContentConverter : TypeConverter
        {
            private Dictionary<string, UserControlTemplate>? userControlTypes;

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
                if (userControlTypes?.TryGetValue((string)value, out var userControlTemplate) ?? false)
                {
                    return userControlTemplate;
                }

                return null;
            }

            public override StandardValuesCollection? GetStandardValues(ITypeDescriptorContext? context)
            {
                userControlTypes = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(typeItem => typeof(UserControl).IsAssignableFrom(typeItem))
                    .Select(item => new UserControlTemplate(item))
                    .ToDictionary(item => item.ToString());

                if (Debugger.IsAttached)
                    Debugger.Break();

                return new StandardValuesCollection(userControlTypes.Values);
            }

            public override bool GetStandardValuesSupported(ITypeDescriptorContext? context)
                => true;
        }
    }
}

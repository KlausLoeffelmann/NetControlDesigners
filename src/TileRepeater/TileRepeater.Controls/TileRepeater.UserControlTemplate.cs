using System.ComponentModel;

namespace WinForms.Tiles
{
    public partial class TileRepeater
    {
        [TypeConverter(typeof(UserControlTemplateConverter))]
        public class UserControlTemplate
        {
            public UserControlTemplate()
            {
            }

            public UserControlTemplate(Type userControlType)
            {
                if (userControlType is null)
                {
                    throw new ArgumentNullException(nameof(userControlType));
                }

                if (!typeof(UserControl).IsAssignableFrom(userControlType))
                {
                    throw new ArgumentException(nameof(userControlType));
                }

                UserControlType = userControlType;
            }

            public string? Name
                => UserControlType?.Name;

            public Type? UserControlType { get; set; }
            public override string ToString()
                => UserControlType?.Name ?? "(none)";
        }
    }
}

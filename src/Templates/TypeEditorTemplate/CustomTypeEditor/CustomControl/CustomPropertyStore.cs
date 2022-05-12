using System.ComponentModel;
using System.Drawing.Design;

namespace CustomControl
{
    [Editor("CustomTypeEditor", typeof(UITypeEditor))]
    public class CustomPropertyStore
    {
        public CustomPropertyStore(
            string someMustHaveId,
            DateTime dateCreated,
            List<string>? listOfStrings,
            CustomEnum customEnumValue)
        {
            SomeMustHaveId = someMustHaveId;
            DateCreated = dateCreated;
            ListOfStrings = listOfStrings;
            CustomEnumValue = customEnumValue;
        }

        public string SomeMustHaveId { get; set; }
        public DateTime DateCreated { get; set; }
        public List<string>? ListOfStrings { get; set; }
        public CustomEnum CustomEnumValue { get; set; }

        public override string ToString()
            => $"{nameof(SomeMustHaveId)}: {SomeMustHaveId}" +
               $"{nameof(DateCreated)}: {DateCreated:yyyy-MM-dd HH:mm}" +
               $"{nameof(CustomEnumValue)}: {CustomEnumValue}" +
               $"{(ListOfStrings is null ? "No" : ListOfStrings?.Count ?? 0)} strings in list defined.";
    }
}

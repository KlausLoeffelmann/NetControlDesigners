using System.ComponentModel;
using System.Drawing.Design;

namespace CustomControl
{
    /// <summary>
    /// An example for a custom type used by a property of a custom control.
    /// </summary>
    /// <remarks>
    /// Since this type is made out of different sub types, there is no editor out of the box to enter data in a 
    /// meaningfull way when we are editing the value at design-time from within the property grid. That is the 
    /// reason we need a dedidcated editor (CustomTypeEditor) derived from <see cref="UITypeEditor"/> which does
    /// that job.
    /// </remarks>
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

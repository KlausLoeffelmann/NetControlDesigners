namespace CustomControl
{
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
    }
}

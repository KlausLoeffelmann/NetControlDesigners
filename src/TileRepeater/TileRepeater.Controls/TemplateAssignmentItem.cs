namespace WinForms.Tiles
{
    public class TemplateAssignmentItem
    {
        private const string UndefinedDefaultName = "Unassigned template";
        private TemplateAssignment? _templateAssignment;
        private int currentCollectionCountSnapshot;

        public TemplateAssignmentItem(int collectionCount)
        {
            currentCollectionCountSnapshot = collectionCount;
            TemplateAssignmentName = GetItemDefaultName();
        }

        private string GetItemDefaultName()
             => $"{UndefinedDefaultName}{currentCollectionCountSnapshot}";

        public string TemplateAssignmentName { get; set; }

        public TemplateAssignment? TemplateAssignment
        {
            get => _templateAssignment;

            set
            {
                if (!Equals(value, TemplateAssignment))
                {
                    var oldAssignmentName = TemplateAssignment?.ToString();
                    _templateAssignment = value;

                    if (TemplateAssignmentName.StartsWith(UndefinedDefaultName) || TemplateAssignmentName == oldAssignmentName)
                    {
                        // The name was always derived and never explicitely set to anything else, so we should overwrite it.
                        TemplateAssignmentName = TemplateAssignment is null
                            ? GetItemDefaultName()
                            : TemplateAssignment.ToString();
                    }
                }
            }
        }

        public override string ToString() => TemplateAssignmentName;
    }
}

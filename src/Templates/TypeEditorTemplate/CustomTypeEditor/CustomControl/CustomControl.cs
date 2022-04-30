using System.ComponentModel;
using System.Text;

namespace CustomControl
{
    public class CustomControl : Control
    {
        public CustomControl()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        [Description("A custom property composed of different value types and a string array."),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomPropertyStore? CustomProperty { get; set; }

        /// <summary>
        /// Controls the Reset-Property function in the PropertyBrowser.
        /// </summary>
        private void ResetCustomPropertyData() 
            => CustomProperty = null;

        /// <summary>
        /// Controls the Serialization of the Property.
        /// </summary>
        /// <returns>
        /// True, if the CodeDOM serializer should emit code for 
        /// assigning a valid content to the property in InitializeComponent.
        /// </returns>
        private bool ShouldSerializeCustomPropertyData()
            => CustomProperty is not null;

        // The only function of this control is to draw a visual
        // representation of the CustomProperty at Design and Runtime.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Drawing a frame around the control's borders:
            var pen = new Pen(ForeColor);
            var brush = new SolidBrush(ForeColor);
            e.Graphics.DrawRectangle(pen, ClientRectangle);

            // Drawing the contents of the CustomProperty.
            e.Graphics.DrawString(
                BuildContentString(CustomProperty),
                Font,
                brush, 
                point: new(10, 10));

            // Builds a long string with the text representation of 
            // the CustomProperty of this control.
            string BuildContentString(CustomPropertyStore? propertyData)
            {
                StringBuilder stringBuilder = new();

                if (propertyData is null)
                {
                    stringBuilder.Append("No CustomProperty Data defined.");
                    return stringBuilder.ToString();
                }

                stringBuilder.AppendLine($"{nameof(propertyData.SomeMustHaveId)}: {propertyData.SomeMustHaveId}");
                stringBuilder.AppendLine($"{nameof(propertyData.DateCreated)}: {propertyData.DateCreated:yyyy-mm-dd (ddd)}");
                stringBuilder.AppendLine($"{nameof(propertyData.CustomEnumValue)}: '{propertyData.CustomEnumValue}'");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("List of Strings:");
                stringBuilder.AppendLine("=============================");

                propertyData.ListOfStrings?.ForEach(
                    stringValue => stringBuilder.AppendLine($"* {stringValue}"));

                return stringBuilder.ToString();
            }
        }
    }
}

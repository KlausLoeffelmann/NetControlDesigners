using System.ComponentModel;
using System.Text;

namespace CustomControl
{
    /// <summary>
    /// Custom Control sample implementation.
    /// </summary>
    /// <remarks>
    /// This sample custom control implements one custom property named <see cref="CustomProperty"/> 
    /// of type <see cref="CustomPropertyStore"/>. Its sole purpose is to demonstrate how to implement
    /// a custom TypeEditor for editing this property's content at design time with the Out-Of-Process
    /// WinForms Designer. 
    /// </remarks>
    [Designer("CustomControlDesigner")]
    public class CustomControl : Control
    {
        // Backing field for CustomProperty.
        private CustomPropertyStore? _customProperty;

        /// <summary>
        /// Raised when CustomProperty changes.
        /// </summary>
        public event EventHandler? CustomPropertyChanged;

        public CustomControl()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        /// <summary>
        /// Gets or sets a value of type <see cref="CustomPropertyStore"/> which is composed of different value types,
        /// a custom enum and a string array.
        /// </summary>
        [Description("A custom property composed of different value types, a custom enum and a string array."),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomPropertyStore? CustomProperty
        {
            get => _customProperty;

            set
            {
                if (!Equals(value, _customProperty))
                {
                    _customProperty = value;
                    OnCustomPropertyChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Raises the CustomPropertyChanged event.
        /// </summary>
        protected virtual void OnCustomPropertyChanged(EventArgs e) 
            => CustomPropertyChanged?.Invoke(this, e);

        /// <summary>
        /// Controls the Reset-Property function in the PropertyBrowser.
        /// </summary>
        private void ResetCustomProperty() 
            => CustomProperty = null;

        /// <summary>
        /// Controls the Serialization of the Property.
        /// </summary>
        /// <returns>
        /// True, if the CodeDOM serializer should emit code for 
        /// assigning a valid content to the property in InitializeComponent.
        /// </returns>
        private bool ShouldSerializeCustomProperty()
            => CustomProperty is not null;

        // The only function of this control is to draw a visual
        // representation of the CustomProperty at Design and Runtime.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Drawing a frame around the control's borders:
            var pen = new Pen(ForeColor);
            var brush = new SolidBrush(ForeColor);

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

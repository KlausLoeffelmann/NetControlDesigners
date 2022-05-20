using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace CustomControl.ClientServerCommunication.DataTransport
{
    /// <summary>
    /// Transport class to carry the content of the CustomPropertyData 
    /// from the DesignToolServer's server process to the client (VS) and back.
    /// </summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class CustomPropertyStoreData : IDataPipeObject
    {
        [AllowNull]
        public string SomeMustHaveId { get; private set; }

        public DateTime DateCreated { get; private set; }
        public string[]? ListOfStrings { get; private set; }
        public byte CustomEnumValue { get; private set; }

        public CustomPropertyStoreData()
        {
        }

        public CustomPropertyStoreData(
            string someMusthaveId,
            DateTime dateCreated,
            string[]? listOfStrings,
            byte customEnumValue)
        {
            SomeMustHaveId = someMusthaveId;
            DateCreated = dateCreated;
            ListOfStrings = listOfStrings;
            CustomEnumValue = customEnumValue;
        }

        public void ReadProperties(IDataPipeReader reader)
        {
            SomeMustHaveId = reader.ReadString(nameof(SomeMustHaveId));
            DateCreated = reader.ReadDateTimeOrDefault(nameof(DateCreated));

            if (Debugger.IsAttached)
                Debugger.Break();

            ListOfStrings = reader.ReadArrayOrNull(
                nameof(ListOfStrings), 
                (reader) => reader.ReadString()!);

            CustomEnumValue = reader.ReadByte(nameof(CustomEnumValue));
        }

        public void WriteProperties(IDataPipeWriter writer)
        {
            writer.Write(nameof(SomeMustHaveId), SomeMustHaveId);
            writer.WriteIfNotDefault(nameof(DateCreated), DateCreated);

            if (Debugger.IsAttached)
                Debugger.Break();

            writer.WriteArrayIfNotNull(
                nameof(ListOfStrings),
                ListOfStrings,
                (writer, value) => writer.Write(value));

            writer.Write(nameof(CustomEnumValue), CustomEnumValue);
        }

        private string GetDebuggerDisplay()
            => $"ID: {SomeMustHaveId}; {nameof(DateCreated)}: {DateCreated}";
    }
}

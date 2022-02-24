using Microsoft.DotNet.DesignTools.Editors;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TileRepeater.ClientServerProtocol.DataTransport;
using WinForms.Tiles;

namespace TileRepeater.Designer.Server.TemplateAssignmentCollectionEditor
{
    internal partial class TemplateAssignmentCollectionEditor
    {
        internal class ViewModel : CollectionEditorViewModel
        {
            private readonly List<TemplateAssignmentItem> _items;

            public ViewModel(CollectionEditor editor)
                : base(editor)
            {
                _items = new List<TemplateAssignmentItem>();
            }

            protected override void OnEditValueChanged()
            {
                _items.Clear();

                if (EditValue is not Collection<TemplateAssignment> collection)
                {
                    return;
                }

                foreach (var templateAssignment in collection)
                {
                    _items.Add(new TemplateAssignmentItem(templateAssignment));
                }
            }

            public TemplateAssignmentItemData AddItem()
            {
                var templateAssignment = new TemplateAssignment(null, null);
                var item = new TemplateAssignmentItem(templateAssignment);
                _items.Add(item);

                return item.ToData();
            }

            public TemplateAssignmentItemData[] GetItems()
                => _items
                    .Select(i => i.ToData())
                    .ToArray();

            public TemplateAssignmentItemData GetItem(int index)
                => _items[index].ToData();

            public void RemoveItem(int index)
                => _items.RemoveAt(index);

            public void OKClick()
                => Items = _items
                    .Select(i => i.TemplateAssignment)
                    .ToArray();
        }
    }
}
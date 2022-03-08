using Microsoft.DotNet.DesignTools.Editors;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WinForms.Tiles.ClientServerProtocol.DataTransport;

namespace WinForms.Tiles.Designer.Server.TemplateAssignmentCollectionEditor
{
    internal partial class TemplateAssignmentCollectionEditor
    {
        internal class ViewModel : CollectionEditorViewModel
        {
            private readonly List<TemplateAssignmentCollectionItem> _items;

            public ViewModel(CollectionEditor editor)
                : base(editor)
            {
                _items = new List<TemplateAssignmentCollectionItem>();
            }

            protected override void OnEditValueChanged()
            {
                _items.Clear();

                if (EditValue is not Collection<TemplateAssignmentItem> collection)
                {
                    return;
                }

                foreach (var templateAssignmentItem in collection)
                {
                    _items.Add(new TemplateAssignmentCollectionItem(templateAssignmentItem));
                }
            }

            public TemplateAssignmentItemData AddItem()
            {
                var templateAssignmentItem = new TemplateAssignmentItem(_items.Count);
                var item = new TemplateAssignmentCollectionItem(templateAssignmentItem);
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
            {
                var items = _items
                   .Select(i => i.TemplateAssignmentItem)
                   .ToArray();

                Items = items;
            }
        }
    }
}

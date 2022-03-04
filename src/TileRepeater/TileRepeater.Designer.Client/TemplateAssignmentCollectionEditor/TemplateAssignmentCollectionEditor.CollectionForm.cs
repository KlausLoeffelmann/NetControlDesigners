using Microsoft.DotNet.DesignTools.Client.Editors;
using System;
using System.Windows.Forms;

namespace TileRepeater.Designer.Client
{
    internal partial class TemplateAssignmentCollectionEditor
    {
        partial class CollectionForm : CollectionForm<TemplateAssignmentCollectionFormClient>
        {
            public CollectionForm(CollectionEditor editor, TemplateAssignmentCollectionFormClient client)
                : base(editor, client)
            {
                InitializeComponent();

                _collectionFormContent!._propertyGrid.Site = new PropertyGridSite(Context, _collectionFormContent!._propertyGrid);

                _collectionFormContent!._btnAdd.Click += BtnAdd_Click;
                _collectionFormContent!._btnRemove.Click += BtnRemove_Click;
                _collectionFormContent!._lbxTemplateAssignments.SelectedIndexChanged += LbxPeople_SelectedIndexChanged;
                _collectionFormContent!._propertyGrid.PropertyValueChanged += PropertyGrid_PropertyValueChanged;
                _collectionFormContent!._btnOk.Click += BtnOk_Click;
            }

            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);

                var items = Client.GetItems();
                _collectionFormContent!._lbxTemplateAssignments.Items.AddRange(items);
                _collectionFormContent!._lbxTemplateAssignments.SelectedIndex = items.Length > 0 ? 0 : -1;
            }

            private void LbxPeople_SelectedIndexChanged(object sender, EventArgs e)
            {
                var selectedPerson = (_collectionFormContent!._lbxTemplateAssignments.SelectedItem as TemplateAssignmentItem)?.TemplateAssignmentProxy;

                _collectionFormContent!._propertyGrid.SelectedObject = selectedPerson;
            }

            private void PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
            {
                var selectedIndex = _collectionFormContent!._lbxTemplateAssignments.SelectedIndex;
                var updatedItem = Client.GetUpdatedItem(selectedIndex);
                _collectionFormContent!._lbxTemplateAssignments.Items[selectedIndex] = updatedItem;
            }

            private void BtnAdd_Click(object sender, EventArgs e)
            {
                var newItem = Client.AddItem();
                var newIndex = _collectionFormContent!._lbxTemplateAssignments.Items.Add(newItem);

                _collectionFormContent!._lbxTemplateAssignments.SelectedIndex = newIndex;
            }

            private void BtnRemove_Click(object sender, EventArgs e)
            {
                var selectedIndex = _collectionFormContent!._lbxTemplateAssignments.SelectedIndex;
                if (selectedIndex < 0)
                {
                    return;
                }

                Client.RemoveItem(selectedIndex);
                _collectionFormContent!._lbxTemplateAssignments.Items.RemoveAt(selectedIndex);

                _collectionFormContent!._lbxTemplateAssignments.SelectedIndex = 
                    Math.Min(selectedIndex, _collectionFormContent!._lbxTemplateAssignments.Items.Count - 1);
            }

            private void BtnOk_Click(object sender, EventArgs e)
            {
                Client.OKClick();
            }

            private void InitializeComponent()
            {
                _collectionFormContent = new TileRepeater.Designer.Client.BaseUI.DesignableCollectionEditor();
                SuspendLayout();
                // 
                // Form1
                // 
                _collectionFormContent.Dock = DockStyle.Fill;
                AcceptButton = _collectionFormContent!._btnOk;
                CancelButton = _collectionFormContent!._btnCancel;
                AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                AutoScaleMode = AutoScaleMode.Font;
                ClientSize = new System.Drawing.Size(784, 561);
                Controls.Add(_collectionFormContent);
                StartPosition = FormStartPosition.CenterParent;
                Text = "Type->UserControl Template Assignment Editor";
                ResumeLayout(false);
            }

            TileRepeater.Designer.Client.BaseUI.DesignableCollectionEditor _collectionFormContent;
        }
    }
}

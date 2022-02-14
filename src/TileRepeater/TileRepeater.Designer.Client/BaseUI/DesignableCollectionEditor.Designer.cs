namespace TileRepeater.Designer.Client.BaseUI
{
    internal partial class DesignableCollectionEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._bottomPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._splitContainer = new System.Windows.Forms.SplitContainer();
            this._lbxTemplateAssignments = new System.Windows.Forms.ListBox();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._btnAdd = new System.Windows.Forms.ToolStripButton();
            this._btnRemove = new System.Windows.Forms.ToolStripButton();
            this._propertyGrid = new System.Windows.Forms.PropertyGrid();
            this._tableLayoutPanel.SuspendLayout();
            this._bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 1;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tableLayoutPanel.Controls.Add(this._bottomPanel, 0, 1);
            this._tableLayoutPanel.Controls.Add(this._splitContainer, 0, 0);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 2;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.Size = new System.Drawing.Size(1061, 672);
            this._tableLayoutPanel.TabIndex = 0;
            // 
            // _bottomPanel
            // 
            this._bottomPanel.Controls.Add(this._btnCancel);
            this._bottomPanel.Controls.Add(this._btnOk);
            this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._bottomPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this._bottomPanel.Location = new System.Drawing.Point(4, 631);
            this._bottomPanel.Margin = new System.Windows.Forms.Padding(4);
            this._bottomPanel.Name = "_bottomPanel";
            this._bottomPanel.Size = new System.Drawing.Size(1053, 37);
            this._bottomPanel.TabIndex = 0;
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(949, 4);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(100, 28);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "&Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.Location = new System.Drawing.Point(841, 4);
            this._btnOk.Margin = new System.Windows.Forms.Padding(4);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(100, 28);
            this._btnOk.TabIndex = 0;
            this._btnOk.Text = "&OK";
            this._btnOk.UseVisualStyleBackColor = true;
            // 
            // _splitContainer
            // 
            this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer.Location = new System.Drawing.Point(4, 4);
            this._splitContainer.Margin = new System.Windows.Forms.Padding(4);
            this._splitContainer.Name = "_splitContainer";
            // 
            // _splitContainer.Panel1
            // 
            this._splitContainer.Panel1.Controls.Add(this._lbxTemplateAssignments);
            this._splitContainer.Panel1.Controls.Add(this._toolStrip);
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this._propertyGrid);
            this._splitContainer.Size = new System.Drawing.Size(1053, 619);
            this._splitContainer.SplitterDistance = 614;
            this._splitContainer.SplitterWidth = 5;
            this._splitContainer.TabIndex = 0;
            // 
            // _lbxPeople
            // 
            this._lbxTemplateAssignments.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lbxTemplateAssignments.FormattingEnabled = true;
            this._lbxTemplateAssignments.ItemHeight = 16;
            this._lbxTemplateAssignments.Location = new System.Drawing.Point(0, 31);
            this._lbxTemplateAssignments.Margin = new System.Windows.Forms.Padding(4);
            this._lbxTemplateAssignments.Name = "_lbxPeople";
            this._lbxTemplateAssignments.Size = new System.Drawing.Size(614, 588);
            this._lbxTemplateAssignments.TabIndex = 1;
            // 
            // _toolStrip
            // 
            this._toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnAdd,
            this._btnRemove});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(614, 31);
            this._toolStrip.TabIndex = 0;
            // 
            // _btnAdd
            // 
            this._btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(41, 28);
            this._btnAdd.Text = "Add";
            // 
            // _btnRemove
            // 
            this._btnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnRemove.Name = "_btnRemove";
            this._btnRemove.Size = new System.Drawing.Size(67, 28);
            this._btnRemove.Text = "Remove";
            // 
            // _propertyGrid
            // 
            this._propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._propertyGrid.Location = new System.Drawing.Point(0, 0);
            this._propertyGrid.Margin = new System.Windows.Forms.Padding(4);
            this._propertyGrid.Name = "_propertyGrid";
            this._propertyGrid.Size = new System.Drawing.Size(434, 619);
            this._propertyGrid.TabIndex = 0;
            // 
            // DesignableCollectionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DesignableCollectionEditor";
            this.Size = new System.Drawing.Size(1061, 672);
            this._tableLayoutPanel.ResumeLayout(false);
            this._bottomPanel.ResumeLayout(false);
            this._splitContainer.Panel1.ResumeLayout(false);
            this._splitContainer.Panel1.PerformLayout();
            this._splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
            this._splitContainer.ResumeLayout(false);
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        internal System.Windows.Forms.FlowLayoutPanel _bottomPanel;
        internal System.Windows.Forms.Button _btnCancel;
        internal System.Windows.Forms.Button _btnOk;
        internal System.Windows.Forms.SplitContainer _splitContainer;
        internal System.Windows.Forms.ListBox _lbxTemplateAssignments;
        internal System.Windows.Forms.ToolStrip _toolStrip;
        internal System.Windows.Forms.ToolStripButton _btnAdd;
        internal System.Windows.Forms.ToolStripButton _btnRemove;
        internal System.Windows.Forms.PropertyGrid _propertyGrid;

        #endregion
    }
}

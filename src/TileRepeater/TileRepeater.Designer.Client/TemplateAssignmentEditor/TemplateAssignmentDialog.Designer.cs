namespace TileRepeater.Designer.Client
{
    partial class TemplateAssignmentDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._templateTypesListBox = new System.Windows.Forms.ListBox();
            this._INotifyPropertyChangedFilterCheckBox = new System.Windows.Forms.CheckBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._selectBindingSourceTemplateTypeLabel = new System.Windows.Forms.Label();
            this._tileContentTypesControlComboBox = new System.Windows.Forms.ComboBox();
            this._selectTileTemplateControlLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._resultStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._clearSelectionsButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _templateTypesListBox
            // 
            this._templateTypesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._templateTypesListBox.FormattingEnabled = true;
            this._templateTypesListBox.IntegralHeight = false;
            this._templateTypesListBox.ItemHeight = 16;
            this._templateTypesListBox.Location = new System.Drawing.Point(23, 29);
            this._templateTypesListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._templateTypesListBox.Name = "_templateTypesListBox";
            this._templateTypesListBox.Size = new System.Drawing.Size(632, 270);
            this._templateTypesListBox.TabIndex = 1;
            this._templateTypesListBox.SelectedIndexChanged += new System.EventHandler(this.TemplateTypeListBox_SelectedIndexChanged);
            // 
            // _INotifyPropertyChangedFilterCheckBox
            // 
            this._INotifyPropertyChangedFilterCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._INotifyPropertyChangedFilterCheckBox.AutoSize = true;
            this._INotifyPropertyChangedFilterCheckBox.Location = new System.Drawing.Point(23, 401);
            this._INotifyPropertyChangedFilterCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._INotifyPropertyChangedFilterCheckBox.Name = "_INotifyPropertyChangedFilterCheckBox";
            this._INotifyPropertyChangedFilterCheckBox.Size = new System.Drawing.Size(323, 20);
            this._INotifyPropertyChangedFilterCheckBox.TabIndex = 4;
            this._INotifyPropertyChangedFilterCheckBox.Text = "Filter types implementing INotifyPropertyChanged";
            this._INotifyPropertyChangedFilterCheckBox.UseVisualStyleBackColor = true;
            this._INotifyPropertyChangedFilterCheckBox.CheckedChanged += new System.EventHandler(this._filterTypesImplementingINotifyPropertyChangedCheckBox_CheckedChanged);
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Enabled = false;
            this._okButton.Location = new System.Drawing.Point(442, 395);
            this._okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(103, 31);
            this._okButton.TabIndex = 5;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(551, 395);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(103, 31);
            this._cancelButton.TabIndex = 6;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _selectBindingSourceTemplateTypeLabel
            // 
            this._selectBindingSourceTemplateTypeLabel.AutoSize = true;
            this._selectBindingSourceTemplateTypeLabel.Location = new System.Drawing.Point(20, 9);
            this._selectBindingSourceTemplateTypeLabel.Name = "_selectBindingSourceTemplateTypeLabel";
            this._selectBindingSourceTemplateTypeLabel.Size = new System.Drawing.Size(223, 16);
            this._selectBindingSourceTemplateTypeLabel.TabIndex = 0;
            this._selectBindingSourceTemplateTypeLabel.Text = "Select binding source template type:";
            // 
            // _tileContentTypesControlComboBox
            // 
            this._tileContentTypesControlComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tileContentTypesControlComboBox.FormattingEnabled = true;
            this._tileContentTypesControlComboBox.Location = new System.Drawing.Point(23, 342);
            this._tileContentTypesControlComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._tileContentTypesControlComboBox.Name = "_tileContentTypesControlComboBox";
            this._tileContentTypesControlComboBox.Size = new System.Drawing.Size(511, 24);
            this._tileContentTypesControlComboBox.TabIndex = 3;
            this._tileContentTypesControlComboBox.SelectedIndexChanged += new System.EventHandler(this.TileTemplateControlComboBox_SelectedIndexChanged);
            // 
            // _selectTileTemplateControlLabel
            // 
            this._selectTileTemplateControlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._selectTileTemplateControlLabel.AutoSize = true;
            this._selectTileTemplateControlLabel.Location = new System.Drawing.Point(20, 324);
            this._selectTileTemplateControlLabel.Name = "_selectTileTemplateControlLabel";
            this._selectTileTemplateControlLabel.Size = new System.Drawing.Size(226, 16);
            this._selectTileTemplateControlLabel.TabIndex = 2;
            this._selectTileTemplateControlLabel.Text = "Select Tile Content Template control:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._resultStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 434);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(676, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _resultStatusLabel
            // 
            this._resultStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._resultStatusLabel.Name = "_resultStatusLabel";
            this._resultStatusLabel.Size = new System.Drawing.Size(661, 16);
            this._resultStatusLabel.Spring = true;
            this._resultStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _clearSelectionsButton
            // 
            this._clearSelectionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._clearSelectionsButton.Enabled = false;
            this._clearSelectionsButton.Location = new System.Drawing.Point(551, 338);
            this._clearSelectionsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._clearSelectionsButton.Name = "_clearSelectionsButton";
            this._clearSelectionsButton.Size = new System.Drawing.Size(103, 31);
            this._clearSelectionsButton.TabIndex = 8;
            this._clearSelectionsButton.Text = "Clear";
            this._clearSelectionsButton.UseVisualStyleBackColor = true;
            this._clearSelectionsButton.Click += new System.EventHandler(this.ClearSelectionsButton_Click);
            // 
            // TemplateAssignmentDialog
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(676, 456);
            this.Controls.Add(this._clearSelectionsButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._selectTileTemplateControlLabel);
            this.Controls.Add(this._tileContentTypesControlComboBox);
            this.Controls.Add(this._selectBindingSourceTemplateTypeLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._INotifyPropertyChangedFilterCheckBox);
            this.Controls.Add(this._templateTypesListBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(482, 377);
            this.Name = "TemplateAssignmentDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Template Types";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _templateTypesListBox;
        private System.Windows.Forms.CheckBox _INotifyPropertyChangedFilterCheckBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _selectBindingSourceTemplateTypeLabel;
        private System.Windows.Forms.ComboBox _tileContentTypesControlComboBox;
        private System.Windows.Forms.Label _selectTileTemplateControlLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _resultStatusLabel;
        private System.Windows.Forms.Button _clearSelectionsButton;
    }
}
namespace TileRepeater.Designer.Client
{
    partial class TileRepeaterTemplateAssignmentDialog
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
            this._selectBindingSourceTemplateTypeListBox = new System.Windows.Forms.ListBox();
            this._filterTypesImplementingINotifyPropertyChangedCheckBox = new System.Windows.Forms.CheckBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._selectBindingSourceTemplateTypeLabel = new System.Windows.Forms.Label();
            this._selectTileTemplateControlComboBox = new System.Windows.Forms.ComboBox();
            this._selectTileTemplateControlLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _selectBindingSourceTemplateTypeListBox
            // 
            this._selectBindingSourceTemplateTypeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._selectBindingSourceTemplateTypeListBox.FormattingEnabled = true;
            this._selectBindingSourceTemplateTypeListBox.ItemHeight = 20;
            this._selectBindingSourceTemplateTypeListBox.Location = new System.Drawing.Point(26, 150);
            this._selectBindingSourceTemplateTypeListBox.Name = "_selectBindingSourceTemplateTypeListBox";
            this._selectBindingSourceTemplateTypeListBox.Size = new System.Drawing.Size(710, 244);
            this._selectBindingSourceTemplateTypeListBox.TabIndex = 3;
            // 
            // _filterTypesImplementingINotifyPropertyChangedCheckBox
            // 
            this._filterTypesImplementingINotifyPropertyChangedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._filterTypesImplementingINotifyPropertyChangedCheckBox.AutoSize = true;
            this._filterTypesImplementingINotifyPropertyChangedCheckBox.Location = new System.Drawing.Point(26, 426);
            this._filterTypesImplementingINotifyPropertyChangedCheckBox.Name = "_filterTypesImplementingINotifyPropertyChangedCheckBox";
            this._filterTypesImplementingINotifyPropertyChangedCheckBox.Size = new System.Drawing.Size(383, 24);
            this._filterTypesImplementingINotifyPropertyChangedCheckBox.TabIndex = 4;
            this._filterTypesImplementingINotifyPropertyChangedCheckBox.Text = "Filter types implementing INotifyPropertyChanged";
            this._filterTypesImplementingINotifyPropertyChangedCheckBox.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.Location = new System.Drawing.Point(498, 469);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(116, 39);
            this._okButton.TabIndex = 5;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.Location = new System.Drawing.Point(620, 469);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(116, 39);
            this._cancelButton.TabIndex = 6;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _selectBindingSourceTemplateTypeLabel
            // 
            this._selectBindingSourceTemplateTypeLabel.AutoSize = true;
            this._selectBindingSourceTemplateTypeLabel.Location = new System.Drawing.Point(22, 127);
            this._selectBindingSourceTemplateTypeLabel.Name = "_selectBindingSourceTemplateTypeLabel";
            this._selectBindingSourceTemplateTypeLabel.Size = new System.Drawing.Size(265, 20);
            this._selectBindingSourceTemplateTypeLabel.TabIndex = 2;
            this._selectBindingSourceTemplateTypeLabel.Text = "Select binding source template type:";
            // 
            // _selectTileTemplateControlComboBox
            // 
            this._selectTileTemplateControlComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._selectTileTemplateControlComboBox.FormattingEnabled = true;
            this._selectTileTemplateControlComboBox.Location = new System.Drawing.Point(26, 63);
            this._selectTileTemplateControlComboBox.Name = "_selectTileTemplateControlComboBox";
            this._selectTileTemplateControlComboBox.Size = new System.Drawing.Size(710, 28);
            this._selectTileTemplateControlComboBox.TabIndex = 1;
            // 
            // _selectTileTemplateControlLabel
            // 
            this._selectTileTemplateControlLabel.AutoSize = true;
            this._selectTileTemplateControlLabel.Location = new System.Drawing.Point(22, 40);
            this._selectTileTemplateControlLabel.Name = "_selectTileTemplateControlLabel";
            this._selectTileTemplateControlLabel.Size = new System.Drawing.Size(208, 20);
            this._selectTileTemplateControlLabel.TabIndex = 0;
            this._selectTileTemplateControlLabel.Text = "Select Tile Template control:";
            // 
            // TileRepeaterTemplateAssignmentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 518);
            this.Controls.Add(this._selectTileTemplateControlLabel);
            this.Controls.Add(this._selectTileTemplateControlComboBox);
            this.Controls.Add(this._selectBindingSourceTemplateTypeLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._filterTypesImplementingINotifyPropertyChangedCheckBox);
            this.Controls.Add(this._selectBindingSourceTemplateTypeListBox);
            this.MinimumSize = new System.Drawing.Size(540, 460);
            this.Name = "TileRepeaterTemplateAssignmentDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Template Types";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _selectBindingSourceTemplateTypeListBox;
        private System.Windows.Forms.CheckBox _filterTypesImplementingINotifyPropertyChangedCheckBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _selectBindingSourceTemplateTypeLabel;
        private System.Windows.Forms.ComboBox _selectTileTemplateControlComboBox;
        private System.Windows.Forms.Label _selectTileTemplateControlLabel;
    }
}
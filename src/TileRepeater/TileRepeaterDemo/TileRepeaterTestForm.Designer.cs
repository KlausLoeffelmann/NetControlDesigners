using WinForms.Tiles;

namespace TileRepeaterDemo
{
    partial class TileRepeaterTestForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TemplateAssignmentItems templateAssignmentItems1 = new TemplateAssignmentItems();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this._pictureTileRepeater = new WinForms.Tiles.TileRepeater();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._setPathToImageFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._imagePathStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(360, 109);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 91);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 67);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _pictureTileRepeater
            // 
            this._pictureTileRepeater.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pictureTileRepeater.DataSource = null;
            this._pictureTileRepeater.Location = new System.Drawing.Point(0, 31);
            this._pictureTileRepeater.Name = "_pictureTileRepeater";
            this._pictureTileRepeater.Size = new System.Drawing.Size(1050, 605);
            this._pictureTileRepeater.TabIndex = 0;
            this._pictureTileRepeater.TemplateControl = null;
            templateAssignmentItems1.Add(new WinForms.Tiles.TemplateAssignmentItem("Template: LandscapePictureItem/Content: LandscapeImageContent", new WinForms.Tiles.TemplateAssignment(Type.GetType("TileRepeater.Data.ListController.LandscapePictureItem, TileRepeater.Data, Version" +
                    "=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Type.GetType("TileRepeaterDemo.TileTemplates.LandscapeImageContent, TileRepeaterDemo, Version=1" +
                    ".0.0.0, Culture=neutral, PublicKeyToken=null"))));
            templateAssignmentItems1.Add(new WinForms.Tiles.TemplateAssignmentItem("Template: PortraitPictureItem/Content: PortraitImageContent", new WinForms.Tiles.TemplateAssignment(Type.GetType("TileRepeater.Data.ListController.PortraitPictureItem, TileRepeater.Data, Version=" +
                    "1.0.0.0, Culture=neutral, PublicKeyToken=null"), Type.GetType("TileRepeaterDemo.TileTemplates.PortraitImageContent, TileRepeaterDemo, Version=1." +
                    "0.0.0, Culture=neutral, PublicKeyToken=null"))));
            this._pictureTileRepeater.TemplateTypes = templateAssignmentItems1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1050, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._setPathToImageFilesToolStripMenuItem,
            this.toolStripMenuItem1,
            this._quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // _setPathToImageFilesToolStripMenuItem
            // 
            this._setPathToImageFilesToolStripMenuItem.Name = "_setPathToImageFilesToolStripMenuItem";
            this._setPathToImageFilesToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this._setPathToImageFilesToolStripMenuItem.Text = "Set path to Image files...";
            this._setPathToImageFilesToolStripMenuItem.Click += new System.EventHandler(this.SetPathToImageFilesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(248, 6);
            // 
            // _quitToolStripMenuItem
            // 
            this._quitToolStripMenuItem.Name = "_quitToolStripMenuItem";
            this._quitToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this._quitToolStripMenuItem.Text = "Quit";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._imagePathStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1050, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _imagePathStatusLabel
            // 
            this._imagePathStatusLabel.Name = "_imagePathStatusLabel";
            this._imagePathStatusLabel.Size = new System.Drawing.Size(1035, 20);
            this._imagePathStatusLabel.Spring = true;
            this._imagePathStatusLabel.Text = "ImagePath";
            // 
            // TileRepeaterTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 665);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._pictureTileRepeater);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TileRepeaterTestForm";
            this.Text = "WinForms PictureViewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button2;
        private Button button1;
        private WinForms.Tiles.TileRepeater _pictureTileRepeater;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem _setPathToImageFilesToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem _quitToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel _imagePathStatusLabel;
    }
}
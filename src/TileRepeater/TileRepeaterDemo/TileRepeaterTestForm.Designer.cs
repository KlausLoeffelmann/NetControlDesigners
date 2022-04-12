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
            this.components = new System.ComponentModel.Container();
            TemplateAssignmentItems templateAssignmentItems1 = new TemplateAssignmentItems();
            this._pictureTileRepeater = new WinForms.Tiles.TileRepeater();
            this._uiControllerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._setPathToImageFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._imagePathStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._templateItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._uiControllerBindingSource)).BeginInit();
            this._mainMenuStrip.SuspendLayout();
            this._statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._templateItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _pictureTileRepeater
            // 
            this._pictureTileRepeater.AutoScroll = true;
            this._pictureTileRepeater.DataSource = this._templateItemsBindingSource;
            this._pictureTileRepeater.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pictureTileRepeater.Location = new System.Drawing.Point(0, 28);
            this._pictureTileRepeater.Name = "_pictureTileRepeater";
            this._pictureTileRepeater.Size = new System.Drawing.Size(946, 624);
            this._pictureTileRepeater.TabIndex = 0;
            templateAssignmentItems1.Add(new WinForms.Tiles.TemplateAssignmentItem("GenericTemplateItem/GroupSeperatorContent", new WinForms.Tiles.TemplateAssignment(Type.GetType("TileRepeater.Data.ListController.GenericTemplateItem, TileRepeater.Data, Version=" +
                    "1.0.0.0, Culture=neutral, PublicKeyToken=null"), Type.GetType("TileRepeaterDemo.TileTemplates.GroupSeperatorContent, TileRepeaterDemo, Version=1" +
                    ".0.0.0, Culture=neutral, PublicKeyToken=null"))));
            templateAssignmentItems1.Add(new WinForms.Tiles.TemplateAssignmentItem("LandscapePictureItem/LandscapeImageContent", new WinForms.Tiles.TemplateAssignment(Type.GetType("TileRepeater.Data.ListController.LandscapePictureItem, TileRepeater.Data, Version" +
                    "=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Type.GetType("TileRepeaterDemo.TileTemplates.LandscapeImageContent, TileRepeaterDemo, Version=1" +
                    ".0.0.0, Culture=neutral, PublicKeyToken=null"))));
            templateAssignmentItems1.Add(new WinForms.Tiles.TemplateAssignmentItem("PortraitPictureItem/PortraitImageContent", new WinForms.Tiles.TemplateAssignment(Type.GetType("TileRepeater.Data.ListController.PortraitPictureItem, TileRepeater.Data, Version=" +
                    "1.0.0.0, Culture=neutral, PublicKeyToken=null"), Type.GetType("TileRepeaterDemo.TileTemplates.PortraitImageContent, TileRepeaterDemo, Version=1." +
                    "0.0.0, Culture=neutral, PublicKeyToken=null"))));
            this._pictureTileRepeater.TemplateTypes = templateAssignmentItems1;
            // 
            // _uiControllerBindingSource
            // 
            this._uiControllerBindingSource.DataSource = typeof(TileRepeater.Data.ListController.UIController);
            // 
            // _mainMenuStrip
            // 
            this._mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this._mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this._mainMenuStrip.Name = "_mainMenuStrip";
            this._mainMenuStrip.Size = new System.Drawing.Size(946, 28);
            this._mainMenuStrip.TabIndex = 1;
            this._mainMenuStrip.Text = "menuStrip1";
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
            // _statusStrip
            // 
            this._statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._imagePathStatusLabel});
            this._statusStrip.Location = new System.Drawing.Point(0, 652);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(946, 26);
            this._statusStrip.TabIndex = 2;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _imagePathStatusLabel
            // 
            this._imagePathStatusLabel.Name = "_imagePathStatusLabel";
            this._imagePathStatusLabel.Size = new System.Drawing.Size(931, 20);
            this._imagePathStatusLabel.Spring = true;
            this._imagePathStatusLabel.Text = "ImagePath";
            // 
            // _templateItemsBindingSource
            // 
            this._templateItemsBindingSource.DataMember = "TemplateItems";
            this._templateItemsBindingSource.DataSource = this._uiControllerBindingSource;
            // 
            // TileRepeaterTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 678);
            this.Controls.Add(this._pictureTileRepeater);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._mainMenuStrip);
            this.MainMenuStrip = this._mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TileRepeaterTestForm";
            this.Text = "WinForms PictureViewer";
            ((System.ComponentModel.ISupportInitialize)(this._uiControllerBindingSource)).EndInit();
            this._mainMenuStrip.ResumeLayout(false);
            this._mainMenuStrip.PerformLayout();
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._templateItemsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinForms.Tiles.TileRepeater _pictureTileRepeater;
        private MenuStrip _mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem _setPathToImageFilesToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem _quitToolStripMenuItem;
        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _imagePathStatusLabel;
        private BindingSource _uiControllerBindingSource;
        private BindingSource _templateItemsBindingSource;
    }
}
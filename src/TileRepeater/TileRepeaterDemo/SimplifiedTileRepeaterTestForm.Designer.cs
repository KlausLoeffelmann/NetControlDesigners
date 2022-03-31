namespace TileRepeaterDemo
{
    partial class SimplifiedTileRepeaterTestForm
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
            this.simpleTileRepeater1 = new WinForms.Tiles.Simplified.SimpleTileRepeater();
            this.simpleTileRepeater2 = new WinForms.Tiles.Simplified.SimpleTileRepeater();
            this.SuspendLayout();
            // 
            // simpleTileRepeater1
            // 
            this.simpleTileRepeater1.ContentTemplate = null;
            this.simpleTileRepeater1.DataSource = null;
            this.simpleTileRepeater1.Location = new System.Drawing.Point(0, 0);
            this.simpleTileRepeater1.Name = "simpleTileRepeater1";
            this.simpleTileRepeater1.TabIndex = 0;
            // 
            // simpleTileRepeater2
            // 
            this.simpleTileRepeater2.ContentTemplate = null;
            this.simpleTileRepeater2.DataSource = null;
            this.simpleTileRepeater2.Location = new System.Drawing.Point(0, 0);
            this.simpleTileRepeater2.Name = "simpleTileRepeater2";
            this.simpleTileRepeater2.TabIndex = 0;
            // 
            // SimplifiedTileRepeaterTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 669);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SimplifiedTileRepeaterTestForm";
            this.Text = "UnrelatedTestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private WinForms.Tiles.Simplified.SimpleTileRepeater simpleTileRepeater1;
        private WinForms.Tiles.Simplified.SimpleTileRepeater simpleTileRepeater2;
    }
}
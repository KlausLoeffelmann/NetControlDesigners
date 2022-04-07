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
            WinForms.Tiles.Simplified.SimpleTileRepeater.TileContentTemplate tileContentTemplate1 = new WinForms.Tiles.Simplified.SimpleTileRepeater.TileContentTemplate();
            this.simpleTileRepeater1 = new WinForms.Tiles.Simplified.SimpleTileRepeater();
            this.SuspendLayout();
            // 
            // simpleTileRepeater1
            // 
            tileContentTemplate1.TileContentType = typeof(WinForms.Tiles.Simplified.TileContent);
            this.simpleTileRepeater1.ContentTemplate = tileContentTemplate1;
            this.simpleTileRepeater1.DataSource = null;
            this.simpleTileRepeater1.Location = new System.Drawing.Point(63, 58);
            this.simpleTileRepeater1.Name = "simpleTileRepeater1";
            this.simpleTileRepeater1.Size = new System.Drawing.Size(560, 447);
            this.simpleTileRepeater1.TabIndex = 0;
            // 
            // SimplifiedTileRepeaterTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 856);
            this.Controls.Add(this.simpleTileRepeater1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SimplifiedTileRepeaterTestForm";
            this.Text = "UnrelatedTestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private WinForms.Tiles.Simplified.SimpleTileRepeater simpleTileRepeater1;
    }
}
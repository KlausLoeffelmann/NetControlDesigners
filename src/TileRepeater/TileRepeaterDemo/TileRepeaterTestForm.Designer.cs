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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tileRepeater1 = new WinForms.Tiles.TileRepeater();
            this.button3 = new System.Windows.Forms.Button();
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
            // tileRepeater1
            // 
            this.tileRepeater1.DataSource = null;
            this.tileRepeater1.HeaderTemplateType.TemplateType = typeof(WinForms.Tiles.Tile);
            this.tileRepeater1.HeaderTemplateType.TileContentControlType = typeof(TileRepeaterDemo.TileTemplates.LandscapeImageContent);
            this.tileRepeater1.Location = new System.Drawing.Point(27, 46);
            this.tileRepeater1.Margin = new System.Windows.Forms.Padding(4);
            this.tileRepeater1.Name = "tileRepeater1";
            this.tileRepeater1.Size = new System.Drawing.Size(1131, 574);
            this.tileRepeater1.TabIndex = 0;
            this.tileRepeater1.TemplateControl = null;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(327, 702);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(218, 50);
            this.button3.TabIndex = 1;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // TileRepeaterTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 770);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tileRepeater1);
            this.Name = "TileRepeaterTestForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button2;
        private Button button1;
        private WinForms.Tiles.TileRepeater tileRepeater1;
        private Button button3;
    }
}
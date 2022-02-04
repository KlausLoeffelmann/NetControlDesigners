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
            this.tileRepeater1 = new WinForms.Tiles.TileRepeater();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tileRepeater1
            // 
            this.tileRepeater1.DataSource = null;
            this.tileRepeater1.Location = new System.Drawing.Point(23, 12);
            this.tileRepeater1.MainHeaderTemplateType = null;
            this.tileRepeater1.Name = "tileRepeater1";
            this.tileRepeater1.Size = new System.Drawing.Size(748, 405);
            this.tileRepeater1.TabIndex = 0;
            this.tileRepeater1.TemplateControl = null;
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
            // TileRepeaterTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tileRepeater1);
            this.Name = "TileRepeaterTestForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WinForms.Tiles.TileRepeater tileRepeater1;
        private Button button2;
        private Button button1;
    }
}
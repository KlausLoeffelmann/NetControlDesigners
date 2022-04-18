namespace TileRepeaterDemo
{
    partial class GenericTestForm
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
            this.fooBarControl1 = new TileRepeater.Controls.Simplified.FooBarControl();
            this.fooBarControl2 = new TileRepeater.Controls.Simplified.FooBarControl();
            this.SuspendLayout();
            // 
            // fooBarControl1
            // 
            this.fooBarControl1.Filename = null;
            this.fooBarControl1.Location = new System.Drawing.Point(100, 97);
            this.fooBarControl1.Name = "fooBarControl1";
            this.fooBarControl1.Size = new System.Drawing.Size(541, 296);
            this.fooBarControl1.SpecialColor = System.Drawing.Color.Empty;
            this.fooBarControl1.TabIndex = 0;
            this.fooBarControl1.Text = "fooBarControl1";
            // 
            // fooBarControl2
            // 
            this.fooBarControl2.Filename = null;
            this.fooBarControl2.Location = new System.Drawing.Point(153, 90);
            this.fooBarControl2.Name = "fooBarControl2";
            this.fooBarControl2.Size = new System.Drawing.Size(475, 240);
            this.fooBarControl2.SpecialColor = System.Drawing.Color.Empty;
            this.fooBarControl2.TabIndex = 1;
            this.fooBarControl2.Text = "fooBarControl2";
            // 
            // GenericTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fooBarControl2);
            this.Controls.Add(this.fooBarControl1);
            this.Name = "GenericTestForm";
            this.Text = "GenericTestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private TileRepeater.Controls.Simplified.FooBarControl fooBarControl1;
        private TileRepeater.Controls.Simplified.FooBarControl fooBarControl2;
    }
}
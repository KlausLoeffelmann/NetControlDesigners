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
            Type templateType1;
            Type tileContentType1;
            TemplateAssignmentItems templateAssignmentItems1 = new TemplateAssignmentItems();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tileRepeater1 = new WinForms.Tiles.TileRepeater();
            this.button3 = new System.Windows.Forms.Button();
            templateType1 = Type.GetType("TileRepeater.Data.ListController.LandscapePictureItem, TileRepeater.Data, Version" +
        "=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            tileContentType1 = Type.GetType("TileRepeaterDemo.TileTemplates.LandscapeImageContent, TileRepeaterDemo, Version=1" +
        ".0.0.0, Culture=neutral, PublicKeyToken=null");
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
            this.tileRepeater1.HeaderTemplateType = new WinForms.Tiles.TemplateAssignment(templateType1, tileContentType1);
            this.tileRepeater1.Location = new System.Drawing.Point(12, 12);
            this.tileRepeater1.Name = "tileRepeater1";
            this.tileRepeater1.Size = new System.Drawing.Size(809, 353);
            this.tileRepeater1.TabIndex = 0;
            this.tileRepeater1.TemplateControl = null;
            templateAssignmentItems1.Add(new WinForms.Tiles.TemplateAssignmentItem("Template: LandscapePictureItem/Content: LandscapeImageContent", new WinForms.Tiles.TemplateAssignment(Type.GetType("TileRepeater.Data.ListController.LandscapePictureItem, TileRepeater.Data, Version" +
                    "=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Type.GetType("TileRepeaterDemo.TileTemplates.LandscapeImageContent, TileRepeaterDemo, Version=1" +
                    ".0.0.0, Culture=neutral, PublicKeyToken=null"))));
            templateAssignmentItems1.Add(new WinForms.Tiles.TemplateAssignmentItem("Template: PortraitPictureItem/Content: PortraitImageContent", new WinForms.Tiles.TemplateAssignment(Type.GetType("TileRepeater.Data.ListController.PortraitPictureItem, TileRepeater.Data, Version=" +
                    "1.0.0.0, Culture=neutral, PublicKeyToken=null"), Type.GetType("TileRepeaterDemo.TileTemplates.PortraitImageContent, TileRepeaterDemo, Version=1." +
                    "0.0.0, Culture=neutral, PublicKeyToken=null"))));
            this.tileRepeater1.TemplateTypes = templateAssignmentItems1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(349, 464);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 37);
            this.button3.TabIndex = 1;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TileRepeaterTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 513);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tileRepeater1);
            this.Margin = new System.Windows.Forms.Padding(2);
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
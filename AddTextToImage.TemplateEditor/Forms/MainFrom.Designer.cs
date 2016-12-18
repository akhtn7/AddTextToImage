namespace AddTextToImage.TemplateEditor.Forms
{
    partial class MainFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrom));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnTextGalleryShow = new System.Windows.Forms.ToolStripButton();
            this.tsbtnClipartGalleryShow = new System.Windows.Forms.ToolStripButton();
            this.tsbtnModelToSampleShow = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFontsShow = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnTextGalleryShow,
            this.tsbtnClipartGalleryShow,
            this.tsbtnModelToSampleShow,
            this.tsbtnFontsShow});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(493, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnTextGalleryShow
            // 
            this.tsbtnTextGalleryShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnTextGalleryShow.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTextGalleryShow.Image")));
            this.tsbtnTextGalleryShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTextGalleryShow.Name = "tsbtnTextGalleryShow";
            this.tsbtnTextGalleryShow.Size = new System.Drawing.Size(125, 22);
            this.tsbtnTextGalleryShow.Text = "Text Template Gallery";
            this.tsbtnTextGalleryShow.Click += new System.EventHandler(this.tsbtnTextGalleryShow_Click);
            // 
            // tsbtnClipartGalleryShow
            // 
            this.tsbtnClipartGalleryShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnClipartGalleryShow.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClipartGalleryShow.Image")));
            this.tsbtnClipartGalleryShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClipartGalleryShow.Name = "tsbtnClipartGalleryShow";
            this.tsbtnClipartGalleryShow.Size = new System.Drawing.Size(85, 22);
            this.tsbtnClipartGalleryShow.Text = "Clipart Gallery";
            this.tsbtnClipartGalleryShow.Click += new System.EventHandler(this.tsbtnClipartGalleryShow_Click);
            // 
            // tsbtnModelToSampleShow
            // 
            this.tsbtnModelToSampleShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnModelToSampleShow.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnModelToSampleShow.Image")));
            this.tsbtnModelToSampleShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnModelToSampleShow.Name = "tsbtnModelToSampleShow";
            this.tsbtnModelToSampleShow.Size = new System.Drawing.Size(101, 22);
            this.tsbtnModelToSampleShow.Text = "Model to Sample";
            this.tsbtnModelToSampleShow.Click += new System.EventHandler(this.tsbtnModelToSampleShow_Click);
            // 
            // tsbtnFontsShow
            // 
            this.tsbtnFontsShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnFontsShow.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFontsShow.Image")));
            this.tsbtnFontsShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFontsShow.Name = "tsbtnFontsShow";
            this.tsbtnFontsShow.Size = new System.Drawing.Size(40, 22);
            this.tsbtnFontsShow.Text = "Fonts";
            this.tsbtnFontsShow.Click += new System.EventHandler(this.tsbtnFontsShow_Click);
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 109);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFrom";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Template Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnTextGalleryShow;
        private System.Windows.Forms.ToolStripButton tsbtnClipartGalleryShow;
        private System.Windows.Forms.ToolStripButton tsbtnModelToSampleShow;
        private System.Windows.Forms.ToolStripButton tsbtnFontsShow;
    }
}


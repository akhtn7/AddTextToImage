namespace AddTextToImage.TemplateEditor.Forms
{
    partial class TemplateClipartGalleryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateClipartGalleryForm));
            this.ddlTemplateGallery = new System.Windows.Forms.ComboBox();
            this.lvCliparts = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnClipartTemplateAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnTemplateEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlTemplateGallery
            // 
            this.ddlTemplateGallery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTemplateGallery.FormattingEnabled = true;
            this.ddlTemplateGallery.Location = new System.Drawing.Point(60, 47);
            this.ddlTemplateGallery.Name = "ddlTemplateGallery";
            this.ddlTemplateGallery.Size = new System.Drawing.Size(176, 21);
            this.ddlTemplateGallery.TabIndex = 1;
            this.ddlTemplateGallery.SelectionChangeCommitted += new System.EventHandler(this.ddlTemplateGallery_SelectionChangeCommitted);
            // 
            // lvCliparts
            // 
            this.lvCliparts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCliparts.Location = new System.Drawing.Point(0, 87);
            this.lvCliparts.MultiSelect = false;
            this.lvCliparts.Name = "lvCliparts";
            this.lvCliparts.Size = new System.Drawing.Size(862, 401);
            this.lvCliparts.TabIndex = 3;
            this.lvCliparts.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Gallery:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClipartTemplateAdd,
            this.toolStripSeparator1,
            this.tsbtnTemplateEdit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(862, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnClipartTemplateAdd
            // 
            this.tsbtnClipartTemplateAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnClipartTemplateAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClipartTemplateAdd.Image")));
            this.tsbtnClipartTemplateAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClipartTemplateAdd.Name = "tsbtnClipartTemplateAdd";
            this.tsbtnClipartTemplateAdd.Size = new System.Drawing.Size(33, 22);
            this.tsbtnClipartTemplateAdd.Text = "Add";
            this.tsbtnClipartTemplateAdd.Click += new System.EventHandler(this.tsbtnClipartTemplateAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnTemplateEdit
            // 
            this.tsbtnTemplateEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnTemplateEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTemplateEdit.Image")));
            this.tsbtnTemplateEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTemplateEdit.Name = "tsbtnTemplateEdit";
            this.tsbtnTemplateEdit.Size = new System.Drawing.Size(31, 22);
            this.tsbtnTemplateEdit.Text = "Edit";
            this.tsbtnTemplateEdit.Click += new System.EventHandler(this.tsbtnTemplateEdit_Click);
            // 
            // TemplateClipartGalleryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 493);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCliparts);
            this.Controls.Add(this.ddlTemplateGallery);
            this.Name = "TemplateClipartGalleryForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Template Clipart Gallery";
            this.Load += new System.EventHandler(this.TemplateClipartGallery_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlTemplateGallery;
        private System.Windows.Forms.ListView lvCliparts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnClipartTemplateAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnTemplateEdit;
    }
}
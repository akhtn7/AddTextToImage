namespace AddTextToImage.TemplateEditor.Forms
{
    partial class TextGalleryFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextGalleryFrom));
            this.ddlTemplateGallery = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnTextTemplateAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTextTemplateEdit = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lvTextTemplates = new System.Windows.Forms.ListView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlTemplateGallery
            // 
            this.ddlTemplateGallery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTemplateGallery.FormattingEnabled = true;
            this.ddlTemplateGallery.Location = new System.Drawing.Point(68, 46);
            this.ddlTemplateGallery.Name = "ddlTemplateGallery";
            this.ddlTemplateGallery.Size = new System.Drawing.Size(162, 21);
            this.ddlTemplateGallery.TabIndex = 1;
            this.ddlTemplateGallery.SelectionChangeCommitted += new System.EventHandler(this.ddlTemplateGallery_SelectionChangeCommitted);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnTextTemplateAdd,
            this.toolStripSeparator1,
            this.btnTextTemplateEdit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(862, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnTextTemplateAdd
            // 
            this.tsbtnTextTemplateAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnTextTemplateAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTextTemplateAdd.Image")));
            this.tsbtnTextTemplateAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTextTemplateAdd.Name = "tsbtnTextTemplateAdd";
            this.tsbtnTextTemplateAdd.Size = new System.Drawing.Size(33, 22);
            this.tsbtnTextTemplateAdd.Text = "Add";
            this.tsbtnTextTemplateAdd.Click += new System.EventHandler(this.tsbtnTextTemplateAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTextTemplateEdit
            // 
            this.btnTextTemplateEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTextTemplateEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnTextTemplateEdit.Image")));
            this.btnTextTemplateEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTextTemplateEdit.Name = "btnTextTemplateEdit";
            this.btnTextTemplateEdit.Size = new System.Drawing.Size(31, 22);
            this.btnTextTemplateEdit.Text = "Edit";
            this.btnTextTemplateEdit.Click += new System.EventHandler(this.btnTextTemplateEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Gallery:";
            // 
            // lvTextTemplates
            // 
            this.lvTextTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTextTemplates.Location = new System.Drawing.Point(15, 90);
            this.lvTextTemplates.Name = "lvTextTemplates";
            this.lvTextTemplates.Size = new System.Drawing.Size(835, 339);
            this.lvTextTemplates.TabIndex = 7;
            this.lvTextTemplates.UseCompatibleStateImageBehavior = false;
            // 
            // TextGalleryFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 441);
            this.Controls.Add(this.lvTextTemplates);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ddlTemplateGallery);
            this.Name = "TextGalleryFrom";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Template Text Gallery";
            this.Load += new System.EventHandler(this.frmTemplateGallery_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlTemplateGallery;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnTextTemplateAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnTextTemplateEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvTextTemplates;
    }
}
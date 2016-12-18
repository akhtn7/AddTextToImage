namespace AddTextToImage.TemplateEditor.Forms
{
    partial class ModelToSampleListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelToSampleListForm));
            this.dgvModels = new System.Windows.Forms.DataGridView();
            this.ModelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnFirstPage = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPrevPage = new System.Windows.Forms.ToolStripButton();
            this.tsbtnNextPage = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLastPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnCopyModelToSample = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnModelPreview = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvModels
            // 
            this.dgvModels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModelId,
            this.ContentType,
            this.ImageWidth,
            this.ImageHeight,
            this.Image});
            this.dgvModels.Location = new System.Drawing.Point(0, 28);
            this.dgvModels.MultiSelect = false;
            this.dgvModels.Name = "dgvModels";
            this.dgvModels.RowTemplate.Height = 200;
            this.dgvModels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModels.Size = new System.Drawing.Size(925, 433);
            this.dgvModels.TabIndex = 0;
            // 
            // ModelId
            // 
            this.ModelId.DataPropertyName = "Id";
            this.ModelId.HeaderText = "ModelId";
            this.ModelId.Name = "ModelId";
            // 
            // ContentType
            // 
            this.ContentType.DataPropertyName = "ContentType";
            this.ContentType.HeaderText = "ContentType";
            this.ContentType.Name = "ContentType";
            // 
            // ImageWidth
            // 
            this.ImageWidth.DataPropertyName = "ImageWidth";
            this.ImageWidth.HeaderText = "Width";
            this.ImageWidth.Name = "ImageWidth";
            // 
            // ImageHeight
            // 
            this.ImageHeight.DataPropertyName = "ImageHeight";
            this.ImageHeight.HeaderText = "Height";
            this.ImageHeight.Name = "ImageHeight";
            // 
            // Image
            // 
            this.Image.DataPropertyName = "Image";
            this.Image.HeaderText = "Image";
            this.Image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Image.Name = "Image";
            this.Image.Width = 200;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnFirstPage,
            this.tsbtnPrevPage,
            this.tsbtnNextPage,
            this.tsbtnLastPage,
            this.toolStripSeparator1,
            this.tsbtnCopyModelToSample,
            this.toolStripSeparator2,
            this.tsbtnModelPreview});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(925, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnFirstPage
            // 
            this.tsbtnFirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnFirstPage.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFirstPage.Image")));
            this.tsbtnFirstPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFirstPage.Name = "tsbtnFirstPage";
            this.tsbtnFirstPage.Size = new System.Drawing.Size(62, 22);
            this.tsbtnFirstPage.Text = "First Page";
            this.tsbtnFirstPage.Click += new System.EventHandler(this.tsbtnFirstPage_Click);
            // 
            // tsbtnPrevPage
            // 
            this.tsbtnPrevPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnPrevPage.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPrevPage.Image")));
            this.tsbtnPrevPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPrevPage.Name = "tsbtnPrevPage";
            this.tsbtnPrevPage.Size = new System.Drawing.Size(85, 22);
            this.tsbtnPrevPage.Text = "Previous Page";
            this.tsbtnPrevPage.Click += new System.EventHandler(this.tsbtnPrevPage_Click);
            // 
            // tsbtnNextPage
            // 
            this.tsbtnNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnNextPage.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNextPage.Image")));
            this.tsbtnNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNextPage.Name = "tsbtnNextPage";
            this.tsbtnNextPage.Size = new System.Drawing.Size(64, 22);
            this.tsbtnNextPage.Text = "Next Page";
            this.tsbtnNextPage.Click += new System.EventHandler(this.tsbtnNextPage_Click);
            // 
            // tsbtnLastPage
            // 
            this.tsbtnLastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnLastPage.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLastPage.Image")));
            this.tsbtnLastPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLastPage.Name = "tsbtnLastPage";
            this.tsbtnLastPage.Size = new System.Drawing.Size(61, 22);
            this.tsbtnLastPage.Text = "Last Page";
            this.tsbtnLastPage.Click += new System.EventHandler(this.tsbtnLastPage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnCopyModelToSample
            // 
            this.tsbtnCopyModelToSample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnCopyModelToSample.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCopyModelToSample.Image")));
            this.tsbtnCopyModelToSample.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCopyModelToSample.Name = "tsbtnCopyModelToSample";
            this.tsbtnCopyModelToSample.Size = new System.Drawing.Size(132, 22);
            this.tsbtnCopyModelToSample.Text = "Copy Model to Sample";
            this.tsbtnCopyModelToSample.Click += new System.EventHandler(this.tsbtnCopyModelToSample_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnModelPreview
            // 
            this.tsbtnModelPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnModelPreview.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnModelPreview.Image")));
            this.tsbtnModelPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnModelPreview.Name = "tsbtnModelPreview";
            this.tsbtnModelPreview.Size = new System.Drawing.Size(52, 22);
            this.tsbtnModelPreview.Text = "Preview";
            this.tsbtnModelPreview.Click += new System.EventHandler(this.tsbtnModelPreview_Click);
            // 
            // ModelToSampleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 463);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvModels);
            this.MinimizeBox = false;
            this.Name = "ModelToSampleListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Model List";
            this.Load += new System.EventHandler(this.ModelToSampleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvModels;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnFirstPage;
        private System.Windows.Forms.ToolStripButton tsbtnNextPage;
        private System.Windows.Forms.ToolStripButton tsbtnPrevPage;
        private System.Windows.Forms.ToolStripButton tsbtnLastPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnCopyModelToSample;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageHeight;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnModelPreview;
    }
}
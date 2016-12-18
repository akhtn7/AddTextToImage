namespace AddTextToImage.TemplateEditor.Forms
{
    partial class FontListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontListForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnFontAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFontEdit = new System.Windows.Forms.ToolStripButton();
            this.dgvFonts = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsClipart = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFonts)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnFontAdd,
            this.tsbtnFontEdit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(647, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnFontAdd
            // 
            this.tsbtnFontAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnFontAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFontAdd.Image")));
            this.tsbtnFontAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFontAdd.Name = "tsbtnFontAdd";
            this.tsbtnFontAdd.Size = new System.Drawing.Size(33, 22);
            this.tsbtnFontAdd.Text = "Add";
            this.tsbtnFontAdd.Click += new System.EventHandler(this.tsbtnFontAdd_Click);
            // 
            // tsbtnFontEdit
            // 
            this.tsbtnFontEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnFontEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFontEdit.Image")));
            this.tsbtnFontEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFontEdit.Name = "tsbtnFontEdit";
            this.tsbtnFontEdit.Size = new System.Drawing.Size(31, 22);
            this.tsbtnFontEdit.Text = "Edit";
            // 
            // dgvFonts
            // 
            this.dgvFonts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFonts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFonts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.colName,
            this.FileName,
            this.IsClipart});
            this.dgvFonts.Location = new System.Drawing.Point(12, 28);
            this.dgvFonts.MultiSelect = false;
            this.dgvFonts.Name = "dgvFonts";
            this.dgvFonts.ReadOnly = true;
            this.dgvFonts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFonts.Size = new System.Drawing.Size(623, 421);
            this.dgvFonts.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 200;
            // 
            // IsClipart
            // 
            this.IsClipart.DataPropertyName = "IsClipart";
            this.IsClipart.HeaderText = "Clipart";
            this.IsClipart.Name = "IsClipart";
            this.IsClipart.ReadOnly = true;
            this.IsClipart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsClipart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FontListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 461);
            this.Controls.Add(this.dgvFonts);
            this.Controls.Add(this.toolStrip1);
            this.MinimizeBox = false;
            this.Name = "FontListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Font List";
            this.Load += new System.EventHandler(this.FontListForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFonts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dgvFonts;
        private System.Windows.Forms.ToolStripButton tsbtnFontAdd;
        private System.Windows.Forms.ToolStripButton tsbtnFontEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsClipart;
    }
}
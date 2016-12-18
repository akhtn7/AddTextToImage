namespace AddTextToImage.TemplateEditor.Forms
{
    partial class TemplateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ddlEffectType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnTextColor1DialogShow = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblTextColor2DialogShow = new System.Windows.Forms.Label();
            this.btnTextColor2DialogShow = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblOutlineColor1DialogShow = new System.Windows.Forms.Label();
            this.btnOutlineColor1DialogShow = new System.Windows.Forms.Button();
            this.lblOutlineAlpha1 = new System.Windows.Forms.Label();
            this.lblOutlineThickness1 = new System.Windows.Forms.Label();
            this.lblOutlineThickness2 = new System.Windows.Forms.Label();
            this.lblOutlineAlpha2 = new System.Windows.Forms.Label();
            this.lblOutlineColor2DialogShow = new System.Windows.Forms.Label();
            this.btnOutlineColor2DialogShow = new System.Windows.Forms.Button();
            this.lblShadowThickness = new System.Windows.Forms.Label();
            this.lblShadowAlpha = new System.Windows.Forms.Label();
            this.lblShadowColorDialogShow = new System.Windows.Forms.Label();
            this.btnShadowColorDialogShow = new System.Windows.Forms.Button();
            this.lblShadowOffsetY = new System.Windows.Forms.Label();
            this.lblShadowOffsetX = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudFontSize = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.ddlFonts = new System.Windows.Forms.ComboBox();
            this.nudOutlineAlpha1 = new System.Windows.Forms.NumericUpDown();
            this.cbTextGradientEnable = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cbShadowEnable = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.nudOutlineAlpha2 = new System.Windows.Forms.NumericUpDown();
            this.nudShadowAlpha = new System.Windows.Forms.NumericUpDown();
            this.nudOutlineThickness1 = new System.Windows.Forms.NumericUpDown();
            this.nudOutlineThickness2 = new System.Windows.Forms.NumericUpDown();
            this.nudShadowThickness = new System.Windows.Forms.NumericUpDown();
            this.nudShadowOffsetX = new System.Windows.Forms.NumericUpDown();
            this.nudShadowOffsetY = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.lbldWidth = new System.Windows.Forms.Label();
            this.lbldHeight = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutlineAlpha1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutlineAlpha2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutlineThickness1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutlineThickness2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowOffsetY)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text Effect:";
            // 
            // ddlEffectType
            // 
            this.ddlEffectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEffectType.FormattingEnabled = true;
            this.ddlEffectType.Items.AddRange(new object[] {
            "No Outline",
            "Single Outline",
            "Double Outline",
            "Text Grow",
            "Double Text Grow",
            "Gradient Outline"});
            this.ddlEffectType.Location = new System.Drawing.Point(417, 26);
            this.ddlEffectType.Name = "ddlEffectType";
            this.ddlEffectType.Size = new System.Drawing.Size(182, 21);
            this.ddlEffectType.TabIndex = 1;
            this.ddlEffectType.SelectionChangeCommitted += new System.EventHandler(this.ddlEffectType_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(118, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(204, 20);
            this.txtName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Text:";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(118, 69);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(204, 20);
            this.txtText.TabIndex = 5;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // btnTextColor1DialogShow
            // 
            this.btnTextColor1DialogShow.BackColor = System.Drawing.Color.Red;
            this.btnTextColor1DialogShow.Location = new System.Drawing.Point(118, 108);
            this.btnTextColor1DialogShow.Name = "btnTextColor1DialogShow";
            this.btnTextColor1DialogShow.Size = new System.Drawing.Size(75, 23);
            this.btnTextColor1DialogShow.TabIndex = 6;
            this.btnTextColor1DialogShow.UseVisualStyleBackColor = false;
            this.btnTextColor1DialogShow.Click += new System.EventHandler(this.btnTextColor1DialogShow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Text Color:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(779, 497);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblTextColor2DialogShow
            // 
            this.lblTextColor2DialogShow.AutoSize = true;
            this.lblTextColor2DialogShow.Location = new System.Drawing.Point(24, 155);
            this.lblTextColor2DialogShow.Name = "lblTextColor2DialogShow";
            this.lblTextColor2DialogShow.Size = new System.Drawing.Size(67, 13);
            this.lblTextColor2DialogShow.TabIndex = 11;
            this.lblTextColor2DialogShow.Text = "Text Color 2:";
            // 
            // btnTextColor2DialogShow
            // 
            this.btnTextColor2DialogShow.BackColor = System.Drawing.Color.Tomato;
            this.btnTextColor2DialogShow.Location = new System.Drawing.Point(118, 150);
            this.btnTextColor2DialogShow.Name = "btnTextColor2DialogShow";
            this.btnTextColor2DialogShow.Size = new System.Drawing.Size(75, 23);
            this.btnTextColor2DialogShow.TabIndex = 10;
            this.btnTextColor2DialogShow.UseVisualStyleBackColor = false;
            this.btnTextColor2DialogShow.Click += new System.EventHandler(this.btnTextColor2DialogShow_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(874, 497);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblOutlineColor1DialogShow
            // 
            this.lblOutlineColor1DialogShow.AutoSize = true;
            this.lblOutlineColor1DialogShow.Location = new System.Drawing.Point(24, 194);
            this.lblOutlineColor1DialogShow.Name = "lblOutlineColor1DialogShow";
            this.lblOutlineColor1DialogShow.Size = new System.Drawing.Size(76, 13);
            this.lblOutlineColor1DialogShow.TabIndex = 14;
            this.lblOutlineColor1DialogShow.Text = "Outline Color1:";
            // 
            // btnOutlineColor1DialogShow
            // 
            this.btnOutlineColor1DialogShow.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOutlineColor1DialogShow.Location = new System.Drawing.Point(118, 189);
            this.btnOutlineColor1DialogShow.Name = "btnOutlineColor1DialogShow";
            this.btnOutlineColor1DialogShow.Size = new System.Drawing.Size(75, 23);
            this.btnOutlineColor1DialogShow.TabIndex = 13;
            this.btnOutlineColor1DialogShow.UseVisualStyleBackColor = false;
            this.btnOutlineColor1DialogShow.Click += new System.EventHandler(this.btnOutlineColor1DialogShow_Click);
            // 
            // lblOutlineAlpha1
            // 
            this.lblOutlineAlpha1.AutoSize = true;
            this.lblOutlineAlpha1.Location = new System.Drawing.Point(215, 194);
            this.lblOutlineAlpha1.Name = "lblOutlineAlpha1";
            this.lblOutlineAlpha1.Size = new System.Drawing.Size(43, 13);
            this.lblOutlineAlpha1.TabIndex = 15;
            this.lblOutlineAlpha1.Text = "Alpha1:";
            // 
            // lblOutlineThickness1
            // 
            this.lblOutlineThickness1.AutoSize = true;
            this.lblOutlineThickness1.Location = new System.Drawing.Point(334, 194);
            this.lblOutlineThickness1.Name = "lblOutlineThickness1";
            this.lblOutlineThickness1.Size = new System.Drawing.Size(65, 13);
            this.lblOutlineThickness1.TabIndex = 17;
            this.lblOutlineThickness1.Text = "Thickness1:";
            // 
            // lblOutlineThickness2
            // 
            this.lblOutlineThickness2.AutoSize = true;
            this.lblOutlineThickness2.Location = new System.Drawing.Point(334, 233);
            this.lblOutlineThickness2.Name = "lblOutlineThickness2";
            this.lblOutlineThickness2.Size = new System.Drawing.Size(65, 13);
            this.lblOutlineThickness2.TabIndex = 23;
            this.lblOutlineThickness2.Text = "Thickness2:";
            // 
            // lblOutlineAlpha2
            // 
            this.lblOutlineAlpha2.AutoSize = true;
            this.lblOutlineAlpha2.Location = new System.Drawing.Point(215, 233);
            this.lblOutlineAlpha2.Name = "lblOutlineAlpha2";
            this.lblOutlineAlpha2.Size = new System.Drawing.Size(43, 13);
            this.lblOutlineAlpha2.TabIndex = 21;
            this.lblOutlineAlpha2.Text = "Alpha2:";
            // 
            // lblOutlineColor2DialogShow
            // 
            this.lblOutlineColor2DialogShow.AutoSize = true;
            this.lblOutlineColor2DialogShow.Location = new System.Drawing.Point(24, 233);
            this.lblOutlineColor2DialogShow.Name = "lblOutlineColor2DialogShow";
            this.lblOutlineColor2DialogShow.Size = new System.Drawing.Size(76, 13);
            this.lblOutlineColor2DialogShow.TabIndex = 20;
            this.lblOutlineColor2DialogShow.Text = "Outline Color2:";
            // 
            // btnOutlineColor2DialogShow
            // 
            this.btnOutlineColor2DialogShow.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnOutlineColor2DialogShow.Location = new System.Drawing.Point(118, 228);
            this.btnOutlineColor2DialogShow.Name = "btnOutlineColor2DialogShow";
            this.btnOutlineColor2DialogShow.Size = new System.Drawing.Size(75, 23);
            this.btnOutlineColor2DialogShow.TabIndex = 19;
            this.btnOutlineColor2DialogShow.UseVisualStyleBackColor = false;
            this.btnOutlineColor2DialogShow.Click += new System.EventHandler(this.btnOutlineColor2DialogShow_Click);
            // 
            // lblShadowThickness
            // 
            this.lblShadowThickness.AutoSize = true;
            this.lblShadowThickness.Location = new System.Drawing.Point(334, 276);
            this.lblShadowThickness.Name = "lblShadowThickness";
            this.lblShadowThickness.Size = new System.Drawing.Size(59, 13);
            this.lblShadowThickness.TabIndex = 29;
            this.lblShadowThickness.Text = "Thickness:";
            // 
            // lblShadowAlpha
            // 
            this.lblShadowAlpha.AutoSize = true;
            this.lblShadowAlpha.Location = new System.Drawing.Point(215, 276);
            this.lblShadowAlpha.Name = "lblShadowAlpha";
            this.lblShadowAlpha.Size = new System.Drawing.Size(37, 13);
            this.lblShadowAlpha.TabIndex = 27;
            this.lblShadowAlpha.Text = "Alpha:";
            // 
            // lblShadowColorDialogShow
            // 
            this.lblShadowColorDialogShow.AutoSize = true;
            this.lblShadowColorDialogShow.Location = new System.Drawing.Point(24, 276);
            this.lblShadowColorDialogShow.Name = "lblShadowColorDialogShow";
            this.lblShadowColorDialogShow.Size = new System.Drawing.Size(76, 13);
            this.lblShadowColorDialogShow.TabIndex = 26;
            this.lblShadowColorDialogShow.Text = "Shadow Color:";
            // 
            // btnShadowColorDialogShow
            // 
            this.btnShadowColorDialogShow.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnShadowColorDialogShow.Location = new System.Drawing.Point(118, 271);
            this.btnShadowColorDialogShow.Name = "btnShadowColorDialogShow";
            this.btnShadowColorDialogShow.Size = new System.Drawing.Size(75, 23);
            this.btnShadowColorDialogShow.TabIndex = 25;
            this.btnShadowColorDialogShow.UseVisualStyleBackColor = false;
            this.btnShadowColorDialogShow.Click += new System.EventHandler(this.btnShadowColorDialogShow_Click);
            // 
            // lblShadowOffsetY
            // 
            this.lblShadowOffsetY.AutoSize = true;
            this.lblShadowOffsetY.Location = new System.Drawing.Point(662, 276);
            this.lblShadowOffsetY.Name = "lblShadowOffsetY";
            this.lblShadowOffsetY.Size = new System.Drawing.Size(90, 13);
            this.lblShadowOffsetY.TabIndex = 33;
            this.lblShadowOffsetY.Text = "Shadow OffsetY::";
            // 
            // lblShadowOffsetX
            // 
            this.lblShadowOffsetX.AutoSize = true;
            this.lblShadowOffsetX.Location = new System.Drawing.Point(491, 276);
            this.lblShadowOffsetX.Name = "lblShadowOffsetX";
            this.lblShadowOffsetX.Size = new System.Drawing.Size(87, 13);
            this.lblShadowOffsetX.TabIndex = 31;
            this.lblShadowOffsetX.Text = "Shadow OffsetX:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(160, 338);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 146);
            this.panel1.TabIndex = 35;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // nudFontSize
            // 
            this.nudFontSize.Location = new System.Drawing.Point(418, 113);
            this.nudFontSize.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudFontSize.Name = "nudFontSize";
            this.nudFontSize.Size = new System.Drawing.Size(181, 20);
            this.nudFontSize.TabIndex = 36;
            this.nudFontSize.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(344, 115);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 37;
            this.label17.Text = "Font Size:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(343, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 38;
            this.label18.Text = "Font:";
            // 
            // ddlFonts
            // 
            this.ddlFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFonts.FormattingEnabled = true;
            this.ddlFonts.Items.AddRange(new object[] {
            "Single Outline",
            "Double Outline",
            "Text Grow",
            "Gradient Outline",
            "No Outline",
            "Double Text Grow"});
            this.ddlFonts.Location = new System.Drawing.Point(417, 72);
            this.ddlFonts.Name = "ddlFonts";
            this.ddlFonts.Size = new System.Drawing.Size(182, 21);
            this.ddlFonts.TabIndex = 39;
            this.ddlFonts.SelectionChangeCommitted += new System.EventHandler(this.ddlFonts_SelectionChangeCommitted);
            // 
            // nudOutlineAlpha1
            // 
            this.nudOutlineAlpha1.Location = new System.Drawing.Point(264, 192);
            this.nudOutlineAlpha1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOutlineAlpha1.Name = "nudOutlineAlpha1";
            this.nudOutlineAlpha1.Size = new System.Drawing.Size(58, 20);
            this.nudOutlineAlpha1.TabIndex = 40;
            this.nudOutlineAlpha1.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // cbTextGradientEnable
            // 
            this.cbTextGradientEnable.AutoSize = true;
            this.cbTextGradientEnable.Location = new System.Drawing.Point(308, 155);
            this.cbTextGradientEnable.Name = "cbTextGradientEnable";
            this.cbTextGradientEnable.Size = new System.Drawing.Size(15, 14);
            this.cbTextGradientEnable.TabIndex = 41;
            this.cbTextGradientEnable.UseVisualStyleBackColor = true;
            this.cbTextGradientEnable.CheckedChanged += new System.EventHandler(this.cbTextGradientEnable_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(215, 154);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 13);
            this.label19.TabIndex = 42;
            this.label19.Text = "Gradient Text:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(832, 276);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 13);
            this.label20.TabIndex = 44;
            this.label20.Text = "Shadow Enable:";
            // 
            // cbShadowEnable
            // 
            this.cbShadowEnable.AutoSize = true;
            this.cbShadowEnable.Location = new System.Drawing.Point(925, 276);
            this.cbShadowEnable.Name = "cbShadowEnable";
            this.cbShadowEnable.Size = new System.Drawing.Size(15, 14);
            this.cbShadowEnable.TabIndex = 43;
            this.cbShadowEnable.UseVisualStyleBackColor = true;
            this.cbShadowEnable.CheckedChanged += new System.EventHandler(this.cbShadowEnable_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(853, 28);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 45;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // nudOutlineAlpha2
            // 
            this.nudOutlineAlpha2.Location = new System.Drawing.Point(264, 230);
            this.nudOutlineAlpha2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOutlineAlpha2.Name = "nudOutlineAlpha2";
            this.nudOutlineAlpha2.Size = new System.Drawing.Size(58, 20);
            this.nudOutlineAlpha2.TabIndex = 46;
            this.nudOutlineAlpha2.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // nudShadowAlpha
            // 
            this.nudShadowAlpha.Location = new System.Drawing.Point(264, 274);
            this.nudShadowAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudShadowAlpha.Name = "nudShadowAlpha";
            this.nudShadowAlpha.Size = new System.Drawing.Size(58, 20);
            this.nudShadowAlpha.TabIndex = 47;
            this.nudShadowAlpha.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // nudOutlineThickness1
            // 
            this.nudOutlineThickness1.Location = new System.Drawing.Point(413, 192);
            this.nudOutlineThickness1.Name = "nudOutlineThickness1";
            this.nudOutlineThickness1.Size = new System.Drawing.Size(58, 20);
            this.nudOutlineThickness1.TabIndex = 48;
            this.nudOutlineThickness1.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudOutlineThickness2
            // 
            this.nudOutlineThickness2.Location = new System.Drawing.Point(413, 231);
            this.nudOutlineThickness2.Name = "nudOutlineThickness2";
            this.nudOutlineThickness2.Size = new System.Drawing.Size(58, 20);
            this.nudOutlineThickness2.TabIndex = 49;
            this.nudOutlineThickness2.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudShadowThickness
            // 
            this.nudShadowThickness.Location = new System.Drawing.Point(413, 273);
            this.nudShadowThickness.Name = "nudShadowThickness";
            this.nudShadowThickness.Size = new System.Drawing.Size(58, 20);
            this.nudShadowThickness.TabIndex = 50;
            this.nudShadowThickness.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudShadowOffsetX
            // 
            this.nudShadowOffsetX.Location = new System.Drawing.Point(584, 274);
            this.nudShadowOffsetX.Name = "nudShadowOffsetX";
            this.nudShadowOffsetX.Size = new System.Drawing.Size(58, 20);
            this.nudShadowOffsetX.TabIndex = 51;
            this.nudShadowOffsetX.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudShadowOffsetY
            // 
            this.nudShadowOffsetY.Location = new System.Drawing.Point(757, 275);
            this.nudShadowOffsetY.Name = "nudShadowOffsetY";
            this.nudShadowOffsetY.Size = new System.Drawing.Size(58, 20);
            this.nudShadowOffsetY.TabIndex = 52;
            this.nudShadowOffsetY.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(687, 150);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 13);
            this.label21.TabIndex = 53;
            this.label21.Text = "Width:";
            // 
            // lbldWidth
            // 
            this.lbldWidth.AutoSize = true;
            this.lbldWidth.Location = new System.Drawing.Point(744, 150);
            this.lbldWidth.Name = "lbldWidth";
            this.lbldWidth.Size = new System.Drawing.Size(41, 13);
            this.lbldWidth.TabIndex = 54;
            this.lbldWidth.Text = "label22";
            // 
            // lbldHeight
            // 
            this.lbldHeight.AutoSize = true;
            this.lbldHeight.Location = new System.Drawing.Point(744, 180);
            this.lbldHeight.Name = "lbldHeight";
            this.lbldHeight.Size = new System.Drawing.Size(41, 13);
            this.lbldHeight.TabIndex = 56;
            this.lbldHeight.Text = "label22";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(687, 180);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 13);
            this.label23.TabIndex = 55;
            this.label23.Text = "Height:";
            // 
            // TemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 544);
            this.Controls.Add(this.lbldHeight);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.lbldWidth);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.nudShadowOffsetY);
            this.Controls.Add(this.nudShadowOffsetX);
            this.Controls.Add(this.nudShadowThickness);
            this.Controls.Add(this.nudOutlineThickness2);
            this.Controls.Add(this.nudOutlineThickness1);
            this.Controls.Add(this.nudShadowAlpha);
            this.Controls.Add(this.nudOutlineAlpha2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cbShadowEnable);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cbTextGradientEnable);
            this.Controls.Add(this.nudOutlineAlpha1);
            this.Controls.Add(this.ddlFonts);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.nudFontSize);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblShadowOffsetY);
            this.Controls.Add(this.lblShadowOffsetX);
            this.Controls.Add(this.lblShadowThickness);
            this.Controls.Add(this.lblShadowAlpha);
            this.Controls.Add(this.lblShadowColorDialogShow);
            this.Controls.Add(this.btnShadowColorDialogShow);
            this.Controls.Add(this.lblOutlineThickness2);
            this.Controls.Add(this.lblOutlineAlpha2);
            this.Controls.Add(this.lblOutlineColor2DialogShow);
            this.Controls.Add(this.btnOutlineColor2DialogShow);
            this.Controls.Add(this.lblOutlineThickness1);
            this.Controls.Add(this.lblOutlineAlpha1);
            this.Controls.Add(this.lblOutlineColor1DialogShow);
            this.Controls.Add(this.btnOutlineColor1DialogShow);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTextColor2DialogShow);
            this.Controls.Add(this.btnTextColor2DialogShow);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTextColor1DialogShow);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlEffectType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TemplateForm";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutlineAlpha1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutlineAlpha2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutlineThickness1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutlineThickness2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowOffsetY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlEffectType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Button btnTextColor1DialogShow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTextColor2DialogShow;
        private System.Windows.Forms.Button btnTextColor2DialogShow;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblOutlineColor1DialogShow;
        private System.Windows.Forms.Button btnOutlineColor1DialogShow;
        private System.Windows.Forms.Label lblOutlineAlpha1;
        private System.Windows.Forms.Label lblOutlineThickness1;
        private System.Windows.Forms.Label lblOutlineThickness2;
        private System.Windows.Forms.Label lblOutlineAlpha2;
        private System.Windows.Forms.Label lblOutlineColor2DialogShow;
        private System.Windows.Forms.Button btnOutlineColor2DialogShow;
        private System.Windows.Forms.Label lblShadowThickness;
        private System.Windows.Forms.Label lblShadowAlpha;
        private System.Windows.Forms.Label lblShadowColorDialogShow;
        private System.Windows.Forms.Button btnShadowColorDialogShow;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblShadowOffsetY;
        private System.Windows.Forms.Label lblShadowOffsetX;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nudFontSize;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox ddlFonts;
        private System.Windows.Forms.NumericUpDown nudOutlineAlpha1;
        private System.Windows.Forms.CheckBox cbTextGradientEnable;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox cbShadowEnable;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.NumericUpDown nudOutlineAlpha2;
        private System.Windows.Forms.NumericUpDown nudShadowAlpha;
        private System.Windows.Forms.NumericUpDown nudOutlineThickness1;
        private System.Windows.Forms.NumericUpDown nudOutlineThickness2;
        private System.Windows.Forms.NumericUpDown nudShadowThickness;
        private System.Windows.Forms.NumericUpDown nudShadowOffsetX;
        private System.Windows.Forms.NumericUpDown nudShadowOffsetY;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lbldWidth;
        private System.Windows.Forms.Label lbldHeight;
        private System.Windows.Forms.Label label23;
    }
}
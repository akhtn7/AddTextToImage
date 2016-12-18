using AddTextToImage.Domain.Entities;
using AddTextToImage.ImageGenerator;
using AddTextToImage.TemplateEditor.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace AddTextToImage.TemplateEditor.Forms
{
    public partial class TemplateForm : Form
    {
        public TemplateBase Template { get; set; }

        public List<FontInfo> Fonts { get; set; }

        private ColorDialog colorDialog;

        private ModelItem fakeModelItem;

        private Bitmap resultImage;

        string fontPath;

        public TemplateForm()
        {
            InitializeComponent();

            colorDialog = new ColorDialog();

            fakeModelItem = new ModelItem()
            {
                Id = 1,
                ModelId = 1,
                PositionTop = 0,
                PositionLeft = 0,
                Text = String.Empty,
                TemplateId = 1,
                FontSize = 64,
                FontColor = "#FF00FF",
                Rotation = 0,
            };

            resultImage = new Bitmap(1, 1);

            fontPath = Utils.GetFontPath();
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            ddlFonts.DataSource = this.Fonts;
            ddlFonts.ValueMember = "Id";
            ddlFonts.DisplayMember = "Name";

            //ToDo
            nudFontSize.Value = fakeModelItem.FontSize;

            txtName.Text = Template.Name;
            ddlEffectType.SelectedIndex = Template.EffectType - 1;

            fakeModelItem.Text = Template.Text;
            txtText.Text = Template.Text;

            for (int i = 0; i < ddlFonts.Items.Count; i++)
            {
                if (((FontInfo)ddlFonts.Items[i]).Id == Template.FontId)
                {
                    ddlFonts.SelectedIndex = i;
                    break;
                }
            }

            btnTextColor1DialogShow.BackColor = Color.FromArgb(Template.TextColor1);
            fakeModelItem.FontColor = ColorTranslator.ToHtml(Color.FromArgb(Template.TextColor1));

            //ToDo fontsize

            btnTextColor2DialogShow.BackColor = Color.FromArgb(Template.TextColor2);
            cbTextGradientEnable.Checked = Template.TextGradientEnable;

            btnOutlineColor1DialogShow.BackColor = Color.FromArgb(Template.OutlineColor1);
            nudOutlineAlpha1.Value = Color.FromArgb(Template.OutlineColor1).A;
            nudOutlineThickness1.Value = Template.OutlineThickness1;

            btnOutlineColor2DialogShow.BackColor = Color.FromArgb(Template.OutlineColor2);
            nudOutlineAlpha2.Value = Color.FromArgb(Template.OutlineColor2).A;
            nudOutlineThickness2.Value = Template.OutlineThickness2;

            btnShadowColorDialogShow.BackColor = Color.FromArgb(Template.ShadowColor);
            nudShadowAlpha.Value = Color.FromArgb(Template.ShadowColor).A;
            nudShadowThickness.Value = Template.ShadowThickness;
            nudShadowOffsetX.Value = Template.ShadowOffsetX;
            nudShadowOffsetY.Value = Template.ShadowOffsetY;

            cbShadowEnable.Checked = Template.ShadowEnable;

            nudFontSize.TextChanged += new EventHandler(Control_ValueChanged);
            nudOutlineAlpha1.TextChanged += new EventHandler(Control_ValueChanged);
            nudOutlineThickness1.TextChanged += new EventHandler(Control_ValueChanged);
            nudOutlineAlpha2.TextChanged += new EventHandler(Control_ValueChanged);
            nudOutlineThickness2.TextChanged += new EventHandler(Control_ValueChanged);
            nudShadowAlpha.TextChanged += new EventHandler(Control_ValueChanged);
            nudShadowThickness.TextChanged += new EventHandler(Control_ValueChanged);
            nudShadowOffsetX.TextChanged += new EventHandler(Control_ValueChanged);
            nudShadowOffsetY.TextChanged += new EventHandler(Control_ValueChanged);

            SetControlsEffectType(Template.EffectType);
            SetControlsShadowEnable(Template.ShadowEnable);
            lblTextColor2DialogShow.Enabled = Template.TextGradientEnable;
            btnTextColor2DialogShow.Enabled = Template.TextGradientEnable;

            UpdateImage();
        }

        void Control_ValueChanged(object sender, EventArgs e)
        {
            fakeModelItem.FontSize = (int)nudFontSize.Value;
            Template.OutlineColor1 = Color.FromArgb((int)nudOutlineAlpha1.Value, btnOutlineColor1DialogShow.BackColor).ToArgb();
            Template.OutlineThickness1 = (int)nudOutlineThickness1.Value;
            Template.OutlineColor2 = Color.FromArgb((int)nudOutlineAlpha2.Value, btnOutlineColor2DialogShow.BackColor).ToArgb();
            Template.OutlineThickness2 = (int)nudOutlineThickness2.Value;
            Template.ShadowColor = Color.FromArgb((int)nudShadowAlpha.Value, btnShadowColorDialogShow.BackColor).ToArgb();
            Template.ShadowThickness = (int)nudShadowThickness.Value;
            Template.ShadowOffsetX = (int)nudShadowOffsetX.Value;
            Template.ShadowOffsetY = (int)nudShadowOffsetY.Value;

            UpdateImage();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            e.Graphics.DrawImage(resultImage, new Point(10, 10));

            e.Graphics.Dispose();
        }

        private void UpdateImage()
        {
            if (!String.IsNullOrWhiteSpace(fakeModelItem.Text))
            {
                fakeModelItem.FontColor = ColorTranslator.ToHtml(Color.FromArgb(Template.TextColor1));

                OutlineTextProcessor outlineTextProcessor = new OutlineTextProcessor(fakeModelItem, Template, fontPath);
                resultImage = outlineTextProcessor.GetImage();
            }
            else
                resultImage = new Bitmap(1, 1);

            lbldWidth.Text = resultImage.Width.ToString();
            lbldHeight.Text = resultImage.Height.ToString();

            panel1.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Template.Name = txtName.Text.Trim();
            Template.Text = txtText.Text.Trim();

            OutlineTextProcessor outlineTextProcessor = new OutlineTextProcessor(fakeModelItem, Template, fontPath);
            resultImage = outlineTextProcessor.GetImage();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                resultImage.Save(memoryStream, ImageFormat.Png);
                Template.Image = memoryStream.ToArray();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnTextColor1DialogShow_Click(object sender, EventArgs e)
        {
            colorDialog.Color = btnTextColor1DialogShow.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                fakeModelItem.FontColor = ColorTranslator.ToHtml(colorDialog.Color);
                btnTextColor1DialogShow.BackColor = colorDialog.Color;
                Template.TextColor1 = btnTextColor1DialogShow.BackColor.ToArgb();

                UpdateImage();
            }
        }

        private void btnTextColor2DialogShow_Click(object sender, EventArgs e)
        {
            colorDialog.Color = btnTextColor2DialogShow.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnTextColor2DialogShow.BackColor = colorDialog.Color;
                Template.TextColor2 = btnTextColor2DialogShow.BackColor.ToArgb();

                UpdateImage();
            }
        }

        private void btnOutlineColor1DialogShow_Click(object sender, EventArgs e)
        {
            colorDialog.Color = btnOutlineColor1DialogShow.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnOutlineColor1DialogShow.BackColor = colorDialog.Color;
                Template.OutlineColor1 = Color.FromArgb((int)nudOutlineAlpha1.Value, btnOutlineColor1DialogShow.BackColor).ToArgb();

                UpdateImage();
            }
        }

        private void btnOutlineColor2DialogShow_Click(object sender, EventArgs e)
        {
            colorDialog.Color = btnOutlineColor2DialogShow.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnOutlineColor2DialogShow.BackColor = colorDialog.Color;
                Template.OutlineColor2 = Color.FromArgb((int)nudOutlineAlpha2.Value, btnOutlineColor2DialogShow.BackColor).ToArgb();

                UpdateImage();
            }
        }

        private void btnShadowColorDialogShow_Click(object sender, EventArgs e)
        {
            colorDialog.Color = btnShadowColorDialogShow.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnShadowColorDialogShow.BackColor = colorDialog.Color;
                Template.ShadowColor = Color.FromArgb((int)nudShadowAlpha.Value, btnShadowColorDialogShow.BackColor).ToArgb();

                UpdateImage();
            }
        }

        private void cbTextGradientEnable_CheckedChanged(object sender, EventArgs e)
        {
            Template.TextGradientEnable = cbTextGradientEnable.Checked;

            lblTextColor2DialogShow.Enabled = Template.TextGradientEnable;
            btnTextColor2DialogShow.Enabled = Template.TextGradientEnable;

            UpdateImage();
        }

        private void cbShadowEnable_CheckedChanged(object sender, EventArgs e)
        {
            Template.ShadowEnable = cbShadowEnable.Checked;
            SetControlsShadowEnable(Template.ShadowEnable);

            UpdateImage();
        }

        private void ddlFonts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Template.FontId = ((FontInfo)ddlFonts.SelectedItem).Id;
            Template.Font = (FontInfo)ddlFonts.SelectedItem;

            UpdateImage();
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            Template.Text = txtText.Text.Trim();
            fakeModelItem.Text = txtText.Text.Trim();

            UpdateImage();
        }

        private void ddlEffectType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Template.EffectType = ddlEffectType.SelectedIndex + 1;

            SetControlsEffectType(Template.EffectType);

            UpdateImage();
        }

        private void SetControlsEffectType(int effectType)
        {
            lblOutlineColor1DialogShow.Enabled = true;
            btnOutlineColor1DialogShow.Enabled = true;

            lblOutlineAlpha1.Enabled = true;
            nudOutlineAlpha1.Enabled = true;

            lblOutlineThickness1.Enabled = true;
            nudOutlineThickness1.Enabled = true;

            lblOutlineColor2DialogShow.Enabled = true;
            btnOutlineColor2DialogShow.Enabled = true;

            lblOutlineAlpha2.Enabled = true;
            nudOutlineAlpha2.Enabled = true;

            lblOutlineThickness2.Enabled = true;
            nudOutlineThickness2.Enabled = true;

            switch (effectType)
            {
                // No Outline
                case 1:

                    lblOutlineColor1DialogShow.Enabled = false;
                    btnOutlineColor1DialogShow.Enabled = false;

                    lblOutlineAlpha1.Enabled = false;
                    nudOutlineAlpha1.Enabled = false;

                    lblOutlineThickness1.Enabled = false;
                    nudOutlineThickness1.Enabled = false;

                    lblOutlineColor2DialogShow.Enabled = false;
                    btnOutlineColor2DialogShow.Enabled = false;

                    lblOutlineAlpha2.Enabled = false;
                    nudOutlineAlpha2.Enabled = false;

                    lblOutlineThickness2.Enabled = false;
                    nudOutlineThickness2.Enabled = false;

                    break;

                // Single Outline
                case 2:

                    lblOutlineColor2DialogShow.Enabled = false;
                    btnOutlineColor2DialogShow.Enabled = false;

                    lblOutlineAlpha2.Enabled = false;
                    nudOutlineAlpha2.Enabled = false;

                    lblOutlineThickness2.Enabled = false;
                    nudOutlineThickness2.Enabled = false;

                    break;

                // Text Grow
                case 4:

                    lblOutlineColor2DialogShow.Enabled = false;
                    btnOutlineColor2DialogShow.Enabled = false;

                    lblOutlineAlpha2.Enabled = false;
                    nudOutlineAlpha2.Enabled = false;

                    lblOutlineThickness2.Enabled = false;
                    nudOutlineThickness2.Enabled = false;

                    break;
            }

        }

        private void SetControlsShadowEnable(bool shadowEnable)
        {
            lblShadowColorDialogShow.Enabled = shadowEnable;
            btnShadowColorDialogShow.Enabled = shadowEnable;

            lblShadowAlpha.Enabled = shadowEnable;
            nudShadowAlpha.Enabled = shadowEnable;

            lblShadowThickness.Enabled = shadowEnable;
            nudShadowThickness.Enabled = shadowEnable;

            lblShadowOffsetX.Enabled = shadowEnable;
            nudShadowOffsetX.Enabled = shadowEnable;

            lblShadowOffsetY.Enabled = shadowEnable;
            nudShadowOffsetY.Enabled = shadowEnable;
        }
    }
}

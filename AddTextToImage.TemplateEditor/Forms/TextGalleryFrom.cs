using AddTextToImage.Data.Context;
using AddTextToImage.Data.Service;
using AddTextToImage.Domain.Entities;
using AddTextToImage.TemplateEditor.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AddTextToImage.TemplateEditor.Forms
{
    public partial class TextGalleryFrom : Form
    {
        private readonly IRepository<TextGallery> _textGalleryRepository = new Repository<TextGallery>(new DbContextFactory());
        private readonly IRepository<TextTemplate> _textTemplateRepository = new Repository<TextTemplate>(new DbContextFactory());
        private readonly IRepository<FontInfo> _fontInfoRepository = new Repository<FontInfo>(new DbContextFactory());
        
        List<TextGallery> templateGalleryList;
        List<FontInfo> fontList;

        ImageList imageList;

        int selectedTextGalleryId;

        public TextGalleryFrom()
        {
            InitializeComponent();

            imageList = new ImageList();
            imageList.ImageSize = new Size(256, 100);
        }

        private void frmTemplateGallery_Load(object sender, EventArgs e)
        {
            fontList = _fontInfoRepository.Where(p => !p.IsClipart).OrderBy(p => p.Name).ToList<FontInfo>();

            templateGalleryList = _textGalleryRepository.GetAll().ToList<TextGallery>();

            ddlTemplateGallery.DataSource = templateGalleryList;
            ddlTemplateGallery.ValueMember = "Id";
            ddlTemplateGallery.DisplayMember = "Name";

            if (ddlTemplateGallery.Items.Count > 0)
                ddlTemplateGallery.SelectedIndex = 0;

            FillTextTemplates();
        }

        private void FillTextTemplates()
        {
            lvTextTemplates.Clear();
            imageList.Images.Clear();

            selectedTextGalleryId = (int)(ddlTemplateGallery.SelectedValue);

            List<TextTemplate> textTemplateList = _textTemplateRepository.Where(p => p.TextGalleryId == selectedTextGalleryId).ToList<TextTemplate>();

            foreach (var c in textTemplateList)
            {
                Bitmap bmp = new Bitmap(256, 100);
                Graphics graphics = Graphics.FromImage(bmp);

                graphics.DrawImage(Utils.ByteArrayToImage(c.Image), new Point(0, 0));

                imageList.Images.Add(bmp);

                graphics.Dispose();
            }

            lvTextTemplates.LargeImageList = imageList;

            int i = 0;
            foreach (var c in textTemplateList)
            {
                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;
                item.Text = c.Name;
                item.Tag = c.Id;

                lvTextTemplates.Items.Add(item);
                i++;
            }

            if (lvTextTemplates.Items.Count > 0)
            {
                lvTextTemplates.Items[0].Selected = true;
                lvTextTemplates.Select();
            }
        }


        private void ddlTemplateGallery_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillTextTemplates();
        }

        private void tsbtnTextTemplateAdd_Click(object sender, EventArgs e)
        {
            TemplateForm frm = new TemplateForm();

            TextTemplate template = new TextTemplate()
            {
                EffectType = 1,
                Name = "New template",
                Text = "New template",
                TextColor1 = Color.Red.ToArgb(),
                TextColor2 = Color.Tomato.ToArgb(),
                TextGradientEnable = true,
                OutlineColor1 = Color.Blue.ToArgb(),
                OutlineThickness1 = 1,
                OutlineColor2 = Color.Yellow.ToArgb(),
                OutlineThickness2 = 1,
                ShadowEnable = true,
                ShadowColor = Color.Black.ToArgb(),
                ShadowThickness = 1,
                ShadowOffsetX = 2,
                ShadowOffsetY = 2,
                FontId = fontList[0].Id,
                Font = fontList[0], //ToDo
                TextGalleryId = selectedTextGalleryId
            };

            frm.Template = template;
            frm.Fonts = fontList;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                template.Font = null;

                _textTemplateRepository.Add(template);
                _textTemplateRepository.Save();

                imageList.Images.Add(Utils.ByteArrayToImage(template.Image));

                ListViewItem item = new ListViewItem();

                item.ImageIndex = imageList.Images.Count - 1;
                item.Text = template.Name;
                item.Tag = template.Id;

                lvTextTemplates.Items.Add(item);

                item.Selected = true;
            }

            lvTextTemplates.Select();

            frm.Dispose();
        }

        private void btnTextTemplateEdit_Click(object sender, EventArgs e)
        {
            TemplateForm frm = new TemplateForm();

            int selectedTextTemplate = (int)lvTextTemplates.SelectedItems[0].Tag;

            TextTemplate template = _textTemplateRepository.Get(selectedTextTemplate);

            template.Font = fontList.Find(f => f.Id == template.FontId);
            frm.Template = template;
            frm.Fonts = fontList;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                template.Font = null;
                _textTemplateRepository.Save();

                imageList.Images[lvTextTemplates.SelectedItems[0].ImageIndex] = Utils.ByteArrayToImage(template.Image);
                lvTextTemplates.SelectedItems[0].Selected = true;

            }
            else
            {
                template.Font = null;
                _textTemplateRepository.SetStateUnchanged(template);
            }

            lvTextTemplates.Select();

            frm.Dispose();
        }

   }
}

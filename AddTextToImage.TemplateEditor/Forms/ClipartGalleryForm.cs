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
    public partial class TemplateClipartGalleryForm : Form
    {
        private readonly IRepository<ClipartTemplate> _clipartTemplateRepository = new Repository<ClipartTemplate>(new DbContextFactory());
        private readonly IRepository<ClipartGallery> _clipartGalleryRepository = new Repository<ClipartGallery>(new DbContextFactory());
        private readonly IRepository<FontInfo> _fontInfoRepository = new Repository<FontInfo>(new DbContextFactory());

        List<ClipartGallery> clipartGalleryList;
        List<FontInfo> fontList;

        ImageList imageList;

        int selectedClipartGalleryId;

        public TemplateClipartGalleryForm()
        {
            InitializeComponent();

            imageList = new ImageList();
            imageList.ImageSize = new Size(100, 100);
        }

        private void TemplateClipartGallery_Load(object sender, EventArgs e)
        {
            fontList = _fontInfoRepository.Where(p => p.IsClipart).OrderBy(p => p.Name).ToList<FontInfo>();

            clipartGalleryList = _clipartGalleryRepository.GetAll().ToList<ClipartGallery>();

            ddlTemplateGallery.DataSource = clipartGalleryList;
            ddlTemplateGallery.ValueMember = "Id";
            ddlTemplateGallery.DisplayMember = "Name";

            if (ddlTemplateGallery.Items.Count > 0)
                ddlTemplateGallery.SelectedIndex = 0;

            FillClipartTemplates();
        }

        private void FillClipartTemplates()
        {
            lvCliparts.Clear();
            imageList.Images.Clear();

            selectedClipartGalleryId = (int)(ddlTemplateGallery.SelectedValue);

            List<ClipartTemplate> clipartTemplateList = _clipartTemplateRepository.Where(p => p.ClipartGalleryId == selectedClipartGalleryId).ToList<ClipartTemplate>();

            foreach (var c in clipartTemplateList)
            {
                Bitmap bmp = new Bitmap(100, 100);
                Graphics graphics = Graphics.FromImage(bmp);

                graphics.DrawImage(Utils.ByteArrayToImage(c.Image), new Point(0, 0));

                imageList.Images.Add(bmp);

                graphics.Dispose();
            }

            lvCliparts.LargeImageList = imageList;

            int i = 0;
            foreach (var c in clipartTemplateList)
            {
                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;
                item.Text = c.Name;
                item.Tag = c.Id;

                lvCliparts.Items.Add(item);
                i++;
            }

            if (lvCliparts.Items.Count > 0)
            {
                lvCliparts.Items[0].Selected = true;
                lvCliparts.Select();
            }
        }

        private void ddlTemplateGallery_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillClipartTemplates();
        }

        private void tsbtnClipartTemplateAdd_Click(object sender, EventArgs e)
        {
            TemplateForm frm = new TemplateForm();

            ClipartTemplate template = new ClipartTemplate()
            {
                EffectType = 1,
                Name = "A",
                Text = "A",
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
                ClipartGalleryId = selectedClipartGalleryId
            };

            frm.Template = template;
            frm.Fonts = fontList;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                template.Font = null;

                _clipartTemplateRepository.Add(template);
                _clipartTemplateRepository.Save();

                imageList.Images.Add(Utils.ByteArrayToImage(template.Image));

                ListViewItem item = new ListViewItem();

                item.ImageIndex = imageList.Images.Count - 1;
                item.Text = template.Name;
                item.Tag = template.Id;

                lvCliparts.Items.Add(item);

                item.Selected = true;
            }

            lvCliparts.Select();

            frm.Dispose();
        }

        private void tsbtnTemplateEdit_Click(object sender, EventArgs e)
        {
            TemplateForm frm = new TemplateForm();

            int selectedClipartTemplate = (int)lvCliparts.SelectedItems[0].Tag;

            ClipartTemplate template = _clipartTemplateRepository.Get(selectedClipartTemplate);

            template.Font = fontList.Find(f => f.Id == template.FontId);
            frm.Template = template;
            frm.Fonts = fontList;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                template.Font = null;
                _clipartTemplateRepository.Save();

                imageList.Images[lvCliparts.SelectedItems[0].ImageIndex] = Utils.ByteArrayToImage(template.Image);
                lvCliparts.SelectedItems[0].Selected = true;

            }
            else
            {
                template.Font = null;
                _clipartTemplateRepository.SetStateUnchanged(template);
            }

            lvCliparts.Select();

            frm.Dispose();
        }
    }
}

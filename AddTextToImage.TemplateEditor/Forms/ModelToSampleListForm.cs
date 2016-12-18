using AddTextToImage.Data.Context;
using AddTextToImage.Data.Service;
using AddTextToImage.Domain.Entities;
using AddTextToImage.TemplateEditor.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddTextToImage.TemplateEditor.Forms
{
    public partial class ModelToSampleListForm : Form
    {
        private readonly IRepository<Model> _modelRepository = new Repository<Model>(new DbContextFactory());
        private readonly IRepository<Sample> _sampleRepository = new Repository<Sample>(new DbContextFactory());


        private int pageSize = 10;
        private int pageIndex = 1;
        private int totalPage = 0; 

        public ModelToSampleListForm()
        {
            InitializeComponent();
        }

        private void ModelToSampleForm_Load(object sender, EventArgs e)
        {
            this.dgvModels.AutoGenerateColumns = false;

            int rowCount = _modelRepository.GetAll().Count();

            totalPage = rowCount / pageSize;

            if (rowCount % pageSize > 0)
                totalPage++;

            this.dgvModels.DataSource = Getdata();
        }

        private List<Model> Getdata ()
        {
            var result = _modelRepository.GetAllWithInclude("Items").OrderBy(o => o.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<Model>();

            foreach(Model m in result)
            {
                m.Image = Utils.BitmapToByteArray(Utils.GetResultImage(m));
            }

            return result;
        }

        private void tsbtnFirstPage_Click(object sender, EventArgs e)
        {
            this.pageIndex = 1;
            this.dgvModels.DataSource = Getdata();
        }

        private void tsbtnNextPage_Click(object sender, EventArgs e)
        {
            if (this.pageIndex < this.totalPage)
            {
                this.pageIndex++;
                
                this.dgvModels.DataSource = Getdata();
            }
        }

        private void tsbtnPrevPage_Click(object sender, EventArgs e)
        {
            if (this.pageIndex > 1)
            {
                this.pageIndex--;

                this.dgvModels.DataSource = Getdata();
            } 
        }

        private void tsbtnLastPage_Click(object sender, EventArgs e)
        {
            this.pageIndex = totalPage;

            this.dgvModels.DataSource = Getdata();
        }

        private void tsbtnModelPreview_Click(object sender, EventArgs e)
        {
            CurrencyManager cm = (CurrencyManager)this.BindingContext[dgvModels.DataSource, dgvModels.DataMember];

            Model model = (Model)cm.Current;

            ModelPreviewFrom frm = new ModelPreviewFrom();

            frm.ModelPreviewImage = Utils.ByteArrayToBitmap(model.Image);

            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void tsbtnCopyModelToSample_Click(object sender, EventArgs e)
        {
            CurrencyManager cm = (CurrencyManager)this.BindingContext[dgvModels.DataSource, dgvModels.DataMember];

            Model model = (Model)cm.Current;

            Sample sample = new Sample();
            sample.Items = new List<SampleItem>();

            sample.ContentType = model.ContentType;
            sample.Image = model.Image;
            sample.ImageWidth = model.ImageWidth;
            sample.ImageHeight = model.ImageHeight;

            Bitmap bmpThumbnail = Utilities.Utils.ResizeImage(Utils.ByteArrayToBitmap(model.Image), 360, 270);
            sample.Thumbnail = Utilities.Utils.BitmapToByteArray(bmpThumbnail);

            foreach (ModelItem modelItem in model.Items)
            {
                SampleItem sampleItem = new SampleItem();

                sampleItem.ItemType = modelItem.ItemType;
                sampleItem.PositionTop = modelItem.PositionTop;
                sampleItem.PositionLeft = modelItem.PositionLeft;
                sampleItem.Text = modelItem.Text;
                sampleItem.TemplateId = modelItem.TemplateId;
                sampleItem.FontSize = modelItem.FontSize;
                sampleItem.FontColor = modelItem.FontColor;
                sampleItem.Rotation = modelItem.Rotation;

                sample.Items.Add(sampleItem);
            }

            _sampleRepository.Add(sample);
            _sampleRepository.Save();

        }
    }
}

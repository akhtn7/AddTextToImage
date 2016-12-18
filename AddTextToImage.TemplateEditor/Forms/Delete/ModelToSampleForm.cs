using AddTextToImage.Data.Context;
using AddTextToImage.Data.Service;
using AddTextToImage.Domain.Entities;
using AddTextToImage.ImageGenerator;
using AddTextToImage.TemplateEditor.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddTextToImage.TemplateEditor.Forms
{
    public partial class ModelToSampleForm : Form
    {
        public int ModelId { get; set; }

        private readonly IRepository<Model> _modelRepository = new Repository<Model>(new DbContextFactory());
        private readonly IRepository<TextTemplate> _textTemplateRepository = new Repository<TextTemplate>(new DbContextFactory());
        private readonly IRepository<ClipartTemplate> _clipartTemplateRepository = new Repository<ClipartTemplate>(new DbContextFactory());
        private readonly IRepository<Sample> _sampleRepository = new Repository<Sample>(new DbContextFactory());


        private Model model;

        private Bitmap resultImage;


        public ModelToSampleForm()
        {
            InitializeComponent();
        }

        //ToDo - 
        private void ModelToSampleForm_Load(object sender, EventArgs e)
        {
            string fontPath = @"E:\xWork\Apps\Work\AddTextToImage\AddTextToImage.WebUI\fonts\";

            model = _modelRepository.Get(ModelId);

            if (model != null)
            {
                ImageConverter ic = new ImageConverter();
                Image img = (Image)ic.ConvertFrom(model.Image);
                Bitmap bmpResult = new Bitmap(img);

                Graphics graphics = Graphics.FromImage(bmpResult);

                foreach (var modelItem in model.Items)
                {
                    TemplateBase template = null;

                    if (modelItem.ItemType == 0)
                    {
                        template = _textTemplateRepository.GetAllWithInclude("Font").Where(p => p.Id == modelItem.TemplateId).FirstOrDefault();
                    }
                    else
                    {
                        template = _clipartTemplateRepository.GetAllWithInclude("Font").Where(p => p.Id == modelItem.TemplateId).FirstOrDefault();
                    }

                    OutlineTextProcessor outlineTextProcessor = new OutlineTextProcessor(modelItem, template, fontPath);
                    Bitmap image = outlineTextProcessor.GetImage();

                    graphics.DrawImage((Image)image, new Point(modelItem.PositionLeft, modelItem.PositionTop));
                }

                resultImage = bmpResult;

                graphics.Flush();
                graphics.Dispose();
            }
        }

        private void pnlImage_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = Utils.ResizeImage(resultImage, e.ClipRectangle.Width, e.ClipRectangle.Height);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            e.Graphics.DrawImage(img, new Point(10, 10));

            e.Graphics.Dispose();
        }

        private void tsbtnToSample_Click(object sender, EventArgs e)
        {

            string fontPath = @"E:\xWork\Apps\Work\AddTextToImage\AddTextToImage.WebUI\fonts\";
            Bitmap bmpResult;

            if (model != null)
            {
                ImageConverter ic = new ImageConverter();
                Image img = (Image)ic.ConvertFrom(model.Image);
                bmpResult = new Bitmap(img);

                Graphics graphics = Graphics.FromImage(bmpResult);

                foreach (var modelItem in model.Items)
                {
                    TemplateBase template = null;

                    if (modelItem.ItemType == 0)
                    {
                        template =
                            (from t in _textTemplateRepository.GetAllWithInclude("Font")
                             where t.Id == modelItem.TemplateId
                             select t).FirstOrDefault();
                    }
                    else
                    {
                        template =
                            (from t in _clipartTemplateRepository.GetAllWithInclude("Font")
                             where t.Id == modelItem.TemplateId
                             select t).FirstOrDefault();

                    }

                    OutlineTextProcessor outlineTextProcessor = new OutlineTextProcessor(modelItem, template, fontPath);
                    Bitmap image = outlineTextProcessor.GetImage();

                    graphics.DrawImage((Image)image, new Point(modelItem.PositionLeft, modelItem.PositionTop));
                }

                resultImage = bmpResult;

                graphics.Flush();
                graphics.Dispose();
            }



            Sample sample = new Sample();
            sample.Items = new List<SampleItem>();
            
            sample.ContentType = model.ContentType;
            sample.Image = model.Image;
            sample.ImageWidth = model.ImageWidth;
            sample.ImageHeight = model.ImageHeight;

            Bitmap bmpThumbnail = Utilities.Utils.ResizeImage(resultImage, 360, 270);
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

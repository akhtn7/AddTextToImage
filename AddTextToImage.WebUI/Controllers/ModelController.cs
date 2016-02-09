using AddTextToImage.Domain.Entities;
using AddTextToImage.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace AddTextToImage.WebUI.Controllers
{
    public class ModelController : ApiController
    {
        private readonly IRepository<Model> _modelRepository;
        private readonly IRepository<Sample> _sampleRepository;

        public ModelController(IRepository<Model> modelRepository, IRepository<Sample> sampleRepository)
        {
            _modelRepository = modelRepository;
            _sampleRepository = sampleRepository;
        }


        [HttpPost]
        public Model UploadFile()
        {
            Model model = new Model();

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                if (httpPostedFile != null)
                {
                    model.ContentType = httpPostedFile.ContentType;
                    model.Image = new byte[httpPostedFile.ContentLength];

                    httpPostedFile.InputStream.Read(model.Image, 0, httpPostedFile.ContentLength);

                    Size imageSize = Utils.getImageSize(model.Image);
                    model.ImageHeight = imageSize.Height;
                    model.ImageWidth = imageSize.Width;

                    _modelRepository.Add(model);
                    _modelRepository.Save();

                    //return model;
                    //Session.SetDataToSession<int>("ModelId", model.ModelId); 
                }

            }

            return model;
        }


        [HttpPut]
        public Model CreateFromSample(int id)
        {
            Sample sample = _sampleRepository.Get(id);

            if (sample != null)
            {
                Model model = new Model();

                model.Image = sample.Image;
                model.ContentType = sample.ContentType;
                model.ImageHeight = sample.ImageHeight;
                model.ImageWidth = sample.ImageWidth;
                model.Items = new List<ModelItem>();

                foreach (SampleItem sampleItem in sample.Items)
                {
                    ModelItem modelItem = new ModelItem();
                    modelItem.ItemType = sampleItem.ItemType;
                    modelItem.FontColor = sampleItem.FontColor;
                    modelItem.TemplateId = sampleItem.TemplateId;
                    modelItem.PositionLeft = sampleItem.PositionLeft;
                    modelItem.PositionTop = sampleItem.PositionTop;
                    modelItem.Rotation = sampleItem.Rotation;
                    modelItem.FontSize = sampleItem.FontSize;
                    modelItem.Text = sampleItem.Text;
                    modelItem.Model = model;

                    model.Items.Add(modelItem);
                }

                _modelRepository.Add(model);
                _modelRepository.Save();

                return model;
            }

            return null;
        }


        [HttpPut]
        public int AddModelItem(ModelItem modelItem)
        {
            var model = _modelRepository.Get(modelItem.ModelId);

            if (model != null)
            {
                model.Items.Add(modelItem);
                _modelRepository.Save();
            }

            return modelItem.Id;
        }


        [HttpGet]
        public HttpResponseMessage Image(int id)
        {
            var image = _modelRepository.Get(id);
            if (image != null)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

                response.Content = new ByteArrayContent(image.Image);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return response;

            }
            else
                return null;
            //XXXXXXXXXXXXXXX
            /*else
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Bitmap imageNotFound = Utils.GetFontedImage("Not Found", "Brewsky.ttf", 31, "#FF00FF", 0);
                    imageNotFound.Save(memoryStream, ImageFormat.Png);

                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

                    response.Content = new ByteArrayContent(memoryStream.ToArray());
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                    return response;
                }
            }*/
        }


      
    }
}

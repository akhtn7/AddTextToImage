﻿using AddTextToImage.Data.Service;
using AddTextToImage.Domain.Entities;
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

        ///<summary>
        /// Creates a new instance of the ModelController class.
        ///</summary>
        public ModelController(IRepository<Model> modelRepository, IRepository<Sample> sampleRepository)
        {
            _modelRepository = modelRepository;
            _sampleRepository = sampleRepository;
        }

        ///<summary>
        ///Uploads file and creates new Model.
        ///</summary>
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

                    Size imageSize = Utils.GetImageSize(model.Image);
                    model.ImageHeight = imageSize.Height;
                    model.ImageWidth = imageSize.Width;

                    _modelRepository.Add(model);
                    _modelRepository.Save();
                }
            }

            return model;
        }

        ///<summary>
        ///Creates new Model based on selected Sample.
        ///</summary>
        /// <param name="id">Unique identifier of Sample item.</param>
        /// <returns>Return Model object</returns>
        [HttpPut]
        public Model CreateFromSample(int id)
        {
            if (!ModelState.IsValid)
                return null;

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
            if (!ModelState.IsValid)
                return 0;

            var model = _modelRepository.Get(modelItem.ModelId);

            if (model == null)
                return 0;

            model.Items.Add(modelItem);
            _modelRepository.Save();

            return modelItem.Id;
        }

        ///<summary>
        ///Returns image for Model item.
        ///</summary>
        [HttpGet]
        public HttpResponseMessage Image(int id)
        {
            if (!ModelState.IsValid)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            var image = _modelRepository.Get(id);

            if (image == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            response.Content = new ByteArrayContent(image.Image);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            return response;
        }
    }
}

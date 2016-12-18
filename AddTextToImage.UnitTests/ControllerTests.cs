using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddTextToImage.Domain.Entities;
using Moq;
using AddTextToImage.WebUI.Controllers;
using System.Net.Http;
using AddTextToImage.Data.Service;
using AddTextToImage.Data.Context;
using System.Collections.Generic;
using System.Net;


namespace AddTextToImage.UnitTests
{
    [TestClass]
    public class ControllerTests
    {
        ///<summary>
        ///Test for ClipartTemplateController controller.
        ///</summary>
        [TestMethod]
        public void Can_Retrieve_Clipart_Image_Data()
        {
            // Arrange - create a ClipartTemplate with image data
            ClipartTemplate clipartTemplate = new ClipartTemplate
            {
                Id = 1,
                Name = "ClipartTemplate1",
                Image = new byte[] { }
            };

            // Arrange - create the mock repository
            Mock<IRepository<ClipartTemplate>> mock = new Mock<IRepository<ClipartTemplate>>();
            mock.Setup(m => m.Get(1)).Returns(clipartTemplate);

            // Arrange - create the controller
            ClipartTemplateController target = new ClipartTemplateController(mock.Object);

            // Act - call the Image method
            HttpResponseMessage result = target.Image(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpResponseMessage));
            Assert.AreEqual(result.Content.Headers.ContentType.MediaType, "image/png");
        }

        ///<summary>
        ///Test for ClipartTemplateController controller.
        ///</summary>
        [TestMethod]
        public void Cannot_Retrieve_ClipartImage_Data_For_Invalid_ID()
        {
            // Arrange - create a ClipartTemplate with image data
            ClipartTemplate clipartTemplate = new ClipartTemplate
            {
                Id = 1,
                Name = "ClipartTemplate2",
                Image = new byte[] { }
            };

            // Arrange - create the mock repository
            Mock<IRepository<ClipartTemplate>> mock = new Mock<IRepository<ClipartTemplate>>();
            mock.Setup(m => m.Get(1)).Returns(clipartTemplate);

            // Arrange - create the controller
            ClipartTemplateController target = new ClipartTemplateController(mock.Object);

            // Act - call the Image method
            HttpResponseMessage result = target.Image(100);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpResponseMessage));
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
        }

        ///<summary>
        ///Test for TextTemplateController controller.
        ///</summary>
        [TestMethod]
        public void Can_Retrieve_Text_Image_Data()
        {
            // Arrange - create a TextTemplate with image data
            TextTemplate textTemplate = new TextTemplate
            {
                Id = 1,
                Name = "TextTemplate1",
                Image = new byte[] { }
            };

            // Arrange - create the mock repository
            Mock<IRepository<TextTemplate>> mock = new Mock<IRepository<TextTemplate>>();
            mock.Setup(m => m.Get(1)).Returns(textTemplate);

            // Arrange - create the controller
            TextTemplateController target = new TextTemplateController(mock.Object);

            // Act - call the Image method
            HttpResponseMessage result = target.Image(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpResponseMessage));
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(result.Content.Headers.ContentType.MediaType, "image/png");
        }

        ///<summary>
        ///Test for TextTemplateController controller.
        ///</summary>
        [TestMethod]
        public void Cannot_Retrieve_TextImage_Data_For_Invalid_ID()
        {
            // Arrange - create a TextTemplate with image data
            TextTemplate textTemplate = new TextTemplate
            {
                Id = 1,
                Name = "TextTemplate1",
                Image = new byte[] { }
            };

            // Arrange - create the mock repository
            Mock<IRepository<TextTemplate>> mock = new Mock<IRepository<TextTemplate>>();
            mock.Setup(m => m.Get(1)).Returns(textTemplate);

            // Arrange - create the controller
            TextTemplateController target = new TextTemplateController(mock.Object);

            // Act - call the Image method
            HttpResponseMessage result = target.Image(100);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpResponseMessage));
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
        }

        ///<summary>
        ///Test for SampleController controller.
        ///</summary>
        [TestMethod]
        public void Can_Retrieve_Sample_Thumbnail_Data()
        {
            // Arrange - create a Sample with image (thumbnail) data
            Sample sample = new Sample
            {
                Id = 1,
                Thumbnail = new byte[] { }
            };

            // Arrange - create the mock repository
            Mock<IRepository<Sample>> mock = new Mock<IRepository<Sample>>();
            mock.Setup(m => m.Get(1)).Returns(sample);

            // Arrange - create the controller
            SampleController target = new SampleController(mock.Object);

            // Act - call the Thumbnail method
            HttpResponseMessage result = target.Thumbnail(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpResponseMessage));
            Assert.AreEqual(result.Content.Headers.ContentType.MediaType, "image/png");
        }

        ///<summary>
        ///Test for SampleController controller.
        ///</summary>
        [TestMethod]
        public void Cannot_Retrieve_Sample_Thumbnail_Data_For_Invalid_ID()
        {
            // Arrange - create a Sample with image (thumbnail) data
            Sample sample = new Sample
            {
                Id = 1,
                Thumbnail = new byte[] { }
            };

            // Arrange - create the mock repository
            Mock<IRepository<Sample>> mock = new Mock<IRepository<Sample>>();
            mock.Setup(m => m.Get(1)).Returns(sample);

            // Arrange - create the controller
            SampleController target = new SampleController(mock.Object);

            // Act - call the Thumbnail method
            HttpResponseMessage result = target.Thumbnail(100);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpResponseMessage));
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
        }


        ///<summary>
        ///Test for ClipartGalleryController controller.
        ///</summary>
        [TestMethod]
        public void Clipart_Gallery_Contains_All_Items()
        {
            // Arrange - create the mock repository
            Mock<IRepository<ClipartGallery>> mock = new Mock<IRepository<ClipartGallery>>();
            mock.Setup(m => m.GetAllWithInclude("Items")).Returns(new ClipartGallery[] {
                new ClipartGallery {Id = 1, Name = "ClipartGallery1", 
                    Items = new List<ClipartTemplate> () {
                        new ClipartTemplate () {Id = 1, Name = "ClipartTemplate1"},
                        new ClipartTemplate () {Id = 2, Name = "ClipartTemplate2"},
                        new ClipartTemplate () {Id = 3, Name = "ClipartTemplate3"} 
                }},
                new ClipartGallery {Id = 2, Name = "ClipartGallery2"},
                new ClipartGallery {Id = 3, Name = "ClipartGallery3"},
            }.AsQueryable());

            // Arrange - create a controller
            ClipartGalleryController target = new ClipartGalleryController(mock.Object);

            // Action
            List<ClipartGallery> result = target.List();

            // Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("ClipartGallery1", result[0].Name);
            Assert.AreEqual("ClipartGallery2", result[1].Name);
            Assert.AreEqual("ClipartGallery3", result[2].Name);
            Assert.AreEqual(((List<ClipartTemplate>)(result[0].Items)).Count, 3);
            Assert.AreEqual("ClipartTemplate1", ((List<ClipartTemplate>)(result[0].Items))[0].Name);
            Assert.AreEqual("ClipartTemplate2", ((List<ClipartTemplate>)(result[0].Items))[1].Name);
            Assert.AreEqual("ClipartTemplate3", ((List<ClipartTemplate>)(result[0].Items))[2].Name);
        }

    }
}

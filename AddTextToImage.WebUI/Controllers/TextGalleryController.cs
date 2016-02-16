using AddTextToImage.Domain.Entities;
using AddTextToImage.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddTextToImage.WebUI.Controllers
{
    ///<summary>
    ///This api controller provides method which returns a list of TextGallery items.
    ///</summary>
    public class TextGalleryController : ApiController
    {
        private readonly IRepository<TextGallery> _textGalleryRepository;

        ///<summary>
        /// Creates a new instance of the TextGalleryController class.
        ///</summary>
        public TextGalleryController(IRepository<TextGallery> textGalleryRepository)
        {
            _textGalleryRepository = textGalleryRepository;
        }


        // Передается все информация
        [HttpGet]
        public List<TextGallery> List()
        {
            List<TextGallery> templateGalleryList =
                (from tg in _textGalleryRepository.GetAllWithInclude("Items")
                 select tg)
                 .ToList<TextGallery>();

            return templateGalleryList;
        }


    }
}

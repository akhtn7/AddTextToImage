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
    ///This api controller provides method which returns list of ClipartGallery items.
    ///</summary>
    public class ClipartGalleryController : ApiController
    {
        private readonly IRepository<ClipartGallery> _clipartGalleryRepository;

        ///<summary>
        /// Creates a new instance of the ClipartGalleryController class.
        ///</summary>
        public ClipartGalleryController(IRepository<ClipartGallery> clipartGalleryRepository)
        {
            _clipartGalleryRepository = clipartGalleryRepository;
        }

        ///<summary>
        ///Returns list of ClipartGallery items. It calls from 'clipartSelector.loadData()' JavaScript function.
        ///</summary>
        [HttpGet]
        public List<ClipartGallery> List()
        {
            List<ClipartGallery> clipartGalleryList = _clipartGalleryRepository.GetAllWithInclude("Items").ToList<ClipartGallery>();

            return clipartGalleryList;
        }
    }
}

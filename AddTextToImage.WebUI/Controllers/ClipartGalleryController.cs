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
    public class ClipartGalleryController : ApiController
    {
        private readonly IRepository<ClipartGallery> _clipartGalleryRepository;

        public ClipartGalleryController(IRepository<ClipartGallery> clipartGalleryRepository)
        {
            _clipartGalleryRepository = clipartGalleryRepository;
        }


        [HttpGet]
        public List<ClipartGallery> List()
        {
            List<ClipartGallery> clipartGalleryList = _clipartGalleryRepository.GetAllWithInclude("Items").ToList<ClipartGallery>();

            return clipartGalleryList;
        }
    }
}

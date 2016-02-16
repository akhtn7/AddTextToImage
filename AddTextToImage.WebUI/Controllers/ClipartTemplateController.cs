using AddTextToImage.Domain.Entities;
using AddTextToImage.Domain.Repository;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AddTextToImage.WebUI.Controllers
{
    ///<summary>
    ///This api controller provides method which returns an image of ClipartTemplate item.
    ///</summary>
    public class ClipartTemplateController : ApiController
    {
        private readonly IRepository<ClipartTemplate> _clipartTemplateRepository;

        ///<summary>
        /// Creates a new instance of the ClipartTemplateController class.
        ///</summary>
        public ClipartTemplateController(IRepository<ClipartTemplate> clipartTemplateRepository)
        {
            _clipartTemplateRepository = clipartTemplateRepository;
        }


        ///<summary>
        ///Returns an image for ClipartTemplate item. It calls from 'clipartSelector.showGallery()' JavaScript function.
        ///</summary>
        [HttpGet]
        public HttpResponseMessage Image(int id)
        {
            //ToDo
            if (!ModelState.IsValid)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            var clipartTemplate = _clipartTemplateRepository.Get(id);

            if (clipartTemplate == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            response.Content = new ByteArrayContent(clipartTemplate.Image);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            return response;
        }
    }
}

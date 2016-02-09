using AddTextToImage.Domain.Entities;
using AddTextToImage.Domain.Repository;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AddTextToImage.WebUI.Controllers
{
    public class ClipartTemplateController : ApiController
    {
        private readonly IRepository<ClipartTemplate> _clipartTemplateRepository;

        public ClipartTemplateController(IRepository<ClipartTemplate> clipartTemplateRepository)
        {
            _clipartTemplateRepository = clipartTemplateRepository;
        }

        [HttpGet]
        public HttpResponseMessage Image(int id)
        {
            var clipartTemplate = _clipartTemplateRepository.Get(id);

            if (clipartTemplate != null)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

                response.Content = new ByteArrayContent(clipartTemplate.Image);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                return response;
            }
            else
                return null;
        }
    }
}

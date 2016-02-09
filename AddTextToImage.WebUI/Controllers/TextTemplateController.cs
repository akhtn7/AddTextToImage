using AddTextToImage.Domain.Entities;
using AddTextToImage.Domain.Repository;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AddTextToImage.WebUI.Controllers
{
    public class TextTemplateController : ApiController
    {
        private readonly IRepository<TextTemplate> _textTemplateRepository;

        public TextTemplateController(IRepository<TextTemplate> textTemplateRepository)
        {
            _textTemplateRepository = textTemplateRepository;
        }


        /// <summary>
        /// Return an image for 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Image(int id)
        {
            var textTemplate = _textTemplateRepository.Get(id);

            if (textTemplate != null)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

                response.Content = new ByteArrayContent(textTemplate.Image);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                return response;
            }
            else
                return null;
        }
    }
}

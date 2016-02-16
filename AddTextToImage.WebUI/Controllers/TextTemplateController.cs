using AddTextToImage.Domain.Entities;
using AddTextToImage.Domain.Repository;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AddTextToImage.WebUI.Controllers
{
    ///<summary>
    ///This api controller provides method which returns an image of ClipartTemplate item.
    ///</summary>
    public class TextTemplateController : ApiController
    {
        private readonly IRepository<TextTemplate> _textTemplateRepository;

        ///<summary>
        /// Creates a new instance of the TextTemplateController class.
        ///</summary>
        public TextTemplateController(IRepository<TextTemplate> textTemplateRepository)
        {
            _textTemplateRepository = textTemplateRepository;
        }


        /// <summary>
        /// Returns an image for TextTemplate item.
        /// </summary>
        /// <param name="id">Unique identifier of TextTemplate item.</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Image(int id)
        {
            var textTemplate = _textTemplateRepository.Get(id);

            if (textTemplate == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            response.Content = new ByteArrayContent(textTemplate.Image);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            return response;
        }
    }
}

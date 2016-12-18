using AddTextToImage.Data.Service;
using AddTextToImage.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddTextToImage.WebUI.Controllers
{
    public class SampleController : ApiController
    {
        private readonly IRepository<Sample> _sampleRepository;

        private readonly int PageSize = 8;

        ///<summary>
        /// Creates a new instance of the SampleController class.
        ///</summary>
        public SampleController(IRepository<Sample> sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }


        ///<summary>
        ///Returns a list of Sample Ids.
        ///</summary>
        [HttpGet]
        public IEnumerable<int> List(int samplePageIndex)
        {
            if (!ModelState.IsValid)
                return new int[0];

            int[] result = _sampleRepository.GetAll().OrderBy(p => p.Id).Skip(samplePageIndex * PageSize).Take(PageSize).Select(p => p.Id).ToArray<int>();

            return result;
        }

        ///<summary>
        ///Returns a thumbnail image for Sample item.
        ///</summary>
        [HttpGet]
        public HttpResponseMessage Thumbnail(int id)
        {
            if (!ModelState.IsValid)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            Sample sample = _sampleRepository.Get(id);

            if (sample == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            response.Content = new ByteArrayContent(sample.Thumbnail);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");

            return response;
        }
    }
}

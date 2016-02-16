using AddTextToImage.Domain.Entities;
using AddTextToImage.Domain.Repository;
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
            int[] result =
               (from s in _sampleRepository.GetAll()
                orderby s.Id
                select s.Id)
                .Skip(samplePageIndex * 8)
                .Take(8)
                .ToArray<int>();

            return result;
        }

        ///<summary>
        ///Returns a thumbnail image for Sample item.
        ///</summary>
        [HttpGet]
        public HttpResponseMessage Thumbnail(int id)
        {
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

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
    public class SampleController : ApiController
    {
        private readonly IRepository<Sample> _sampleRepository;

        public SampleController(IRepository<Sample> sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        [HttpGet]
        public IEnumerable<int> List(int samplePageIndex)
        {
            int[] result = (from s in _sampleRepository.GetAll()
                            orderby s.Id
                            select s.Id).Skip(samplePageIndex * 8).Take(8).ToArray<int>();

            return result;
        }


        [HttpGet]
        public HttpResponseMessage Thumbnail(int id)
        {
            Sample sample = _sampleRepository.Get(id);

            if (sample != null)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

                response.Content = new ByteArrayContent(sample.Thumbnail);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");

                return response;
            }
            else
                return null;
        }


    }
}

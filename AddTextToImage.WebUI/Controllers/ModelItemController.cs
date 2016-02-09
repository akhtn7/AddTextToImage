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

    public class ModelItemController : ApiController
    {
        private readonly IRepository<ModelItem> _modelItemRepository;

        public ModelItemController(IRepository<ModelItem> modelItemRepository)
        {
            _modelItemRepository = modelItemRepository;
        }


        [HttpPost]
        public void Update(ModelItem modelItem)
        {
            var mi = _modelItemRepository.Get(modelItem.Id);
            if (mi != null)
            {
                mi.PositionLeft = modelItem.PositionLeft;
                mi.PositionTop = modelItem.PositionTop;
                mi.Rotation = modelItem.Rotation;
                mi.Text = modelItem.Text;
                mi.TemplateId = modelItem.TemplateId;
                mi.FontColor = modelItem.FontColor;
                mi.FontSize = modelItem.FontSize;

                _modelItemRepository.Save();
            }
        }

        [HttpDelete]
        public void Delete(ModelItem modelItem)
        {
            var mi = _modelItemRepository.Get(modelItem.Id);

            if (mi != null)
            {
                _modelItemRepository.Delete(mi);

                _modelItemRepository.Save();
            }
        }

    }
}

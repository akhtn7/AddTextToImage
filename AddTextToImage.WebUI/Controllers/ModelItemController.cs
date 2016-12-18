using AddTextToImage.Data.Service;
using AddTextToImage.Domain.Entities;
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

        ///<summary>
        /// Creates a new instance of the ModelItemController class.
        ///</summary>
        public ModelItemController(IRepository<ModelItem> modelItemRepository)
        {
            _modelItemRepository = modelItemRepository;
        }


        [HttpPost]
        public void Update(ModelItem modelItem)
        {
            //ToDo JavaScript does not know if modelItem saves in the database
            if (!ModelState.IsValid)
                return;

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
            //ToDo JavaScript does not know if modelItem deletes from the database
            if (!ModelState.IsValid)
                return;

            var mi = _modelItemRepository.Get(modelItem.Id);

            if (mi != null)
            {
                _modelItemRepository.Delete(mi);

                _modelItemRepository.Save();
            }
        }

    }
}

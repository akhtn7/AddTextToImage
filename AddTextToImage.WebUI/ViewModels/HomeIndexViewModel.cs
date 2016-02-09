using System.Collections.Generic;
using System.Web.Mvc;

namespace AddTextToImage.WebUI.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<SelectListItem> TextGalleryList { get; set; }

        public List<SelectListItem> ClipartGalleryList { get; set; }

        public int[] SampleIds { get; set; }

        public int SampleTotalPage { get; set; }

        public int SelectedTextTemplateId { get; set; }

        public string SelectedTextTemplateName { get; set; }

        public string SelectedTextTemplateTextColor1 { get; set; }

        public int SelectedTextGalleryId { get; set; }

    }
}
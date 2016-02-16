using AddTextToImage.Domain.Entities;
using AddTextToImage.Domain.Repository;
using AddTextToImage.WebUI.ViewModels;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;


namespace AddTextToImage.WebUI.Controllers
{
    /// <summary>
    /// This controller supplies the main view of the site.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IRepository<Sample> _sampleRepository;
        private readonly IRepository<TextGallery> _textGalleryRepository;
        private readonly IRepository<ClipartGallery> _clipartGalleryRepository;

        ///<summary>
        /// Creates a new instance of the HomeController class.
        ///</summary>
        public HomeController(IRepository<Sample> sampleRepository, IRepository<TextGallery> textGalleryRepository, IRepository<ClipartGallery> clipartGalleryRepository)
        {
            this._sampleRepository = sampleRepository;
            this._textGalleryRepository = textGalleryRepository;
            this._clipartGalleryRepository = clipartGalleryRepository;
        }

        public ActionResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel();

            var textGalleryList = _textGalleryRepository.GetAllWithInclude("Items");

            var textGallery = textGalleryList.FirstOrDefault();

            if (textGallery != null)
            {
                viewModel.SelectedTextGalleryId = textGallery.Id;

                if (textGallery.Items.Count > 0)
                {
                    viewModel.SelectedTextTemplateId = textGallery.Items.First().Id;
                    viewModel.SelectedTextTemplateName = textGallery.Items.First().Name;
                    viewModel.SelectedTextTemplateTextColor1 = ColorTranslator.ToHtml(Color.FromArgb(textGallery.Items.First().TextColor1));
                }
            }

            // Populate drop down lists with text gallery names
            viewModel.TextGalleryList = textGalleryList.Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString()}).ToList<SelectListItem>();

            // Populate drop down lists with clipart gallery names
            viewModel.ClipartGalleryList = _clipartGalleryRepository.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString() }).ToList<SelectListItem>();

            viewModel.SampleIds = _sampleRepository.GetAll().OrderBy(p => p.Id).Take(8).Select(p => p.Id).ToArray<int>();

            //ToDo If total samples does not div on 8
            viewModel.SampleTotalPage = (_sampleRepository.GetAll().Count() / 8) - 1;

            return View(viewModel);
        }
    }
}
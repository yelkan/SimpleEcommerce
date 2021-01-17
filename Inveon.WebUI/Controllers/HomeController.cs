using Inveon.Services.Abstract;
using System.Web.Mvc;

namespace Inveon.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product()
        {
            var model = _productService.Products();          

            ViewBag.Message = "Inveon Ecommerce Procudts";

            return View(model);
        }

        public ActionResult ProductDetail(long Id)
        {
            var model = _productService.ProductDetail(Id);

            if(model==null)
            return View("Error");

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
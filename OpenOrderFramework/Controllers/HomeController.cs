using System.Web.Mvc;

namespace OpenOrderFramework.Controllers {
    public class HomeController : Controller {
        public ActionResult Index()
        {
            return View("Index", "_SplashLayout");
        }

        
        public ActionResult About() {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

using System.Web.Mvc;

namespace Epam.Wunderlist.MvcPL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
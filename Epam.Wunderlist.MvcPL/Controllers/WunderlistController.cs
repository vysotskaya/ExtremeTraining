using System.Web.Mvc;

namespace Epam.Wunderlist.MvcPL.Controllers
{
    [Authorize]
    public class WunderlistController : Controller
    {
        [ActionName("wunderlist")]
        public ActionResult GetMainWunderlistPage()
        {
            return View();
        }
    }
}
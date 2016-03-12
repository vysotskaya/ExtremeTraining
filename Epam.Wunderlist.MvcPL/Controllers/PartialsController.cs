using System.Web.Mvc;

namespace Epam.Wunderlist.MvcPL.Controllers
{
    public class PartialsController : Controller
    {
        public ActionResult TodoTasks()
        {
            return PartialView("tasks");
        }

        public ActionResult EditTodoListModal()
        {
            return PartialView("editTodoListModal");
        }
    }
}
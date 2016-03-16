using System.Web.Mvc;

namespace Epam.Wunderlist.MvcPL.Controllers
{
    public class PartialsController : Controller
    {
        public ActionResult TodoTasks()
        {
            return PartialView("tasks");
        }

        public ActionResult DetailOfTodoTask()
        {
            return PartialView("detailOfTodoTask");
        }

        public ActionResult EditTodoListModal()
        {
            return PartialView("editTodoListModal");
        }
    }
}
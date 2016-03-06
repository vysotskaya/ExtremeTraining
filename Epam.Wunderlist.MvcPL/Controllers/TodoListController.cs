using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataServices.TodoListServices;
using Epam.Wunderlist.MvcPL.Identity;
using Ninject;

namespace Epam.Wunderlist.MvcPL.Controllers
{
    public class TodoListController : ApiController
    {
        [Inject]
        private readonly ITodoListService _todoListService;

        public TodoListController()
        {
            _todoListService = (ITodoListService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ITodoListService));
        }

        //public TodoListController(ITodoListService todoListService)
        //{
        //    _todoListService = todoListService;
        //}

        [HttpGet]
        public IEnumerable<object> Get()
        {
            var lists = _todoListService.GetListEntitiesByUserId(User.Identity.GetUserId<int>())?.ToList();
            return lists;
        }

        [HttpPost]
        public int Post(TodoList todoList)
        {
            var createdId = _todoListService.Create(todoList);
            return createdId;
        }
    }
}

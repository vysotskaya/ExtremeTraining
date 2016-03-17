using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataServices.TodoListServices;
using Epam.Wunderlist.MvcPL.Identity;

namespace Epam.Wunderlist.MvcPL.Controllers
{
    public class TodoListController : ApiController
    {
        private readonly ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

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

        [HttpPut]
        public void Put(int id, [FromBody]TodoList todoList)
        {
            _todoListService.Update(todoList);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var todoList = _todoListService.GetById(id);
            _todoListService.Delete(todoList);
        }
    }
}

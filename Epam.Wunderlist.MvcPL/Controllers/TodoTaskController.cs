using System.Collections.Generic;
using System.Web.Http;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataServices.TodoTaskServices;

namespace Epam.Wunderlist.MvcPL.Controllers
{
    [Authorize]
    public class TodoTaskController : ApiController
    {
        private readonly ITodoTaskService _todoTaskService;

        public TodoTaskController(ITodoTaskService todoTaskService)
        {
            _todoTaskService = todoTaskService;
        }

        [HttpGet]
        public object Get(int? id)
        {
            if (id.HasValue)
            {
                var task = _todoTaskService.GetById(id.Value);
                return task;
            }
            return null;
        }

        [HttpGet]
        public IEnumerable<object> GetByListId(int? todoListId)
        {
            if (todoListId.HasValue)
            {
                var tasks = _todoTaskService.GetByListId(todoListId.Value);
                return tasks;
            }
            return new List<object>();
        }

        [HttpPost]
        public object Post(TodoTask todoTask)
        {
            var createdTodoTask= _todoTaskService.Create(todoTask);
            return createdTodoTask;
        }

        public void Put(int id, [FromBody]TodoTask todoTask)
        {
            _todoTaskService.Update(todoTask);
        }

        [HttpPut]
        public void Put(IEnumerable<TodoTask> todoTasks)
        {
            _todoTaskService.UpdatePriority(todoTasks);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var todoList = _todoTaskService.GetById(id);
            _todoTaskService.Delete(todoList);
        }
    }
}

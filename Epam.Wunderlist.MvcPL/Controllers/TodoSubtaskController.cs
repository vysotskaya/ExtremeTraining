using System.Collections.Generic;
using System.Web.Http;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataServices.TodoSubtaskServices;
using Ninject;

namespace Epam.Wunderlist.MvcPL.Controllers
{
    public class TodoSubtaskController : ApiController
    {
        [Inject]
        private readonly ITodoSubtaskService _todoSubtaskService;

        public TodoSubtaskController(ITodoSubtaskService todoSubtaskService)
        {
            _todoSubtaskService = todoSubtaskService;
        }

        [HttpGet]
        public object Get(int id)
        {
            var subtask = _todoSubtaskService.GetById(id);
            return subtask;
        }

        [HttpGet]
        public IEnumerable<object> GetByTaskId(int? todoTaskId)
        {
            if (todoTaskId.HasValue)
            {
                var subtask = _todoSubtaskService.GetByTaskId(todoTaskId.Value);
                return subtask;
            }
            return new List<object>();
        }

        [HttpPost]
        public object Post(TodoSubtask todoSubtask)
        {
            var createdTodoSubtask = _todoSubtaskService.Create(todoSubtask);
            return createdTodoSubtask;
        }

        [HttpPut]
        public void Put(int id, [FromBody]TodoSubtask todoSubtask)
        {
            _todoSubtaskService.Update(todoSubtask);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var subtask = _todoSubtaskService.GetById(id);
            _todoSubtaskService.Delete(subtask);
        }
    }
}
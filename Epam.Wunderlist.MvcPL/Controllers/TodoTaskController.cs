using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataServices.TodoTaskServices;
using Ninject;

namespace Epam.Wunderlist.MvcPL.Controllers
{
    public class TodoTaskController : ApiController
    {
        [Inject]
        private readonly ITodoTaskService _todoTaskService;

        public TodoTaskController()
        {
            _todoTaskService = (ITodoTaskService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ITodoTaskService));
        }

        //public TodoListController(ITodoListService todoListService)
        //{
        //    _todoListService = todoListService;
        //}

        [HttpGet]
        public object Get(int id)
        {
            var task = _todoTaskService.GetById(id);
            return task;
        }

        [HttpGet]
        public IEnumerable<object> GetByListId(int todoListId)
        {
            var tasks = _todoTaskService.GetByListId(todoListId);
            return tasks;
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

        [HttpDelete]
        public void Delete(int id)
        {
            var todoList = _todoTaskService.GetById(id);
            _todoTaskService.Delete(todoList);
        }
    }
}

using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;

namespace Epam.Wunderlist.DataServices.TodoTaskServices
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly ITodoTaskRepository _todoTaskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TodoTaskService(ITodoTaskRepository todoTaskRepository, IUnitOfWork unitOfWork)
        {
            _todoTaskRepository = todoTaskRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TodoTask> GetByListId(int todoListId)
        {
            return _todoTaskRepository.GetByTodoListId(todoListId);
        }

        public TodoTask GetById(int id)
        {
            return _todoTaskRepository.GetById(id);
        }

        public void Create(TodoTask entity)
        {
            _todoTaskRepository.Create(entity);
            _unitOfWork.Commit();
        }

        public void Update(TodoTask entity)
        {
            _todoTaskRepository.Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(TodoTask entity)
        {
            _todoTaskRepository.Delete(entity);
            _unitOfWork.Commit();
        }
    }
}

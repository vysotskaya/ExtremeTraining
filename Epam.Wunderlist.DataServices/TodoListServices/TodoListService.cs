using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;

namespace Epam.Wunderlist.DataServices.TodoListServices
{
    public class TodoListService : ITodoListService
    {
        private readonly ITodoListRepository _todoListRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TodoListService(ITodoListRepository todoListRepository, IUnitOfWork unitOfWork)
        {
            _todoListRepository = todoListRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TodoList> GetListEntitiesByUserId(int userId)
        {
            return _todoListRepository.GetByUserId(userId);
        }

        public TodoList GetById(int id)
        {
            return _todoListRepository.GetById(id);
        }

        public int Create(TodoList entity)
        {
            var insertedTodoListId = _todoListRepository.Create(entity);
            _unitOfWork.Commit();
            return insertedTodoListId;
        }

        public void Update(TodoList entity)
        {
            _todoListRepository.Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(TodoList entity)
        {
            _todoListRepository.Delete(entity);
            _unitOfWork.Commit();
        }
    }
}

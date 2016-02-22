using System.Collections.Generic;
using System.Linq;
using BLL.Interface.BllEntities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repositories;

namespace BLL.Concrete
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

        public IEnumerable<TodoTaskEntity> GetTaskEntitiesByListId(int todoListId)
        {
            return _todoTaskRepository.GetByTodoListId(todoListId).Select(t => t.ToTodoTaskEntity());
        }

        public TodoTaskEntity GetTodoTaskEntity(int id)
        {
            return _todoTaskRepository.GetById(id).ToTodoTaskEntity();
        }

        public void CreateTodoTask(TodoTaskEntity todoTaskEntity)
        {
            _todoTaskRepository.Create(todoTaskEntity.ToDalTodoTask());
            _unitOfWork.Commit();
        }

        public void UpdateTodoTask(TodoTaskEntity todoTaskEntity)
        {
            _todoTaskRepository.Update(todoTaskEntity.ToDalTodoTask());
            _unitOfWork.Commit();
        }

        public void DeleteTodoTask(TodoTaskEntity todoTaskEntity)
        {
            _todoTaskRepository.Delete(todoTaskEntity.ToDalTodoTask());
            _unitOfWork.Commit();
        }
    }
}

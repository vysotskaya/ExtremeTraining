using System.Collections.Generic;
using System.Linq;
using BLL.Interface.BllEntities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repositories;

namespace BLL.Concrete
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

        public IEnumerable<TodoListEntity> GetListEntitiesByUserId(int userId)
        {
            return _todoListRepository.GetByUserId(userId).Select(l => l.ToTodoListEntity());
        }

        public TodoListEntity GetTodoListEntity(int id)
        {
            return _todoListRepository.GetById(id).ToTodoListEntity();
        }

        public void CreateTodoList(TodoListEntity todoListEntity)
        {
            _todoListRepository.Create(todoListEntity.ToDalListEntity());
            _unitOfWork.Commit();
        }

        public void UpdateTodoList(TodoListEntity todoListEntity)
        {
            _todoListRepository.Update(todoListEntity.ToDalListEntity());
            _unitOfWork.Commit();
        }

        public void DeleteTodoList(TodoListEntity todoListEntity)
        {
            _todoListRepository.Delete(todoListEntity.ToDalListEntity());
            _unitOfWork.Commit();
        }
    }
}

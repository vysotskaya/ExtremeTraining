using System;
using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;
using Epam.Wunderlist.Logger;

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
            try
            {
                return _todoListRepository.GetByUserId(userId);
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return new List<TodoList>();
            }
        }

        public TodoList GetById(int id)
        {
            try
            {
                return _todoListRepository.GetById(id);
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return null;
            }
        }

        public int Create(TodoList entity)
        {
            try
            {
                var insertedTodoListId = _todoListRepository.Create(entity);
                _unitOfWork.Commit();
                return insertedTodoListId;
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return 0;
            }
        }

        public void Update(TodoList entity)
        {
            try
            {
                _todoListRepository.Update(entity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Log.LogError(e);
            }
        }

        public void Delete(TodoList entity)
        {
            try
            {
                _todoListRepository.Delete(entity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Log.LogError(e);
            }
        }
    }
}

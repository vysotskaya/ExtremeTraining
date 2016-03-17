using System;
using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;
using Epam.Wunderlist.Logger;

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
            try
            {
                return _todoTaskRepository.GetByTodoListId(todoListId);
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return new List<TodoTask>();
            }
        }

        public TodoTask GetById(int id)
        {
            try
            {
                return _todoTaskRepository.GetById(id);
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return null;
            }
        }

        public TodoTask Create(TodoTask entity)
        {
            try
            {
                var id = _todoTaskRepository.Create(entity);
                _unitOfWork.Commit();
                return id != 0 ? _todoTaskRepository.GetById(id) : null;
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return null;
            }
        }

        public void Update(TodoTask entity)
        {
            try
            {
                _todoTaskRepository.Update(entity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Log.LogError(e);
            }
        }

        public void UpdatePriority(IEnumerable<TodoTask> list)
        {
            try
            {
                foreach (var task in list)
                {
                    _todoTaskRepository.Update(task);
                }
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Log.LogError(e);
            }
        }

        public void Delete(TodoTask entity)
        {
            try
            {
                _todoTaskRepository.Delete(entity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Log.LogError(e);
            }
        }
    }
}

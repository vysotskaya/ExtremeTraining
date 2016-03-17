using System;
using System.Collections.Generic;
using System.Linq;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;
using Epam.Wunderlist.Logger;

namespace Epam.Wunderlist.DataServices.TodoSubtaskServices
{
    public class TodoSubtaskService : ITodoSubtaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITodoSubtaskRepository _subtaskRepository;

        public TodoSubtaskService(IUnitOfWork unitOfWork, ITodoSubtaskRepository subtaskRepository)
        {
            _unitOfWork = unitOfWork;
            _subtaskRepository = subtaskRepository;
        }

        public TodoSubtask Create(TodoSubtask entity)
        {
            try
            {
                var id = _subtaskRepository.Create(entity);
                _unitOfWork.Commit();
                return id != 0 ? _subtaskRepository.GetById(id) : null;
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return null;
            }
        }

        public void Delete(TodoSubtask entity)
        {
            try
            {
                _subtaskRepository.Delete(entity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Log.LogError(e);
            }
        }

        public TodoSubtask GetById(int key)
        {
            try
            {
                return _subtaskRepository.GetById(key);
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return null;
            }
        }

        public void Update(TodoSubtask entity)
        {
            try
            {
                _subtaskRepository.Update(entity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Log.LogError(e);
            }
        }

        public IEnumerable<TodoSubtask> GetByTaskId(int taskId)
        {
            try
            {
                return _subtaskRepository.GetByTaskId(taskId).ToList();
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return new List<TodoSubtask>();
            }
        }

        
    }
}

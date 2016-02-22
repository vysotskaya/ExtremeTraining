using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Services;
using BLL.Interface.BllEntities;
using DAL.Interface.Repositories;
using BLL.Mappers;


namespace BLL.Concrete
{
    public class TodoSubtaskService : ITodoSubtaskService
    {
        private readonly IUnitOfWork _uow;
        private readonly ITodoSubtaskRepository _subtaskRepository;

        public TodoSubtaskService(IUnitOfWork uow, ITodoSubtaskRepository subtaskRepository)
        {
            _uow = uow;
            _subtaskRepository = subtaskRepository;
        }

        public void Create(TodoSubtaskEntity entity)
        {
            _subtaskRepository.Create(entity.ToDalTodoSubtask());
            _uow.Commit();
        }

        public void Delete(TodoSubtaskEntity entity)
        {
            _subtaskRepository.Delete(entity.ToDalTodoSubtask());
            _uow.Commit();
        }

        public IEnumerable<TodoSubtaskEntity> GetAll()
        {
            return _subtaskRepository.GetAll().Select(subtask => subtask.ToBllToDoSubtask());
        }

        public TodoSubtaskEntity GetById(int key)
        {
            return _subtaskRepository.GetById(key).ToBllToDoSubtask();
        }

        public void Update(TodoSubtaskEntity entity)
        {
            _subtaskRepository.Update(entity.ToDalTodoSubtask());
            _uow.Commit();
        }

        public IEnumerable<TodoSubtaskEntity> GetByTaskId(int taskId)
        {
            return _subtaskRepository.GetByTaskId(taskId).Select(subtask => subtask.ToBllToDoSubtask());
        }

        
    }
}

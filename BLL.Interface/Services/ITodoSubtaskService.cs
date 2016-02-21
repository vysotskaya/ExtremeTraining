using System;
using System.Collections.Generic;
using BLL.Interface.BllEntities;

namespace BLL.Interface.Services
{
    public interface ITodoSubtaskService
    {
        IEnumerable<TodoSubtaskEntity> GetAll();
        IEnumerable<TodoSubtaskEntity> GetByTaskId(int taskId);
        IEnumerable<TodoSubtaskEntity> GetBySateId(int stateId);
        TodoSubtaskEntity GetById(int key);
        void Create(TodoSubtaskEntity entity);
        void Update(TodoSubtaskEntity entity);
        void Delete(TodoSubtaskEntity entity);
    }
}

using System;
using System.Collections.Generic;
using BLL.Interface.BllEntities;

namespace BLL.Interface.Services
{
    public interface IStateService
    {
        IEnumerable<StateEntity> GetAll();
        StateEntity GetById(int key);       
        void Create(StateEntity entity);
        void Update(StateEntity entity);
        void Delete(StateEntity entity);
    }
}

using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Services;
using BLL.Interface.BllEntities;
using DAL.Interface.Repositories;
using BLL.Mappers;

namespace BLL.Concrete
{
    public class StateService : IStateService
    {
        private readonly IUnitOfWork _uow;
        private readonly IStateRepository _statusRepository;

        public StateService(IUnitOfWork uow, IStateRepository statusRepository)
        {
            _uow = uow;
            _statusRepository = statusRepository;
        }

        public void Create(StateEntity entity)
        {
            _statusRepository.Create(entity.ToDalStatus());
            _uow.Commit();
        }

        public void Delete(StateEntity entity)
        {
            _statusRepository.Delete(entity.ToDalStatus());
            _uow.Commit();
        }

        public IEnumerable<StateEntity> GetAll()
        {
            return _statusRepository.GetAll().Select(state => state.ToBllStatus());
        }

        public StateEntity GetById(int key)
        {
            return _statusRepository.GetById(key).ToBllStatus();
        }
        
        public void Update(StateEntity entity)
        {
            _statusRepository.Update(entity.ToDalStatus());
            _uow.Commit();
        }
    }
}

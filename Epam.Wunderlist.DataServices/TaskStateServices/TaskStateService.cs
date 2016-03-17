using System;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;
using Epam.Wunderlist.Logger;

namespace Epam.Wunderlist.DataServices.TaskStateServices
{
    public class TaskStateService : ITaskStateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskStateRepository _taskStateRepository;

        public TaskStateService(IUnitOfWork unitOfWork, ITaskStateRepository taskStateRepository)
        {
            _unitOfWork = unitOfWork;
            _taskStateRepository = taskStateRepository;
        }

        public void Create(TaskState entity)
        {
            try
            {
                _taskStateRepository.Create(entity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Log.LogError(e);
            }
        }

        public void Delete(TaskState entity)
        {
            try
            {
                _taskStateRepository.Delete(entity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Log.LogError(e);
            }
        }

        public TaskState GetById(int key)
        {
            try
            {
                return _taskStateRepository.GetById(key);
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return null;
            }
        }
    }
}

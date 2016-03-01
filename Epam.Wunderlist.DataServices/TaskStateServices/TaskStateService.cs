using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;

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
            _taskStateRepository.Create(entity);
            _unitOfWork.Commit();
        }

        public void Delete(TaskState entity)
        {
            _taskStateRepository.Delete(entity);
            _unitOfWork.Commit();
        }

        public TaskState GetById(int key)
        {
            return _taskStateRepository.GetById(key);
        }
    }
}

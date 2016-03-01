using System.Collections.Generic;
using System.Linq;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;

namespace Epam.Wunderlist.DataServices.AttachedTaskFileServices
{
    public class AttachedTaskFileService : IAttachedTaskFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttachedTaskFileRepository _attachedTaskFileRepository;

        public AttachedTaskFileService(IUnitOfWork unitOfWork, IAttachedTaskFileRepository attachedTaskFileRepository)
        {
            _unitOfWork = unitOfWork;
            _attachedTaskFileRepository = attachedTaskFileRepository;
        }

        public void Create(AttachedTaskFile entity)
        {
            _attachedTaskFileRepository.Create(entity);
            _unitOfWork.Commit();
        }

        public void Delete(AttachedTaskFile entity)
        {
            _attachedTaskFileRepository.Delete(entity);
            _unitOfWork.Commit();
        }

        public AttachedTaskFile GetById(int key)
        {
            return _attachedTaskFileRepository.GetById(key);
        }

        public IEnumerable<AttachedTaskFile> GetByTaskId(int taskId)
        {
            return _attachedTaskFileRepository.GetByTaskId(taskId).ToList();
        }
    }
}

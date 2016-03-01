using System.Collections.Generic;
using System.Linq;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;

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

        public void Create(TodoSubtask entity)
        {
            _subtaskRepository.Create(entity);
            _unitOfWork.Commit();
        }

        public void Delete(TodoSubtask entity)
        {
            _subtaskRepository.Delete(entity);
            _unitOfWork.Commit();
        }

        public TodoSubtask GetById(int key)
        {
            return _subtaskRepository.GetById(key);
        }

        public void Update(TodoSubtask entity)
        {
            _subtaskRepository.Update(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<TodoSubtask> GetByTaskId(int taskId)
        {
            return _subtaskRepository.GetByTaskId(taskId).ToList();
        }

        
    }
}

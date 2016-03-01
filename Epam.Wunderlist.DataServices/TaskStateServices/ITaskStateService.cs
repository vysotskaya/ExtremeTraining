using Epam.Wunderlist.DataAccess.Entities;

namespace Epam.Wunderlist.DataServices.TaskStateServices
{
    public interface ITaskStateService
    {
        TaskState GetById(int key);       
        void Create(TaskState entity);
        void Delete(TaskState entity);
    }
}

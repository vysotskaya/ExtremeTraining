using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;

namespace Epam.Wunderlist.DataServices.AttachedTaskFileServices
{
    public interface IAttachedTaskFileService
    {
        IEnumerable<AttachedTaskFile> GetByTaskId(int taskId);
        AttachedTaskFile GetById(int key);
        void Create(AttachedTaskFile entity);
        void Delete(AttachedTaskFile entity);
    }
}

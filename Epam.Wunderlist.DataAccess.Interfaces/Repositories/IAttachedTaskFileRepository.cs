using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repositories
{
    public interface IAttachedTaskFileRepository: IRepository<AttachedTaskFile>
    {
        IEnumerable<AttachedTaskFile> GetByTaskId(int taskId);
    }
}

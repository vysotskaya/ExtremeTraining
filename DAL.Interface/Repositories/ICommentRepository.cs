using DAL.Interface.DalEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Repositories
{
    public interface ICommentRepository : IRepository<DalComment>
    {
        IEnumerable<DalComment> GetByTaskId(int taskId);
    }
}

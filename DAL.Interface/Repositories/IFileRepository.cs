﻿using System;
using System.Collections.Generic;
using DAL.Interface.DalEntities;

namespace DAL.Interface.Repositories
{
    public interface IFileRepository: IRepository<DalFile>
    {
        IEnumerable<DalFile> GetByTaskId(int taskId);
    }
}

using System;
using System.Collections.Generic;
using BLL.Interface.BllEntities;

namespace BLL.Interface.Services
{
    public interface IFileService
    {
        IEnumerable<FileEntity> GetAll();
        IEnumerable<FileEntity> GetByTaskId(int taskId);
        FileEntity GetById(int key);
        void Create(FileEntity entity);
        void Update(FileEntity entity);
        void Delete(FileEntity entity);
    }
}

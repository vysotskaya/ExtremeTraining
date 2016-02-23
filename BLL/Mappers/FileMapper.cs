using System;
using DAL.Interface.DalEntities;
using BLL.Interface.BllEntities;

namespace BLL.Mappers
{
    public static class FileMapper
    {
        public static DalFile ToDalFile (this FileEntity bllEntity)
        {
            return new DalFile()
            {
                Id = bllEntity.Id,
                Name = bllEntity.Name,
                Content = bllEntity.Content,
                Size = bllEntity.Size,
                CreationDate = bllEntity.CreationDate,
                TodoTaskRefId = bllEntity.TodoTaskRefId
            };
        }

        public static FileEntity ToBllFile(this DalFile dalEntity)
        {
            return new FileEntity()
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name,
                Content = dalEntity.Content,
                Size = dalEntity.Size,
                CreationDate = dalEntity.CreationDate,
                TodoTaskRefId = dalEntity.TodoTaskRefId
            };
        }
    }
}

using ORM;
using DAL.Interface.DalEntities;

namespace DAL.Mappers
{
    public static class DalFileMapper
    {
        public static File ToFile (this DalFile dalEntity)
        {
            return new File()
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name,
                Content = dalEntity.Content,
                CreationDate = dalEntity.CreationDate,
                TodoTaskRefId = dalEntity.TodoTaskRefId
            };
        }

        public static DalFile ToDalFile(this File entity)
        {
            return new DalFile()
            {
                Id = entity.Id,
                Name = entity.Name,
                Content = entity.Content,
                CreationDate = entity.CreationDate,
                TodoTaskRefId = entity.TodoTaskRefId
            };
        }
    }
}

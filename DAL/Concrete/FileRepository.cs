using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using DAL.Interface.DalEntities;
using DAL.Interface.Repositories;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class FileRepository : IFileRepository
    {
        private readonly DbContext context;

        public void Create(DalFile entity)
        {
            var file = entity?.ToFile();
            context.Set<File>().Add(file);
        }

        public void Delete(DalFile entity)
        {
            var removeFile = context.Set<File>().FirstOrDefault(file => file.Id == entity.Id);
            if (removeFile != null)
            {
                context.Set<File>().Remove(removeFile);
            }
        }

        public IEnumerable<DalFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalFile GetById(int key)
        {
            return context.Set<File>().FirstOrDefault(file => file.Id == key)?.ToDalFile();
        }

        public DalFile GetByPredicate(Expression<Func<DalFile, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalFile> GetByTaskId(int taskId)
        {
            return context.Set<File>().Where(file => file.TodoTaskRefId == taskId)
                .Select(file => file.ToDalFile());
        }

        public void Update(DalFile entity)
        {
            throw new NotImplementedException();
        }
    }
}

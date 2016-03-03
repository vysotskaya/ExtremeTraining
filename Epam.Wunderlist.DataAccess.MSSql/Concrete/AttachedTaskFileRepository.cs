using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;
using Epam.Wunderlist.DataAccess.MSSqlDbModel;

namespace Epam.Wunderlist.DataAccess.MSSql.Concrete
{
    public class AttachedTaskFileRepository : IAttachedTaskFileRepository
    {
        private readonly DbContext _dbContext;

        public AttachedTaskFileRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            Mapper.Initialize(cfg => {
                cfg.CreateMap<AttachedTaskFile, AttachedTaskFileDbModel>()
                    .ForSourceMember(x => x.Id, y => y.Ignore());
                cfg.CreateMap<AttachedTaskFileDbModel, AttachedTaskFile>()
                    .ForSourceMember(x => x.TodoTaskDbModel, y => y.Ignore());
            });
        }

        public bool Create(AttachedTaskFile entity)
        {
            var file = Mapper.Map<AttachedTaskFile, AttachedTaskFileDbModel>(entity);
            return _dbContext.Set<AttachedTaskFileDbModel>().Add(file) != null;
        }

        public void Delete(AttachedTaskFile entity)
        {
            var removeFile = _dbContext.Set<AttachedTaskFileDbModel>().FirstOrDefault(file => file.Id == entity.Id);
            if (removeFile != null)
            {
                _dbContext.Set<AttachedTaskFileDbModel>().Remove(removeFile);
            }
        }

        public IEnumerable<AttachedTaskFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public AttachedTaskFile GetById(int key)
        {
            //Exception?
            var task = _dbContext.Set<AttachedTaskFileDbModel>().FirstOrDefault(file => file.Id == key);
            return Mapper.Map<AttachedTaskFileDbModel, AttachedTaskFile>(task);
        }

        public AttachedTaskFile GetByPredicate(Expression<Func<AttachedTaskFile, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AttachedTaskFile> GetByTaskId(int taskId)
        {
            return _dbContext.Set<AttachedTaskFileDbModel>().Where(file => file.TodoTaskRefId == taskId)
                .Select(file => Mapper.Map<AttachedTaskFileDbModel, AttachedTaskFile>(file));
        }

        public void Update(AttachedTaskFile entity)
        {
            throw new NotImplementedException();
        }
    }
}

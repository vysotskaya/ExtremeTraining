using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;
using Epam.Wunderlist.DataAccess.MSSqlDbModel;
using Ninject;

namespace Epam.Wunderlist.DataAccess.MSSql.Concrete
{
    public class TaskStateRepository : ITaskStateRepository
    {
        private readonly DbContext _dbContext;

        [Inject]
        public TaskStateRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            Mapper.Initialize(cfg => {
                cfg.CreateMap<TaskStateDbModel, TaskState>();
                cfg.CreateMap<TaskState, TaskStateDbModel>()
                    .ForSourceMember(x => x.Id, y => y.Ignore());
            });
        }

        public int Create(TaskState entity)
        {
            var state = Mapper.Map<TaskState, TaskStateDbModel>(entity);
            _dbContext.Set<TaskStateDbModel>().Add(state);
            _dbContext.SaveChanges();
            return state.Id;
        }

        public TaskState GetById(int key)
        {
            var state = _dbContext.Set<TaskStateDbModel>().FirstOrDefault(s => s.Id == key);
            return Mapper.Map<TaskStateDbModel, TaskState>(state);
        }


        public void Delete(TaskState entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskState> GetAll()
        {
            throw new NotImplementedException();
        }      

        public TaskState GetByPredicate(Expression<Func<TaskState, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(TaskState entity)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DalEntities;
using DAL.Interface.Repositories;
using ORM;
using DAL.Mappers;
using System.Data.Entity;

namespace DAL.Concrete
{
    public class StateRepository : IStateRepository
    {
        private readonly DbContext context;

        public void Create(DalState entity)
        {
            var state = entity.ToState();
            context.Set<State>().Add(state);
        }

        public DalState GetById(int key)
        {
            return context.Set<State>().FirstOrDefault(state => state.Id == key)?.ToDalState();
        }


        public void Delete(DalState entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalState> GetAll()
        {
            throw new NotImplementedException();
        }      

        public DalState GetByPredicate(Expression<Func<DalState, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(DalState entity)
        {
            throw new NotImplementedException();
        }
    }
}

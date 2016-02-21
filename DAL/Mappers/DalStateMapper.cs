using ORM;
using DAL.Interface.DalEntities;

namespace DAL.Mappers
{
    public static class DalStateMapper
    {
        public static State ToState(this DalState dalEntity)
        {
            return new State()
            {
                Id = dalEntity.Id,
                StateName = dalEntity.StateName
            };
        }

        public static DalState ToDalState(this State entity)
        {
            return new DalState()
            {
                Id = entity.Id,
                StateName = entity.StateName
            };
        }
    }
}

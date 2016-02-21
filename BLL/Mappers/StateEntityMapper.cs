using DAL.Interface.DalEntities;
using BLL.Interface.BllEntities;

namespace BLL.Mappers
{
    public static class StateEntityMapper
    {
        public static DalState ToDalStatus (this StateEntity bllEntity )
        {
            return new DalState()
            {
                Id = bllEntity.Id,
                StateName = bllEntity.StateName
            };
        }

        public static StateEntity ToBllStatus(this DalState dalEntity)
        {
            return new StateEntity()
            {
                Id = dalEntity.Id,
                StateName = dalEntity.StateName
            };
        }
    }
}

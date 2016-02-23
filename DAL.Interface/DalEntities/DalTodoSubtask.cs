

namespace DAL.Interface.DalEntities
{
    public class DalTodoSubtask : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TodoTaskRefId { get; set; }
        public int StateRefId { get; set; }
    }
}

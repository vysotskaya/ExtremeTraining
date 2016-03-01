namespace Epam.Wunderlist.DataAccess.Entities
{
    public class TaskState : IEntity
    {
        public int Id { get; set; }
        public string TaskStateName { get; set; } 
    }
}

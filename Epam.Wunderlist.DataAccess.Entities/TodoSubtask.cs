namespace Epam.Wunderlist.DataAccess.Entities
{
    public class TodoSubtask : IEntity
    {
        public int Id { get; set; }
        public string TodoSubtaskName { get; set; }
        public int TodoTaskRefId { get; set; }
        public int TaskStateRefId { get; set; }
    }
}

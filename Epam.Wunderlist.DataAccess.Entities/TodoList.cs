namespace Epam.Wunderlist.DataAccess.Entities
{
    public class TodoList : IEntity
    {
        public int Id { get; set; }
        public string TodoListName { get; set; }
        public int UserProfileRefId { get; set; }
    }
}

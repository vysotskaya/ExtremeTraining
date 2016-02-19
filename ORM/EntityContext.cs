using System.Data.Entity;

namespace ORM
{
    public class EntityContext : DbContext
    {
        public EntityContext() 
            : base("name=EntityContext")
        {
            Database.SetInitializer<EntityContext>(new WunderlistDbInitializer());
        }

        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Comment> Comments { get; set; }
        public virtual IDbSet<State> States { get; set; }
        public virtual IDbSet<TodoList> TodoLists { get; set; }
        public virtual IDbSet<TodoTask> TodoTasks { get; set; }
        public virtual IDbSet<TodoSubtask> TodoSubtasks { get; set; }
        public virtual IDbSet<File> Files { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<TodoList>(u => u.TodoLists)
                .WithMany(l => l.Users)
                .Map(m =>
                {
                    m.ToTable("UserTodoList");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("TodoListId");
                });

            modelBuilder.Entity<Comment>()
                  .HasRequired<User>(c => c.User)
                  .WithMany(u => u.Comments)
                  .HasForeignKey(c => c.UserRefId);

            modelBuilder.Entity<Comment>()
                 .HasRequired<TodoTask>(c => c.TodoTask)
                 .WithMany(t => t.Comments)
                 .HasForeignKey(c => c.TodoTaskRefId);

            modelBuilder.Entity<TodoTask>()
                  .HasRequired<TodoList>(t => t.TodoList)
                  .WithMany(l => l.TodoTasks)
                  .HasForeignKey(t => t.TodoListRefId);

            modelBuilder.Entity<TodoSubtask>()
                  .HasRequired<TodoTask>(s => s.TodoTask)
                  .WithMany(t => t.TodoSubtasks)
                  .HasForeignKey(s => s.TodoTaskRefId);

            modelBuilder.Entity<TodoSubtask>()
                  .HasRequired<State>(s => s.State)
                  .WithMany(s => s.TodoSubtasks)
                  .HasForeignKey(s => s.StateRefId);

            modelBuilder.Entity<TodoTask>()
                  .HasRequired<State>(s => s.State)
                  .WithMany(s => s.TodoTasks)
                  .HasForeignKey(s => s.StateRefId);

            modelBuilder.Entity<File>()
                 .HasRequired<TodoTask>(f => f.TodoTask)
                 .WithMany(t => t.Files)
                 .HasForeignKey(f => f.TodoTaskRefId);

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Epam.Wunderlist.DataAccess.MSSqlDbModel
{
    public class DbModelContext : DbContext
    {
        public DbModelContext() 
            : base("name=DbModelContext")
        {
            Database.SetInitializer(new WunderlistDbInitializer());
        }

        public virtual IDbSet<UserProfileDbModel> UserProfiles { get; set; }
        public virtual IDbSet<TaskStateDbModel> TaskStates { get; set; }
        public virtual IDbSet<TodoListDbModel> TodoLists { get; set; }
        public virtual IDbSet<TodoTaskDbModel> TodoTasks { get; set; }
        public virtual IDbSet<TodoSubtaskDbModel> TodoSubtasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskStateDbModel>().HasKey(t => t.Id);
            modelBuilder.Entity<TaskStateDbModel>().Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TodoListDbModel>().HasKey(t => t.Id);
            modelBuilder.Entity<TodoListDbModel>().Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TodoSubtaskDbModel>().HasKey(t => t.Id);
            modelBuilder.Entity<TodoSubtaskDbModel>().Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TodoTaskDbModel>().HasKey(t => t.Id);
            modelBuilder.Entity<TodoTaskDbModel>().Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<UserProfileDbModel>().HasKey(t => t.Id);
            modelBuilder.Entity<UserProfileDbModel>().Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<TodoListDbModel>()
                  .HasRequired<UserProfileDbModel>(l => l.UserProfile)
                  .WithMany(u => u.TodoLists)
                  .HasForeignKey(l => l.UserProfileRefId);

            modelBuilder.Entity<TodoTaskDbModel>()
                .HasRequired<TodoListDbModel>(t => t.TodoListDbModel)
                .WithMany(l => l.TodoTasks)
                .HasForeignKey(t => t.TodoListRefId);

            modelBuilder.Entity<TodoSubtaskDbModel>()
                  .HasRequired<TodoTaskDbModel>(s => s.TodoTaskDbModel)
                  .WithMany(t => t.TodoSubtasks)
                  .HasForeignKey(s => s.TodoTaskRefId)
                  .WillCascadeOnDelete(false);

            modelBuilder.Entity<TodoSubtaskDbModel>()
                  .HasRequired<TaskStateDbModel>(s => s.TaskStateDbModel)
                  .WithMany(s => s.TodoSubtasks)
                  .HasForeignKey(s => s.TaskStateRefId);

            modelBuilder.Entity<TodoTaskDbModel>()
                  .HasRequired<TaskStateDbModel>(s => s.TaskStateDbModel)
                  .WithMany(s => s.TodoTasks)
                  .HasForeignKey(s => s.TaskStateRefId);
        }
    }
}

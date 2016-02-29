using Ninject;

namespace Epam.Wunderlist.DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            Configure(kernel);
        }

        private static void Configure(IKernel kernel)
        {
            //if (isWeb)
            //{
            //    kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            //    kernel.Bind<DbContext>().To<DbModelContext>().InRequestScope();
            //}
            //else
            //{
            //    kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            //    kernel.Bind<DbContext>().To<DbModelContext>().InSingletonScope();
            //}

            //kernel.Bind<IUserProfileRepository>().To<UserProfileRepository>();
            //kernel.Bind<IUserProfileService>().To<UserProfileService>();

            //kernel.Bind<ITodoListRepository>().To<TodoListRepository>();
            //kernel.Bind<ITodoListService>().To<TodoListService>();

            //kernel.Bind<ITodoTaskRepository>().To<TodoTaskRepository>();
            //kernel.Bind<ITodoTaskService>().To<TodoTaskService>();

            //kernel.Bind<IAttachedTaskFileRepository>().To<AttachedTaskFileRepository>();
            //kernel.Bind<IAttachedTaskFileService>().To<AttachedTaskFileService>();

            //kernel.Bind<ITodoSubtaskRepository>().To<TodoSubtaskRepository>();
            //kernel.Bind<ITodoSubtaskService>().To<TodoSubtaskService>();

            //kernel.Bind<ITaskStateRepository>().To<TaskStateRepository>();
            //kernel.Bind<ITaskStateService>().To<TaskStateService>();
            //XDocument xDoc = XDocument.Load("Configuration.xml");

            kernel.Load("Configuration.xml");
        }
    }
}
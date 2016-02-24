using System.Data.Entity;
using BLL.Concrete;
using BLL.Interface.Services;
using DAL.Concrete;
using DAL.Interface.Repositories;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<EntityContext>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<EntityContext>().InSingletonScope();
            }

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IUserService>().To<UserService>();

            kernel.Bind<ITodoListRepository>().To<TodoListRepository>();
            kernel.Bind<ITodoListService>().To<TodoListService>();

            kernel.Bind<ITodoTaskRepository>().To<TodoTaskRepository>();
            kernel.Bind<ITodoTaskService>().To<TodoTaskService>();
			
			kernel.Bind<ICommentRepository>().To<CommentRepository>();
            kernel.Bind<ICommentService>().To<CommentService>();
			
            kernel.Bind<IFileRepository>().To<FileRepository>();
            kernel.Bind<IFileService>().To<FileService>();
			
            kernel.Bind<ITodoSubtaskRepository>().To<TodoSubtaskRepository>();
            kernel.Bind<ITodoSubtaskService>().To<TodoSubtaskService>();
			
            kernel.Bind<IStateRepository>().To<StateRepository>();
            kernel.Bind<IStateService>().To<StateService>();

        }
    }
}

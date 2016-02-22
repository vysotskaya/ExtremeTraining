using System.Data.Entity;
using DAL.Concrete;
using DAL.Interface.Repositories;
using Ninject;
using Ninject.Web.Common;
using ORM;
using BLL.Interface.Services;
using BLL.Concrete;

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

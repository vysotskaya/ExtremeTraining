using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Epam.Wunderlist.DependencyResolver;
using Ninject;

namespace Epam.Wunderlist.MvcPL.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            _kernel.ConfigurateResolver();
        }

        public object GetService(Type type)
       {
            return _kernel.TryGet(type);
        }

        public IEnumerable<object> GetServices(Type type)
        {
            return _kernel.GetAll(type);
        }
    }
}
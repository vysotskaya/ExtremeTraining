using Ninject;

namespace Epam.Wunderlist.DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Load("Configuration.xml");
        }
    }
}
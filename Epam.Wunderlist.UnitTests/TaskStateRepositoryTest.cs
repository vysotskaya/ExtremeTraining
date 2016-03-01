using Epam.Wunderlist.DataAccess.Interfaces.Repositories;
using Epam.Wunderlist.DependencyResolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Epam.Wunderlist.UnitTests
{
    [TestClass]
    public class TaskStateRepositoryTest
    {
        private IKernel _kernel;

        [TestInitialize]
        public void Initialize()
        {
            _kernel = new StandardKernel();
            _kernel.ConfigurateResolver();
        }

        [TestMethod]
        public void GetByIdTaskState()
        {
            //var assemblyName = typeof(UnitOfWork).AssemblyQualifiedName;
            var id = 1;
            ITaskStateRepository taskStateRepository = _kernel.Get<ITaskStateRepository>();
            var state = taskStateRepository.GetById(id);
            Assert.AreEqual("Active", state.TaskStateName);
        }
    }
}

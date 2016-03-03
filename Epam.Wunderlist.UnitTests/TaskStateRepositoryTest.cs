using Epam.Wunderlist.DataAccess.Interfaces.Repositories;
using Epam.Wunderlist.DependencyResolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Extensions.Xml;

namespace Epam.Wunderlist.UnitTests
{
    [TestClass]
    public class TaskStateRepositoryTest
    {
        private IKernel _kernel;

        [TestInitialize]
        public void Initialize()
        {
            var settings = new NinjectSettings { LoadExtensions = false };
            _kernel = new StandardKernel(settings, new XmlExtensionModule());
            _kernel.ConfigurateResolver();
        }

        [TestMethod]
        public void GetByIdTaskState()
        {
            var id = 1;
            ITaskStateRepository taskStateRepository = _kernel.Get<ITaskStateRepository>();
            var state = taskStateRepository.GetById(id);
            Assert.AreEqual("Active", state.TaskStateName);
        }
    }
}

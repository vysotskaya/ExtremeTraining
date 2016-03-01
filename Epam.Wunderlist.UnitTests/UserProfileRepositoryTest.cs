using System.Linq;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;
using Epam.Wunderlist.DependencyResolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Extensions.Xml;

namespace Epam.Wunderlist.UnitTests
{
    [TestClass]
    public class UserProfileRepositoryTest
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
        public void GetAllUserProfiles()
        {
            IUserProfileRepository userProfileRepository = _kernel.Get<IUserProfileRepository>();
            var users = userProfileRepository.GetAll().ToList();
            Assert.AreEqual(1, users.Count);
        }
    }
}

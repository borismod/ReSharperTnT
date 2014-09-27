using FluentAssertions;
using NUnit.Framework;
using ReSharperTnT.Engine;

namespace ReSharperTnT.Tests
{
    [TestFixture]
    public class BootstrapperTests
    {
        [Test]
        public void Get_ITipsAndTricksRepository_Resolved()
        {
            // Act
            var bootstrapper = new Bootstrapper();
            var tipsAndTricksRepository = bootstrapper.Get<ITipsAndTricksRepository>();

            // Assert
            tipsAndTricksRepository.Should().BeAssignableTo<ITipsAndTricksRepository>();
        }
    }
}
using FluentAssertions;
using NUnit.Framework;
using ReSharperTnT.Engine;
using ReSharperTnT.Models;

namespace ReSharperTnT.Tests.Engine
{
    [TestFixture]
    public class TipsAndTricksRepositoryIntegrationTests
    {
        [Test]
        public void GetAll_DoesNotContainContentNodes()
        {
            var bootstrapper = new Bootstrapper();
            var tipsAndTricksRepository = bootstrapper.Get<ITipsAndTricksRepository>();
            var resharperTips = tipsAndTricksRepository.GetAll();

            resharperTips.Should().NotContain(new ResharperTip("Core functions and performance"));
        }
    }
}
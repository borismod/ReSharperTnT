using NUnit.Framework;

namespace ReSharperTnT.Tests
{
    [TestFixture]
    public class TipsAndTricksRepositoryTests
    {
        [Test]
        public void GetAllTips_NotEmpty()
        {
            var tipsAndTricksRepository = new TipsAndTricksRepository();
            var resharperTips = tipsAndTricksRepository.GetAllTips();

            Assert.That(resharperTips, Is.Not.Empty);
        }
    }
}
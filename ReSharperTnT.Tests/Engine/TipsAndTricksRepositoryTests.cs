using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using ReSharperTnT.Engine;
using ReSharperTnT.Models;

namespace ReSharperTnT.Tests.Engine
{
    [TestFixture]
    public class TipsAndTricksRepositoryTests
    {
        [Test]
        public void GetRandom_OneTip_Returned()
        {
            var reSharperTipsHtmlParser = A.Fake<IReSharperTipsHtmlParser>();
            A.CallTo(() => reSharperTipsHtmlParser.Parse(null)).WithAnyArguments().Returns(new ResharperTip("my tip").AsList());

            var tipsAndTricksRepository = new TipsAndTricksRepository(reSharperTipsHtmlParser);
            var resharperTip = tipsAndTricksRepository.GetRandom();

            resharperTip.Tip.Should().Be("my tip");
        }
    }
}
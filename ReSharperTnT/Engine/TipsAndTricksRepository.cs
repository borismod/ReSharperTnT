using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using ReSharperTnT.Models;

namespace ReSharperTnT.Engine
{
    public interface ITipsAndTricksRepository
    {
        ResharperTip GetRandom();
        IList<ResharperTip> GetAll();
    }

    public class TipsAndTricksRepository : ITipsAndTricksRepository
    {
        private readonly IList<ResharperTip> _resharperTips = new List<ResharperTip>();
        readonly Random _randomGenerator = new Random();

        public TipsAndTricksRepository(IReSharperTipsHtmlParser reSharperTipsHtmlParser)
        {
            const string url = "http://confluence.jetbrains.com/display/NETCOM/ReSharper+Tips+and+Tricks";
            var web = new HtmlWeb();
            var htmlDocument = web.Load(url);
            _resharperTips = reSharperTipsHtmlParser.Parse(htmlDocument);
        }

        public ResharperTip GetRandom()
        {
            var tipIndex = _randomGenerator.Next(_resharperTips.Count - 1);
            return _resharperTips[tipIndex];
        }

        public IList<ResharperTip> GetAll()
        {
            return _resharperTips;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using ReSharperTnT.Models;

namespace ReSharperTnT.Engine
{
    public interface IReSharperTipsHtmlParser
    {
        IList<ResharperTip> Parse(HtmlDocument htmlDocument);
    }

    public class ReSharperTipsHtmlParser : IReSharperTipsHtmlParser
    {
        private readonly IResharperTipHtmlNodeValidator _resharperTipHtmlNodeValidator;

        public ReSharperTipsHtmlParser(IResharperTipHtmlNodeValidator resharperTipHtmlNodeValidator)
        {
            _resharperTipHtmlNodeValidator = resharperTipHtmlNodeValidator;
        }

        public IList<ResharperTip> Parse(HtmlDocument htmlDocument)
        {
            return htmlDocument.DocumentNode
                .SelectNodes("//div/ul/li")
                .Where(node => _resharperTipHtmlNodeValidator.IsValidNode(node))
                .Select(node => (new ResharperTip(HttpUtility.HtmlDecode(node.InnerText))))
                .ToList();
        }
    }
}
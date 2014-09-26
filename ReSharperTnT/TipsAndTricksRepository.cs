using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using ReSharperTnT.Models;

namespace ReSharperTnT
{
    public interface ITipsAndTricksRepository
    {
        ResharperTip GetRandom();
        List<ResharperTip> GetAllTips();
    }

    public class TipsAndTricksRepository : ITipsAndTricksRepository
    {
        private readonly List<ResharperTip> _resharperTips = new List<ResharperTip>();

        public TipsAndTricksRepository()
        {
            const string url = "http://confluence.jetbrains.com/display/NETCOM/ReSharper+Tips+and+Tricks";
            var web = new HtmlWeb();
            var htmlDocument = web.Load(url);
            var htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//div/ul/li");
            foreach (var htmlNode in htmlNodeCollection)
            {
                if (IsInvalidNode(htmlNode))
                    continue;

                _resharperTips.Add(new ResharperTip() {Success = true, Tip = HttpUtility.HtmlDecode(htmlNode.InnerText)});
            }
        }

        private static bool IsInvalidNode(HtmlNode htmlNode)
        {
            if (!htmlNode.HasChildNodes) return false;

            return htmlNode.ChildNodes.Any(IsInvalidChildNode);
        }

        private static bool IsInvalidChildNode(HtmlNode childHtmlNode)
        {
            if (childHtmlNode.Name != "a") return false;
            if (!childHtmlNode.HasAttributes) return false;

            var attributeValue = childHtmlNode.GetAttributeValue("href", "");

            return attributeValue.StartsWith("#") || attributeValue.StartsWith("/display");
        }

        public List<ResharperTip> GetAllTips()
        {
            return _resharperTips;
        }

        public ResharperTip GetRandom()
        {
            var random = new Random();
            var next = random.Next(_resharperTips.Count - 1);
            return _resharperTips[next];
        }
    }
}
using System.Linq;
using HtmlAgilityPack;

namespace ReSharperTnT.Engine
{
    public interface IResharperTipHtmlNodeValidator
    {
        bool IsValidNode(HtmlNode htmlNode);
    }

    public class ResharperTipHtmlNodeValidator : IResharperTipHtmlNodeValidator
    {
        public bool IsValidNode(HtmlNode htmlNode)
        {
            if (!htmlNode.HasChildNodes) return true;

            return htmlNode.ChildNodes.All(IsValidChildNode);
        }

        private static bool IsValidChildNode(HtmlNode childHtmlNode)
        {
            if (childHtmlNode.Name != "a") return true;
            if (!childHtmlNode.HasAttributes) return true;

            var attributeValue = childHtmlNode.GetAttributeValue("href", "");

            return !attributeValue.StartsWith("#") && !attributeValue.StartsWith("/display");
        }
    }
}
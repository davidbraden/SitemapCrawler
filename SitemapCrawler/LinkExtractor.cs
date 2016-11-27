using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SitemapCrawler
{
    public class LinkExtractor
    {
        public HashSet<string> ExtractLinks(string htmlContent, string pageUrl)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            var links = new HashSet<string>();

            foreach (HtmlNode aNode in htmlDoc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = aNode.Attributes["href"];
                var link = att.Value;

                if (link == "/" || link == "")
                    continue;

                links.Add(MakeAbsolute(link, pageUrl));
            }

            return links;
        }

        private string MakeAbsolute(string link, string baseUrl)
        {
            baseUrl = baseUrl.TrimEnd('/');

            if (link.StartsWith("http"))
                return link;
            if (link.StartsWith("/"))
                return baseUrl + link;
            return baseUrl + "/" + link;
        }

        public bool IsLink(string link, string domain)
        {
            return !IsExternalLink(link, domain) && !IsAsset(link);
        }

        public bool IsAsset(string link)
        {
            return false;
        }

        public bool IsExternalLink(string link, string domain)
        {
            return !link.Contains(domain);
        }
    }
}

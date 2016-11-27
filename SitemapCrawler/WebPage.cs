using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitemapCrawler
{
    public class WebPage
    {
        public string Url { get;}
        public HashSet<string> Links { get; }
        public HashSet<string> ExternalLinks { get; }
        public HashSet<string> Assets { get; }

        public WebPage(string url, HashSet<string> links, HashSet<string> externalLinks, HashSet<string> assets)
        {
            Url = url;
            Links = links;
            ExternalLinks = externalLinks;
            Assets = assets;
        }
    }
}

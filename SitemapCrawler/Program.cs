using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitemapCrawler
{
    class Program
    {
        private static PageCrawler _pageCrawler = new PageCrawler();
        private static SiteMapWriter _siteMapWriter = new SiteMapWriter();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the base url to scrape:");
            var baseUrl = new Uri(Console.ReadLine());

            var urlsToScrape = new Queue<string>();
            var pages = new Dictionary<string, WebPage>();

            urlsToScrape.Enqueue(baseUrl.ToString());

            while (urlsToScrape.Count > 0)
            {
                var url = urlsToScrape.Dequeue();
                var webPage = _pageCrawler.ScrapeUrl(url).Result;
                if (webPage != null)
                {
                    var newPages = new HashSet<string>(webPage.Links);
                    newPages.ExceptWith(pages.Keys);
                    foreach (var newPage in newPages)
                    {
                        urlsToScrape.Enqueue(newPage);
                    }
                }
            }

            _siteMapWriter.Write(pages, "sitemap.json");
        }
    }
}

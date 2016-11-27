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

            var urlsToScrape = new Queue<Tuple<string, int>>();
            var pages = new Dictionary<string, WebPage>();

            urlsToScrape.Enqueue(new Tuple<string, int>(baseUrl.ToString(), 0));

            while (urlsToScrape.Count > 0)
            {
                var tuple = urlsToScrape.Dequeue();

                if (tuple.Item2 > 1)
                    continue;

                if (pages.ContainsKey(tuple.Item1))
                    continue;

                var webPage = _pageCrawler.ScrapeUrl(tuple.Item1).Result;

                pages.Add(tuple.Item1, webPage);

                if (webPage != null)
                {
                    var newPages = new HashSet<string>(webPage.Links);
                    newPages.ExceptWith(pages.Keys);
                    foreach (var newPage in newPages)
                    {
                        urlsToScrape.Enqueue(new Tuple<string, int>(newPage, tuple.Item2 + 1));
                    }
                }
            }

            _siteMapWriter.Write(pages, "sitemap.json");
        }
    }
}

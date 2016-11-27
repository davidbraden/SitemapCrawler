using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SitemapCrawler
{
    public class PageCrawler
    {
        private HttpClient _httpClient;



        public async Task<WebPage> ScrapeUrl(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return null;
        }
    }
}

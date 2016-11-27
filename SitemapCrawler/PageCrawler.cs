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
        private HttpClient _httpClient = new HttpClient();
        private LinkExtractor _linkExtractor = new LinkExtractor();

        public async Task<WebPage> ScrapeUrl(string url)
        {
            try {
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return null;

                if (!"text/html".Equals(response.Content.Headers.ContentType.MediaType.ToString()))
                    return null;

                var links = _linkExtractor.ExtractLinks(response.Content.ReadAsStringAsync().Result, url);

                return new WebPage(url, links, new HashSet<string>(), new HashSet<string>());
            } catch
            {
                return null;
            }
            
        }
    }
}

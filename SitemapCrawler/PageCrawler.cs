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
                var uri = new Uri(url);
                var response = await _httpClient.GetAsync(uri);

                if (!response.IsSuccessStatusCode)
                    return null;

                if (!"text/html".Equals(response.Content.Headers.ContentType.MediaType.ToString()))
                    return null;

                var links = _linkExtractor.ExtractLinks(response.Content.ReadAsStringAsync().Result, url);

                return new WebPage(
                    url,
                    new HashSet<string>(links.Where(l => _linkExtractor.IsLink(l, uri.Host))),
                    new HashSet<string>(links.Where(l => _linkExtractor.IsExternalLink(l, uri.Host))),
                    new HashSet<string>(links.Where(l => _linkExtractor.IsAsset(l))));
            } catch
            {
                return null;
            }
            
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitemapCrawler
{
    public class SiteMapWriter
    {
        public void Write(Dictionary<string, WebPage> pages, string fileName)
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(SiteMapWriter)).Location);

            var json = JsonConvert.SerializeObject(pages);

            File.WriteAllText(path + "/" + fileName, json);
        }
    }
}

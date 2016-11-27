using NUnit.Framework;
using SitemapCrawler;
using System;
using System.Collections.Generic;
using System.IO;

namespace SiteMapCrawlerTests
{
    [TestFixture]
    public class SiteMapWriterTests
    {
        [Test]
        public void Write()
        {
            var writer = new SiteMapWriter();
            writer.Write(new Dictionary<string, WebPage> { { "site.com/page", new WebPage("site.com/page", new HashSet<string>(), new HashSet<string>(), new HashSet<string>())} }, "test.json");


            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(SiteMapWriter)).Location);
            var sitemap = File.ReadAllText(path + "test.json");

            Assert.AreEqual("{\"site.com/page\":{\"Url\":\"site.com/page\",\"Links\":[],\"ExternalLinks\":[],\"Assets\":[]}}", sitemap);
        }
    }
}

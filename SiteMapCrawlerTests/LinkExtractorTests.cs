using NUnit.Framework;
using SitemapCrawler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteMapCrawlerTests
{
    [TestFixture]
    public class LinkExtractorTests
    {

        private LinkExtractor _extractor = new LinkExtractor();

        [Test]
        public void ExtractLinks_Relative()
        {
            var html = LoadHtmlFile("\\Resources\\RelativeUrl.html");

            var links = _extractor.ExtractLinks(html, "http://base.com");

            Assert.AreEqual(2, links.Count);
            Assert.AreEqual("http://base.com/relative/page1", links.First());
            Assert.AreEqual("http://base.com/relative/page2", links.Skip(1).First());
        }

        [Test]
        public void ExtractLinks_Absolute()
        {
            var html = LoadHtmlFile("\\Resources\\AbsoluteUrl.html");

            var links = _extractor.ExtractLinks(html, "base.com");

            Assert.AreEqual(1, links.Count);
            Assert.AreEqual("http://www.website.com/page1", links.First());
        }

        private string LoadHtmlFile(string filename)
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(typeof(LinkExtractorTests)).Location);
            return File.ReadAllText(path + filename);
        }


    }
}

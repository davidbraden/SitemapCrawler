# Site map crawler
Console app for generating a json sitemap given a starting url. Does a breadth first search with maximum depth.

I didn't want to go over the time so it's not complete. 

### Issues
* Only checks <a href> tags and doesn't look at images etc.
* Doesn't strip out query string/fragments.
* Doesn't handle sub-domains.
* Not fully unit tested - ended up manually testing with random sites.
* Pretty slow, might investigate making it scrape urls concurrently.

## How to Run

### Requirements
* Visual Studio 2015 - https://www.visualstudio.com/post-download-vs/?sku=community&clcid=0x409&telem=ga
* NUnit3TestAdapter - https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnit3TestAdapter

Either run SitemapCrawler through Visual Studio or build and run .\SitemapCrawler\bin\Debug\SitemapCrawler.exe

It will output a json sitemap file in \SitemapCrawler\bin\Debug\sitemap.json


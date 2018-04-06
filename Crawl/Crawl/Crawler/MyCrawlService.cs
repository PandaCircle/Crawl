using Abot.Poco;
using Crawl.Crawler.Cookie;
using Crawl.Crawler.Requester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crawl.Crawler
{
    public class MyCrawlService
    {
        public CrawlSettings Predo(CrawlSettings settings,RequestParameters parameters)
        {
            
            AuthenticPageRequester pageRequester = new AuthenticPageRequester(settings);
        }
    }
}
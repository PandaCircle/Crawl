using Abot.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Crawl.Crawler
{
    public class CrawlSettings
    {
        public CrawlSettings()
        {
            CrawConfiguration = new CrawlConfiguration();
            CookieContainer = new CookieContainer();
        }

        public CrawlConfiguration CrawConfiguration { get; set; }
        public CookieContainer CookieContainer { get; set; }
    }
}
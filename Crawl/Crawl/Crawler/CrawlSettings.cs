using Abot.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crawl.Crawler
{
    public class CrawlSettings
    {
        public CrawlSettings()
        {
            CrawConfiguration = new CrawlConfiguration();
            TargetUri = "http://";
        }

        public CrawlConfiguration CrawConfiguration { get; set; }

        public string TargetUri { get; set; }
    }
}
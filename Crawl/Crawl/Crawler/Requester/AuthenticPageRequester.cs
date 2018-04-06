using Abot.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abot.Poco;

namespace Crawl.Crawler.Requester
{
    public class AuthenticPageRequester : PageRequester
    {
        public AuthenticPageRequester(CrawlSettings setting) : this(setting.CrawConfiguration)
        {
            _cookieContainer = setting.CookieContainer;
        }
        public AuthenticPageRequester(CrawlConfiguration config) : base(config)
        {
        }

        public AuthenticPageRequester(CrawlConfiguration config, IWebContentExtractor contentExtractor) : base(config, contentExtractor)
        {
        }
    }
}
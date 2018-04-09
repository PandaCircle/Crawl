using Abot.Crawler;
using Abot.Poco;
using Crawl.Crawler.Cookie;
using Crawl.Crawler.Requester;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crawl.Crawler
{
    public class MyCrawlService
    {
        public void StartCrawl(CrawlSettings settings,RequestArgs parameters)
        {
            ILog log = LogManager.GetLogger("crawlLog");
            CrawlSettings settings2 = CookieRequester.PostRequest(settings, parameters);
            if(settings2.CookieContainer == null)
            {
                log.Error("Failure getting Cookies ,Crawl Suspended.");
                return;
            }
            AuthenticPageRequester authenticPageRequester = new AuthenticPageRequester(settings);
            PoliteWebCrawler crawler = new PoliteWebCrawler(settings.CrawConfiguration, null, null, null, authenticPageRequester, null, null, null, null);
            //添加处理事件
            //....
            crawler.Crawl(new Uri(""));
        }
    }
}
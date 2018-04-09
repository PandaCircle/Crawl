using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crawl.Crawler.Requester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Crawl.Crawler.Requester.Tests
{
    [TestClass()]
    public class CookieRequesterTests
    {
        [TestMethod()]
        public void PostRequestTest()
        {
            CrawlSettings settings = new CrawlSettings();
            RequestArgs args = new RequestArgs() { PostParameters = "a=1234", RequestUri = "http://www.wqii.com.cn" };
            ILog log = LogManager.GetLogger("requestLogger");
            CookieRequester.PostRequest(settings, args, log);
            Assert.AreEqual(null, settings.CookieContainer);
            
        }
    }
}
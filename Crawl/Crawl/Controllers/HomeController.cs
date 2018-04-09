using Abot.Poco;
using Crawl.Crawler;
using Crawl.Crawler.Cookie;
using Crawl.Crawler.Requester;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crawl.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult CrawlSettings()
        {
            CrawlSettings config = new CrawlSettings();
            return View(config);
        }

        public ActionResult GetCookie()
        {
            RequestArgs parameters = new RequestArgs();
            return View(parameters);
        }
        [HttpPost,ActionName("GetCookie")]
        public ActionResult GetCookiePost(RequestArgs param)
        {
            ILog log = LogManager.GetLogger("cookielog");
            CookieRequester.PostRequest(new CrawlSettings(), param);
            return View();
        }

    }
}

using Abot.Poco;
using Crawl.Crawler;
using Crawl.Crawler.Cookie;
using Crawl.Crawler.Requester;
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
            RequestParameters parameters = new RequestParameters();
            return View(parameters);
        }
        [HttpPost,ActionName("GetCookie")]
        public ActionResult GetCookiePost(RequestParameters param)
        {
            CookieRequester re = new CookieRequester(param, new Crawler.CrawlSettings(), DefaultCookieStorage.GetInstance());
            re.Excute();
            return View();
        }

    }
}

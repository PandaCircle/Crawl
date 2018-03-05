using Abot.Poco;
using Crawl.Crawler;
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

    }
}

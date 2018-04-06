using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Crawl.Crawler.Cookie
{
    public class CookieBlock
    {
        public string Key { get; set; }
        public DateTime SaveTime { get; set; }
        public CookieStoreStrategy Strategy { get; set; }
        public CookieContainer CookieContainer { get; set; }

        public bool IsExpire
        {
            get
            {
                return ((DateTime.Now - SaveTime) >= Strategy.ExpireMinute);
            }
        }

    }
}
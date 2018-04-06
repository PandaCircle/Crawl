using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crawl.Crawler.Cookie
{
    [Serializable]
    public class CookieStoreStrategy
    {
        /// <summary>
        /// 失效时间按分钟算
        /// </summary>
        public TimeSpan ExpireMinute { get; set; }
    }
}
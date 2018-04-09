using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Crawl.Crawler.Requester
{
    public class RequestContext
    {
        public HttpWebResponse Response { get; set; }
        public HttpWebRequest Request { get; set; }
        public RequestArgs RequestArgs { get; set; }

    }
}
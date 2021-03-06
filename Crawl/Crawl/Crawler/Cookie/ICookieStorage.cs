﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Crawl.Crawler.Cookie
{
    public interface ICookieStorage
    {
        CookieBlock Get(string key);
        void Save(CookieBlock cookie);
    }
}
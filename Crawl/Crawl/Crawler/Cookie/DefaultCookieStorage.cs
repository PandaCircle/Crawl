using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crawl.Crawler.Cookie
{
    public class DefaultCookieStorage : ICookieStorage
    {
        private static DefaultCookieStorage _instance;
        private static object _lock = new object();
        private static Dictionary<string,CookieBlock> _cookieBlock = new Dictionary<string, CookieBlock>();

        private DefaultCookieStorage() { }

        public static DefaultCookieStorage GetInstance()
        {
            if(_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DefaultCookieStorage();
                    }
                }
            }
            return _instance;
        }

        public CookieBlock Get(string key)
        {
            CookieBlock block = null;
            _cookieBlock.TryGetValue(key,out block);
            return block;
        }

        public void Save(CookieBlock cookie)
        {
            _cookieBlock[cookie.Key] = cookie;
        }
    }
}
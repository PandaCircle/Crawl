using Crawl.Crawler.Cookie;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Crawl.Crawler.Requester
{
    public class CookieRequester
    {
        private readonly RequestParameters _requestParameters;
        private readonly CrawlSettings _crawlSettings;
        private readonly ICookieStorage _cookieStorage;

        public CookieRequester
            (
               RequestParameters requestParameters,
               CrawlSettings crawlSettings,
               ICookieStorage cookieStorage
            )
        {
            _requestParameters = requestParameters;
            _crawlSettings = crawlSettings;
            _cookieStorage = cookieStorage;
        }

        public ILog Log = LogManager.GetLogger("logger");

        public CookieContainer GetCookie()
        {
            CookieContainer cookie = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(_requestParameters.RequestUri));
            request.Method = "POST";
            request.Accept = "*/*";
            request.UserAgent = _crawlSettings.CrawConfiguration.UserAgentString;

            byte[] transferData = Encoding.UTF8.GetBytes(_requestParameters.PostParameters);
            request.ContentLength = transferData.Length;

            using(Stream stream = request.GetRequestStream())
            {
                stream.Write(transferData,0,transferData.Length);
            }

            HttpWebResponse response = null;
            try { response = (HttpWebResponse)request.GetResponse(); }
            catch(WebException e)
            {               
                Log.Error(string.Format("Server Return Error :{0}", e.Message));
            }
            catch(Exception e)
            {
                Log.Error(string.Format("Error occured when getting cookie , Reason :{0}", e.Message));
            }

            //handle error code 
            if (response == null) return;

            if(response.StatusCode != HttpStatusCode.OK)
            {
                Log.Error(string.Format("Server Return StatusCode {0}", response.StatusCode));
                return ;
            }

            Log.Info(string.Format("Cookie (key:{0}) is achieved", _requestParameters.RequestUri));
           
        }



    }
}
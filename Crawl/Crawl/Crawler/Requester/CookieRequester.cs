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

        public static RequestContext BuildRequestContext(CrawlSettings settings, RequestArgs args)
        {
            RequestContext requestContext = new RequestContext();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(args.RequestUri));
            request.Method = "POST";
            request.Accept = "*/*";
            request.UserAgent = settings.CrawConfiguration.UserAgentString;

            byte[] transferData = Encoding.UTF8.GetBytes(args.PostParameters);
            request.ContentLength = transferData.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(transferData, 0, transferData.Length);
            }
            requestContext.Request = request;

            return requestContext;
        }

        public static CrawlSettings PostRequest(CrawlSettings settings,RequestArgs args)
        {
            CookieContainer cookie = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(args.RequestUri));
            request.Method = "POST";
            request.Accept = "*/*";
            request.UserAgent = settings.CrawConfiguration.UserAgentString;

            byte[] transferData = Encoding.UTF8.GetBytes(args.PostParameters);
            request.ContentLength = transferData.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(transferData, 0, transferData.Length);
            }

            HttpWebResponse response = null;
            try { response = (HttpWebResponse)request.GetResponse(); }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Error occured when getting cookie , Reason :{0}", e.Message));
            }

            //handle error code 
            if (response != null)
            {
                Console.WriteLine(string.Format("Server Return StatusCode {0}", response.StatusCode));
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    cookie.Add(response.Cookies);
                    settings.CookieContainer = cookie;
                    Console.WriteLine(string.Format("Cookie (key:{0}) is achieved", args.RequestUri));
                }
            }
            else
            {
                Console.WriteLine("No Response From Server");
            }

            return settings;   

        }


    }
}
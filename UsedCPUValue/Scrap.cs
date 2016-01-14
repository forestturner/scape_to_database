using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UsedCPUValue
{
    class Scrap
    {
        /// <summary>
        /// parameters = two strings (url of webpage and Node)
        /// </summary>
        /// <returns></returns>
        public List<string> grab_page_return_list_of_strings(string url,string node)
        {
            List<string> list = new List<string>();
            WebClient client = new WebClient();
            string response = client.DownloadString(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(response);
            var test = doc.DocumentNode.SelectNodes(node);
            foreach(var i in test)
            {
                list.Add(i.InnerText);
                Console.WriteLine(i.InnerText);
            }
            return list;
        }
    }
}

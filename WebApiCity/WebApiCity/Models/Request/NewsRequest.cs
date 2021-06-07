using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCity.Models.Request
{
    public class NewsRequest
    {
        public List<Articles> articles { get; set; }
    }

    public class Articles
    {
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public string publishedAt { get; set; }
        public string content { get; set; }
    }
}
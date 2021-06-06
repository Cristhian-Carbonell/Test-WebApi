using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using WebApi_News_and_Weather.Models.Request;

namespace WebApi_News_and_Weather.Controllers
{
    public class CityController : ApiController
    {
        //public IHttpActionResult Add(Models.Request.NewsRequest model, string json)
        [HttpPost]
        public string Post([FromBody] Models.Request.NewsRequest model)
        {
            string json = GetNews();

            NewsRequest Object = JsonConvert.DeserializeObject<NewsRequest>(json);

            using (Models.DataBaseEntities2 db = new Models.DataBaseEntities2())
            {
                var oNews = new Models.Table_2();

                for (int i = 0; i < 2; i++)
                {
                    if (Object.articles[i].author != null)
                    {
                        oNews.author = Object.articles[i].author;
                    }
                    if (Object.articles[i].title != null)
                    {
                        oNews.title = Object.articles[i].title;
                    }
                    if (Object.articles[i].description != null)
                    {
                    oNews.description = Object.articles[i].description;
                    }
                    if (Object.articles[i].url != null)
                    {
                        oNews.url = Object.articles[i].url;
                    }
                    if (Object.articles[i].urlToImage != null)
                    {
                        oNews.utlToImage = Object.articles[i].urlToImage;
                    }
                    if (Object.articles[i].publishedAt != null)
                    {
                        oNews.publishedAt = Object.articles[i].publishedAt;
                    }
                    if (Object.articles[i].content != null)
                    {
                        oNews.content_desc = Object.articles[i].content;
                    }
                    db.Table_2.Add(oNews);
                    db.SaveChanges();
                }

            }

            return ("Ok");
        }

        public string GetNews()
        {
            var url = "https://newsapi.org/v2/top-headlines?" +
                "country=us&" +
                "apiKey=4f00a4757944415dbb933bb63af1e124";

            var json = new WebClient().DownloadString(url);

            return json;
        }
    }


}

using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApiCity.Models.Request;

namespace WebApiCity.Controllers
{
    public class NewsWeatherController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get(string city)
        {
            PostNewsWeathe(city);
            //PostNews(city);
            Dictionary<string, List<ViewModel.NewsViewModel>> dict = new Dictionary<string, List<ViewModel.NewsViewModel>>();
            List<ViewModel.NewsViewModel> lts = new List<ViewModel.NewsViewModel>();
            List<ViewModel.NewsViewModel> lts1 = new List<ViewModel.NewsViewModel>();



            using (Models.DataBaseEntities1 db = new Models.DataBaseEntities1())
            {
                lts = (from d in db.TableWebAPI
                       select new ViewModel.NewsViewModel
                       {
                           id = d.id,
                           author = d.author,
                           title = d.title,
                           description = d.description,
                           url = d.url,
                           urlToImage = d.utlToImage,
                           publishedAt = d.publishedAt,
                           content = d.content_desc,
                           temperature = d.temp,
                           weather_descriptions = new List<string>
                           {
                               d.description_weather
                           },
                           wind_speed = d.speed,
                           wind_degree = d.deg,
                           pressure = d.pressure,
                           humidity = d.humidity,
                           visibility = d.visibility                     
                       }).ToList();
                dict["news"] = lts;
            }
            //string json = JsonConvert.SerializeObject(lts, Formatting.Indented);
            
            return Ok(lts);
        }

        private void PostNewsWeathe(string city)
        {
            string json = News(city);
            string json2 = Weather(city);

            WeatherRequest Object2 = JsonConvert.DeserializeObject<WeatherRequest>(json2);

            NewsRequest Object = JsonConvert.DeserializeObject<NewsRequest>(json);

            using (Models.DataBaseEntities1 db = new Models.DataBaseEntities1())
            {
                var oNews = new Models.TableWebAPI();

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
                    oNews.description = Object2.weather[0].description;
                    oNews.temp = Object2.main.temp;
                    oNews.pressure = Object2.main.pressure;
                    oNews.humidity = Object2.main.humidity;
                    oNews.visibility = Object2.visibility;
                    oNews.speed = Object2.wind.speed;
                    oNews.deg = Object2.wind.deg;
                    db.TableWebAPI.Add(oNews);
                    db.SaveChanges();
                }
            }

            using (Models.DataBaseEntities3 db = new Models.DataBaseEntities3())
            {
                var oCity = new Models.TableCity();
                oCity.city = city;
                oCity.infor = "infor";
                db.TableCity.Add(oCity);
                db.SaveChanges();
            }
        }
        [HttpGet]
        public string GetCity()
        {
            List<ViewModel.CityViewModel> lts = new List<ViewModel.CityViewModel>();
            using (Models.DataBaseEntities3 db = new Models.DataBaseEntities3())
            {
                lts = (from d in db.TableCity
                       select new ViewModel.CityViewModel
                       {
                           city = d.city,
                           info = d.infor
                       }).ToList();
            }

            Dictionary<string, List<ViewModel.CityViewModel>> dict = new Dictionary<string, List<ViewModel.CityViewModel>>();
            dict["history"] = lts;
            string json = JsonConvert.SerializeObject(dict, Formatting.Indented);

            return json;
        }

        public string News(string city)
        {
            Dictionary<string, string> myCity = new Dictionary<string, string>
            {
                {"NewYork", "us" },
                {"Bogota", "co" },
                {"London", "gb" }
            };
            

            string value = "";
            foreach (var x in myCity)
            {
                if (x.Key == city)
                {
                    value = x.Value;
                    
                }
            }
            var url = "https://newsapi.org/v2/top-headlines?" +
                "country={0}&" +
                "apiKey=4f00a4757944415dbb933bb63af1e124";
            var output = string.Format(url, value);
            var json = new WebClient().DownloadString(output);
            return json;
        }

        public string Weather(string city)
        {
            var url = "https://api.openweathermap.org/data/2.5/weather?" +
                "q={0}&" +
                "appid=2eb33963d6923222fc19d8e71487726d";

            var output = string.Format(url, city);
            var json = new WebClient().DownloadString(output);

            return json;
        }
    }
}

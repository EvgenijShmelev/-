using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Прогноз_погоды
{
    internal class Weather
    {
        static string city = "Moscow";
        const string API = "362ba17051da00e13a5a17361174bef3";
        static HttpClient client = new HttpClient();
        static string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API}&units=metric";
        static public async void getWeather()
        {
            string response = await client.GetStringAsync(url);
            string result = response;
            var json = JObject.Parse(result);
            string temp = json["main"]["temp"].ToString();
        }
    }
} 

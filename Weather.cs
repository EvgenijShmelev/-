using System;
using System.CodeDom.Compiler;
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
        public static string temp;
        public static string wind;
        public static string weather;
        public static string pressure;
        static string city = "Moscow";
        const string API = "362ba17051da00e13a5a17361174bef3";
        static HttpClient client = new HttpClient();
        static string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API}&units=metric&lang=ru";
        static public async void getWeather()
        {
            string response = await client.GetStringAsync(url);
            string result = response;
            var json = JObject.Parse(result);
            temp = json["main"]["temp"].ToString();
            pressure = json["main"]["pressure"].ToString();
            wind = json["wind"]["speed"].ToString();
            weather = json["weather"][0]["description"].ToString();
        }
    }
} 

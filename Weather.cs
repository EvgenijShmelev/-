using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Прогноз_погоды
{
    internal class Weather
    {
        static string db_info = @"Data Source=Pogoda.db;Pooling=true;;Version=3";
        static public string lon_lat = "lat=55.7558&lon=37.617";
        static string city = "Moscow";
        const string API = "362ba17051da00e13a5a17361174bef3"; 
        static HttpClient client = new HttpClient();
        static string url_day = $"https://api.openweathermap.org/data/2.5/weather?{lon_lat}&appid={API}&units=metric&lang=ru";
        static string url_day_array = $"https://api.openweathermap.org/data/2.5/forecast?{lon_lat}&appid={API}&units=metric&lang=ru";
        static public string icon;
        static public string pressure;
        static public string wind_speed;
        static public string temp;
        static public string description;
        static public void UpdateUrl()
        {
            url_day = $"https://api.openweathermap.org/data/2.5/weather?{lon_lat}&appid={API}&units=metric&lang=ru";
            
        }
        static public async void getWeather()
        
        {
            UpdateUrl();
            string response = await client.GetStringAsync(url_day);
            Console.WriteLine(url_day);
            string result = response;
            var json = JObject.Parse(result);
            temp = json["main"]["temp"].ToString();
            icon = json["weather"][0]["icon"].ToString();
            pressure = json["main"]["pressure"].ToString();
            wind_speed = json["wind"]["speed"].ToString();
            description = json["weather"][0]["description"].ToString();

        }
        public static void CheckDB() //Проверяет наличие базы данных, если нет создаёт пустую.
        {
            if (!File.Exists("Pogoda.db"))
            {
                DialogResult result = MessageBox.Show("База данных отсутсвует, создать новую?", "База данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    MessageBox.Show("База данных отсутсвует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                

                SQLiteConnection.CreateFile("Pogoda.db");
                using (SQLiteConnection conect = new SQLiteConnection(db_info))
                {

                    string command = "CREATE TABLE \"Города\" (\"id\" INTEGER,\"Название_города\" TEXT,\"Долгота_и_Ширина\" TEXT,PRIMARY KEY(\"id\" AUTOINCREMENT)); " +
                        "CREATE TABLE \"User\" (\"ID_User\"INTEGER NOT NULL,\"id\"INTEGER,FOREIGN KEY(\"id\") REFERENCES \"Города\"(\"id\"),PRIMARY KEY(\"ID_User\" AUTOINCREMENT)); " +
                        "INSERT INTO \"Города\" (\"id\", \"Название_города\",\"Долгота_и_Ширина\") VALUES ('1', 'Москва','lat=55.7558&lon=37.617'); " +
                        "INSERT INTO \"User\" (\"ID_User\", \"id\") VALUES ('1', '1'); " +
                        "INSERT INTO \"Города\" (\"id\", \"Название_города\", \"Долгота_и_Ширина\") VALUES ('2', 'Самара', 'lat=53.2001&lon=50.15'); " +
                        "INSERT INTO \"Города\" (\"id\", \"Название_города\", \"Долгота_и_Ширина\") VALUES ('3', 'Саратов', 'lat=51.5667&lon=46.0333'); " +
                        "INSERT INTO \"Города\" (\"id\", \"Название_города\", \"Долгота_и_Ширина\") VALUES ('4', 'Ростов-на-Дону', 'lat=47.2313&lon=39.7233'); " +
                        "INSERT INTO \"Города\" (\"id\", \"Название_города\", \"Долгота_и_Ширина\") VALUES ('5', 'Санкт-Петербург', 'lat=59.9386&lon=30.3141');" +
                        "INSERT INTO \"Города\" (\"id\", \"Название_города\", \"Долгота_и_Ширина\") VALUES ('6', 'Хабаровск', 'lat=48.4827&lon=135.084');" +
                        "INSERT INTO \"Города\" (\"id\", \"Название_города\", \"Долгота_и_Ширина\") VALUES ('7', 'Владивосток', 'lat=43.1056&lon=131.874');" +
                        "INSERT INTO \"Города\" (\"id\", \"Название_города\", \"Долгота_и_Ширина\") VALUES ('8', 'Нижний Новгород', 'lat=56.3287&lon=44.002');" +
                        "INSERT INTO \"Города\" (\"id\", \"Название_города\", \"Долгота_и_Ширина\") VALUES ('9', 'Архангельск', 'lat=64.5401&lon=40.5433');" +
                        "INSERT INTO \"Города\" (\"id\", \"Название_города\", \"Долгота_и_Ширина\") VALUES ('10', 'Сочи', 'lat=43.5992&lon=39.7257');";
                        
                    using (SQLiteCommand cmd = new SQLiteCommand(command, conect))
                    {
                        conect.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public static DataTable ComboBox()
        { 
            DataTable dt = new DataTable();
            using (SQLiteConnection conect = new SQLiteConnection(db_info))
            {
                string command = "SELECT Города.id, Города.Долгота_и_Ширина FROM Города , User Where User.id = Города.id";
                using (SQLiteCommand cmd = new SQLiteCommand(command, conect))
                {
                    conect.Open();
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }
        public static string time_temp1 = "";
        public static string time_temp2 = "";
        public static string time_temp3 = "";
        public static string time_pressure1 = "";
        public static string time_pressure2 = "";
        public static string time_pressure3 = "";
        public static string time_wind_speed1 = "";
        public static string time_wind_speed2 = "";
        public static string time_wind_speed3 = "";
        public static string time_wind_description1 = "";
        public static string time_wind_description2 = "";
        public static string time_wind_description3 = "";
        public static async void Dop_infa()
        {
            string response = await client.GetStringAsync(url_day_array);
            string result = response;
            var json = JObject.Parse(result);
            var array1 = json["list"][1].ToString();
            time_temp1 = json["list"][1]["main"]["temp"].ToString();
            time_pressure1 = json["list"][1]["main"]["pressure"].ToString();
            time_wind_speed1 = json["list"][1]["wind"]["speed"].ToString();
            time_wind_description1 = json["list"][1]["weather"][0]["description"].ToString();
            var array2 = json["list"][2].ToString();
            time_temp2 = json["list"][2]["main"]["temp"].ToString();
            time_pressure2 = json["list"][2]["main"]["pressure"].ToString();
            time_wind_speed2 = json["list"][2]["wind"]["speed"].ToString();
            time_wind_description2 = json["list"][2]["weather"][0]["description"].ToString();
            var array3 = json["list"][3].ToString();
            time_temp3 = json["list"][3]["main"]["temp"].ToString();
            time_pressure3 = json["list"][3]["main"]["pressure"].ToString();
            time_wind_speed3 = json["list"][3]["wind"]["speed"].ToString();
            time_wind_description3 = json["list"][3]["weather"][0]["description"].ToString();
        }
        public static DataTable Combobox_feel() 
        {
            DataTable dota = new DataTable();   
            using (SQLiteConnection conect = new SQLiteConnection(db_info))
            {
                string command = "SELECT Название_города, Долгота_и_Ширина FROM Города";
                using (SQLiteCommand cmd = new SQLiteCommand(command, conect))
                {
                    conect.Open();
                    SQLiteDataAdapter dt = new SQLiteDataAdapter(command,conect);
                    dt.Fill(dota);
                }
            }  
            return dota;
        }
    }
} 

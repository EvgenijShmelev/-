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
        static public async void getWeather()
        {
            string response = await client.GetStringAsync(url_day);
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
                        "INSERT INTO \"User\" (\"ID_User\", \"id\") VALUES ('1', '1'); ";

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
            //}
            //catch
            //{
            //    return null;
            //}
        }

    }
} 

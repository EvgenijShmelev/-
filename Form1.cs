using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Прогноз_погоды
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            button2.Parent = pictureBox1;
            button2.BackColor = Color.Transparent;
            Weather.getWeather();

        }
        private void update_main_label(object sender, EventArgs e) 
        {
            label1.Text = Math.Round(Convert.ToDecimal(Weather.temp)).ToString() + "°";

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Weather.CheckDB();
            DataTable data = Weather.ComboBox();
            int id_cuntry = int.Parse(data.Rows[0][0].ToString());
            Weather.lon_lat = data.Rows[0][1].ToString();
            button2.FlatAppearance.BorderSize = 0;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Tick += new EventHandler(update_main_label);
            timer.Start();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;
            string time = "";
            if (h < 10)
            {
                time += "0" + h;
            }
            else
            {
                time += h;
            }

            time += ":";

            if (m < 10)
            {
                time += "0" + m;
            }
            else
            {
                time += m;
            }

            time += ":";

            if (s < 10)
            {
                time += "0" + s;
            }
            else
            {
                time += s;
            }
            label3.Text = time;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label27_Click(object sender, EventArgs e)
        {

        }
        private void Check_icon(string pogoda)
        {
            if (pogoda != Weather.icon)
            {

                switch (pogoda)
                {
                    case "01d":
                        pictureBox1.BackgroundImage = Properties.Resources.clear_sky;
                        break;
                    case "02d":
                        pictureBox1.BackgroundImage = Properties.Resources.few_clouds;
                        break;
                    case "03d":
                        pictureBox1.BackgroundImage = Properties.Resources.scattered_clouds;
                        break;
                    case "04d":
                        pictureBox1.BackgroundImage = Properties.Resources.broken_clouds;
                        break;
                    case "09d":
                        pictureBox1.BackgroundImage = Properties.Resources.shower_rain;
                        break;
                    case "10d":
                        pictureBox1.BackgroundImage = Properties.Resources.rain1;
                        break;
                    case "11d":
                        pictureBox1.BackgroundImage = Properties.Resources.thunderstorm;
                        break;
                    case "13d":
                        pictureBox1.BackgroundImage = Properties.Resources.snow;
                        break;
                    case "50d":
                        pictureBox1.BackgroundImage = Properties.Resources.mist;
                        break;
                    case "01n":
                        pictureBox1.BackgroundImage = Properties.Resources.clear_sky_n;
                        break;
                    case "02n":
                        pictureBox1.BackgroundImage = Properties.Resources.few_clouds_n;
                        break;
                    case "03n":
                        pictureBox1.BackgroundImage = Properties.Resources.scattered_clouds_n;
                        break;
                    case "04n":
                        pictureBox1.BackgroundImage = Properties.Resources.broken_clouds_n;
                        break;
                    case "09n":
                        pictureBox1.BackgroundImage = Properties.Resources.shower_rain;
                        break;
                    case "10n":
                        pictureBox1.BackgroundImage = Properties.Resources.rain1;
                        break;
                    case "11n":
                        pictureBox1.BackgroundImage = Properties.Resources.thunderstorm;
                        break;
                    case "13n":
                        pictureBox1.BackgroundImage = Properties.Resources.snow_n;
                        break;
                    case "50n":
                        pictureBox1.BackgroundImage = Properties.Resources.mist_n;
                        break;
                }
            }
        }
        private void PictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}


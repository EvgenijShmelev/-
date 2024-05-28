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
using Label = System.Reflection.Emit.Label;

namespace Прогноз_погоды
{
    public partial class Form1 : Form
    {
        static public string now_icon = "";
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
            panel1.Parent = pictureBox1;
            Weather.getWeather();

            Weather.CheckDB();
            DataTable data = Weather.ComboBox();
            button2.FlatAppearance.BorderSize = 0;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Tick += new EventHandler(update_main_label);
            timer.Start();

            

        }
        private void update_main_label(object sender, EventArgs e) 
        {
            
            Check_icon();
            Weather.Dop_infa();
            Weather.getWeather();
            label1.Text = Math.Round(Convert.ToDecimal(Weather.temp)).ToString() + "°";
            label24.Text = Weather.time_pressure1;
            label25.Text = Weather.time_wind_speed1;
            label27.Text = Weather.time_temp1;
            label26.Text = Weather.time_wind_description1;

            label9.Text = Weather.time_pressure1;
            label13.Text = Weather.time_wind_speed1;
            label17.Text = Weather.time_temp2;
            label21.Text = Weather.time_wind_description2;

            label10.Text = Weather.time_pressure1;
            label14.Text = Weather.time_wind_speed1;
            label18.Text = Weather.time_temp3;
            label22.Text = Weather.time_wind_description3;

            label2.Text = Weather.description;
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
            now_icon = "";

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
        private void Check_icon()
        {
            if (now_icon != Weather.icon)
            {
                now_icon= Weather.icon;
                switch (now_icon)
                {
                    case "01d":
                        pictureBox1.Image = Properties.Resources.clear_sky;
                        break;
                    case "02d":
                        pictureBox1.Image = Properties.Resources.few_clouds;
                        break;
                    case "03d":
                        pictureBox1.Image = Properties.Resources.scattered_clouds;
                        break;
                    case "04d":
                        pictureBox1.Image = Properties.Resources.broken_clouds;
                        break;
                    case "09d":
                        pictureBox1.Image = Properties.Resources.shower_rain;
                        break;
                    case "10d":
                        pictureBox1.Image = Properties.Resources.rain1;
                        break;
                    case "11d":
                        pictureBox1.Image = Properties.Resources.thunderstorm;
                        break;
                    case "13d":
                        pictureBox1.Image = Properties.Resources.snow;
                        break;
                    case "50d":
                        pictureBox1.Image = Properties.Resources.mist;
                        break;
                    case "01n":
                        pictureBox1.Image = Properties.Resources.clear_sky_n;
                        foreach (Control control in panel1.Controls)
                        {
                            if (control is System.Windows.Forms.Label)
                            {
                                control.ForeColor = Color.Blue; // здесь можно указать любой другой цвет
                            }
                        }
                        foreach (Control control in pictureBox1.Controls)
                        {
                            if (control is System.Windows.Forms.Label)
                            {
                                control.ForeColor = Color.Blue; // здесь можно указать любой другой цвет
                            }
                        }
                        break;
                    case "02n":
                        pictureBox1.Image = Properties.Resources.few_clouds_n;
                        break;
                    case "03n":
                        pictureBox1.Image = Properties.Resources.scattered_clouds_n;  
                        break;
                    case "04n":
                        pictureBox1.Image = Properties.Resources.broken_clouds_n;
                        break;
                    case "09n":
                        pictureBox1.Image = Properties.Resources.shower_rain;
                        break;
                    case "10n":
                        pictureBox1.Image = Properties.Resources.rain1;
                        break;
                    case "11n":
                        pictureBox1.Image = Properties.Resources.thunderstorm;
                        break;
                    case "13n":
                        pictureBox1.Image = Properties.Resources.snow_n;
                        break;
                    case "50n":
                        pictureBox1.Image = Properties.Resources.mist_n;
                        break;
                }
                Console.WriteLine("switch");
            }
        }
        private void PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}


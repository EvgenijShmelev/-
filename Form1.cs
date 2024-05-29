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
            
            
            label3.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            
            button2.BackColor = Color.Transparent;
            
            Weather.getWeather();

            Weather.CheckDB();
            DataTable data = Weather.ComboBox();
            button2.FlatAppearance.BorderSize = 0;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Tick += new EventHandler(update_main_label);
            timer.Start();
            Timer timer2 = new Timer();
            timer2.Interval = 3000;
            timer2.Tick += new EventHandler(Check_icon);
            timer2.Start();



        }
        private void update_main_label(object sender, EventArgs e) 
        {
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
        private void Check_icon(object sender, EventArgs e)
        { 
                now_icon= Weather.icon;
                switch (now_icon)
                {
                    case "01d":
                        this.BackgroundImage = Properties.Resources.clear_sky;         
                        break;
                    case "02d":
                        this.BackgroundImage = Properties.Resources.few_clouds;
                        break;
                    case "03d":
                        this.BackgroundImage = Properties.Resources.scattered_clouds;
                        break;
                    case "04d":
                        this.BackgroundImage = Properties.Resources.broken_clouds;
                        break;
                    case "09d":
                        this.BackgroundImage = Properties.Resources.shower_rain;
                        break;
                    case "10d":
                        this.BackgroundImage = Properties.Resources.rain1;
                        break;
                    case "11d":
                        this.BackgroundImage = Properties.Resources.thunderstorm;
                        break;
                    case "13d":
                        this.BackgroundImage = Properties.Resources.snow;
                        break;
                    case "50d":
                        this.BackgroundImage = Properties.Resources.mist;
                        break;
                    case "01n":
                        this.BackgroundImage = Properties.Resources.clear_sky_n;
                        foreach (Control control in panel1.Controls)
                        {
                            if (control is System.Windows.Forms.Label)
                            {
                                control.ForeColor = Color.Blue; // здесь можно указать любой другой цвет
                            }
                        }
                        foreach (Control control in this.Controls)
                        {
                            if (control is System.Windows.Forms.Label)
                            {
                                control.ForeColor = Color.Blue; // здесь можно указать любой другой цвет
                            }
                        }
                        break;
                    case "02n":
                        this.BackgroundImage = Properties.Resources.few_clouds_n;
                        break;
                    case "03n":
                        this.BackgroundImage = Properties.Resources.scattered_clouds_n;  
                        break;
                    case "04n":
                        this.BackgroundImage = Properties.Resources.broken_clouds_n;
                        break;
                    case "09n":
                        this.BackgroundImage = Properties.Resources.shower_rain;
                        break;
                    case "10n":
                        this.BackgroundImage = Properties.Resources.rain1;
                        break;
                    case "11n":
                        this.BackgroundImage = Properties.Resources.thunderstorm;
                        break;
                    case "13n":
                        this.BackgroundImage = Properties.Resources.snow_n;
                        break;
                    case "50n":
                        this.BackgroundImage = Properties.Resources.mist_n;
                        break;
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

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


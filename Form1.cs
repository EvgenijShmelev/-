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
            label3.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
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
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
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
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

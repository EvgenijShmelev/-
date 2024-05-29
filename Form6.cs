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
    public partial class Form6 : Form
    {
        public Form6(int id1)
        {
            InitializeComponent();
            id = id1;
        }
        static public int id;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form = new Form5();
            form.Show();
        }
        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Weather.new_info(id);
            Timer timer2 = new Timer();
            timer2.Interval = 1000;
            timer2.Tick += new EventHandler(labels);
            timer2.Start();

        }
        private void labels(object sender, EventArgs e) 
        {
            label7.Text = Weather.temp1;
            label5.Text = Weather.pressure1;
            label6.Text = Weather.wind_speed1;
            label8.Text = Weather.description1;
        }
    }
}

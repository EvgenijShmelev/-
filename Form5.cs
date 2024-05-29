using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Прогноз_погоды
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form = new Form6(8);
            form.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime tomorrow1 = now.AddDays(1);
            DateTime dateWithoutTime1 = tomorrow1.Date;
            button1.Text = dateWithoutTime1.ToShortDateString();

            DateTime tomorrow2 = now.AddDays(2);
            DateTime dateWithoutTime2 = tomorrow2.Date;
            button2.Text = dateWithoutTime2.ToShortDateString();

            DateTime tomorrow3 = now.AddDays(3);
            DateTime dateWithoutTime3 = tomorrow3.Date;
            button3.Text = dateWithoutTime3.ToShortDateString();

            DateTime tomorrow4 = now.AddDays(4);
            DateTime dateWithoutTime4 = tomorrow4.Date;
            button5.Text = dateWithoutTime4.ToShortDateString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form = new Form6(16);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form = new Form6(24);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form = new Form6(32);
            form.Show();
        }
    }
}

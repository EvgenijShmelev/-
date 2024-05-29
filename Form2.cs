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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Geolocation_form form3 = new Geolocation_form();
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Частота_обновления_данных form5 = new Частота_обновления_данных();
            form5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
          Application.Exit();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button4.FlatAppearance.BorderSize = 0;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Yvedomlenia form4 = new Yvedomlenia();
            form4.Show();
        }
    }
}

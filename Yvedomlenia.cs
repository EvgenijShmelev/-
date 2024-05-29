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
    public partial class Yvedomlenia : Form
    {
        public Yvedomlenia()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы уже включили уведомления!");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы уже выключили уведомления!");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }
        private void Yvedomlenia_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }
    }
}

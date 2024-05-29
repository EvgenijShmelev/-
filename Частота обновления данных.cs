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
    public partial class Частота_обновления_данных : Form
    {
        public Частота_обновления_данных()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }
        private void Частота_обновления_данных_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }
    }
}

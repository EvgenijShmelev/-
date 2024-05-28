using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Прогноз_погоды
{
    public partial class Geolocation_form : Form
    {
        static public string Moscow = "lat=55.7558&lon=37.617&";
        public Geolocation_form()
        {
            InitializeComponent();
        }

        private void Geolocation_form_Load(object sender, EventArgs e)
        {
            DataTable data = Weather.Combobox_feel();

            comboBox1.DisplayMember = "Название_города";
            comboBox1.ValueMember = "Долгота_и_Ширина";
            comboBox1.DataSource = data;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string i = comboBox1.SelectedValue.ToString();
            Weather.lon_lat = i;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }

        private void Geolocation_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

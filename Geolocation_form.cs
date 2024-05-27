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
    public partial class Geolocation_form : Form
    {
        static public string Moscow = "lat=55.7558&lon=37.617&";
        public Geolocation_form()
        {
            InitializeComponent();
        }

        private void Geolocation_form_Load(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

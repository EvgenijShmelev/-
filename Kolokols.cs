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
    public partial class Kolokols : Form
    {

        public Kolokols()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Kolokols_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            if (Form1.yvedomlenia == 1) 
            {
                panel1.Visible = true;
            }
            if (Form1.yvedomlenia == 2)
            {
                panel1.Visible = true;
                panel2.Visible = true;
            }
            if (Form1.yvedomlenia == 3)
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
            }
        }

    }
}

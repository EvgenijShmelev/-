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
        static public bool Prosto = false;
        public Yvedomlenia()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Prosto == true)
            {
                MessageBox.Show("Вы уже включили уведомления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Уведомления успешно включены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Prosto = true;
            }          
        }
        //static public void UpdateProsto()
        //{
        //    Prosto =
        //}
        private void Button1_Click(object sender, EventArgs e)
        {
            if (Prosto == false)
            {
                MessageBox.Show("Вы уже отключили уведомления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            else
            {
                MessageBox.Show("Уведомления успешно отключены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Prosto = false;
            }
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

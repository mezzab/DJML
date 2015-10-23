using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Compra
{
    public partial class FormEncomienda : Form
    {
        public static int kilos;
        
        public FormEncomienda()
        {
            InitializeComponent();
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FormCompra2 m = new FormCompra2();
            this.Hide();
            m.ShowDialog();
            m = (FormCompra2)this.ActiveMdiChild;

        }

        private void FormEncomienda_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            FormCompra2.tipoPasaje = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCompra3 m = new FormCompra3();
            this.Hide();
            m.ShowDialog();
            m = (FormCompra3)this.ActiveMdiChild;

           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ( kilosEncomienda != null)
            {
                button2.Enabled = true;
            }

           kilos = Int32.Parse(kilosEncomienda.Text.Trim());

          // MessageBox.Show(string(kilos));
        }

        private void textBox1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class FormCompra2 : Form
    {
        public FormCompra2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCompra1 volver = new FormCompra1();
            this.Hide();
            volver.ShowDialog();
            volver = (FormCompra1)this.ActiveMdiChild;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FormPasaje enc = new FormPasaje();
            this.Hide();
            enc.ShowDialog();
            enc = (FormPasaje)this.ActiveMdiChild;

            int tipocompra;
            tipocompra = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormEncomienda Pasaje = new FormEncomienda();
            this.Hide();
            Pasaje.ShowDialog();
            Pasaje = (FormEncomienda)this.ActiveMdiChild;

            int tipocompra;
            tipocompra = 1;
        }
    }
}

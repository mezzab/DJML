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
            FormEncomienda enc = new FormEncomienda();
            this.Hide();
            enc.ShowDialog();
            enc = (FormEncomienda)this.ActiveMdiChild;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPasaje Pasaje = new FormPasaje();
            this.Hide();
            Pasaje.ShowDialog();
            Pasaje = (FormPasaje)this.ActiveMdiChild;
        }
    }
}

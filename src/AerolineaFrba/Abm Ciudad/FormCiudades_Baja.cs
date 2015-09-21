using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class FormCiudades_Baja : Form
    {
        public FormCiudades_Baja()
        {
            InitializeComponent();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            FormCiudades a = new FormCiudades();
            this.Hide();
            a.ShowDialog();
            a = (FormCiudades)this.ActiveMdiChild;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BoxCiudades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

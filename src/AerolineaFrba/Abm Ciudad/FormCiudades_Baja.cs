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

        private void FormCiudades_Baja_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCiudades volver = new FormCiudades();
            this.Hide();
            volver.ShowDialog();
            volver = (FormCiudades)this.ActiveMdiChild;
        }
    }
}

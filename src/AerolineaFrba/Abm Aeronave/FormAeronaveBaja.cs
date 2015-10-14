using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class FormAeronaveBaja : Form
    {
        public FormAeronaveBaja()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAeronave aero = new FormAeronave();
            this.Hide();
            aero.ShowDialog();
            aero = (FormAeronave)this.ActiveMdiChild;

        }
    }
}

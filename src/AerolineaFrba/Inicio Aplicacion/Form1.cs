using AerolineaFrba.Abm_Ciudad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   //esto en realidad te va a mandar al login 
            this.Visible = false;
            FormCiudades frm = new FormCiudades();
            frm.ShowDialog();
            frm = (FormCiudades)this.ActiveMdiChild;
        }
    }
}

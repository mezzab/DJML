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
    public partial class FormCiudades_List : Form
    {
        public FormCiudades_List()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCiudades a = new FormCiudades();
            this.Hide();
            a.ShowDialog();
            a = (FormCiudades)this.ActiveMdiChild;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void modificar_Click(object sender, EventArgs e)
        {

        }
        }
    }

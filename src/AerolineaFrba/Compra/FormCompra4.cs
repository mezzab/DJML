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
    public partial class FormCompra4 : Form
    {   
        public FormCompra4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // vuelve al formcompra3 y lo carga con los datos de la fila
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormCompra4_Load(object sender, EventArgs e)
        {
            
            
            verificacion.DataSource = FormCompra3.tabla;
            verificacion.Show();
        }
    }
}

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
            FormFormaDePago volver = new FormFormaDePago();
            this.Hide();
            volver.ShowDialog();
            volver = (FormFormaDePago)this.ActiveMdiChild;
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
            DataGridViewColumn column = verificacion.Columns[0];
            column.Width = 55;
            DataGridViewColumn column1 = verificacion.Columns[1];
            column1.Width = 60;
            DataGridViewColumn column2 = verificacion.Columns[2];
            column2.Width = 78;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormCompra1 volver = new FormCompra1();
            this.Hide();
            volver.ShowDialog();
            volver = (FormCompra1)this.ActiveMdiChild;
        }
    }
}

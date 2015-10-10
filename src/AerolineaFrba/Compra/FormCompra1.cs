using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Inicio_Aplicacion;

namespace AerolineaFrba.Compra
{
    public partial class FormCompra1 : Form
    {
        public FormCompra1()
        {
            InitializeComponent();
        }

        private void FormCompra1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            FormInicioFuncionalidades FormInicioFuncionalidades = new FormInicioFuncionalidades();
            this.Hide();
            FormInicioFuncionalidades.ShowDialog();
            FormInicioFuncionalidades = (FormInicioFuncionalidades)this.ActiveMdiChild;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
    }
}

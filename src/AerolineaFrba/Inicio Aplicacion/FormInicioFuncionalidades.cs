using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Abm_Rol;
using AerolineaFrba.Generacion_Viaje;
using AerolineaFrba.Compra;


namespace AerolineaFrba.Inicio_Aplicacion
{
    public partial class FormInicioFuncionalidades : Form
    {
        public FormInicioFuncionalidades()
        {
            InitializeComponent();
        }

        private void abm_rol_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            Form frm = new FormRol();
            frm.ShowDialog();
            frm = (FormRol)this.ActiveMdiChild;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form frm = new FormGenerarViaje();
            frm.ShowDialog();
            frm = (FormGenerarViaje)this.ActiveMdiChild;
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            FormCompra1 frm = new FormCompra1();
            frm.ShowDialog();
            frm = (FormCompra1)this.ActiveMdiChild;
        }
    }
}

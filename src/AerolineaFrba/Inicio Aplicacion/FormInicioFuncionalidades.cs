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
using AerolineaFrba.Abm_Ciudad;
using AerolineaFrba.Abm_Ruta;
using AerolineaFrba.Devolucion;
using AerolineaFrba.Listado_Estadistico;

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
            frm.StartPosition = FormStartPosition.CenterScreen;
          
            frm.ShowDialog();
            frm = (FormRol)this.ActiveMdiChild;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form frm = new FormGenerarViaje();
            frm.StartPosition = FormStartPosition.CenterScreen;
          
            frm.ShowDialog();
            frm = (FormGenerarViaje)this.ActiveMdiChild;
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
             FormCompra1 frm = new FormCompra1();
             frm.StartPosition = FormStartPosition.CenterScreen;
        
            frm.ShowDialog();
            frm = (FormCompra1)this.ActiveMdiChild;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form frm = new FormCiudades();
            frm.StartPosition = FormStartPosition.CenterScreen;
          
            frm.ShowDialog();
            frm = (FormCiudades)this.ActiveMdiChild;
        
        }

        private void button_rutas_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form frm = new FormRuta();
            frm.StartPosition = FormStartPosition.CenterScreen;
          
            frm.ShowDialog();
            frm = (FormRuta)this.ActiveMdiChild;
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Devolucion0 frm = new Devolucion0();
            frm.StartPosition = FormStartPosition.CenterScreen;

            frm.ShowDialog();
            frm = (Devolucion0)this.ActiveMdiChild;
        }

        private void bnListado_Click(object sender, EventArgs e)
        {
            FormListadoEstadistico inicioF = new FormListadoEstadistico();
            this.Hide();
            inicioF.ShowDialog();
            inicioF = (FormListadoEstadistico)this.ActiveMdiChild;
        }

    }
}

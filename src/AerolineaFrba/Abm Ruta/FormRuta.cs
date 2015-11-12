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
using AerolineaFrba.Abm_Ruta;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class FormRuta : Form
    {
        public FormRuta()
        {
            InitializeComponent();
        }

        private void button_alta_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormRutaAlta frm = new FormRutaAlta();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void button_baja_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormRutaBaja frm = new FormRutaBaja();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void button_modificacion_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormRutaModificacion1 frm = new FormRutaModificacion1();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void button_listado_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormRutaListado frm = new FormRutaListado();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            FormInicioFuncionalidades frm = new FormInicioFuncionalidades();
            frm.ShowDialog();
            this.Visible = true;
        }

    }
}

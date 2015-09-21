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
            //esto en realidad te va a mandar al login 
            this.Visible = false;
            Form frm = new FormRol();
            frm.ShowDialog();
            frm = (FormRol)this.ActiveMdiChild;
        }
    }
}

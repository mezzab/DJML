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

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class FormCiudades : Form
    {
        public FormCiudades()
        {
            InitializeComponent();
        }

        private void FormCiudades_Load(object sender, EventArgs e)
        {

        }

        private void alta_Click(object sender, EventArgs e)
        {
            FormCiudades_Alta alta = new FormCiudades_Alta();
            this.Hide();
            alta.ShowDialog();
            alta = (FormCiudades_Alta)this.ActiveMdiChild;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCiudades_Baja baja = new FormCiudades_Baja();
            this.Hide();
            baja.ShowDialog();
            baja = (FormCiudades_Baja)this.ActiveMdiChild;
            /*FormCiudades_List list = new FormCiudades_List();
            this.Hide();
            list.ShowDialog();
            list = (FormCiudades_List)this.ActiveMdiChild;*/
        }

        private void modificacion_Click(object sender, EventArgs e)
        {
          /*  FormCiudades_Modi modi = new FormCiudades_Modi();
            this.Hide();
            modi.ShowDialog();
            modi = (FormCiudades_Modi)this.ActiveMdiChild; */

            FormCiudades_List list = new FormCiudades_List();
            this.Hide();
            list.ShowDialog();
            list = (FormCiudades_List)this.ActiveMdiChild;
        }

        private void listado_Click(object sender, EventArgs e)
        {
            FormCiudades_List list = new FormCiudades_List();
            this.Hide();
            list.ShowDialog();
            list = (FormCiudades_List)this.ActiveMdiChild;
        }

        private void volver_Click(object sender, EventArgs e)
        { // solo para probar
            Form a = new FormInicioFuncionalidades();
            this.Hide();
            a.ShowDialog();
            a = (FormInicioFuncionalidades)this.ActiveMdiChild;
        }
    }
}

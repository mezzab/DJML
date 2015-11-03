using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Properties;
using System.Data.SqlClient;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class FormRutaListado : Form
    {
        public FormRutaListado()
        {
            InitializeComponent();
        }

        private void FormRutaListado_Load(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            string qry = " SELECT [Ciudad Origen], [Ciudad Destino], [Servicio], [Pasaje], [Kilo Encomienda] FROM [DJML].v_rutas ORDER BY 1";

            dataGrid.DataSource = new Query(qry).ObtenerDataTable();
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            FormRuta ruta = new FormRuta();
            this.Hide();
            ruta.ShowDialog();
            ruta = (FormRuta)this.ActiveMdiChild;
        }

    }
}

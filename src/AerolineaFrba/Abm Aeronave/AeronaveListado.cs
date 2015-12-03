using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AerolineaFrba.Properties;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class AeronaveListado : Form
    {
        public AeronaveListado()
        {
            InitializeComponent();
        }

        private void bnVolver_Click(object sender, EventArgs e)
        {
            FormAeronave aeronave = new FormAeronave();
            this.Hide();
            aeronave.ShowDialog();
            aeronave = (FormAeronave)this.ActiveMdiChild;
        }

        private void txtMatricula_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtServicio_TextChanged(object sender, EventArgs e)
        {

        }

        private void bnFiltrar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            string matricula = txtMatricula.Text;
            string modelo = txtModelo.Text;
            string servicio = txtServicio.Text;
            string fabricante = txtFabricante.Text;


            string qry = "SELECT a.aero_matricula, a.aero_modelo, f.descripcion, a.aero_kilos_disponibles,s.serv_descripcion, a.aero_baja_fuera_servicio, a.aero_baja_vida_util, a.aero_fecha_baja_def, a.aero_fecha_alta   FROM djml.AERONAVES A JOIN DJML.FABRICANTES F on a.AERO_FABRICANTE = f.ID_FABRICANTE JOIN DJML.SERVICIOS S ON a.AERO_SERVICIO_ID = s.SERV_ID WHERE (a.AERO_MODELO like '" + modelo + "' OR '" + modelo + "' like '') AND (a.AERO_MATRICULA like '" + matricula + "' OR '" + matricula + "' like '') AND (f.DESCRIPCION like '" + fabricante + "' OR '" + fabricante + "' like '') AND (s.SERV_DESCRIPCION like '" + servicio + "' OR '" + servicio + "' like '')";

            datos.DataSource = new Query(qry).ObtenerDataTable();

        }



    }
}

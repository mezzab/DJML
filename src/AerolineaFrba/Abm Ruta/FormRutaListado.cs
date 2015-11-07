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
            cargarGrid();
         
        }

        private void cargarGrid() 
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;
    
            Query qry2 = new Query("select ruta_codigo from djml.rutas ");
            datos.DataSource = qry2.ObtenerDataTable();
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            FormRuta ruta = new FormRuta();
            this.Hide();
            ruta.ShowDialog();
            ruta = (FormRuta)this.ActiveMdiChild;
        }

        /*private void cargarGrid()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            //Query qry2 = new Query("SELECT [Ciudad Origen], [Ciudad Destino], [Servicio], [Pasaje], [Kilo Encomienda] FROM [DJML].v_rutas ORDER BY 1");
            Query qry2 = new Query("SELECT 1 FROM [DJML].RUTAS");
            dataGrid.DataSource = qry2.ObtenerDataTable();
        }
        */
        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

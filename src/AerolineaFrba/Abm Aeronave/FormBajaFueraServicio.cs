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
using AerolineaFrba.Inicio_Aplicacion;


namespace AerolineaFrba.Abm_Aeronave
{
    public partial class FormBajaFueraServicio : Form
    {
        public FormBajaFueraServicio()
        {
            InitializeComponent();
        }

        private void FormBajaFueraServicio_Load(object sender, EventArgs e)
        {
             cargarAeronaves();
            comboBoxAeronaves.DropDownStyle = ComboBoxStyle.DropDownList;
        }



        private void cargarAeronaves()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select AERO_MATRICULA from DJML.AERONAVES where AERO_BAJA_VIDA_UTIL = 0", conexion);
            da.Fill(ds, "DJML.ROLES");

            comboBoxAeronaves.DataSource = ds.Tables[0].DefaultView;
            comboBoxAeronaves.ValueMember = "AERO_MATRICULA";
            comboBoxAeronaves.SelectedItem = null;
        

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

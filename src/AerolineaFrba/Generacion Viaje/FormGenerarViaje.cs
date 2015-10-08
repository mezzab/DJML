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


namespace AerolineaFrba.Generacion_Viaje
{
    public partial class FormGenerarViaje : Form
    {

        public FormGenerarViaje()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fechaSalida_ValueChanged(object sender, EventArgs e)
        {

        }

        private void llenarComboBox()
        {

            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select a.AERO_MATRICULA from DJML.AERONAVES a where a.AERO_BAJA_FUERA_SERVICIO = 0 AND a.AERO_BAJA_VIDA_UTIL = 0 having a.AERO_MATRICULA not in (  select v.VIAJE_AERO_ID from VIAJES v  where VIAJE_FECHA_SALIDA =  fechaSalida and VIAJE_FECHA_LLEGADA = fechaLlegada)) ", conexion);
            da.Fill(ds, "DJML.AERONAVES");

            comboBoxAeronaves.DataSource = ds.Tables[0].DefaultView;
            comboBoxAeronaves.ValueMember = "AERO_MATRICULA";
            comboBoxAeronaves.SelectedItem = null;
        
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
          /*  if (fechaLlegada.Value.ToShortDateString()  fechaSalida.Value.ToShortDateString()) 
            {
                
              
            }
          */
        }

        
    }
}

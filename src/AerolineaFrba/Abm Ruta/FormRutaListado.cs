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
            //SqlConnection conexion = new SqlConnection();
            //conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            string qry = "SELECT DISTINCT RUTA_CODIGO as Codigo, " +
                                         "(SELECT CIUD_DETALLE FROM DJML.CIUDADES WHERE CIUD_ID = RUTA_CIUDAD_ORIGEN) as Origen, " +
                                         "(SELECT CIUD_DETALLE FROM DJML.CIUDADES WHERE CIUD_ID = RUTA_CIUDAD_DESTINO) as Destino, " +
                                         "(SELECT SERV_DESCRIPCION FROM DJML.SERVICIOS WHERE SERV_ID = RUTA_SERVICIO_ID) as Servicio, " +
                                         "'$ ' + cast ([RUTA_PRECIO_BASE_PASAJE] as CHAR(100)) as Pasaje, " +
                                         "'$ ' + cast ([RUTA_PRECIO_BASE_KILO] as CHAR(100)) as 'Kilo Encomienda', " +      
                         "FROM DJML.RUTAS" +
                         "ORDER BY 2";

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

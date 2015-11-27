using AerolineaFrba.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Inicio_Aplicacion;


namespace AerolineaFrba.Consulta_Millas
{
    public partial class ConsultarMillas : Form
    {
        public ConsultarMillas()
        {
            InitializeComponent();
        }

        private void ConsultarMillas_Load(object sender, EventArgs e)
        {
            LlenarComboBoxTipoDocumento();
            tipoDeDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void LlenarComboBoxTipoDocumento()
        {
            SqlConnection conexion1 = new SqlConnection();
            conexion1.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DESCRIPCION FROM DJML.TIPO_DOCUMENTO", conexion1);
            da.Fill(ds1, "DJML.TIPO_DOCUMENTO");

            tipoDeDocumento.DataSource = ds1.Tables[0].DefaultView;
            tipoDeDocumento.ValueMember = "DESCRIPCION";
            tipoDeDocumento.SelectedItem = null;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxDNI.Clear();
            dataGridConsultaMillas.DataSource = null;
        }

        private void botonConsultar_Click(object sender, EventArgs e)
        {
            String dni = textBoxDNI.Text;
            String tipo = tipoDeDocumento.Text;
            if (dni != string.Empty && tipo != string.Empty)
            {
                //MILLAS
                string qry = "SELECT COMPRA_FECHA as 'Fecha', COMPRA_ID as 'Compra', '$ ' + cast (COMPRA_MONTO as CHAR(100)) as 'Importe', FLOOR(COMPRA_MONTO / 10) AS 'Millas'" +
                        " FROM DJML.COMPRAS" +
                        " JOIN DJML.VIAJES on COMPRA_VIAJE_ID = VIAJE_ID" +
                        " JOIN DJML.CLIENTES on COMPRA_CLIE_ID = CLIE_ID" +
                        " JOIN DJML.TIPO_DOCUMENTO on CLIE_TIPO_DOC = CLIE_ID" +
                        " WHERE CLIE_DNI = " + dni + "'" +
                        " AND CLIE_TIPO_DOC =" + tipo + "'" +
                        " AND VIAJE_FECHA_SALIDA < GETDATE()";

                var result = new Query(qry).ObtenerDataTable();
                if (false)
                {
                    
                }
                else
                {
                    MessageBox.Show("Ninguna ruta coincide con su descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FormInicioFuncionalidades FormInicioFuncionalidades = new FormInicioFuncionalidades();
            this.Hide();
            FormInicioFuncionalidades.ShowDialog();
            FormInicioFuncionalidades = (FormInicioFuncionalidades)this.ActiveMdiChild;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

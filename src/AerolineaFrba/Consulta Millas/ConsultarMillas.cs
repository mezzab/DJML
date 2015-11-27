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
            labelTotal.Text = "0";
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
            labelTotal.Text = "0";
            this.textBoxDNI.Clear();
            dataGridConsultaMillas.DataSource = null;
            dataGridConsultaCanjes.DataSource = null;

            dataGridConsultaMillas.Visible = true;
            emptyMillas.Visible = false;

            dataGridConsultaCanjes.Visible = true;
            emptyCanjes.Visible = false;
        }

        private void botonConsultar_Click(object sender, EventArgs e)
        {
            String dni = textBoxDNI.Text;
            String tipo = tipoDeDocumento.Text;
            if (dni != string.Empty && tipo != string.Empty)
            {
                //MILLAS CANT
                string qryCant = "SELECT  DJML.CALCULAR_MILLAS('" + dni + "', '" + tipo + "')";
                var resultCant = new Query(qryCant).ObtenerDataTable();
                labelTotal.Text = resultCant.Rows[0][0].ToString();

                //MILLAS GRID
                string qryMillas = "SELECT COMPRA_FECHA as 'Fecha', COMPRA_CODIGO as 'Compra', '$ ' + cast (COMPRA_MONTO as VARCHAR(100)) as 'Importe', CAST(FLOOR(COMPRA_MONTO / 10) AS int) AS 'Millas'" +
                                   " FROM DJML.COMPRAS" +
                                   " JOIN DJML.VIAJES on COMPRA_VIAJE_ID = VIAJE_ID" +
                                   " JOIN DJML.CLIENTES on COMPRA_CLIE_ID = CLIE_ID" +
                                   " JOIN DJML.TIPO_DOCUMENTO td on CLIE_TIPO_DOC = ID_TIPO_DOC" +
                                   " WHERE CLIE_DNI = '" + dni + "'" +
                                   " AND td.DESCRIPCION = '" + tipo + "'" +
                                   " AND VIAJE_FECHA_SALIDA < GETDATE()" +
                                   " ORDER BY 1 ASC;";

                var resultMillas = new Query(qryMillas).ObtenerDataTable();
                if (resultMillas.Rows.Count != 0)
                {
                    dataGridConsultaMillas.DataSource = resultMillas;
                }
                else
                {
                    dataGridConsultaMillas.Visible = false;
                    emptyMillas.Visible = true;
                }

                //CANJES GRID
                string qryCanjes = "SELECT CANJ_FECHA_CANJE as 'Fecha', PROD_NOMBRE as 'Producto',	CANJ_CANTIDAD as 'Cantidad', CANJ_MILLAS_USADAS as 'Millas Gastadas'" +
                                   " FROM DJML.CANJES" +
                                   " JOIN DJML.PRODUCTO on CANJ_PRODUCTO_ID = PROD_ID" +
                                   " JOIN DJML.CLIENTES on CANJ_CLIE_ID = CLIE_ID" +
                                   " JOIN DJML.TIPO_DOCUMENTO td on CLIE_TIPO_DOC = ID_TIPO_DOC" +
                                   " WHERE CLIE_DNI = '" + dni + "'" +
                                   " AND td.DESCRIPCION = '" + tipo + "'" +
                                   " ORDER BY 1 ASC;";

                var resultCanjes = new Query(qryCanjes).ObtenerDataTable();
                if (resultCanjes.Rows.Count != 0)
                {
                    dataGridConsultaCanjes.DataSource = resultCanjes;
                }
                else
                {
                    dataGridConsultaCanjes.Visible = false;
                    emptyCanjes.Visible = true;
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

        private void emptyMillas_Click(object sender, EventArgs e)
        {

        }

        private void labelDetalle_Click(object sender, EventArgs e)
        {

        }
    }
}

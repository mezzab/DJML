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

        public static string IDC;


        public ConsultarMillas()
        {
            InitializeComponent();

        }

        private void ConsultarMillas_Load(object sender, EventArgs e)
        {
            LlenarComboBoxTipoDocumento();
            tipoDeDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            dataGrid1.Enabled = false;
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
            dataGrid1.DataSource = null;
         
            dataGrid1.Visible = true;
         
        }

        private int obtenerMillasEnPeriodo(string id_cliente)
        {
            string sql2 = "SELECT SUM(M.MILLAS_CANTIDAD)AS MILLAS_CANTIDAD FROM DJML.MILLAS M JOIN DJML.CLIENTES C ON M.MILLAS_CLIE_ID = C.CLIE_ID WHERE C.CLIE_ID = '" + id_cliente + "' AND MILLAS_FECHA BETWEEN DATEADD(yy,-1,GETDATE()) AND GETDATE() GROUP BY C.CLIE_ID ";
            Query qry2 = new Query(sql2);
            int millasViejas = Convert.ToInt32(qry2.ObtenerUnicoCampo());

            return millasViejas;

        }
        
        private void guardarIdCliente()
        {

            string sql = "SELECT CLIE_ID FROM DJML.CLIENTES " +
            "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDeDocumento.Text + "')" +
             " AND CLIE_DNI = '" + textBoxDNI.Text + "'";
            Query qry1 = new Query(sql);
            IDC = qry1.ObtenerUnicoCampo().ToString();
        }


        private void botonConsultar_Click(object sender, EventArgs e)
        {

            guardarIdCliente();


            if (textBoxDNI.Text != string.Empty && tipoDeDocumento.Text != string.Empty)
            {
                totalMillas.Text = obtenerMillasEnPeriodo(IDC).ToString();

                string sql1 = "SELECT MILLAS_COMPRA_ID ID_DE_COMPRA, MILLAS_CANTIDAD CANTIDAD_DE_MILLAS, MILLAS_FECHA FECHA FROM DJML.MILLAS WHERE MILLAS_CLIE_ID = '" + IDC + "'";

                dataGrid1.DataSource = new Query(sql1).ObtenerDataTable();

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

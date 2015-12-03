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
            string sql2 = "SELECT SUM(M.MILLAS_CANTIDAD)AS CANTIDAD_DE_MILLAS FROM DJML.MILLAS M JOIN DJML.CLIENTES C ON M.MILLAS_CLIE_ID = C.CLIE_ID WHERE C.CLIE_ID = '" + id_cliente + "' AND MILLAS_FECHA BETWEEN DATEADD(yy,-1,GETDATE()) AND GETDATE() GROUP BY C.CLIE_ID ";
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

        private bool existeUsuario()
        {
            string sql = "SELECT CLIE_DNI FROM DJML.CLIENTES " +
                         "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" +  tipoDeDocumento.Text + "') " +
                         "AND CLIE_DNI = '" + textBoxDNI.Text + "'";
            Query qry = new Query(sql);
            object ndni = qry.ObtenerUnicoCampo();

            return ndni != null;
        }

        private void botonConsultar_Click(object sender, EventArgs e)
        {
            if (existeUsuario())
            {

                guardarIdCliente();


                if (textBoxDNI.Text != string.Empty && tipoDeDocumento.Text != string.Empty)
                {
                    totalMillas.Text = obtenerMillasEnPeriodo(IDC).ToString();

                    string sql1 = "SELECT MILLAS_PASA_ID ID_DE_PASAJE, MILLAS_ENCO_ID ID_DE_ENCOMIENDA, MILLAS_CANTIDAD CANTIDAD_DE_MILLAS, MILLAS_FECHA FECHA, MILLAS_INFORMACION INFORMACION FROM DJML.MILLAS WHERE MILLAS_CLIE_ID = '" + IDC + "' AND MILLAS_FECHA BETWEEN DATEADD(yy,-1,GETDATE()) AND GETDATE() ";

                    dataGrid1.DataSource = new Query(sql1).ObtenerDataTable();
                    DataGridViewColumn column2 = dataGrid1.Columns[0];
                    column2.Width = 85;
                    DataGridViewColumn column1 = dataGrid1.Columns[1];
                    column1.Width = 85;
                    DataGridViewColumn column3 = dataGrid1.Columns[2];
                    column3.Width = 60;
                    DataGridViewColumn column4 = dataGrid1.Columns[3];
                    column4.Width = 85;
                    DataGridViewColumn column5 = dataGrid1.Columns[4];
                    column5.Width = 450;
                    

                    //carga el historial del grid con sus millas historicas
                    millasHistoricas();

                }
                else
                    MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                  MessageBox.Show("Inserte los datos de un usuario valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
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

        private void totalMillas_TextChanged(object sender, EventArgs e)
        {

        }


        private void millasHistoricas() 
        {

            string sql1 = "SELECT MILLAS_PASA_ID ID_DE_PASAJE, MILLAS_ENCO_ID ID_DE_ENCOMIENDA, MILLAS_CANTIDAD_HISTORICA CANTIDAD_DE_MILLAS_HISTORICAS, MILLAS_FECHA FECHA, MILLAS_INFORMACION INFORMACION FROM DJML.MILLAS WHERE MILLAS_CLIE_ID = '" + IDC + "'"; 

            datos.DataSource = new Query(sql1).ObtenerDataTable();
        
        
        
        }
    }
}

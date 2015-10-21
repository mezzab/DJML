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

namespace AerolineaFrba.Compra
{
    public partial class FormCompra3 : Form
    {
        public static string nombre = "marcos";
 
        public FormCompra3()
        {
            InitializeComponent();

         
        }
        private void FormCompra3_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            LlenarComboBox1();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            /*
         string qry = "SELECT B.BUTA_NRO BUTACA , T.DESCRIPCION FROM DJML.BUTACA_AERO X, DJML.BUTACAS B, DJML.TIPO_BUTACA T" +
                     "WHERE X.BXA_BUTA_ID = B.BUTA_ID " +
                     "AND T.TIPO_BUTACA_ID = B.BUTA_TIPO_ID" +
                     "AND X.BXA_AERO_MATRICULA = 'ASQ-169'";

         dataGrid.DataSource = new Query(qry).ObtenerDataTable();
          */
         
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FormCompra2.tipoPasaje == true)
            {
                FormPasaje volver = new FormPasaje();
                this.Hide();
                volver.ShowDialog();
                volver = (FormPasaje)this.ActiveMdiChild;
            }

            else 
            {
                FormEncomienda volver = new FormEncomienda();
                this.Hide();
                volver.ShowDialog();
                volver = (FormEncomienda)this.ActiveMdiChild;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {  
            if (FormPasaje.cantPasajes > 0 ){
            /*FormCompra3_2 siguiente = new FormCompra3_2();
            this.Hide();
            siguiente.ShowDialog();
            siguiente = (FormCompra3_)this.ActiveMdiChild;*/

                FormPasaje.cantPasajes = (FormPasaje.cantPasajes - 1);
            }
            else if (FormPasaje.cantPasajes == 0)
            {
                FormCompra4 siguiente = new FormCompra4();
                this.Hide();
                siguiente.ShowDialog();
                siguiente = (FormCompra4)this.ActiveMdiChild;
            }
        }

        public void LlenarComboBox1()
        {
            SqlConnection conexion1 = new SqlConnection();
            conexion1.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DESCRIPCION FROM DJML.TIPO_DOCUMENTO", conexion1);
            da.Fill(ds1, "DJML.TIPO_DOCUMENTO");

            comboBox1.DataSource = ds1.Tables[0].DefaultView;
            comboBox1.ValueMember = "DESCRIPCION";
            comboBox1.SelectedItem = null;
        }
        
        
        public void LlenarComboBox2() //borrar luego de cargar bien el datagrid
        {
         /*   SqlConnection conexion1 = new SqlConnection();
            conexion1.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ( CONVERT(varchar, B.BUTA_NRO) + ' - ' + T.DESCRIPCION) AS DatosCombinados" +
                                                    "FROM DJML.BUTACA_AERO X, DJML.BUTACAS B, DJML.TIPO_BUTACA T" +
                                                    "WHERE X.BXA_BUTA_ID = B.BUTA_ID AND T.TIPO_BUTACA_ID = B.BUTA_TIPO_ID" +
                                                    "AND X.BXA_AERO_MATRICULA = 'ASQ-169'", conexion1);
            da.Fill(ds1, "DJML.BUTACA_AERO");

            comboBox2.DataSource = ds1.Tables[0].DefaultView;
            comboBox2.ValueMember = "DatosCombinados";
            comboBox2.SelectedItem = null; 
            */
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtdni.Text = "";
            txtmail.Text = "";
            txtdireccion.Text = "";
            
            txttelefono.Text = "";
            txtnombre.Text = "";
            txtapellido.Text ="";
            comboBox1.SelectedItem = null;
            //dateTimePicker1 ??? = null;
           
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtdni_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCompra3_Load()
        {

        }

    
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
         
        }

           /*nombre = "SELECT CLIE_NOMBRE FROM DJML.CLIENTES C, DJML.TIPO_DOCUMENTO T WHERE C.CLIE_TIPO_DOC = T.ID_TIPO_DOC AND T.DESCRIPCION = 'DNI' AND C.CLIE_DNI = 38055435";
            Query qry = new Query(nombre);
            qry.Ejecutar();
            txtnombre.AutoCompleteCustomSource.Add(nombre); */
        
        
    }
}


// el usuario va a poder comprar 5 pasajes como maximo a la vez. por lo que abra 4 de estar formas que las voy a copypastear una vez terminada esta



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Inicio_Aplicacion;
using System.Data.SqlClient;
using AerolineaFrba.Properties;

namespace AerolineaFrba.Compra
{
    public partial class FormCompra1 : Form
    {
        public static int viajeID;
        public static string aeroID;
    
        public FormCompra1()
        {
            InitializeComponent();
           
        }

        private void FormCompra1_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            LlenarComboBox1();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            LlenarComboBox2();
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            FormInicioFuncionalidades FormInicioFuncionalidades = new FormInicioFuncionalidades();
            this.Hide();
            FormInicioFuncionalidades.ShowDialog();
            FormInicioFuncionalidades = (FormInicioFuncionalidades)this.ActiveMdiChild;

        }

        public void LlenarComboBox1()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select CIUD_DETALLE from DJML.CIUDADES", conexion);
            da.Fill(ds, "DJML.CIUDADES");

            comboBox1.DataSource = ds.Tables[0].DefaultView;
            comboBox1.ValueMember = "CIUD_DETALLE";
            comboBox1.SelectedItem = null;
        }

         public void LlenarComboBox2()
        {
            SqlConnection conexion1= new SqlConnection();
            conexion1.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select CIUD_DETALLE from DJML.CIUDADES", conexion1);
            da.Fill(ds1, "DJML.CIUDADES");

            comboBox2.DataSource = ds1.Tables[0].DefaultView;
            comboBox2.ValueMember = "CIUD_DETALLE";
            comboBox2.SelectedItem = null;
        }
        
        
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox2.Text.Trim() != "" || comboBox2.SelectedItem != null) &&
                (comboBox1.Text.Trim() != "" || comboBox1.SelectedItem != null))
            {
                button3.Enabled = true;
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox2.Text.Trim() != "" || comboBox2.SelectedItem != null )&&
                ( comboBox1.Text.Trim() != "" || comboBox1.SelectedItem != null))
            {
                button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = null;            
            comboBox2.SelectedItem = null;

            //dataGrid.DataSource = null;
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string origen = comboBox1.Text;
            string destino = comboBox2.Text;

            string qry = "SELECT V.VIAJE_ID, S.SERV_DESCRIPCION TIPO_DE_SERVICIO, COUNT(DISTINCT X.BXA_ID) BUTACAS_LIBRES, A.AERO_KILOS_DISPONIBLES KILOS_DISPONIBLES" +
    " FROM DJML.RUTAS R, DJML.VIAJES V, DJML.SERVICIOS S, DJML.BUTACA_AERO B, DJML.AERONAVES A, DJML.BUTACA_AERO X" +
    " WHERE R.RUTA_CODIGO = V.VIAJE_RUTA_ID " +
    " AND R.RUTA_SERVICIO_ID = S.SERV_ID" +
    " AND B.BXA_AERO_MATRICULA = V.VIAJE_AERO_ID" +
    " AND A.AERO_MATRICULA = V.VIAJE_AERO_ID" +
    " AND X.BXA_AERO_MATRICULA = A.AERO_MATRICULA" +
    " AND R.RUTA_CIUDAD_DESTINO = (select CIUD_ID from djml.CIUDADES WHERE CIUD_DETALLE = '"+origen+"')" +
    " AND R.RUTA_CIUDAD_ORIGEN = (select CIUD_ID from djml.CIUDADES WHERE CIUD_DETALLE = '"+destino+"')" +
    " AND X.BXA_ESTADO = 1" +
    //" AND V.VIAJE_FECHA_SALIDA > '2017-01-01 02:00:00.000' AND V.VIAJE_FECHA_SALIDA < '2017-02-01 02:00:00.000'" +
    " GROUP BY V.VIAJE_ID, S.SERV_DESCRIPCION, A.AERO_KILOS_DISPONIBLES, V.VIAJE_FECHA_SALIDA";


            dataGridView1.DataSource = new Query(qry).ObtenerDataTable();
            //dataGridView1.Columns["VIAJE_ID"].Visible = false;  //OCULTO LA COLUMNA
           
            

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            viajeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

            FormCompra2 asd = new FormCompra2();
            this.Hide();
            asd.ShowDialog();
            asd = (FormCompra2)this.ActiveMdiChild;

            
                       
           
        }

      
    }
}

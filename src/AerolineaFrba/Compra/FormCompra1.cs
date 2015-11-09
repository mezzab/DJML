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

        private void avisar(string quePaso)
        {
            MessageBox.Show(quePaso, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            FormInicioFuncionalidades.StartPosition = FormStartPosition.CenterScreen;
          
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
            date.ResetText();
            dataGridView1.DataSource = null;
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {   bool error1 = date.Value.Date < DateTime.Now.Date; 
            bool error2 = comboBox1.SelectedValue == comboBox2.SelectedValue;
            if (error1)
                MessageBox.Show("Fecha incorrecta");
            else if (error2)
                MessageBox.Show("Las ciudades origen y destino no pueden coincidir");
            else
            {
                string origen = comboBox1.Text;
                string destino = comboBox2.Text;


                DateTime fecha_salida = date.Value.Date;
                string qry = " select v.VIAJE_ID, s.SERV_DESCRIPCION, COUNT(DISTINCT X.BXA_ID) BUTACAS_LIBRES, A.AERO_KILOS_DISPONIBLES KGS_DISPONIBLES" +
                            " from djml.VIAJES v, djml.RUTAS r, djml.TRAMOS t, djml.SERVICIOS s, DJML.BUTACA_AERO B, DJML.AERONAVES A, DJML.BUTACA_AERO X" +
                            " where v.VIAJE_RUTA_ID = r.RUTA_CODIGO" +
                            " and r.RUTA_TRAMO = t.TRAMO_ID" +
                            " and r.RUTA_SERVICIO = s.SERV_ID" +
                            " AND B.BXA_AERO_MATRICULA = v.VIAJE_AERO_ID" +
                            " AND A.AERO_MATRICULA = v.VIAJE_AERO_ID" +
                            " AND X.BXA_AERO_MATRICULA = A.AERO_MATRICULA" +
                            " AND X.BXA_ESTADO = 1" +
                            " AND t.TRAMO_CIUDAD_ORIGEN = (select CIUD_ID from djml.CIUDADES WHERE CIUD_DETALLE ='" + origen + "') " +
                            " AND t.TRAMO_CIUDAD_DESTINO= (select CIUD_ID from djml.CIUDADES WHERE CIUD_DETALLE ='" + destino + "') " +
                            " and YEAR(v.VIAJE_FECHA_SALIDA) = YEAR('" + fecha_salida + "') " +
                            " AND MONTH(v.VIAJE_FECHA_SALIDA) = MONTH('" + fecha_salida + "') " +
                            " AND DAY(v.VIAJE_FECHA_SALIDA) = DAY('" + fecha_salida + "') " +
                            " group by v.viaje_id, s.SERV_DESCRIPCION, a.AERO_KILOS_DISPONIBLES ";


                dataGridView1.DataSource = new Query(qry).ObtenerDataTable();
                //OCULTO LA COLUMNA
                dataGridView1.Columns["VIAJE_ID"].Visible = false;  
                //REDEFINO ANCHO DE LAS COLUMNAS DEL DATA GRID PARA QUE SE VEA LINDO
                DataGridViewColumn column = dataGridView1.Columns[0];
                column.Width = 95;
                DataGridViewColumn column1 = dataGridView1.Columns[1];
                column1.Width = 90;
                DataGridViewColumn column2 = dataGridView1.Columns[2];
                column2.Width = 115;
                DataGridViewColumn column3 = dataGridView1.Columns[3];
                column3.Width = 125;
                DataGridViewColumn column4 = dataGridView1.Columns[4];
                column4.Width = 135;
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            viajeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

            string sql = "select VIAJE_AERO_ID from djml.VIAJES " +
                         "where VIAJE_ID = " + viajeID ;
            Query qry = new Query(sql);
            aeroID = qry.ObtenerUnicoCampo().ToString();

            // avisar("viaje id= " + viajeID + " ... matricula= " + aeroID + " ");

            CompraPasaje asd = new CompraPasaje();
            asd.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            asd.ShowDialog();
            asd = (CompraPasaje)this.ActiveMdiChild;






            
                       
           
        }

        private void button4_Click(object sender, EventArgs e)
        {  DateTime fecha_salida = date.Value.Date;
       // MessageBox.Show(fecha_salida);
        }


      
    }
}


//TODO: DATAGRID VACIO CLICK
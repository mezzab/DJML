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

namespace AerolineaFrba.Registro_Llegada_Destino
{
    public partial class FormRegistroLlegada : Form
    {
        public FormRegistroLlegada()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarComboBoxAeronaves();
            LlenarComboBoxCiudadOrigen();
            LlenarComboBoxCiudadDestino();
            comboBoxAeronaves.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCiudadOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCiudadDestino.DropDownStyle = ComboBoxStyle.DropDownList;
         
        }

        private void cargarGrid()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;


            Query qry7 = new Query("select v.viaje_id as Codigo_Viaje, c1.ciud_detalle as Ciudad_Origen, c2.ciud_detalle as Ciudad_Destino from djml.viajes v "
            + " join djml.rutas r on v.viaje_ruta_id = r.ruta_codigo"
            + " join djml.tramos t on r.ruta_tramo = t.tramo_id "
            + " join djml.ciudades c1 on t.tramo_ciudad_origen = c1.ciud_id"
            + " join djml.ciudades c2 on t.tramo_ciudad_destino = c2.ciud_id"
            + " where v.viaje_aero_id = '" + comboBoxAeronaves.Text + "' "
            + " and c1.ciud_id = (select CIUD_ID from djml.CIUDADES WHERE CIUD_DETALLE ='" + comboBoxCiudadOrigen.Text + "')"
            + " and c2.ciud_id = (select CIUD_ID from djml.CIUDADES WHERE CIUD_DETALLE ='" + comboBoxCiudadDestino.Text + "')"
            + " and v.viaje_id not in (select rd_viaje_id from djml.registro_destino)");

            datos.DataSource = qry7.ObtenerDataTable();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAeronaves.SelectedIndex != -1 && comboBoxCiudadOrigen.SelectedIndex != -1 && comboBoxCiudadDestino.SelectedIndex != -1)
            {
                datos.Visible = true;
                cargarGrid();
            }
            else
                datos.Visible = false;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAeronaves.SelectedIndex != -1 && comboBoxCiudadOrigen.SelectedIndex != -1 && comboBoxCiudadDestino.SelectedIndex != -1)
            { 
                datos.Visible = true;
                cargarGrid();
            }
            else
                datos.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        public void LlenarComboBoxAeronaves()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select AERO_MATRICULA from DJML.AERONAVES", conexion);
            da.Fill(ds, "DJML.AERONAVES");

            comboBoxAeronaves.DataSource = ds.Tables[0].DefaultView;
            comboBoxAeronaves.ValueMember = "AERO_MATRICULA";
            comboBoxAeronaves.SelectedItem = null;
        }

        public void LlenarComboBoxCiudadOrigen()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select CIUD_DETALLE from DJML.CIUDADES", conexion);
            da.Fill(ds, "DJML.CIUDADES");

            comboBoxCiudadOrigen.DataSource = ds.Tables[0].DefaultView;
            comboBoxCiudadOrigen.ValueMember = "CIUD_DETALLE";
            comboBoxCiudadOrigen.SelectedItem = null;
        }

        public void LlenarComboBoxCiudadDestino()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select CIUD_DETALLE from DJML.CIUDADES", conexion);
            da.Fill(ds, "DJML.CIUDADES");

            comboBoxCiudadDestino.DataSource = ds.Tables[0].DefaultView;
            comboBoxCiudadDestino.ValueMember = "CIUD_DETALLE";
            comboBoxCiudadDestino.SelectedItem = null;
        }

        private void bnVolver_Click(object sender, EventArgs e)
        {
            FormInicioFuncionalidades inicioF = new FormInicioFuncionalidades();
            this.Hide();
            inicioF.ShowDialog();
            inicioF = (FormInicioFuncionalidades)this.ActiveMdiChild;
        
        }



        private void comboBoxAeronaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAeronaves.SelectedIndex != -1 && comboBoxCiudadOrigen.SelectedIndex != -1 && comboBoxCiudadDestino.SelectedIndex != -1)
            {  
                datos.Visible = true;
                cargarGrid();
            }
                else
                datos.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBoxAeronaves.SelectedIndex != -1 && comboBoxCiudadOrigen.SelectedIndex != -1 && comboBoxCiudadDestino.SelectedIndex != -1)
            {

                //HACER EL INSERT EN REGISTRO DESTINO
                int viajeId;
                viajeId = Convert.ToInt32(datos.Rows[e.RowIndex].Cells[1].Value.ToString());

                //obtener datos de ciudad Origen
                int ciudadOrigen;
                Query qry3 = new Query("SELECT CIUD_ID FROM DJML.CIUDADES WHERE CIUD_DETALLE = '" + comboBoxCiudadOrigen.Text + "'");
                ciudadOrigen = (int)qry3.ObtenerUnicoCampo();

                //obtener datos de ciudad Destino
                int ciudadDestino;
                Query qry4 = new Query("SELECT CIUD_ID FROM DJML.CIUDADES WHERE CIUD_DETALLE = '" + comboBoxCiudadOrigen.Text + "'");
                ciudadDestino = (int)qry4.ObtenerUnicoCampo();
               
                DateTime fechaViaje;   
                //obtener datos viaje
               
                Query qry5 = new Query("SELECT VIAJE_FECHA_SALIDA FROM DJML.VIAJES WHERE VIAJE_ID = '" + viajeId + "'");
                fechaViaje = (DateTime)qry5.ObtenerUnicoCampo();


                if ( fechaViaje < fechaLlegada.Value)
                {
                    //hace la insercion en la base de datos del nuevo registro generado
                    string sql1 = "INSERT INTO DJML.REGISTRO_DESTINO(RD_VIAJE_ID, RD_AERO_ID, RD_FECHA_LLEGADA, RD_CIUDAD_ORIGEN_ID, RD_CIUDAD_DESTINO_ID)"
                                    + "values (" + viajeId + " ,'" + comboBoxAeronaves.SelectedValue.ToString() + "', '" + fechaLlegada.Value.ToShortDateString() + "' , " + ciudadOrigen + ", " + ciudadDestino + " )";
                    Query qry = new Query(sql1);
                    qry.pComando = sql1;
                    qry.Ejecutar();

                    fechaLlegada.Text = "";
                    comboBoxAeronaves.Text = "";
                    comboBoxCiudadDestino.Text = "";
                    comboBoxCiudadOrigen.Text = "";
                    cargarGrid();
                    MessageBox.Show("Registro destino Generado Correctamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La fecha de llegada no puede ser anterior a la del viaje", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


 
    }
}

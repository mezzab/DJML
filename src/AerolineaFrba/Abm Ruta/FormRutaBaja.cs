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

namespace AerolineaFrba.Abm_Ruta
{
    public partial class FormRutaBaja : Form
    {
        public FormRutaBaja()
        {
            InitializeComponent();
        }

        private void FormRutaBaja_Load(object sender, EventArgs e)
        {   /*
            //comboBox_origen
            string qry_origen = "SELECT CIUD_DETALLE, CIUD_ID FROM DJML.CIUDADES ORDER BY 1";
            DataTable origen_data = new Query(qry_origen).ObtenerDataTable();

            //comboBox_destino
            string qry_destino = "SELECT CIUD_DETALLE, CIUD_ID FROM DJML.CIUDADES ORDER BY 1";
            DataTable destino_data = new Query(qry_destino).ObtenerDataTable();

            //comboBox_servicio
            string qry_servicio = "SELECT SERV_DESCRIPCION, SERV_ID FROM DJML.SERVICIOS ORDER BY 1";
            DataTable servicio_data = new Query(qry_servicio).ObtenerDataTable();
            */
            LlenarCombo_Origen();
            comboBox_origen.DropDownStyle = ComboBoxStyle.DropDownList;
            LlenarCombo_Destino();
            comboBox_destino.DropDownStyle = ComboBoxStyle.DropDownList;
            LlenarCombo_Servicio();
            comboBox_servicio.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public void LlenarCombo_Origen()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT CIUD_DETALLE FROM DJML.CIUDADES ORDER BY 1", conexion);
            da.Fill(ds, "DJML.CIUDADES");

            comboBox_origen.DataSource = ds.Tables[0].DefaultView;
            comboBox_origen.ValueMember = "CIUD_DETALLE";
            comboBox_origen.SelectedItem = null;
        }

        public void LlenarCombo_Destino()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT CIUD_DETALLE FROM DJML.CIUDADES ORDER BY 1", conexion);
            da.Fill(ds, "DJML.CIUDADES");

            comboBox_destino.DataSource = ds.Tables[0].DefaultView;
            comboBox_destino.ValueMember = "CIUD_DETALLE";
            comboBox_destino.SelectedItem = null;
        }


        public void LlenarCombo_Servicio()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT SERV_DESCRIPCION FROM DJML.SERVICIOS ORDER BY 1", conexion);
            da.Fill(ds, "DJML.SERVICIOS");

            comboBox_servicio.DataSource = ds.Tables[0].DefaultView;
            comboBox_servicio.ValueMember = "SERV_DESCRIPCION";
            comboBox_servicio.SelectedItem = null;
        }



        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string RutaCodigo = dataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();

            darBajaRuta(RutaCodigo);

            MessageBox.Show("Se ha dado de baja la ruta de codigo " + RutaCodigo + "correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            button_volver_Click(sender, e);

        }

        private void darBajaRuta(string codigo)
        {
            
            string qry =   "update DJML.RUTAS" +
                          " set RUTA_IS_ACTIVE = 0 " +
                          " where RUTA_CODIGO = " + codigo ;
                          

            new Query(qry).Ejecutar();

        }

        private void button_buscar_Click(object sender, EventArgs e)
        {

            string origen = comboBox_origen.Text;
            string destino = comboBox_destino.Text;
            string servicio = comboBox_servicio.Text;

            string qry = "select RUTA_CODIGO ruta_codigo, t.TRAMO_CIUDAD_ORIGEN origen, t.TRAMO_CIUDAD_DESTINO destino, r.RUTA_PRECIO_BASE_KILO precio_base_kilo, r.RUTA_PRECIO_BASE_PASAJE precio_base_pasaje  from djml.RUTAS r, djml.TRAMOS t, djml.SERVICIOS s" +
                        " where r.RUTA_TRAMO = t.TRAMO_ID" +
                        " and r.RUTA_SERVICIO = s.SERV_ID" +
                        " and t.TRAMO_CIUDAD_ORIGEN =  (select CIUD_ID from djml.CIUDADES WHERE CIUD_DETALLE ='" + origen + "')" +
                        " and t.TRAMO_CIUDAD_DESTINO = (select CIUD_ID from djml.CIUDADES WHERE CIUD_DETALLE ='" + destino + "')" +
                        " and s.SERV_DESCRIPCION = '" + servicio + "'";


            dataGrid.DataSource = new Query(qry).ObtenerDataTable();
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            FormRuta volver = new FormRuta();
            volver.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            volver.ShowDialog();
            volver = (FormRuta)this.ActiveMdiChild;
        }
    }
}

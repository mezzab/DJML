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
    public partial class FormRutaModificacion1 : Form
    {

        public static string origen;
        public static string destino;
        public static string servicio;
        public static string precio_encomienda;
        public static string precio_pasaje;
        public static string ruta_id;


        public FormRutaModificacion1()
        {
            InitializeComponent();
        }

        private void FormRutaModificacion1_Load(object sender, EventArgs e)
        {
            llenar_combo_origen();
            llenar_combo_destino();
            llenar_combo_servicio(); 
        }

        private void llenar_combo_origen()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds_ciudades = new DataSet();
            SqlDataAdapter da_ciudades = new SqlDataAdapter("SELECT CIUD_DETALLE, CIUD_ID FROM DJML.CIUDADES ORDER BY 1", conexion);
            da_ciudades.Fill(ds_ciudades, "DJML.CIUDADES");

            comboBox_origen.DataSource = ds_ciudades.Tables[0].DefaultView;
            comboBox_origen.DisplayMember = "CIUD_DETALLE";
            comboBox_origen.ValueMember = "CIUD_ID";
            comboBox_origen.SelectedItem = null;
            comboBox_origen.Text = null;
            comboBox_origen.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void llenar_combo_destino()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds_ciudades = new DataSet();
            SqlDataAdapter da_ciudades = new SqlDataAdapter("SELECT CIUD_DETALLE, CIUD_ID FROM DJML.CIUDADES ORDER BY 1", conexion);
            da_ciudades.Fill(ds_ciudades, "DJML.CIUDADES");

            comboBox_destino.DataSource = ds_ciudades.Tables[0].DefaultView;
            comboBox_destino.DisplayMember = "CIUD_DETALLE";
            comboBox_destino.ValueMember = "CIUD_ID";
            comboBox_destino.SelectedItem = null;
            comboBox_destino.Text = null;
            comboBox_destino.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void llenar_combo_servicio()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds_servicios = new DataSet();
            SqlDataAdapter da_servicios = new SqlDataAdapter("SELECT SERV_DESCRIPCION, SERV_ID FROM DJML.SERVICIOS ORDER BY 1", conexion);
            da_servicios.Fill(ds_servicios, "DJML.SERVICIOS");

            comboBox_servicio.DataSource = ds_servicios.Tables[0].DefaultView;
            comboBox_servicio.DisplayMember = "SERV_DESCRIPCION";
            comboBox_servicio.ValueMember = "SERV_ID";
            comboBox_servicio.SelectedItem = null;
            comboBox_servicio.Text = null;
            comboBox_servicio.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            FormRuta ruta = new FormRuta();
            this.Hide();
            ruta.ShowDialog();
            ruta = (FormRuta)this.ActiveMdiChild;
        }


        private void button_buscar_Click(object sender, EventArgs e)
        {
            origen = comboBox_origen.Text;
            destino = comboBox_destino.Text;
            servicio = comboBox_servicio.Text;

            string qry = "select RUTA_CODIGO ruta_codigo, co.CIUD_DETALLE origen, cd.CIUD_DETALLE destino, s.SERV_DESCRIPCION servicio, r.RUTA_PRECIO_BASE_KILO precio_base_kilo, r.RUTA_PRECIO_BASE_PASAJE precio_base_pasaje" +
                        " from djml.RUTAS r" +
                        " join djml.TRAMOS t on r.RUTA_TRAMO = t.TRAMO_ID" +
                        " join djml.CIUDADES co on co.CIUD_ID = t.TRAMO_CIUDAD_ORIGEN" +
                        " join djml.CIUDADES cd on cd.CIUD_ID = t.TRAMO_CIUDAD_DESTINO" +
                        " join djml.SERVICIOS s on r.RUTA_SERVICIO = s.SERV_ID" +
                        " where co.CIUD_DETALLE like '%" + origen + "'" +
                        " and cd.CIUD_DETALLE like '%" + destino + "'" +
                        " and s.SERV_DESCRIPCION like '%" + servicio + "'";

            var result = new Query(qry).ObtenerDataTable();
            if (result.Rows.Count != 0 && origen != string.Empty && destino != string.Empty && servicio != string.Empty)
            {
                dataGrid.DataSource = result;
                button_siguiente.Enabled = true;
                ruta_id = result.Rows[0][0].ToString();
                precio_encomienda = result.Rows[0][4].ToString();
                precio_pasaje = result.Rows[0][5].ToString();
            }
            else {
                MessageBox.Show("Ninguna ruta coincide con su descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void button_siguiente_Click(object sender, EventArgs e)
        {
            FormRutaModificacion2 ruta = new FormRutaModificacion2();
            this.Hide();
            ruta.ShowDialog();
            ruta = (FormRutaModificacion2)this.ActiveMdiChild;
        }
    }
}

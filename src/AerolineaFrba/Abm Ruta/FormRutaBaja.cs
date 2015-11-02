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
        {
            llenar_combo_origen();
            llenar_combo_destino();
            llenar_combo_servicio();
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            FormRuta ruta = new FormRuta();
            this.Hide();
            ruta.ShowDialog();
            ruta = (FormRuta)this.ActiveMdiChild;
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
    }
}

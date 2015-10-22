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
    public partial class FormRutaAlta : Form
    {
        public FormRutaAlta()
        {
            InitializeComponent();
        }

        private void FormRutaAlta_Load(object sender, EventArgs e)
        {
            llenar_combo_origen();
            llenar_combo_destino();
            llenar_combo_servicio();            
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {          
            string ciudad_origen_id = comboBox_origen.Text.Trim();  //ToDo: pasar a id
            string ciudad_destino_id = comboBox_destino.Text.Trim();//ToDo: pasar a id 
            string servicio_id = comboBox_servicio.Text.Trim();     //ToDo: pasar a id
            string precio_pasaje = text_precio_pasaje.Text.Trim();
            string precio_encomienda = text_precio_encomienda.Text.Trim();

            string error_message = "";

            //Validate: No vacios en el formulario
            if (ciudad_origen_id == string.Empty || ciudad_destino_id == string.Empty || servicio_id == string.Empty || precio_pasaje == string.Empty || precio_encomienda == string.Empty)
            {
                error_message += "Los campos del formulario no pueden estar vacios." + Environment.NewLine + Environment.NewLine;
            }
            //Validate: precios sean numeros
            float output1;
            double output2;
            bool a = float.TryParse(precio_pasaje, out output1);
            bool b = double.TryParse(precio_encomienda, out output2);
            if (true)
            {
                error_message += "Los campos Precio deben ser numericos." + Environment.NewLine + Environment.NewLine;
            }
            //Validate: origen y destino diferentes
            if (ciudad_origen_id != string.Empty && ciudad_destino_id != string.Empty && ciudad_origen_id == ciudad_destino_id)
            {
                error_message += "Los campos Ciudad Origen y Ciudad Destino deben ser diferentes." + Environment.NewLine + Environment.NewLine;
            }
            //Validate: No guardar un ruta identica a otra
            if (false)
            {
                error_message += "Ya exite una ruta identica a la ingresada." ;
            }

            if (error_message != string.Empty) 
            {
                label_message.Text = "¡RUTA NO CREADA!" + Environment.NewLine + Environment.NewLine + error_message;
                label_message.Visible = true;
            } else
            {
                label_message.Text = "Sos crack!";
                label_message.Visible = true;
            }
            //SqlConnection conexion = new SqlConnection();
            //conexion.ConnectionString = Settings.Default.CadenaDeConexion;
            /*string qry_validate = "SELECT RUTA_CODIGO FROM DJML.RUTAS" +
                                   "WHERE RUTA_CIUDAD_ORIGEN = " + ciudad_origen_id +
                                   ", RUTA_CIUDAD_DESTINO = " + ciudad_destino_id +
                                   ", RUTA_SERVICIO_ID = " + servicio_id;
            DataTable validate_data = new Query(qry_validate).ObtenerDataTable();

            // if (validate_data not empty) {
            

            string insert_query = "INSERT INTO DJML.RUTAS (RUTA_CODIGO_REAL, RUTA_CIUDAD_ORIGEN, RUTA_CIUDAD_DESTINO, RUTA_SERVICIO_ID, RUTA_PRECIO_BASE_PASAJE, RUTA_PRECIO_BASE_KILO)" +
                                    "VALUES (123456789, " + ciudad_origen_id + ", " + ciudad_destino_id + ", " + servicio_id + ", " + precio_pasaje + ", " + precio_encomienda + ")";
            //Success message (?)
            //"Limpiar" comboboxes y textboxes

            //} else {
            label_message.Text = "Ruta no creada, existe una identica";
            label_message.Visible = true;
            //}*/
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
            comboBox_origen.ValueMember = "CIUD_DETALLE";
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
            comboBox_destino.ValueMember = "CIUD_DETALLE";
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
            comboBox_servicio.ValueMember = "SERV_DESCRIPCION";
            comboBox_servicio.SelectedItem = null;
            comboBox_servicio.Text = null;
            comboBox_servicio.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        
    }
}

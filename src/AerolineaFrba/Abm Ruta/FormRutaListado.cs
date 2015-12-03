using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Properties;
using System.Data.SqlClient;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class FormRutaListado : Form
    {
        public FormRutaListado()
        {
            InitializeComponent();
        }

        private void FormRutaListado_Load(object sender, EventArgs e)
        {
            cargarGrid();
            LlenarCombo_Servicio();
            comboBox_servicio.DropDownStyle = ComboBoxStyle.DropDownList;
         
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            FormRuta ruta = new FormRuta();
            this.Hide();
            ruta.ShowDialog();
            ruta = (FormRuta)this.ActiveMdiChild;
        }

        private void cargarGrid()
        {
            Query qry2 = new Query("SELECT [Ciudad Origen], [Ciudad Destino], [Servicio], [Pasaje], [Kilo Encomienda] FROM [DJML].v_rutas ORDER BY 1");
            datos.DataSource = qry2.ObtenerDataTable();

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

        private void button_buscar_Click(object sender, EventArgs e)
        {
            string origen = textOrigen.Text;
            string destino = textDestino.Text;
            string servicio = comboBox_servicio.Text;

            string condicionOrigen = "[Ciudad Origen] like '%" + origen + "%'";
            string condicionDestino = "[Ciudad Destino] like '%" + destino + "%'";
            string condicionServicio = "[Servicio] = '" + servicio + "'";

            string[] filtros = new string[3] { origen, destino, servicio };
            string[] condiciones = new string[3] { condicionOrigen, condicionDestino, condicionServicio };

            int c = 0;
            string where = " ";

            for (int i = 0; i <= 2; i++)
            {
                if (c > 0) {
                    if (filtros[i] != string.Empty) {
                        where = where + " AND " + condiciones[i];
                        c++;
                    }
                }
                else {
                    if (filtros[i] != string.Empty) {
                        where = where + "WHERE " + condiciones[i];
                        c++;
                    }
                }
            }

            string qry = "SELECT [Ciudad Origen], [Ciudad Destino], [Servicio], [Pasaje], [Kilo Encomienda] FROM [DJML].v_rutas" + where + " ORDER BY 1";
            var result = new Query(qry).ObtenerDataTable();
            
            datos.DataSource = result;

            if (result.Rows.Count == 0) {
                MessageBox.Show("Ninguna ruta coincide con su descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            comboBox_servicio.SelectedItem = null;
            textOrigen.Text = "";
            textDestino.Text = "";
            cargarGrid();
        }


    }
}

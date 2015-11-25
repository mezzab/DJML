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
        public ConsultarMillas()
        {
            InitializeComponent();
        }

        private void ConsultarMillas_Load(object sender, EventArgs e)
        {
            LlenarComboBoxTipoDocumento();
            tipoDeDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
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
            dataGridConsultaMillas.DataSource = null;
        }

        private void botonConsultar_Click(object sender, EventArgs e)
        {
            String dni = this.textBoxDNI.Text;
            if (dni != "")
            {/*
                DataTable tablaClientes = SqlConnector.obtenerTablaSegunConsultaString(@"select ID as Id 
                from AERO.clientes where BAJA = 0 AND DNI = " + dni);
                if (tablaClientes.Rows.Count > 0)
                {
                    List<string> lista = new List<string>();
                    lista.Add("@dni");
                    DataTable resultado = SqlConnector.obtenerTablaSegunProcedure("AERO.consultarMillas", lista, dni);
                    dataGridConsultaMillas.DataSource = resultado;
                    Int32 millas = 0;
                    foreach (DataRow row in resultado.Rows)
                    {
                        millas += Int32.Parse(row.ItemArray[2].ToString());
                    }
                    textBoxTotal.Text = millas.ToString();
                }
                else
                {
                    MessageBox.Show("No se encuentra el cliente. Por favor ingrese nuevamente el DNI");
                }*/
            }
            else
                MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FormInicioFuncionalidades FormInicioFuncionalidades = new FormInicioFuncionalidades();
            this.Hide();
            FormInicioFuncionalidades.ShowDialog();
            FormInicioFuncionalidades = (FormInicioFuncionalidades)this.ActiveMdiChild;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

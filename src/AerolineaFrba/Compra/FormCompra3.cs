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

namespace AerolineaFrba.Compra
{
    public partial class FormCompra3 : Form
    {
        public FormCompra3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Query qry10 = new Query("SELECT VIAJE_AERO_ID FROM DJML.VIAJES WHERE VIAJE_ID =" + "'" + FormCompra1.viajeID + "'");
            string aeroID = (string)qry10.ObtenerUnicoCampo();

            //    MessageBox.Show("El numero de matricula de la aeronave que realizara el viaje es:" + aeroID , "Consulta de matricula", MessageBoxButtons.OK, MessageBoxIcon.Information);



            string qryButacas = "SELECT B.BUTA_NRO NUMERO, T.DESCRIPCION " +
                                "FROM DJML.BUTACA_AERO X, DJML.BUTACAS B, DJML.TIPO_BUTACA T " +
                                "WHERE X.BXA_BUTA_ID = B.BUTA_ID " +
                                "AND T.TIPO_BUTACA_ID = B.BUTA_TIPO_ID " +
                                "AND X.BXA_AERO_MATRICULA = '" + aeroID + "'";

            //MessageBox.Show(qryButacas);

            dataGridView1.DataSource = new Query(qryButacas).ObtenerDataTable();
        }

        private void Volver_Click(object sender, EventArgs e)
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

        private void Siguiente_Click(object sender, EventArgs e)
        {
            if (FormPasaje.cantPasajes > 0)
            {
                /*FormCompra3_2 siguiente = new FormCompra3_2();
                this.Hide();
                siguiente.ShowDialog();
                siguiente = (FormCompra3_)this.ActiveMdiChild;

                FormPasaje.cantPasajes = (FormPasaje.cantPasajes - 1);*/

                FormFormaDePago siguiente = new FormFormaDePago();
                this.Hide();
                siguiente.ShowDialog();
                siguiente = (FormFormaDePago)this.ActiveMdiChild;

            }
            else if (FormPasaje.cantPasajes == 0)
            {
                FormFormaDePago siguiente = new FormFormaDePago();
                this.Hide();
                siguiente.ShowDialog();
                siguiente = (FormFormaDePago)this.ActiveMdiChild;
            }
        }

  
        private void BuscarPorCliente_Click(object sender, EventArgs e)
        {
            

        }

        private void FormCompra3_Load(object sender, EventArgs e)
        {
           // Siguiente.Enabled = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            tipoDeDocumento.Items.Clear();
            numeroDeDocumento.Text = "";

        }

        private void LimpiarCliente_Click(object sender, EventArgs e)
        {
            apellido.Text = "";
            nombre.Text = "";
            direccion.Text = "";
            mail.Text = "";
            telefono.Text = "";
            numero.Text = "";
            fechaNacimiento.ResetText();
        }

        private void tipoDeDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

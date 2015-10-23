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
    public partial class FormEfectivo : Form
    {
        public FormEfectivo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormFormaDePago volver = new FormFormaDePago();
            this.Hide();
            volver.ShowDialog();
            volver = (FormFormaDePago)this.ActiveMdiChild;
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

        private void FormEfectivo_Load(object sender, EventArgs e)
        {
            Comprar.Enabled = false;
            LlenarComboBoxTipoDocumento();
            tipoDeDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void tipoDeDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LimpiarTodo_Click(object sender, EventArgs e)
        {
            tipoDeDocumento.Items.Clear();

        }
    }
}

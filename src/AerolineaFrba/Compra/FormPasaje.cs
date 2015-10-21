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
    public partial class FormPasaje : Form
    {
        public FormPasaje()
        {
            InitializeComponent();
        }

        private void FormCompra1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            LlenarComboBox1();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
         
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


        private void button2_Click(object sender, EventArgs e)
        {
            FormCompra2 m = new FormCompra2();
            this.Hide();
            m.ShowDialog();
            m = (FormCompra2)this.ActiveMdiChild;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Text.Trim() != "" || comboBox1.SelectedItem != null))
            {
                button1.Enabled = true;
            }
             FormCompra3 m = new FormCompra3();
            this.Hide();
            m.ShowDialog();
            m = (FormCompra3)this.ActiveMdiChild;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

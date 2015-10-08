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


namespace AerolineaFrba.Abm_Rol
{
    public partial class FormRolConsulta : Form
    {
        public FormRolConsulta()
        {
            InitializeComponent();
        }

        private void FormRolConsulta_Load(object sender, EventArgs e)
        {
            bnBuscar.Enabled = false;
            LlenarComboBox();
            comboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void LlenarComboBox()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select ROL_DESCRIPCION from DJML.ROLES where ROL_ACTIVO = 1", conexion);
            da.Fill(ds, "DJML.ROLES");

            comboBoxRol.DataSource = ds.Tables[0].DefaultView;
            comboBoxRol.ValueMember = "ROL_DESCRIPCION";
            comboBoxRol.SelectedItem = null;
        }

        private void bnBuscar_Click(object sender, EventArgs e)
        {
            string rol = comboBoxRol.Text;
            string qry = " SELECT DISTINCT f.DESCRIPCION Funcionalidad " +
                            " FROM DJML.ROL_FUNCIONALIDAD rf, DJML.ROLES r, DJML.FUNCIONALIDAD f " +
                            " where rf.RXF_FUNC_ID = f.FUNC_ID " +
                            " and rf.RXF_ROL_ID = r.ROL_ID" +
                            " and r.ROL_DESCRIPCION = '" + rol + "' " +
                            " and rf.RXF_HABILITADO = 1 " +
                            " order by f.DESCRIPCION";

            dataGrid.DataSource = new Query(qry).ObtenerDataTable();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            comboBoxRol.SelectedItem = null;
            dataGrid.DataSource = null;
            bnBuscar.Enabled = false;
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxRol.Text.Trim() != "" || comboBoxRol.SelectedItem != null)
            {
                bnBuscar.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRol rol = new FormRol();
            this.Hide();
            rol.ShowDialog();
            rol = (FormRol)this.ActiveMdiChild;


        }
    }
}

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

namespace AerolineaFrba.Abm_Rol
{
    public partial class FormRolBaja : Form
    {
        public FormRolBaja()
        {
            InitializeComponent();
        }

        private void LlenarComboBox()
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

        private void FormRolBaja_Load(object sender, EventArgs e)
        {
            LlenarComboBox();
            comboBoxRol.Text = null;
            comboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void bnAceptar_Click(object sender, EventArgs e)
        {
            if (comboBoxRol.Text != "")
            {
                //DAR DE BAJA UN ROL
                string detalle = comboBoxRol.Text.ToString();
                string qry = " update DJML.ROLES " +
                                " set ROL_Activo = 0  " +
                                " where ROL_DESCRIPCION = '" + detalle + "'";
                new Query(qry).Ejecutar();

                // se deshabilita el rol de los usuarios que tenian asignado el mismo
                string bajaRol = "   update u " +
                                 "   set u.usua_habilitado = 0" +
                                 "   from DJML.USUARIOS u, DJML.ROLES r" +
                                 "   where r.ROL_ID = u.USUA_ROL_ID" +
                                 "   and r.ROL_DESCRIPCION = '" + detalle + "'";
                new Query(bajaRol).Ejecutar();

                MessageBox.Show("Rol inhabilitado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Visible = false;

                FormRol rol = new FormRol();
                this.Hide();
                rol.ShowDialog();
                rol = (FormRol)this.ActiveMdiChild;


            }
            else
            {
                //MESAJE DE ERROR
                MessageBox.Show("Seleccione un Rol", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRol rol = new FormRol();
            this.Hide();
            rol.ShowDialog();
            rol = (FormRol)this.ActiveMdiChild;
        }

      
    }
}

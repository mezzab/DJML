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
    public partial class FormRolAlta : Form
    {
        //crea una instancia de conexion a la base de datos 
       SqlConnection conexion = new SqlConnection();
        

        public FormRolAlta()
        {
            InitializeComponent();
        }

        private void FormRolAlta_Load(object sender, EventArgs e)
        {
            CargarFuncionalidadesEnLista();
            bnAceptar.Enabled = false;
        }
        
        //CARGAR FUNCIONALIDADES EN LA LISTA
        private void CargarFuncionalidadesEnLista()
        {
            string sql = "select DESCRIPCION, FUNC_ID from DJML.FUNCIONALIDAD";
            Query qry = new Query(sql);
            List<KeyValuePair<string, int>> datos = (from x in qry.ObtenerDataTable().AsEnumerable()
                                                     select new
                                                     KeyValuePair<string, int>(x["DESCRIPCION"].ToString(), Convert.ToInt32(x["FUNC_ID"]))).ToList();

            Funcionalidades.DataSource = datos;
            Funcionalidades.DisplayMember = "Key";
            Funcionalidades.ValueMember = "Value";
        }
        

        //ACEPTAR::  INSERTA LOS DATOS EN LA BASE
        private void button1_Click(object sender, EventArgs e)
        {
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            if (txtRol.Text.Trim() != "")
            {
                //CONSULTA SI YA EXISTE LA DESCRIPCION DEL ROL
                string sql1 = "SELECT COUNT(1) FROM DJML.ROLES where ROL_DESCRIPCION = '" + txtRol.Text + "'";
                Query qry = new Query(sql1);
                qry.pComando = sql1;
                int existeRol = (int)qry.ObtenerUnicoCampo();

                if (existeRol.Equals(1))
                {
                    //MUESTRA ERROR - DESCRIPCION EXISTENTE 
                    txtRol.Text = null;
                    MessageBox.Show("Nombre de rol existente - Ingresar nuevo nombre"
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //INSERTA NUEVO ROL 
                    string sql2 = "INSERT INTO DJML.ROLES(ROL_DESCRIPCION, ROL_ACTIVO) VALUES ('" + txtRol.Text + "', 1)";
                    qry.pComando = sql2;
                    qry.Ejecutar();

                    //CONSULTA ID DE ROL INGRESADO
                    string consulta = "SELECT ROL_ID FROM DJML.ROLES where ROL_DESCRIPCION= '" + txtRol.Text + "'";
                    Query qr = new Query(consulta);
                    qr.pComando = consulta;
                    int idRol = (int)qr.ObtenerUnicoCampo();

                    foreach (var checkedItem in Funcionalidades.CheckedItems)
                    {   
                        //INSERTA LAS FUNCIONALIDADES CORRESPONDIENTES
                        string sql3 = "insert into DJML.ROL_FUNCIONALIDAD (RXF_ROL_ID, RXF_FUNC_ID, RXF_ESTADO) " +
                                     "select " + idRol + ",FUNC_ID, 1 ESTADO " +
                                     "from DJML.FUNCIONALIDAD where DESCRIPCION = '" + checkedItem.ToString().Replace('[', ' ').Substring(1, checkedItem.ToString().IndexOf(',') - 1).TrimStart() + "'";

                        Query qry3 = new Query(sql3);
                        qry3.Ejecutar();
                    }

                    MessageBox.Show("Rol dado de alta exitosamente!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;

                    ///VOLVER A ABM ROL                  
                    FormRol rol = new FormRol();
                    this.Hide();
                    rol.ShowDialog();
                    rol = (FormRol)this.ActiveMdiChild;
     
                }
            }
        }
        
        private void txtRol_TextChanged(object sender, EventArgs e)
        {
            if (txtRol.Text.Trim() != "")
            {
                CargarFuncionalidadesEnLista();
                bnAceptar.Enabled = true;
            }
        }

        private void Funcionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CUANDO SE TILDA ALGUN OBJETO SE HABILITA EL BOTON
            if (Funcionalidades.CheckedItems.Count > 0)
                bnAceptar.Enabled = true;
            else
                bnAceptar.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            txtRol.Clear();
            {
                foreach (int i in Funcionalidades.CheckedIndices)
                {
                    Funcionalidades.SetItemCheckState(i, CheckState.Unchecked);
                }
                bnAceptar.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormRol rol = new FormRol();
            this.Hide();
            rol.ShowDialog();
            rol = (FormRol)this.ActiveMdiChild;


        }

        private void txtRol_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

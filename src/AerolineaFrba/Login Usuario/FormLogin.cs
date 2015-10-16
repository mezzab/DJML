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

namespace AerolineaFrba.Login_Usuario
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        
        public int loginInvalido;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bnAceptar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            if (!faltanDatos())
            //CONSULTA POR USUARIO/CONTRASEÑA DISTINTO VACIO
            {   
               /* //VALIDA USUARIO HABILITADO Y SI EXISTE
                if ((usuarioHabilitado) && existeUsuario(string txtUsu))
                {
                    string sql_usua = "SELECT USUA_USERNAME FROM DJML.USUARIOS WHERE USUA_USERNAME = '" + txtUsu.Text + "'";
                    Query qry = new Query(sql_usua);
                    qry.Ejecutar();
                    string sql_passw = "SELECT USUA_PASSWORD FROM DJML.USUARIOS WHERE USUA_PASSWORD = '" + txtPassw.Text + "'";
                    Query qry2 = new Query(sql_passw);
                    qry2.Ejecutar();

                }
                */

            }
            else
            {

            }
        }
        
        //Valida la falta de campos, primero por ambos vacio, luego individualmente
        private bool faltanDatos()
        {
            if (txtPassw.Text.Length.Equals(0) && txtUsu.Text.Length.Equals(0))
            {
                MessageBox.Show("Complete los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtUsu.Focus();
                txtPassw.Text = null;
                txtUsu.Text = null;
                return true;
            }

            if (txtPassw.Text.Length.Equals(0))
            {
                MessageBox.Show("Complete password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassw.Focus();
                return true;
            }

            if (txtUsu.Text.Length.Equals(0))
            {
                MessageBox.Show("Complete usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsu.Focus();
                return true;
            }
            
            return false;

        }

        private bool existeUsuario(string txtUsu)
        {
            return ((int)new Query("SELECT COUNT(1) FROM DJML.USUARIOS WHERE USUA_USERNAME ='" + txtUsu + "'").ObtenerUnicoCampo() ==1);
        }
        private void label2_Click(object sender, EventArgs e)
        {
        
        }

        private void bnSalir_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.ShowDialog();
            login = (Form1)this.ActiveMdiChild;
        }
    }
}

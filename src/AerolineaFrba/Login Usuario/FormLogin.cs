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
using System.Security.Cryptography;
using AerolineaFrba.Properties;
using AerolineaFrba.Abm_Rol;
using AerolineaFrba.Inicio_Aplicacion;


namespace AerolineaFrba.Login_Usuario
{
    public partial class FormLogin : Form
    {
        
        SqlConnection conexion = new SqlConnection();
        private int idUsuario;

        public FormLogin()
        {
            InitializeComponent();
        }


        public int validar;
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
            return ((int)new Query("SELECT COUNT(1) FROM DJML.USUARIOS WHERE USUA_USERNAME ='" + txtUsu + "'").ObtenerUnicoCampo() == 1);
        }
        
        private bool usuarioHabilitado()
        {
            return ((int)new Query("SELECT COUNT(1) FROM DJML.USUARIOS WHERE USUA_USERNAME = '" + txtUsu.Text + "' AND USUA_HABILITADO = 1").ObtenerUnicoCampo() == 1);
        }
        
        private void validaUsuario()
        {
            validar = (int)new Query("SELECT count(1) FROM DJML.USUARIOS WHERE USUA_USERNAME ='" + txtUsu.Text + "'" +
                        " AND USUA_PASSWORD ='" + getSha256(txtPassw.Text) + "'").ObtenerUnicoCampo();
        }
        
        public string getSha256(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] result;
            SHA256 shaM = new SHA256Managed();
            result = shaM.ComputeHash(inputBytes);
            return BitConverter.ToString(result);
        }

        public void intento()
        {
            string consulta = ("UPDATE DJML.USUARIOS SET USUA_USERNAME = '" + txtUsu.Text + "', USUA_PASSWORD = '" + getSha256(txtPassw.Text) + "', USUA_LOGIN_FALLIDOS = 0 WHERE USUA_ID =  " + txtUsu.Text);
            Query qr = new Query(consulta);
            qr.pComando = consulta;
            int idUsuario = (int)qr.ObtenerUnicoCampo();

        }

        private void bnAceptar_Click_Login(object sender, EventArgs e)
        {

            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            if (!faltanDatos())
            //CONSULTA POR USUARIO/CONTRASEÑA DISTINTO VACIO
            {   
               //VALIDA USUARIO HABILITADO Y SI EXISTE
                if ((usuarioHabilitado()) && existeUsuario(txtUsu.Text))
                {

                    string inicia = ("SELECT USUA_ID FROM DJML.USUARIOS WHERE USUA_USERNAME = '" + txtUsu.Text + "' AND USUA_PASSWORD = '" + getSha256(txtPassw.Text) + "'");
                    Query qr1 = new Query(inicia);
                    qr1.pComando = inicia;
                    object validaUsuario = qr1.ObtenerUnicoCampo();

                    if (validaUsuario != null )
                    {

                        MessageBox.Show("Ha iniciado sesion con exito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                        FormInicioFuncionalidades func = new FormInicioFuncionalidades();
                        this.Hide();
                        func.ShowDialog();
                        func = (FormInicioFuncionalidades)this.ActiveMdiChild;
                    }
                    if (validaUsuario == null)
                    {

                        MessageBox.Show("La contraseña es incorrecta. BLA BLA BLA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // NO SE SI TENDRSA QUE SUMARLE UN INTENTO O ALGO ASI...
                    }



               }

                else
                {
                    intento();
                    MessageBox.Show(" Verifique habilitacion o habilitacion del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }
        
        private void label2_Click(object sender, EventArgs e)
        {
        
        }

        private void bnSalir_Click(object sender, EventArgs e)
        {
            FormInicioFuncionalidades inicioF = new FormInicioFuncionalidades();
            this.Hide();
            inicioF.ShowDialog();
            inicioF = (FormInicioFuncionalidades)this.ActiveMdiChild;
        }

        private void txtPassw_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

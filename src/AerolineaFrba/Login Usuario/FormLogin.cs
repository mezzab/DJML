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
        public FormLogin()
        {
            InitializeComponent();
        }


        public int validar;
        public int loginInvalido;
        public int idUsuario;
    
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Largo maximo usuario 8 caracteres
            txtUsu.MaxLength = 8;
            // Alinea a izquierda el input del usuario
            txtPassw.TextAlign = HorizontalAlignment.Left;

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

        //Valida que el tipo de dato de Usuario sea valido (numerico)
        private bool datosValidos(string txtUsu)
        {
            try
            {
                Int32.Parse(txtUsu);
              //  MessageBox.Show("Solo numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            catch
            {
                MessageBox.Show("Usuario incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        
        //Valida la existencia del Usuario
        private bool existeUsuario(string txtUsu)
        {
            return ((int)new Query("SELECT COUNT(1) FROM DJML.USUARIOS WHERE USUA_USERNAME ='" + txtUsu + "'").ObtenerUnicoCampo() == 1);
        }
        
        //Valida la habilitacion del Usuario
        private bool usuarioHabilitado(string txtUsu)
        {
            return ((int)new Query("SELECT COUNT(1) FROM DJML.USUARIOS WHERE USUA_USERNAME = '"+ txtUsu + "' AND USUA_HABILITADO = 1").ObtenerUnicoCampo() == 1);
        }
        //Devuelve 1 si usuario y contraseña coinciden 
        private void validaUsuario()
        {
            validar = (int)new Query("SELECT count(1) FROM DJML.USUARIOS WHERE USUA_USERNAME ='" + txtUsu.Text + "'" +
                        " AND USUA_PASSWORD ='" + getSha256(txtPassw.Text) + "'").ObtenerUnicoCampo();
        }
        
        //Definida la funcion getSha256 para poder convertir el UsuTxt a Sha256 al ser invocada
        public string getSha256(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] result;
            SHA256 shaM = new SHA256Managed();
            result = shaM.ComputeHash(inputBytes);
            return BitConverter.ToString(result);
        }


        private void bnAceptar_Click_Login(object sender, EventArgs e)
        {
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            //CONSULTA POR USUARIO/CONTRASEÑA DISTINTO VACIO
            if (!faltanDatos() && datosValidos(txtUsu.Text))
            {
                //VALIDA USUARIO HABILITADO, SI EXISTE Y EL TIPO DE DATO DE USUARIO SE CORRECTO
                if ((usuarioHabilitado(txtUsu.Text)) && existeUsuario(txtUsu.Text) && datosValidos(txtUsu.Text))
                {

                    string inicia = ("SELECT USUA_ID FROM DJML.USUARIOS WHERE USUA_USERNAME = '" + txtUsu.Text + "' AND USUA_PASSWORD = '" + getSha256(txtPassw.Text) + "'");
                    Query qr1 = new Query(inicia);
                    qr1.pComando = inicia;
                    object validaUsuario = qr1.ObtenerUnicoCampo();

                    if (validaUsuario != null)
                    {
                        iniciaAplicacion();
                    }

                    else 
                    {
                        //NO SESION
                        idUsuario = (int)new Query("SELECT USUA_ID FROM DJML.USUARIOS WHERE USUA_USERNAME='" + txtUsu.Text + "'").ObtenerUnicoCampo();
                        Query qr = new Query("SELECT USUA_LOGIN_FALLIDOS FROM DJML.USUARIOS WHERE USUA_ID = " + idUsuario);
                        loginInvalido = Convert.ToInt32(qr.ObtenerUnicoCampo());
                        loginInvalido++;

                        if (loginInvalido < 4)
                        {
                            actualizaIntentos();
                        }
                    }
               }
                //INFORMA SI EL USUARIO SE ENCUENTRA INHABILITADO
               else
                    {
                        if (!usuarioHabilitado(txtUsu.Text))
                        {
                            MessageBox.Show("Usuario bloqueado, contacte al Administrador.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                
            }
        }


        private void iniciaAplicacion()
        {
            //MENSAJE INICIO SESION
            MessageBox.Show("Ha iniciado sesion con exito!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.None);
            //PONE EN 0 LOGIN FALLIDOS Y CONTINUA CON EL INGRESO
            new Query("UPDATE DJML.USUARIOS SET USUA_LOGIN_FALLIDOS = 0 WHERE USUA_ID = " + idUsuario).Ejecutar();
            FormInicioFuncionalidades func = new FormInicioFuncionalidades();
            this.Hide();
            func.ShowDialog();
            func = (FormInicioFuncionalidades)this.ActiveMdiChild;
        }


        private void actualizaIntentos()
        {
            //VALIDA LA CANTIDAD DE LOGIN FALLIDOS, SI ES 3 BLOQUEA AL USUARIO
            if (loginInvalido == 3)
            {
                new Query("UPDATE DJML.USUARIOS SET USUA_HABILITADO = 0 WHERE USUA_ID = " + idUsuario).Ejecutar();
                MessageBox.Show("Usuario bloqueado, contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //SI NO ES 3 ADVIERTE AL USUARIO
            else
            {
                new Query("UPDATE DJML.USUARIOS SET USUA_LOGIN_FALLIDOS= " + loginInvalido + " WHERE USUA_ID = " + idUsuario).Ejecutar();

                if (loginInvalido == 1)
                {
                    MessageBox.Show("Ya intentó 1 vez, a la tercera vez la cuenta quedara inhabilitada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (loginInvalido != 1)
                {
                    MessageBox.Show("Ya intentó " + loginInvalido + " veces, a la tercera vez la cuenta quedara inhabilitada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
               

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        
        }

        private void bnSalir_Click(object sender, EventArgs e)
        {
            Bienvenida login = new Bienvenida();
            this.Hide();
            login.ShowDialog();
            login = (Bienvenida)this.ActiveMdiChild;

        }

        private void txtPassw_TextChanged(object sender, EventArgs e)
        {
            //Largo maximo contraseña 8 caracteres
            txtPassw.MaxLength = 8;
            // Asigna * al password
            txtPassw.PasswordChar = '*';
            // Cambia a minusculas el input de password
            txtPassw.CharacterCasing = CharacterCasing.Lower;
            // Alinea a izquierda el input del password
            txtPassw.TextAlign = HorizontalAlignment.Left;
        }
    }
}

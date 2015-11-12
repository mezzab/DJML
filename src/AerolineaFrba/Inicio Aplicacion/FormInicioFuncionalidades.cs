using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Inicio_Aplicacion;
using System.Data.SqlClient;
using AerolineaFrba.Properties;
using AerolineaFrba.Abm_Rol;
using AerolineaFrba.Generacion_Viaje;
using AerolineaFrba.Compra;
using AerolineaFrba.Abm_Ciudad;
using AerolineaFrba.Abm_Ruta;
using AerolineaFrba.Devolucion;
using AerolineaFrba.Listado_Estadistico;
using AerolineaFrba.Abm_Aeronave;


namespace AerolineaFrba.Inicio_Aplicacion
{
    public partial class FormInicioFuncionalidades : Form
    {
        public FormInicioFuncionalidades()
        {
            InitializeComponent();
        }

        private void abm_rol_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            Form frm = new FormRol();
            frm.StartPosition = FormStartPosition.CenterScreen;
          
            frm.ShowDialog();
            frm = (FormRol)this.ActiveMdiChild;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form frm = new FormGenerarViaje();
            frm.StartPosition = FormStartPosition.CenterScreen;
          
            frm.ShowDialog();
            frm = (FormGenerarViaje)this.ActiveMdiChild;
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
             FormCompra1 frm = new FormCompra1();
             frm.StartPosition = FormStartPosition.CenterScreen;
        
            frm.ShowDialog();
            frm = (FormCompra1)this.ActiveMdiChild;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form frm = new FormCiudades();
            frm.StartPosition = FormStartPosition.CenterScreen;
          
            frm.ShowDialog();
            frm = (FormCiudades)this.ActiveMdiChild;
        
        }

        private void button_rutas_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form frm = new FormRuta();
            frm.StartPosition = FormStartPosition.CenterScreen;
          
            frm.ShowDialog();
            frm = (FormRuta)this.ActiveMdiChild;
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Devolucion0 frm = new Devolucion0();
            frm.StartPosition = FormStartPosition.CenterScreen;

            frm.ShowDialog();
            frm = (Devolucion0)this.ActiveMdiChild;
        }

        private void bnListado_Click(object sender, EventArgs e)
        {
            FormListadoEstadistico inicioF = new FormListadoEstadistico();
            this.Hide();
            inicioF.ShowDialog();
            inicioF = (FormListadoEstadistico)this.ActiveMdiChild;
        }

        private void FormInicioFuncionalidades_Load(object sender, EventArgs e)
        {
            rolTextBox.Text = Bienvenida.rol;

            LlenarComboFuncionalidades();
            funcionalidades.DropDownStyle = ComboBoxStyle.DropDownList;
        }



        public void LlenarComboFuncionalidades()
        {
            if (Bienvenida.rol == "Administrador")
            {
                //avisar("se cargan las funcionalidades del administrador.");

                
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = Settings.Default.CadenaDeConexion;

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT F2.DESCRIPCION from DJML.ROL_FUNCIONALIDAD F1, DJML.FUNCIONALIDAD F2" +
                                                        " WHERE F1.RXF_FUNC_ID = F2.FUNC_ID" + 
                                                        " AND RXF_HABILITADO = 1 AND RXF_ROL_ID = 1", conexion);
                da.Fill(ds, "DJML.FUNCIONALIDAD");

                funcionalidades.DataSource = ds.Tables[0].DefaultView;
                funcionalidades.ValueMember = "DESCRIPCION";
                funcionalidades.SelectedItem = null;


            }
            if (Bienvenida.rol == "Cliente")
            {
                //avisar("se cargan las funcionalidades del cliente");


                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = Settings.Default.CadenaDeConexion;

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT F2.DESCRIPCION from DJML.ROL_FUNCIONALIDAD F1, DJML.FUNCIONALIDAD F2" +
                                                        " WHERE F1.RXF_FUNC_ID = F2.FUNC_ID" +
                                                        " AND RXF_HABILITADO = 1 AND RXF_ROL_ID = 2", conexion);
                da.Fill(ds, "DJML.FUNCIONALIDAD");

                funcionalidades.DataSource = ds.Tables[0].DefaultView;
                funcionalidades.ValueMember = "DESCRIPCION";
                funcionalidades.SelectedItem = null;

            }
        }

        private void avisar(string quePaso)
        {
            MessageBox.Show(quePaso, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form frm = new Bienvenida();
            frm.ShowDialog();
            frm = (Bienvenida)this.ActiveMdiChild;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            switch (funcionalidades.Text)
            {
                case "ABM ROL":
                    this.Visible = false;
                    Form frm = new FormRol();
                    frm.ShowDialog();
                    frm = (FormRol)this.ActiveMdiChild;                   
                    break;
                case "ABM CIUDAD":
                    this.Visible = false;
                    Form frm2 = new FormCiudades();
                    frm2.ShowDialog();
                    frm2 = (FormCiudades)this.ActiveMdiChild;                      
                    break;
                case "ABM RUTA AEREA":
                    this.Visible = false;
                    Form frm3 = new FormRuta();
                    frm3.ShowDialog();
                    frm3 = (FormRuta)this.ActiveMdiChild;
                    break;
                case "ABM AERONAVE":
                    this.Visible = false;
                    FormAeronave frm4 = new FormAeronave();
                    frm4.ShowDialog();
                    frm4 = (FormAeronave)this.ActiveMdiChild;
                    break;
                case "LOGIN Y SEGURIDAD":
                    /*
                    this.Visible = false;
                    Form frm5 = new FormRol();
                    frm5.ShowDialog();
                    frm5 = (FormRol)this.ActiveMdiChild;*/
                    break;
                case "REGISTRO USUARIO":
                    /*
                    this.Visible = false;
                    Form frm6 = new FormRol();
                    frm6.ShowDialog();
                    frm6 = (FormRol)this.ActiveMdiChild;*/
                    break;
                case "GENERAR VIAJE":
                    this.Visible = false;
                    Form frm7 = new FormGenerarViaje();
                    frm7.ShowDialog();
                    frm7 = (FormGenerarViaje)this.ActiveMdiChild;
                    break;
                case "REGISTRO DE LLEGADA A DESTINO":
                    /*
                    this.Visible = false;
                    Form frm8 = new FormRol();
                    frm8.ShowDialog();
                    frm8 = (FormRol)this.ActiveMdiChild;*/
                    break;
                case "COMPRA PASAJE/ENCOMIENDA":
                    this.Visible = false;
                    Form frm9 = new FormCompra1();
                    frm9.ShowDialog();
                    frm9 = (FormCompra1)this.ActiveMdiChild;
                    break;
                case "DEVOLUCION/CANCELACION PASAJE/ENCOMIENDA":
                    this.Visible = false;
                    Form frm10 = new Devolucion0();
                    frm10.ShowDialog();
                    frm10 = (Devolucion0)this.ActiveMdiChild;
                    break;
                case "CONSULTA MILLAS PASAJERO":
                    /*
                    this.Visible = false;
                    Form frm11 = new FormRol();
                    frm11.ShowDialog();
                    frm11 = (FormRol)this.ActiveMdiChild;*/
                    break;
                case "CANJE MILLAS":
                    /*
                    this.Visible = false;
                    Form frm12 = new FormRol();
                    frm12.ShowDialog();
                    frm12 = (FormRol)this.ActiveMdiChild;*/
                    break;
                case "LISTADO ESTADISTICO":
                    this.Visible = false;
                    Form frm13 = new FormListadoEstadistico();
                    frm13.ShowDialog();
                    frm13 = (FormListadoEstadistico)this.ActiveMdiChild;
                    break;
            }
             

        }

   }
}

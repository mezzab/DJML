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
using System.Globalization;
using System.Text.RegularExpressions;
using AerolineaFrba.Inicio_Aplicacion;



namespace AerolineaFrba.Abm_Aeronave
{
    public partial class FormAeronaveAlta : Form

    {
        public FormAeronaveAlta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FormAlta_Load(object sender, EventArgs e)
        {
            llenarComboTservicio();
            comboT_serv.DropDownStyle = ComboBoxStyle.DropDownList;

            llenarComboFabricante();
            comboFab.DropDownStyle = ComboBoxStyle.DropDownList;

            f_alta.Format = DateTimePickerFormat.Custom;
            f_alta.CustomFormat = "yyyy-dd-MM";
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAeronave aeronave = new FormAeronave();
            this.Hide();
            aeronave.ShowDialog();
            aeronave = (FormAeronave)this.ActiveMdiChild;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            this.matricula.Clear();
            this.modelo.Clear();
            this.txtKg_disp.Clear();
            this.comboFab = null;
            this.comboT_serv = null;
            this.txtC_but.Clear();
            this.f_alta = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (controlarQueEsteTodoCompletado() == false)
            {
                MessageBox.Show("Primero debes completar todos los datos. ");

            }

            if (controlarQueEsteTodoCompletado()) // controla que no haya ningun dato en null
            {
                if (controlarNumeroDeButacasIngresado() == false)
                {
                    MessageBox.Show("Se deben ingresar menos de 100 butacas.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // todo: agregar esto a la estrategia?
                }

                if (controlarNumeroDeButacasIngresado()) // controla que no ingrese mas de 99 en el textbox butacas
                {

                    if (matriculaExistente())
                    {
                        MessageBox.Show("La matricula ya existe. Debe dar de baja la aeronave vieja, o bien puede modificarla.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    if (!matriculaExistente())
                    {

                        //variable auxiliar para ingresar bien la fecha 
                        string aux = f_alta.Text + " 00:00:00.000";

                        //Inserta nueva matricula aeronave
                        string sql = "INSERT INTO [DJML].[AERONAVES] (AERO_MATRICULA, " +
                                            "AERO_MODELO, " +
                                            "AERO_FABRICANTE, " +
                                            "AERO_KILOS_DISPONIBLES," +
                                            "AERO_SERVICIO_ID, " +
                                            "AERO_BAJA_FUERA_SERVICIO, " +
                                            "AERO_BAJA_VIDA_UTIL, " +
                                            "AERO_FECHA_BAJA_DEF, " +
                                            "AERO_FECHA_ALTA ) " +
                                    "VALUES ('" + matricula.Text + "', " +
                                            "'" + modelo.Text + "', " +
                                            "( select ID_FABRICANTE from djml.FABRICANTES where DESCRIPCION = '" + comboFab.Text + "'), " +
                                            "'" + txtKg_disp.Text + "', " +
                                            "( select serv_id from djml.servicios where SERV_DESCRIPCION = '" + comboT_serv.Text + "'), " +
                                            " 0, 0, NULL, ' " + aux + "' )";


                        Query qry1 = new Query(sql);
                        qry1.pComando = sql;
                        qry1.Ejecutar();

                        //insert en aero_butacas de las butacas 
                        darDeAltaButacasParaLaNuevaAeronave();

                        MessageBox.Show("Se ha cargado correctamente la nueva aeronave! ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.None);
                        limpiar();


                        FormInicioFuncionalidades aero = new FormInicioFuncionalidades();
                        this.Hide();
                        aero.ShowDialog();
                        aero = (FormInicioFuncionalidades)this.ActiveMdiChild;

                    }
                }

            }

          }


        private bool controlarNumeroDeButacasIngresado()
        {

            bool variable = false;
            if (Convert.ToInt32(txtC_but.Text) < 100)
            {
                variable = true;
            }
            return variable;
        }

        private void darDeAltaButacasParaLaNuevaAeronave()
        {
            
            for (int i = Convert.ToInt32(txtC_but.Text); i >= 1; i--) // lo hago hasta 1, por que los ids empiezan de 1
            {
                string sql1 = "INSERT INTO [DJML].[BUTACA_AERO] ([BXA_BUTA_ID],[BXA_AERO_MATRICULA] ,[BXA_ESTADO]) VALUES (" + i + ", '" + matricula.Text + "' , 1 ) " ;
              
                Query qry1 = new Query(sql1);
                qry1.pComando = sql1;
                qry1.Ejecutar();
            
            }
         
        }



        private bool matriculaExistente()
        {

            string sql = "SELECT AERO_MATRICULA FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula.Text + "'";
            Query qry = new Query(sql);
            object matric = qry.ObtenerUnicoCampo();

            return (matric != null);
        }


        private void llenarComboFabricante()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DESCRIPCION FROM DJML.FABRICANTES ORDER BY 1", conexion);
            da.Fill(ds, "DJML.AERONAVES");

            comboFab.DataSource = ds.Tables[0].DefaultView;
            comboFab.ValueMember = "DESCRIPCION";
            comboFab.SelectedItem = null;

        }

        private void llenarComboTservicio()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT SERV_DESCRIPCION FROM DJML.SERVICIOS ORDER BY 1", conexion);
            da.Fill(ds, "DJML.AERONAVES");

            comboT_serv.DataSource = ds.Tables[0].DefaultView;
            comboT_serv.ValueMember = "SERV_DESCRIPCION";
            comboT_serv.SelectedItem = null;
        }

        
        private void kg_TextChanged(object sender, EventArgs e)
        {
            txtKg_disp.Text = Regex.Replace(txtKg_disp.Text, @"[^\d]", "");
        }

        private void matri_TextChanged(object sender, EventArgs e)
        {

        }

        private void f_alta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtC_but_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKg_disp_TextChanged(object sender, EventArgs e)
        {
         
            //solo deja ingresar numeros
            txtKg_disp.Text = Regex.Replace(txtKg_disp.Text, @"[^\d]", "");
        }

        private void txtC_but_TextChanged_1(object sender, EventArgs e)
        {
            // solo deja ingresar numeros
            txtC_but.Text = Regex.Replace(txtC_but.Text, @"[^\d]", "");
        }

        private bool controlarQueEsteTodoCompletado()
        {

            bool estanTodos = false;

            if (matricula.Text != "" &&
            modelo.Text != "" &&
            txtKg_disp.Text != "" &&
            txtC_but.Text != "" &&
            comboFab.Text != "" &&
            comboT_serv.Text != "")
            {
                estanTodos = true;
            }

            return estanTodos;
        }

        private void matricula_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboT_serv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void f_alta_ValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}

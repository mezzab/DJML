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


        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAeronave rol = new FormAeronave();
            this.Hide();
            rol.ShowDialog();
            rol = (FormAeronave)this.ActiveMdiChild;
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
            this.txtMatri.Clear();
            this.txtModelo.Clear();
            this.txtKg_disp.Clear();
            this.comboFab = null;
            this.comboT_serv = null;
            this.txtC_but.Clear();
            this.f_alta = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 c_butacas = 0;
            Int32 kg_disp = 0;
            String modelo = txtModelo.Text;
            String matricula = txtMatri.Text;
            Int32 fabricante = 0;
            Int32 servicio = 0;


            if (!faltanDatos())
            {
                if (txtC_but.Text != ""){ 
                    c_butacas = Int32.Parse(txtC_but.Text);
                }
                if (txtKg_disp.Text != ""){
                    kg_disp = Int32.Parse(txtKg_disp.Text);
                }
                if (comboFab.SelectedValue != null){
                    fabricante = (Int32)comboFab.SelectedValue;
                }
                if (comboT_serv.SelectedValue != null){
                    servicio = (Int32)comboT_serv.SelectedValue;
                }

                bool cumpleCondiciones = (c_butacas > 0 && kg_disp > 0 && fabricante > 0 && servicio > 0 && txtModelo.Text != "" && txtMatri.Text != "");
                if (cumpleCondiciones){
                    if (!matriculaExistente())
                    {
                        //Inserta nueva matricula aeronave
                        string sql_matricula = "INSERT INTO DJML.(AERO_MATRICULA, AERO_MODELO, AERO_FABRICANTE, AERO_KILOS_DISPONIBLES," +
                            "AERO_SERVICIO_ID, AERO_BAJA_FUERA_SERVICIO, AERO_BAJA_VIDA_UTIL, AERO_FECHA_FUERA_SERVICIO, AERO_FECHA_REINICIO_SERVICIO," +
                            "AERO_FECHA_BAJA_DEF, AERO_FECHA_ALTA ) VALUES ('" + txtMatri.Text + "', '" + txtModelo.Text + "', '" + txtKg_disp.Text + "', 0, 0, 0, NULL ,NULL NULL NULL ')";
                        {
                            //da el alta de la aeronave y limpia los campos para agregar otra aeronave de ser conveniente
                            MessageBox.Show("Alta Aeronave correcta");
                            limpiar();
                        }
                    }

                }
            }
            else
            { 
                
            }
        }

        private bool matriculaExistente()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;
            string mat = ("SELECT COUNT(1) AERO_MATRICULA FROM DJML.USUARIOS WHERE AERO_MATRICULA = '" + txtMatri.Text + "'");
            if (mat.Equals(1))
            {
                MessageBox.Show("Matricula ya habilitada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool faltanDatos()
        {
            bool condiciones = (txtMatri.Text.Length.Equals(0) || txtModelo.Text.Length.Equals(0) || txtKg_disp.Text.Length.Equals(0) || txtC_but.Text.Length.Equals(0) /* falta f_alta ts y fabricante (combos)*/);
            string matricula;

            if (!condiciones.Equals(true))
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {

            }

            return false;

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
    }
}

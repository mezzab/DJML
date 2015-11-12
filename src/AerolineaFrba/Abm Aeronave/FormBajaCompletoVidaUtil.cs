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
using AerolineaFrba.Inicio_Aplicacion;


namespace AerolineaFrba.Abm_Aeronave
{
    public partial class FormBajaCompletoVidaUtil : Form
    {
        public FormBajaCompletoVidaUtil()
        {
            InitializeComponent();
        }

        private void FormBajaCompletoVidaUtil_Load(object sender, EventArgs e)
        {
            cargarAeronaves();
            comboBoxAeronaves.DropDownStyle = ComboBoxStyle.DropDownList;
        }



        private void cargarAeronaves()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select AERO_MATRICULA from DJML.AERONAVES where AERO_BAJA_VIDA_UTIL = 0", conexion);
            da.Fill(ds, "DJML.ROLES");

            comboBoxAeronaves.DataSource = ds.Tables[0].DefaultView;
            comboBoxAeronaves.ValueMember = "AERO_MATRICULA";
            comboBoxAeronaves.SelectedItem = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxAeronaves.Text != "")
            {
                //DAR DE BAJA UN AERONAVE

                string qry = " update DJML.AERONAVES " +
                                " set AERO_BAJA_VIDA_UTIL = 1  " +
                                " where AERO_MATRICULA = '" + comboBoxAeronaves.Text.ToString() + "'";
                new Query(qry).Ejecutar();

                /*
                
                // HACER: Si la inactivad es por fin de la vida útil se reemplazan todos los viajes futuros!!!
                
                string qry2 = "UPDATE A VIAJES  " 
                new Query(qry2).Ejecutar();
                */



                MessageBox.Show("Aeronave inhabilitada exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Visible = false;

                FormInicioFuncionalidades funcionalidades = new FormInicioFuncionalidades();
                this.Hide();
                funcionalidades.ShowDialog();
                funcionalidades = (FormInicioFuncionalidades)this.ActiveMdiChild;


            }
            else
            {
                //MESAJE DE ERROR
                MessageBox.Show("Seleccione una Aeronave", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAeronaveBaja funcionalidades = new FormAeronaveBaja();
            this.Hide();
            funcionalidades.ShowDialog();
            funcionalidades = (FormAeronaveBaja)this.ActiveMdiChild;
        }
    }
}

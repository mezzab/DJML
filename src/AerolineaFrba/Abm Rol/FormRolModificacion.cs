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
    public partial class FormRolModificacion : Form
    {
        string rol;

        public FormRolModificacion()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRol rol = new FormRol();
            this.Hide();
            rol.ShowDialog();
            rol = (FormRol)this.ActiveMdiChild;


        }

        private void FormRolModificacion_Load(object sender, EventArgs e)
        {
            LlenarComboBox();
            bnBuscar.Enabled = false;
            chkHabilitado.Enabled = false;
            txtRol.Enabled = false;
            bnAceptar.Enabled = false;
            comboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private void bnBuscar_Click(object sender, EventArgs e)
        {
            rol = comboBoxRol.Text.ToString();
            comboBoxRol.Enabled = false;
            txtRol.Enabled = true;
            chkHabilitado.Enabled = true;
            CargarDatosRol();
        }


        private void CargarDatosRol()
        {
            
            txtRol.Text = rol;
            CargarFuncionalidadesEnLista();
            string ConsultarFuncionalidades = " SELECT f.DESCRIPCION Funcionalidad, rf.RXF_ESTADO " +
                                                " FROM DJML.ROL_FUNCIONALIDAD rf" +
                                                " JOIN DJML.ROLES r ON r.ROL_ID = rf.RXF_ROL_ID" +
                                                " RIGHT JOIN DJML.FUNCIONALIDAD f on f.FUNC_ID = rf.RXF_FUNC_ID" +
                                                " where rf.RXF_ROL_ID = r.ROL_ID " +
                                                " and r.ROL_DESCRIPCION = '" + rol + "' ";

            Query qry = new Query(ConsultarFuncionalidades);

            //TILDAR FUNCIONALIDADES HABILITADAS
            DataTable funcionalidades = qry.ObtenerDataTable();
            foreach (DataRow funcionalidad in funcionalidades.Rows)
            {
                string descripcionFuncionalidad = funcionalidad["Funcionalidad"].ToString();
                int index = Funcionalidades.FindString(descripcionFuncionalidad, 0);
                Funcionalidades.SetItemChecked(index, true);
            }


            //PARA TILDAR EL CHECK DE ROL HABILITADO
            string Habilitado = "SELECT ROL_ACTIVO FROM DJML.ROLES where ROL_DESCRIPCION = '" + rol + "'";
            qry.pComando = Habilitado;
            chkHabilitado.Checked = (bool)qry.ObtenerUnicoCampo();

            if (chkHabilitado.Checked == true)
                chkHabilitado.Enabled = false;
            
        }


        public void LlenarComboBox()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select ROL_DESCRIPCION from DJML.ROLES", conexion);
            da.Fill(ds, "DJML.ROLES");

            comboBoxRol.DataSource = ds.Tables[0].DefaultView;
            comboBoxRol.ValueMember = "ROL_DESCRIPCION";
            comboBoxRol.SelectedItem = null;
        }

        //SE CARGAN FUNCIONALIDADES 
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

        private void txtRol_TextChanged(object sender, EventArgs e)
        {
            if (txtRol.Text != comboBoxRol.Text)
                bnAceptar.Enabled = true;
            else
                bnBuscar.Enabled = false;
        }


        //ACTUALIZAR FUNCIONALIDADES
        private void ActualizarFuncionalidades()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            string consulta = "SELECT ROL_ID FROM DJML.ROLES where ROL_DESCRIPCION = '" + rol + "'";
            Query qr = new Query(consulta);
            qr.pComando = consulta;
            int idRol = (int)qr.ObtenerUnicoCampo();

            for (int i = 0; i < Funcionalidades.Items.Count; i++)
            {
                string sql;
                string Funcionalidad = Funcionalidades.Items[i].ToString().Replace(']', ' ').Substring(Funcionalidades.Items[i].ToString().IndexOf(',') + 1).TrimEnd();
                if (Funcionalidades.GetItemChecked(i))
                {
                    //INSERTA SI NO EXISTE
                    sql = " INSERT INTO DJML.ROL_FUNCIONALIDAD (RXF_FUNC_ID, RXF_ROL_ID, RXF_ESTADO)" +
                            " select distinct " + Funcionalidad + ", " + idRol + ", 1 HABILITADO" +
                            " from DJML.FUNCIONALIDAD" +
                            " where " + Funcionalidad + " not in ( select FUNC_ID from DJML.ROL_FUNCIONALIDAD where RXF_ROL_ID = " + idRol + ")";
                }
                else
                {
                    // BORRAR SI ESTA DESMARCADO (no es necesario chequear si existe)
                    sql = " UPDATE  DJML.ROL_FUNCIONALIDAD" +
                            " set RXF_ESTADO = 0 " +
                            " where RXF_ROL_ID = " + idRol +
                            " and RXF_FUNC_ID = " + Funcionalidad;
                }

                Query qry = new Query(sql);
                qry.Ejecutar();
            }
        }

        private void GuardarModificaciones()
        {
            string sql = "UPDATE DJML.ROLES SET ROL_DESCRIPCION = '" + txtRol.Text +
                                   "',ROL_ACTIVO = " + (chkHabilitado.Checked ? '1' : '0') +
                                   " WHERE ROL_DESCRIPCION = '" + rol + "'";

            new Query(sql).Ejecutar();
        }

        private void bnAceptar_Click(object sender, EventArgs e)
        {
            ActualizarFuncionalidades();
            GuardarModificaciones();
            MessageBox.Show("Modificación realizada con éxito!");
            //Volver a ABM ROL
            this.Visible = false;
            FormRol rol = new FormRol();
            this.Hide();
            rol.ShowDialog();
            rol = (FormRol)this.ActiveMdiChild;
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBoxRol.Enabled == true)
               comboBoxRol.SelectedItem = null;
            
            txtRol.Text = null;

            if(chkHabilitado.Checked != true)
               chkHabilitado.Checked = false;
            
            foreach (int i in Funcionalidades.CheckedIndices)
            {
                Funcionalidades.SetItemCheckState(i, CheckState.Unchecked);
            }

            bnAceptar.Enabled = false;
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRol.Text.Trim() != "")
                bnBuscar.Enabled = true;
            
        }

        private void Funcionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
              
            if (Funcionalidades.CheckedItems.Count > 0)
                 bnAceptar.Enabled = true;
           else
                bnAceptar.Enabled = false;
        }

        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            bnAceptar.Enabled = true;
        }


    }
}

﻿using System;
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
using System.Globalization;
using System.Text.RegularExpressions;

namespace AerolineaFrba.Canje_Millas
{
    /*
     * 12. Canje de millas de pasajero frecuente
    Funcionalidad que permite a un cliente cambiar sus millas de pasajero frecuente
    por beneficios. Simplemente el cliente elegirá una recompensa que estará al alcance de
    sus millas. Las mismas no serán viajes, ni crédito a favor para futuros viajes, las
    recompensas serán productos y se debe validar que la cantidad en stock del producto
    elegido permita realizar el canje.
    Los productos del programa serán determinados por los alumnos, como así
    también las millas necesarias para realizar el canje.
    Una vez que el stock de un determinado producto se agota no se vuelve a reponer.
    El canje solo podrá ser realizado por un administrativo quien es el encargado de
    validar si el número de documento se corresponde con la persona que desea realizar el
    canje. Para hacerse efectivo el canje, será necesario que se registre:
     Número de documento
     Producto elegido
     Cantidad del producto elegido
     Fecha de canje.*/


    public partial class canjeMillas : Form
    {

        public static string producto;
        public static string producto_id;
        public static int millas;
        public static int stock;
        public static string dni;
        public static string tipo;

        public canjeMillas()
        {
            InitializeComponent();
        }

        private void canjeMillas_Load(object sender, EventArgs e)
        {
            canjear.Enabled = false;
           LlenarComboBoxTipoDocumento();
           tipoDeDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
           LlenarGridProductos();

           cantidad.Visible = false;
           cantidadLabel.Visible = false;

        }

        public void LlenarComboBoxTipoDocumento()
        {
            SqlConnection conexion1 = new SqlConnection();
            conexion1.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DESCRIPCION FROM DJML.TIPO_DOCUMENTO", conexion1);
            da.Fill(ds1, "DJML.TIPO_DOCUMENTO");

            tipoDeDocumento.DataSource = ds1.Tables[0].DefaultView;
            tipoDeDocumento.ValueMember = "DESCRIPCION";
            tipoDeDocumento.SelectedItem = null;
        }

        public void LlenarGridProductos() 
        {
            string qry = "SELECT PROD_ID as 'Codigo', PROD_NOMBRE as 'Producto', PROD_MILLAS_REQUERIDAS as 'Millas Requeridas', PROD_STOCK as 'Stock'" +
                         " FROM DJML.PRODUCTO";

            var result = new Query(qry).ObtenerDataTable();
            dataGridProductos.DataSource = result;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FormInicioFuncionalidades FormInicioFuncionalidades = new FormInicioFuncionalidades();
            this.Hide();
            FormInicioFuncionalidades.ShowDialog();
            FormInicioFuncionalidades = (FormInicioFuncionalidades)this.ActiveMdiChild;
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            //Limpio datos para el canje
            producto = null;
            producto_id = null;
            millas = 0;
            stock = 0;
            canjear.Enabled = false;

            dni = textBoxDNI.Text;
            tipo = tipoDeDocumento.Text;
            if (dni != string.Empty && tipo != string.Empty)
            {
                string qry = "SELECT PROD_ID as 'Codigo', PROD_NOMBRE as 'Producto', PROD_MILLAS_REQUERIDAS as 'Millas Requeridas', PROD_STOCK as 'Stock'" +
                          " FROM DJML.PRODUCTO" +
                          " WHERE PROD_MILLAS_REQUERIDAS < DJML.CALCULAR_MILLAS('" + dni + "', '" + tipo + "')";

                var result = new Query(qry).ObtenerDataTable();
                if (result.Rows.Count != 0)
                {
                    dataGridProductos.DataSource = result;
                }
                else
                {
                    MessageBox.Show("Usted no posee millas suficientes para ningun canje", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
                MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }  

        private void dataGridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            producto_id = dataGridProductos.Rows[e.RowIndex].Cells[1].Value.ToString();
            producto = dataGridProductos.Rows[e.RowIndex].Cells[2].Value.ToString();
            millas = Int32.Parse(dataGridProductos.Rows[e.RowIndex].Cells[3].Value.ToString());
            stock = Int32.Parse(dataGridProductos.Rows[e.RowIndex].Cells[4].Value.ToString());

            productoSeleccionado.Text = "Seleccionaste el producto " + producto + "  " ;
            productoSeleccionado.Visible = true;
            cantidad.Visible = true;
            cantidadLabel.Visible = true;

            canjear.Enabled = true;
        }

        private void canjear_Click(object sender, EventArgs e)
        {

            if ( cantidad.Text == string.Empty) 
            {
                MessageBox.Show("Debe ingresar una cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string qryCant = "SELECT  DJML.CALCULAR_MILLAS('" + dni + "', '" + tipo + "')";
                var resultCant = new Query(qryCant).ObtenerDataTable();
                int resultado = Int32.Parse(resultCant.Rows[0][0].ToString());
                int cant = Int32.Parse(cantidad.Text);
                if (stock < cant){
                    MessageBox.Show("Lo sentimos pero no disponemos de stock suficiente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
                else if (resultado < millas*cant) {
                    MessageBox.Show("Lo sentimos pero no dispone de suficientes millas para canjear", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {

                    string insert_canje = "INSERT INTO DJML.CANJES (CANJ_CLIE_ID, CANJ_PRODUCTO_ID, CANJ_CANTIDAD, CANJ_FECHA_CANJE, CANJ_MILLAS_USADAS)" +
                                     " SELECT CLIE_ID, " + producto_id + ", " + cantidad.Text + ", GETDATE(), " + (millas*cant) +
                                     " FROM DJML.CLIENTES" +
                                     " JOIN DJML.TIPO_DOCUMENTO td on CLIE_TIPO_DOC = ID_TIPO_DOC" +
                                     " WHERE CLIE_DNI = '" + dni + "'" +
                                     " AND td.DESCRIPCION = '" + tipo + "'";
                    new Query(insert_canje).Ejecutar();

                    string update_productos = "UPDATE DJML.PRODUCTO SET PROD_STOCK = PROD_STOCK - " + cant +  "WHERE PROD_ID = " + producto_id;
                    new Query(update_productos).Ejecutar();

                    MessageBox.Show("Felicitaciones! Pase por la ventanilla de al lado para retirar sus productos", "Felicitaciones!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    FormInicioFuncionalidades FormInicioFuncionalidades = new FormInicioFuncionalidades();
                    this.Hide();
                    FormInicioFuncionalidades.ShowDialog();
                    FormInicioFuncionalidades = (FormInicioFuncionalidades)this.ActiveMdiChild;
                }
            }


        }

        private void cantidad_TextChanged(object sender, EventArgs e)
        {
            //solo deja ingresar numeros
           cantidad.Text = Regex.Replace(cantidad.Text, @"[^\d]", "");
        }

    }
}

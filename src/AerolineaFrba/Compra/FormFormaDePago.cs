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

namespace AerolineaFrba.Compra
{
    public partial class FormFormaDePago : Form
    {
        public static Boolean pagoEnEfectivo;

        public static string codigoCompra;
        public static string IDCompra;


        public FormFormaDePago()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {/*
            CargaDatos m = new CargaDatos();
            this.Hide();
            m.StartPosition = FormStartPosition.CenterScreen;

            m.ShowDialog();
            m = (CargaDatos)this.ActiveMdiChild;*/
        }


        private void button1_Click(object sender, EventArgs e)
        {
            switch (formaPago.Text)
            {
                case "Tarjeta de credito":
                    pagoEnEfectivo = false;

                    PagoConTarjeta t = new PagoConTarjeta();
                    t.StartPosition = FormStartPosition.CenterScreen;
                    this.Hide();
                    t.ShowDialog();
                    t = (PagoConTarjeta)this.ActiveMdiChild;

                    break;
                case "Efectivo":
                    pagoEnEfectivo = true;

                    PagoEfectivo m = new PagoEfectivo();
                    m.StartPosition = FormStartPosition.CenterScreen;
                    this.Hide();
                    m.ShowDialog();
                    m = (PagoEfectivo)this.ActiveMdiChild;

                    break;
            }
        }

        private void FormFormaDePago_Load(object sender, EventArgs e)
        {

            LlenarComboBoxTiposCompra();
            formaPago.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void LlenarComboBoxTiposCompra()
        {

            if (Bienvenida.rol == "Administrador")
            {
                formaPago.Items.Add("Efectivo");
                formaPago.Items.Add("Tarjeta de credito");
                formaPago.SelectedItem = null;

            }
            if (Bienvenida.rol == "Cliente")
            {
                formaPago.Items.Add("Efectivo");
                formaPago.SelectedItem = null;
            }

        }

        private void formaPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            FormCompra1.vuelve = true;
            CargaDatos t = new CargaDatos();
            t.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            t.ShowDialog();
            t = (CargaDatos)this.ActiveMdiChild;


        }
    }
}
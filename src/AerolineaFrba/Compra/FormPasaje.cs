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

namespace AerolineaFrba.Compra
{
    public partial class FormPasaje : Form
    { 
        
        public static int cantPasajes;
        public static int cantPasajes1;

        public FormPasaje()
        {
            InitializeComponent();
           
        }

        private void FormPasaje_Load(object sender, EventArgs e)
        {
                        
            button1.Enabled = false;
            LlenarComboBox1();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            FormCompra2.esEncomienda = false;
         
        }
        public void LlenarComboBox1()
        {
             comboBox1.Items.Add(1);
             comboBox1.Items.Add(2);
             comboBox1.Items.Add(3);
             comboBox1.Items.Add(4);
             comboBox1.Items.Add(5);
             comboBox1.Items.Add(6);
             comboBox1.Items.Add(7);
             comboBox1.Items.Add(8);
             comboBox1.Items.Add(9);
             comboBox1.Items.Add(10);
 
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCompra2 m = new FormCompra2();
            m.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            m.ShowDialog();
            m = (FormCompra2)this.ActiveMdiChild;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Text.Trim() != "" || comboBox1.SelectedItem != null))
            {
                button1.Enabled = true;
            }
             CompraPasaje m = new CompraPasaje();
             m.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            m.ShowDialog();
            m = (CompraPasaje)this.ActiveMdiChild;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cantPasajes = Int32.Parse(comboBox1.Text.Trim());
            cantPasajes1 = Int32.Parse(comboBox1.Text.Trim());
            button1.Enabled = true;

        }

        private void FormPasaje_Load()
        {

        }


    }
}

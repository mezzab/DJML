﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class FormCiudades_Modificacion : Form
    {
        public FormCiudades_Modificacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCiudades volver = new FormCiudades();
            this.Hide();
           // this.Close();??
            volver.ShowDialog();
            volver = (FormCiudades)this.ActiveMdiChild;
        }
    }
}

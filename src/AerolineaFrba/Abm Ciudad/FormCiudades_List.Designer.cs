namespace AerolineaFrba.Abm_Ciudad
{
    partial class FormCiudades_List
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCiudades_List));
            this.volver = new System.Windows.Forms.Button();
            this.resultados = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.Label();
            this.boxBusqueda = new System.Windows.Forms.TextBox();
            this.buscar = new System.Windows.Forms.Button();
            this.Filtros = new System.Windows.Forms.GroupBox();
            this.darBaja = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.Button();
            this.resultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(120, 316);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 0;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.button1_Click);
            // 
            // resultados
            // 
            this.resultados.Controls.Add(this.dataGridView1);
            this.resultados.Location = new System.Drawing.Point(12, 93);
            this.resultados.Name = "resultados";
            this.resultados.Size = new System.Drawing.Size(472, 217);
            this.resultados.TabIndex = 2;
            this.resultados.TabStop = false;
            this.resultados.Text = "Resultados";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(458, 191);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // nombre
            // 
            this.nombre.AutoSize = true;
            this.nombre.Location = new System.Drawing.Point(7, 31);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(47, 13);
            this.nombre.TabIndex = 0;
            this.nombre.Text = "Nombre:";
            // 
            // boxBusqueda
            // 
            this.boxBusqueda.Location = new System.Drawing.Point(60, 28);
            this.boxBusqueda.Name = "boxBusqueda";
            this.boxBusqueda.Size = new System.Drawing.Size(276, 20);
            this.boxBusqueda.TabIndex = 1;
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(342, 26);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(114, 23);
            this.buscar.TabIndex = 2;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            // 
            // Filtros
            // 
            this.Filtros.Controls.Add(this.buscar);
            this.Filtros.Controls.Add(this.boxBusqueda);
            this.Filtros.Controls.Add(this.nombre);
            this.Filtros.Location = new System.Drawing.Point(12, 13);
            this.Filtros.Name = "Filtros";
            this.Filtros.Size = new System.Drawing.Size(472, 74);
            this.Filtros.TabIndex = 1;
            this.Filtros.TabStop = false;
            this.Filtros.Text = "Busqueda";
            // 
            // darBaja
            // 
            this.darBaja.Location = new System.Drawing.Point(212, 316);
            this.darBaja.Name = "darBaja";
            this.darBaja.Size = new System.Drawing.Size(75, 23);
            this.darBaja.TabIndex = 3;
            this.darBaja.Text = "Dar de baja";
            this.darBaja.UseVisualStyleBackColor = true;
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(303, 316);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(75, 23);
            this.modificar.TabIndex = 4;
            this.modificar.Text = "Modificar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // FormCiudades_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(496, 351);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.darBaja);
            this.Controls.Add(this.resultados);
            this.Controls.Add(this.Filtros);
            this.Controls.Add(this.volver);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCiudades_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Ciudades";
            this.Load += new System.EventHandler(this.FormCiudades_List_Load);
            this.resultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Filtros.ResumeLayout(false);
            this.Filtros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.GroupBox resultados;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label nombre;
        private System.Windows.Forms.TextBox boxBusqueda;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.GroupBox Filtros;
        private System.Windows.Forms.Button darBaja;
        private System.Windows.Forms.Button modificar;
    }
}
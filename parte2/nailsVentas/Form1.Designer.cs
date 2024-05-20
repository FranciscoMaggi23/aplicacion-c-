namespace nailsVentas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDataMateriales = new System.Windows.Forms.DataGridView();
            this.dgvDataTiempoServicio = new System.Windows.Forms.DataGridView();
            this.dgvDataPrecioFinal = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvDataMoviliario = new System.Windows.Forms.DataGridView();
            this.dgvDataGastos = new System.Windows.Forms.DataGridView();
            this.dgvDataMes = new System.Windows.Forms.DataGridView();
            this.dgvDataMaterialesAdicionales = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataMateriales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTiempoServicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPrecioFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataMoviliario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataGastos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataMaterialesAdicionales)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDataMateriales
            // 
            this.dgvDataMateriales.AllowUserToAddRows = false;
            this.dgvDataMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataMateriales.Location = new System.Drawing.Point(32, 52);
            this.dgvDataMateriales.Name = "dgvDataMateriales";
            this.dgvDataMateriales.ReadOnly = true;
            this.dgvDataMateriales.RowHeadersWidth = 51;
            this.dgvDataMateriales.RowTemplate.Height = 24;
            this.dgvDataMateriales.Size = new System.Drawing.Size(676, 242);
            this.dgvDataMateriales.TabIndex = 0;
            this.dgvDataMateriales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataMateriales_CellDoubleClick);
            this.dgvDataMateriales.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataMateriales_CellValueChanged);
            // 
            // dgvDataTiempoServicio
            // 
            this.dgvDataTiempoServicio.AllowUserToAddRows = false;
            this.dgvDataTiempoServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTiempoServicio.Location = new System.Drawing.Point(48, 355);
            this.dgvDataTiempoServicio.Name = "dgvDataTiempoServicio";
            this.dgvDataTiempoServicio.ReadOnly = true;
            this.dgvDataTiempoServicio.RowHeadersWidth = 51;
            this.dgvDataTiempoServicio.RowTemplate.Height = 24;
            this.dgvDataTiempoServicio.Size = new System.Drawing.Size(660, 179);
            this.dgvDataTiempoServicio.TabIndex = 1;
            this.dgvDataTiempoServicio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataTiempoServicio_CellDoubleClick);
            // 
            // dgvDataPrecioFinal
            // 
            this.dgvDataPrecioFinal.AllowUserToAddRows = false;
            this.dgvDataPrecioFinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataPrecioFinal.Location = new System.Drawing.Point(744, 62);
            this.dgvDataPrecioFinal.Name = "dgvDataPrecioFinal";
            this.dgvDataPrecioFinal.RowHeadersWidth = 51;
            this.dgvDataPrecioFinal.RowTemplate.Height = 24;
            this.dgvDataPrecioFinal.Size = new System.Drawing.Size(530, 319);
            this.dgvDataPrecioFinal.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "MATERIALES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "TIEMPO SERVICIO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(875, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "PRECIO FINAL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 545);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "MATERIALES ADICIONALES POR SERVICIO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(472, 744);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "MES";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1461, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "GASTOS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(968, 453);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "MOVILIARIO";
            // 
            // dgvDataMoviliario
            // 
            this.dgvDataMoviliario.AllowUserToAddRows = false;
            this.dgvDataMoviliario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataMoviliario.Location = new System.Drawing.Point(895, 472);
            this.dgvDataMoviliario.Name = "dgvDataMoviliario";
            this.dgvDataMoviliario.RowHeadersWidth = 51;
            this.dgvDataMoviliario.RowTemplate.Height = 24;
            this.dgvDataMoviliario.Size = new System.Drawing.Size(641, 168);
            this.dgvDataMoviliario.TabIndex = 10;
            // 
            // dgvDataGastos
            // 
            this.dgvDataGastos.AllowUserToAddRows = false;
            this.dgvDataGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataGastos.Location = new System.Drawing.Point(1299, 91);
            this.dgvDataGastos.Name = "dgvDataGastos";
            this.dgvDataGastos.RowHeadersWidth = 51;
            this.dgvDataGastos.RowTemplate.Height = 24;
            this.dgvDataGastos.Size = new System.Drawing.Size(540, 168);
            this.dgvDataGastos.TabIndex = 11;
            // 
            // dgvDataMes
            // 
            this.dgvDataMes.AllowUserToAddRows = false;
            this.dgvDataMes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataMes.Location = new System.Drawing.Point(132, 774);
            this.dgvDataMes.Name = "dgvDataMes";
            this.dgvDataMes.RowHeadersWidth = 51;
            this.dgvDataMes.RowTemplate.Height = 24;
            this.dgvDataMes.Size = new System.Drawing.Size(1269, 168);
            this.dgvDataMes.TabIndex = 12;
            // 
            // dgvDataMaterialesAdicionales
            // 
            this.dgvDataMaterialesAdicionales.AllowUserToAddRows = false;
            this.dgvDataMaterialesAdicionales.AllowUserToDeleteRows = false;
            this.dgvDataMaterialesAdicionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataMaterialesAdicionales.Location = new System.Drawing.Point(141, 564);
            this.dgvDataMaterialesAdicionales.Name = "dgvDataMaterialesAdicionales";
            this.dgvDataMaterialesAdicionales.RowHeadersWidth = 51;
            this.dgvDataMaterialesAdicionales.RowTemplate.Height = 24;
            this.dgvDataMaterialesAdicionales.Size = new System.Drawing.Size(684, 168);
            this.dgvDataMaterialesAdicionales.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1860, 1055);
            this.Controls.Add(this.dgvDataMaterialesAdicionales);
            this.Controls.Add(this.dgvDataMes);
            this.Controls.Add(this.dgvDataGastos);
            this.Controls.Add(this.dgvDataMoviliario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDataPrecioFinal);
            this.Controls.Add(this.dgvDataTiempoServicio);
            this.Controls.Add(this.dgvDataMateriales);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataMateriales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTiempoServicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPrecioFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataMoviliario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataGastos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataMaterialesAdicionales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataMateriales;
        private System.Windows.Forms.DataGridView dgvDataTiempoServicio;
        private System.Windows.Forms.DataGridView dgvDataPrecioFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvDataMoviliario;
        private System.Windows.Forms.DataGridView dgvDataGastos;
        private System.Windows.Forms.DataGridView dgvDataMes;
        private System.Windows.Forms.DataGridView dgvDataMaterialesAdicionales;
    }
}


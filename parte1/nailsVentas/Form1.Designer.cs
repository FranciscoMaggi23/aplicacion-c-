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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataMateriales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTiempoServicio)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDataMateriales
            // 
            this.dgvDataMateriales.AllowUserToAddRows = false;
            this.dgvDataMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataMateriales.Location = new System.Drawing.Point(32, 2);
            this.dgvDataMateriales.Name = "dgvDataMateriales";
            this.dgvDataMateriales.ReadOnly = true;
            this.dgvDataMateriales.RowHeadersWidth = 51;
            this.dgvDataMateriales.RowTemplate.Height = 24;
            this.dgvDataMateriales.Size = new System.Drawing.Size(771, 356);
            this.dgvDataMateriales.TabIndex = 0;
            this.dgvDataMateriales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataMateriales_CellDoubleClick);
            this.dgvDataMateriales.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataMateriales_CellValueChanged);
            // 
            // dgvDataTiempoServicio
            // 
            this.dgvDataTiempoServicio.AllowUserToAddRows = false;
            this.dgvDataTiempoServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTiempoServicio.Location = new System.Drawing.Point(32, 384);
            this.dgvDataTiempoServicio.Name = "dgvDataTiempoServicio";
            this.dgvDataTiempoServicio.ReadOnly = true;
            this.dgvDataTiempoServicio.RowHeadersWidth = 51;
            this.dgvDataTiempoServicio.RowTemplate.Height = 24;
            this.dgvDataTiempoServicio.Size = new System.Drawing.Size(771, 179);
            this.dgvDataTiempoServicio.TabIndex = 1;
            this.dgvDataTiempoServicio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataTiempoServicio_CellDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 666);
            this.Controls.Add(this.dgvDataTiempoServicio);
            this.Controls.Add(this.dgvDataMateriales);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataMateriales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTiempoServicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataMateriales;
        private System.Windows.Forms.DataGridView dgvDataTiempoServicio;
    }
}


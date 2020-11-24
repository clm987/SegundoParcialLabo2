namespace MenuVenta
{
    partial class PantallaPedidos
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
            this.dgvEnPreparacion = new System.Windows.Forms.DataGridView();
            this.dgvListo = new System.Windows.Forms.DataGridView();
            this.lblPedidosListos = new System.Windows.Forms.Label();
            this.lblTituloPantallaEnPreparacion = new System.Windows.Forms.Label();
            this.lblTituloPantallaPedidosListos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnPreparacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEnPreparacion
            // 
            this.dgvEnPreparacion.AllowUserToAddRows = false;
            this.dgvEnPreparacion.AllowUserToDeleteRows = false;
            this.dgvEnPreparacion.AllowUserToResizeColumns = false;
            this.dgvEnPreparacion.AllowUserToResizeRows = false;
            this.dgvEnPreparacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEnPreparacion.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvEnPreparacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnPreparacion.Location = new System.Drawing.Point(4, 37);
            this.dgvEnPreparacion.Name = "dgvEnPreparacion";
            this.dgvEnPreparacion.RowHeadersVisible = false;
            this.dgvEnPreparacion.Size = new System.Drawing.Size(374, 297);
            this.dgvEnPreparacion.TabIndex = 0;
            // 
            // dgvListo
            // 
            this.dgvListo.AllowUserToAddRows = false;
            this.dgvListo.AllowUserToDeleteRows = false;
            this.dgvListo.AllowUserToResizeColumns = false;
            this.dgvListo.AllowUserToResizeRows = false;
            this.dgvListo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListo.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.dgvListo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListo.Location = new System.Drawing.Point(384, 37);
            this.dgvListo.Name = "dgvListo";
            this.dgvListo.RowHeadersVisible = false;
            this.dgvListo.Size = new System.Drawing.Size(382, 297);
            this.dgvListo.TabIndex = 1;
            // 
            // lblPedidosListos
            // 
            this.lblPedidosListos.AutoSize = true;
            this.lblPedidosListos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedidosListos.Location = new System.Drawing.Point(12, 358);
            this.lblPedidosListos.Name = "lblPedidosListos";
            this.lblPedidosListos.Size = new System.Drawing.Size(213, 18);
            this.lblPedidosListos.TabIndex = 2;
            this.lblPedidosListos.Text = "Todos los pedidos estan listos!";
            // 
            // lblTituloPantallaEnPreparacion
            // 
            this.lblTituloPantallaEnPreparacion.AutoSize = true;
            this.lblTituloPantallaEnPreparacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPantallaEnPreparacion.Location = new System.Drawing.Point(12, 9);
            this.lblTituloPantallaEnPreparacion.Name = "lblTituloPantallaEnPreparacion";
            this.lblTituloPantallaEnPreparacion.Size = new System.Drawing.Size(264, 25);
            this.lblTituloPantallaEnPreparacion.TabIndex = 3;
            this.lblTituloPantallaEnPreparacion.Text = "Pedidos en Preparacion";
            // 
            // lblTituloPantallaPedidosListos
            // 
            this.lblTituloPantallaPedidosListos.AutoSize = true;
            this.lblTituloPantallaPedidosListos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPantallaPedidosListos.Location = new System.Drawing.Point(401, 9);
            this.lblTituloPantallaPedidosListos.Name = "lblTituloPantallaPedidosListos";
            this.lblTituloPantallaPedidosListos.Size = new System.Drawing.Size(318, 25);
            this.lblTituloPantallaPedidosListos.TabIndex = 4;
            this.lblTituloPantallaPedidosListos.Text = "Pedidos Listos para Entregar";
            // 
            // PantallaPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(770, 450);
            this.Controls.Add(this.lblTituloPantallaPedidosListos);
            this.Controls.Add(this.lblTituloPantallaEnPreparacion);
            this.Controls.Add(this.lblPedidosListos);
            this.Controls.Add(this.dgvListo);
            this.Controls.Add(this.dgvEnPreparacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PantallaPedidos";
            this.ShowIcon = false;
            this.Text = "Monitor de Estados de Pedidos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnPreparacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEnPreparacion;
        private System.Windows.Forms.DataGridView dgvListo;
        private System.Windows.Forms.Label lblPedidosListos;
        private System.Windows.Forms.Label lblTituloPantallaEnPreparacion;
        private System.Windows.Forms.Label lblTituloPantallaPedidosListos;
    }
}
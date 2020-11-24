namespace MenuVenta
{
    partial class MenuVentas
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
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dgvPedido = new System.Windows.Forms.DataGridView();
            this.lblDniEmpleado = new System.Windows.Forms.Label();
            this.lblDniCliente = new System.Windows.Forms.Label();
            this.txtDniCliente = new System.Windows.Forms.TextBox();
            this.txtDniEmpleado = new System.Windows.Forms.TextBox();
            this.lblDatosCliente = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.cmbDelivery = new System.Windows.Forms.ComboBox();
            this.btnConfirmarPedido = new System.Windows.Forms.Button();
            this.txtDireccionDlivery = new System.Windows.Forms.TextBox();
            this.lblInstruccionCampoDireccion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeColumns = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(12, 77);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.Size = new System.Drawing.Size(505, 150);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentDoubleClick);
            // 
            // dgvPedido
            // 
            this.dgvPedido.AllowUserToAddRows = false;
            this.dgvPedido.AllowUserToDeleteRows = false;
            this.dgvPedido.AllowUserToResizeColumns = false;
            this.dgvPedido.AllowUserToResizeRows = false;
            this.dgvPedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedido.Location = new System.Drawing.Point(12, 269);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.ReadOnly = true;
            this.dgvPedido.RowHeadersVisible = false;
            this.dgvPedido.Size = new System.Drawing.Size(505, 150);
            this.dgvPedido.TabIndex = 1;
            // 
            // lblDniEmpleado
            // 
            this.lblDniEmpleado.AutoSize = true;
            this.lblDniEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDniEmpleado.Location = new System.Drawing.Point(9, 29);
            this.lblDniEmpleado.Name = "lblDniEmpleado";
            this.lblDniEmpleado.Size = new System.Drawing.Size(186, 18);
            this.lblDniEmpleado.TabIndex = 2;
            this.lblDniEmpleado.Text = "Ingrese el dni del empleado";
            // 
            // lblDniCliente
            // 
            this.lblDniCliente.AutoSize = true;
            this.lblDniCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDniCliente.Location = new System.Drawing.Point(426, 29);
            this.lblDniCliente.Name = "lblDniCliente";
            this.lblDniCliente.Size = new System.Drawing.Size(163, 18);
            this.lblDniCliente.TabIndex = 3;
            this.lblDniCliente.Text = "Ingrese el dni del cliente";
            // 
            // txtDniCliente
            // 
            this.txtDniCliente.Location = new System.Drawing.Point(595, 30);
            this.txtDniCliente.Name = "txtDniCliente";
            this.txtDniCliente.Size = new System.Drawing.Size(144, 20);
            this.txtDniCliente.TabIndex = 4;
            this.txtDniCliente.TextChanged += new System.EventHandler(this.txtDniCliente_TextChanged);
            // 
            // txtDniEmpleado
            // 
            this.txtDniEmpleado.Location = new System.Drawing.Point(212, 27);
            this.txtDniEmpleado.Name = "txtDniEmpleado";
            this.txtDniEmpleado.Size = new System.Drawing.Size(129, 20);
            this.txtDniEmpleado.TabIndex = 5;
            // 
            // lblDatosCliente
            // 
            this.lblDatosCliente.AutoSize = true;
            this.lblDatosCliente.Location = new System.Drawing.Point(535, 77);
            this.lblDatosCliente.Name = "lblDatosCliente";
            this.lblDatosCliente.Size = new System.Drawing.Size(10, 13);
            this.lblDatosCliente.TabIndex = 6;
            this.lblDatosCliente.Text = "I";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(535, 154);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(202, 18);
            this.lblCantidad.TabIndex = 7;
            this.lblCantidad.Text = "Ingrese la cantidad a comprar";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(743, 155);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(47, 20);
            this.txtCantidad.TabIndex = 8;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.Location = new System.Drawing.Point(538, 312);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(131, 18);
            this.lblMonto.TabIndex = 9;
            this.lblMonto.Text = "Monto total pedido";
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Location = new System.Drawing.Point(718, 312);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(0, 13);
            this.lblMontoTotal.TabIndex = 10;
            // 
            // cmbDelivery
            // 
            this.cmbDelivery.FormattingEnabled = true;
            this.cmbDelivery.Location = new System.Drawing.Point(538, 211);
            this.cmbDelivery.Name = "cmbDelivery";
            this.cmbDelivery.Size = new System.Drawing.Size(164, 21);
            this.cmbDelivery.TabIndex = 11;
            this.cmbDelivery.SelectedValueChanged += new System.EventHandler(this.cmbDelivery_SelectedValueChanged);
            // 
            // btnConfirmarPedido
            // 
            this.btnConfirmarPedido.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnConfirmarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarPedido.Location = new System.Drawing.Point(622, 344);
            this.btnConfirmarPedido.Name = "btnConfirmarPedido";
            this.btnConfirmarPedido.Size = new System.Drawing.Size(130, 43);
            this.btnConfirmarPedido.TabIndex = 12;
            this.btnConfirmarPedido.Text = "Confirmar Pedido";
            this.btnConfirmarPedido.UseVisualStyleBackColor = false;
            this.btnConfirmarPedido.Click += new System.EventHandler(this.btnConfirmarPedido_Click);
            // 
            // txtDireccionDlivery
            // 
            this.txtDireccionDlivery.Location = new System.Drawing.Point(541, 255);
            this.txtDireccionDlivery.Name = "txtDireccionDlivery";
            this.txtDireccionDlivery.Size = new System.Drawing.Size(197, 20);
            this.txtDireccionDlivery.TabIndex = 13;
            this.txtDireccionDlivery.Visible = false;
            // 
            // lblInstruccionCampoDireccion
            // 
            this.lblInstruccionCampoDireccion.AutoSize = true;
            this.lblInstruccionCampoDireccion.Location = new System.Drawing.Point(538, 239);
            this.lblInstruccionCampoDireccion.Name = "lblInstruccionCampoDireccion";
            this.lblInstruccionCampoDireccion.Size = new System.Drawing.Size(153, 13);
            this.lblInstruccionCampoDireccion.TabIndex = 14;
            this.lblInstruccionCampoDireccion.Text = "Escriba la direccion de entrega";
            // 
            // MenuVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInstruccionCampoDireccion);
            this.Controls.Add(this.txtDireccionDlivery);
            this.Controls.Add(this.btnConfirmarPedido);
            this.Controls.Add(this.cmbDelivery);
            this.Controls.Add(this.lblMontoTotal);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblDatosCliente);
            this.Controls.Add(this.txtDniEmpleado);
            this.Controls.Add(this.txtDniCliente);
            this.Controls.Add(this.lblDniCliente);
            this.Controls.Add(this.lblDniEmpleado);
            this.Controls.Add(this.dgvPedido);
            this.Controls.Add(this.dgvProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuVentas";
            this.ShowIcon = false;
            this.Text = "Cargar Nuevo Pedido";
            this.Load += new System.EventHandler(this.MenuVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.Label lblDniEmpleado;
        private System.Windows.Forms.Label lblDniCliente;
        private System.Windows.Forms.TextBox txtDniCliente;
        private System.Windows.Forms.TextBox txtDniEmpleado;
        private System.Windows.Forms.Label lblDatosCliente;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.ComboBox cmbDelivery;
        private System.Windows.Forms.Button btnConfirmarPedido;
        private System.Windows.Forms.TextBox txtDireccionDlivery;
        private System.Windows.Forms.Label lblInstruccionCampoDireccion;
    }
}


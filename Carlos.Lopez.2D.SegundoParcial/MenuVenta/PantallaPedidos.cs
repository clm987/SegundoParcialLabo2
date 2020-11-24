using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Threading;

namespace MenuVenta
{
    public partial class PantallaPedidos : Form
    {
        //Genera el hilo que actualizará las pantallas
        public Thread actualizarPantalla;
        public bool hiloVivo = false;

        public PantallaPedidos()
        {
            InitializeComponent();
            lblPedidosListos.Visible = false;
            actualizarPantalla = new Thread(ActualizarPedidos);
            actualizarPantalla.IsBackground = true;
        }
        /// <summary>
        /// Al cargar el formulario comienza el hilo actualización y llama al método que carga los pedidos desde el XLM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Restaurant.EncolarPedidosEnPreparacion();
                dgvEnPreparacion.DataSource = null;
                dgvEnPreparacion.DataSource = Restaurant.PedidosEnPreparacion.ToArray();

                if (!actualizarPantalla.IsAlive)
                {
                    actualizarPantalla.Start();

                }
                else
                {
                    actualizarPantalla.Abort();
                    actualizarPantalla.Start();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método que simula la preparación de los pedidos pasandolos de una cola a la otra cada 4 segundos. 
        /// </summary>
        public void ActualizarPedidos()
        {
            bool continuar = true;
            try
            {
                hiloVivo = true;

                while (continuar == true)
                {
                    ActualizarEnPreparacion();
                    Thread.Sleep(4000);

                    if (Restaurant.PedidosEnPreparacion.Count > 0)
                    {
                        Pedido auxPedidoListo;
                        auxPedidoListo = Restaurant.PedidosEnPreparacion.Dequeue();

                        //Actualiza el EstadoPedido de este pedido en la base de datos
                        HelperBD.ActualizarEstadoPedido(auxPedidoListo);
                        auxPedidoListo.EstadoPedido = Pedido.EEstadoPedido.Listo;
                        Restaurant.PedidosListos.Enqueue(auxPedidoListo);
                        ActualizarEnPreparacion();
                        ActualizarEntregados();
                        Thread.Sleep(4000);
                    }
                    else
                    {
                        //Si la cola no tiene más elementos lo informa por pantalla
                        if (this.lblPedidosListos.InvokeRequired)
                        {
                            this.lblPedidosListos.BeginInvoke((MethodInvoker)delegate ()
                            {
                                lblPedidosListos.Visible = true;
                                this.lblPedidosListos.Text = "Todos los pedidos fueron entregados";
                            });

                        }
                        else
                        {
                            lblPedidosListos.Visible = true;
                            this.lblPedidosListos.Text = "Todos los pedidos fueron entregados";
                        }
                        continuar = false;
                    }
                }

                hiloVivo = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                hiloVivo = false;
            }
        }

        /// <summary>
        /// Llama al método de actualización de los dtgv previa validación antes de la invocacion
        /// </summary>
        private void ActualizarEnPreparacion()
        {
            if (this.dgvEnPreparacion.InvokeRequired)
            {
                this.dgvEnPreparacion.BeginInvoke((MethodInvoker)delegate ()
                {
                    ActualizarPedidosEnPreparacion();
                });
            }
            else
            {
                ActualizarPedidosEnPreparacion();
            }
        }

        /// <summary>
        /// Llama al método de actualizar el dgv de pedidos listos previa validación de si requiere invocacion
        /// </summary>
        private void ActualizarEntregados()
        {
            if (this.dgvListo.InvokeRequired)
            {
                this.dgvListo.BeginInvoke((MethodInvoker)delegate ()
                {
                    ActualizarPedidosEntregados();

                });
            }
            else
            {
                ActualizarPedidosEntregados();

            }
        }

        /// <summary>
        /// Método que actualiza el dataGridView de pedidos en Preparacion
        /// </summary>
        private void ActualizarPedidosEnPreparacion()
        {

            dgvEnPreparacion.DataSource = null;
            dgvEnPreparacion.DataSource = Restaurant.PedidosEnPreparacion.ToArray();
        }

        /// <summary>
        /// Método que actualiza el DataGridView de pedidos listos
        /// </summary>
        private void ActualizarPedidosEntregados()
        {
            dgvListo.DataSource = null;
            dgvListo.DataSource = Restaurant.PedidosListos.ToArray();
        }
    }

}

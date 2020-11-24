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
using Excepciones;

namespace MenuVenta
{
    public partial class MenuVentas : Form
    {
        int auxcantidad = -1;
        PantallaPedidos auxPantallaPedidos = new PantallaPedidos();
        public MenuVentas()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Carga las listas con datos de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuVentas_Load(object sender, EventArgs e)
        {
            Restaurant.CargarListas();
            lblInstruccionCampoDireccion.Visible = false;
            dgvProductos.DataSource = Restaurant.listProductos;
            cmbDelivery.DataSource = Enum.GetValues(typeof(Pedido.ETipoConsumo));

            auxPantallaPedidos.Show();
        }

        /// <summary>
        /// Detecta el cambio en el TextBox de Dni y busca el cliente en la lista de Clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDniCliente_TextChanged(object sender, EventArgs e)
        {
            string auxDni;
            auxDni = Restaurant.BuscarClientePorDni(this.txtDniCliente.Text);
            lblDatosCliente.Text = auxDni;
        }

        /// <summary>
        /// Al hacer Doble Click en un producto del DataGridView se agregan productos al Pedido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Obtiene el id del articulo seleccionado
                int idProductoSeleccionado = (int)dgvProductos.CurrentRow.Cells[0].Value;
                Producto auxProducto = Restaurant.buscarProductoPorId(idProductoSeleccionado);

                //Validacion de datos ingresados
                Validaciones.validarEntradaDni(txtDniCliente.Text);
                Validaciones.validarEntradaCantidad(txtCantidad.Text);
                if (!Restaurant.buscarProductoRepetido(auxProducto))
                {
                    //Si es primera vez que se carda lo agrega a la lista
                    Restaurant.ConfirmarStock(idProductoSeleccionado, auxcantidad);
                    int.TryParse(txtCantidad.Text, out auxcantidad);
                    Restaurant.listaDeItemPedido.Add(new ItemPedido(auxProducto.Nombre, auxProducto.Marca, auxProducto.PrecioUnitario, int.Parse(txtCantidad.Text), auxProducto.IdProducto));
                    lblMontoTotal.Text = Restaurant.listaDeItemPedido.CalcularMontoPedido().ToString();
                }
                else
                {
                    //Si fue cargado previamente solo actualiza la cantidad
                    for (int i = 0; i < Restaurant.listaDeItemPedido.Count; i++)
                    {
                        if (Restaurant.listaDeItemPedido[i].CodigoItem == idProductoSeleccionado)
                        {
                            Restaurant.ConfirmarStock(idProductoSeleccionado, (auxcantidad + Restaurant.listaDeItemPedido[i].CantidadItem));
                            Restaurant.listaDeItemPedido[i].CantidadItem += auxcantidad;
                        }
                    }
                    lblMontoTotal.Text = Restaurant.listaDeItemPedido.CalcularMontoPedido().ToString();
                }
                dgvPedido.DataSource = null;
                dgvPedido.DataSource = Restaurant.listaDeItemPedido;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Producto no encontrado");
            }
            catch (StockException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ImputException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }

        /// <summary>
        /// Detecta un cambio en el TextBox cantidad y carga el atributo auxcantidad para visibilizarlo en todos los métodos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            int cantidadseleccionada = 0;

            if (int.TryParse(txtCantidad.Text, out cantidadseleccionada))
            {
                auxcantidad = cantidadseleccionada;
            }
        }

        /// <summary>
        /// Realiza la funcionalidad de confirmar un pedido 
        /// </summary>
        public void ConfirmarPedido()
        {

            try
            {
                ///Valida datos de entrada que serán necesarios para generar un pedido
                Validaciones.validarEntradaDni(txtDniCliente.Text);
                Validaciones.validarEntradaDni(txtDniEmpleado.Text);
                int auxIdEmpleado = Restaurant.DevolverEmpleadoPorDni(txtDniEmpleado.Text).idEmpleado;
                string auxTipoConsumo = cmbDelivery.SelectedItem.ToString();
                string auxEstadoPedido = Pedido.EEstadoPedido.Preparando.ToString();
                float.TryParse(lblMontoTotal.Text, out float auxMonto);
                int.TryParse(txtDniCliente.Text, out int dniCliente);

                ///Si se encontró el cliente solicitado procede a cargar los datos para el pedido
                if (lblDatosCliente.Text != "Cliente no Encontrado")
                {
                    string auxDni = txtDniCliente.Text;
                    Cliente clientePedidoActual = Restaurant.DevolverClientePorDni(auxDni);

                    if (!(clientePedidoActual is null) && auxIdEmpleado > 0)
                    {
                        ///Con los datos ingresados genera el pedido en la base de datos y lo devuelve para cargarlo
                        Pedido pedidoActual = HelperBD.GenerarPedido(auxIdEmpleado, dniCliente, auxTipoConsumo, auxEstadoPedido, auxMonto);
                        Restaurant.PedidoReciente = pedidoActual;

                        //Muestra el numero de orden (idPedido) por pantalla si es para consumo en el local
                        if (pedidoActual.TipoConsumo == Pedido.ETipoConsumo.Insitu)
                        {
                            MessageBox.Show(String.Concat("El numero de orden es:", pedidoActual.IdPedido.ToString()));
                        }

                        //Se suscribe el método EncolarPedido al delegado nuevopedido
                        Restaurant.nuevoPedido += Restaurant.EncolarPedidoReciente;

                        //Llama al método que invoca al evento nuevopedido pasandole el pedido actual
                        Restaurant.InvocarEvento(pedidoActual);

                        Restaurant.listaDePedidos = HelperBD.TraerPedidos();

                        for (int i = 0; i < Restaurant.listaDeItemPedido.Count; i++)
                        {
                            Restaurant.ModificarCantidad(Restaurant.listaDeItemPedido[i].CodigoItem, Restaurant.listaDeItemPedido[i].CantidadItem);
                        }
                        Restaurant.listaDeProductos = HelperBD.TraerProductos();
                        dgvProductos.DataSource = null;
                        dgvProductos.DataSource = Restaurant.listProductos;
                        Restaurant.Guardar(Restaurant.listaDePedidos);

                        Restaurant.listaDeItemPedido.Clear();
                        dgvPedido.DataSource = null;
                        dgvPedido.DataSource = Restaurant.listaDeItemPedido;

                        ///Si el pedido es para Delivery genera un ticket con los datos necesarios
                        if (cmbDelivery.Text == Pedido.ETipoConsumo.Delivery.ToString())
                        {
                            Restaurant.DireccionDelivery = txtDireccionDlivery.Text;
                            if (Restaurant.GenerarTicketDelivery(pedidoActual, lblDatosCliente.Text))
                            {
                                MessageBox.Show("Se generó correctamente el ticket de delivery");
                            }
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Cliente no encontrado");

            }
            catch (ImputException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un Error. Valide los datos ingresados");

            }

        }

        /// <summary>
        /// Método del evento click del boton confirmar pedido. Llama al método confirmarPedido y valida el estado del hilo de actualizacion de pantalla y actualizar en caso que se haya terminado el  proceso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            ConfirmarPedido();
            if (!auxPantallaPedidos.hiloVivo)
            {
                auxPantallaPedidos.ActualizarPedidos();
            }
        }

        /// <summary>
        /// Si seleccionó Delivery en el comboBox visibiliza el campo para cargar la dirección. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDelivery_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbDelivery.Text == Pedido.ETipoConsumo.Delivery.ToString())
            {
                txtDireccionDlivery.Visible = true;
                lblInstruccionCampoDireccion.Visible = true;

            }
        }


    }
}

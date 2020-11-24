using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Archivos;
using Excepciones;

namespace Entidades
{
    public delegate void DelegadoNuevoPedido(Pedido auxPedido);
    public static class Restaurant
    {
        #region Listas y Propiedades
        public static event DelegadoNuevoPedido nuevoPedido;
        public static List<Producto> listaDeProductos;
        public static List<Cliente> listaDeClientes;
        public static List<Empleado> listaDeEmpleados;
        public static List<ItemPedido> listaDeItemPedido;
        public static List<Pedido> listaDePedidos;
        public static List<Pedido> listaDePruebas;
        public static Queue<Pedido> colaDePedidosEnPreparacion;
        public static Queue<Pedido> colaDePedidosListos;
        public static string direccionDelivery;
        private static Pedido pedidoAEncolar;

        /// <summary>
        /// Propiedad que permite acceder al pedido actual
        /// </summary>
        public static Pedido PedidoReciente
        {
            get { return pedidoAEncolar; }
            set { pedidoAEncolar = value; }
        }

        /// <summary>
        /// Queue de pedidos que tienen el campo EstadoPedido cargado como en preparacion
        /// </summary>
        public static Queue<Pedido> PedidosEnPreparacion
        {
            get { return colaDePedidosEnPreparacion; }
        }

        /// <summary>
        /// Queue de pedidos que ya están listos
        /// </summary>
        public static Queue<Pedido> PedidosListos
        {
            get { return colaDePedidosListos; }
        }

        /// <summary>
        /// Propiedad el atributo direccionDelivery
        /// </summary>
        public static string DireccionDelivery
        {
            get
            {
                return direccionDelivery;
            }
            set
            {
                direccionDelivery = value;
            }
        }

        /// <summary>
        /// Obtiene la lista de empleados
        /// </summary>
        public static List<Empleado> listEmpleados
        {
            get { return listaDeEmpleados; }
        }

        /// <summary>
        /// Obtiene la lista de Clientes
        /// </summary>
        public static List<Cliente> listClientes
        {
            get { return listaDeClientes; }
        }

        /// <summary>
        /// Obtiene la lista de productos
        /// </summary>
        public static List<Producto> listProductos
        {
            get { return listaDeProductos; }
        }

        /// <summary>
        /// Obtiene la lista de pedidos
        /// </summary>
        public static List<Pedido> listPedidos
        {
            get { return listaDePedidos; }
        }

        #endregion

        #region Constructor estático
        /// <summary>
        /// Se instancias en este constructor estático por defecto las listas con las que trabajará la aplicación
        /// </summary>
        static Restaurant()
        {
            listaDeProductos = new List<Producto>();
            listaDeClientes = new List<Cliente>();
            listaDeEmpleados = new List<Empleado>();
            listaDeItemPedido = new List<ItemPedido>();
            listaDePedidos = new List<Pedido>();
            listaDePruebas = new List<Pedido>();
            colaDePedidosEnPreparacion = new Queue<Pedido>();
            colaDePedidosListos = new Queue<Pedido>();
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Método estatico que carga las listas con datos provenientes de la base de datos
        /// </summary>
        public static void CargarListas()
        {
            listaDeProductos = HelperBD.TraerProductos();
            listaDeClientes = HelperBD.TraerClientes();
            listaDeEmpleados = HelperBD.TraerEmpleados();
            listaDePedidos = HelperBD.TraerPedidos();

        }

        /// <summary>
        /// Método que permite buscar un cliente en la lista de clientes partiendo del dato DNI
        /// </summary>
        /// <param name="dniCliente">Parámetro de tipo string con el dni a buscar</param>
        /// <returns>retorna un string con los datos del Cliente encontrado. Sino retorna el mensaje "Cliente no Encontrado"</returns>
        public static string BuscarClientePorDni(string dniCliente)
        {
            string retValue = "Cliente no Encontrado";

            foreach (Cliente item in listaDeClientes)
            {

                if (int.TryParse(dniCliente, out int auxDni))
                {

                    if (item.Dni == auxDni)
                    {
                        retValue = item.Mostrar();
                        break;
                    }

                }

            }

            return retValue;
        }

        /// <summary>
        /// Método que devuelve un Producto al buscar en la lista de productos por Id
        /// </summary>
        /// <param name="idProducto">ID del prodcuto que se quiere buscar</param>
        /// <returns>Retorna un objeto de tipo Producto</returns>
        public static Producto buscarProductoPorId(int idProducto)
        {
            Producto auxProducto = null;
            for (int i = 0; i < Restaurant.listaDeProductos.Count; i++)
            {
                if (Restaurant.listaDeProductos[i].IdProducto == idProducto)
                {
                    auxProducto = Restaurant.listaDeProductos[i];
                }
            }
            return auxProducto;
        }

        /// <summary>
        /// Método que establece si un producto es igual a otro previamente cargado en la Lista de Productos
        /// </summary>
        /// <param name="unProducto">Objeto de tipo Producto</param>
        /// <returns>retorna un booleano para control de ejecución</returns>
        public static bool buscarProductoRepetido(Producto unProducto)
        {
            bool retValue = false;
            if (Restaurant.listaDeItemPedido.Count == 0)
            {
                return retValue;

            }

            for (int i = 0; i < Restaurant.listaDeItemPedido.Count; i++)
            {
                if (unProducto.IdProducto == Restaurant.listaDeItemPedido[i].CodigoItem)
                {
                    retValue = true;
                }
            }
            return retValue;
        }

        /// <summary>
        /// Método que confirma si existe suficiente stock de un producto determinado 
        /// </summary>
        /// <param name="idProductoAValidar">Id del producto a consultar en la lista</param>
        /// <param name="cantidaProductoSeleccionado">CEntero que representa la cantidad del producto que se solicita</param>
        public static void ConfirmarStock(int idProductoAValidar, int cantidaProductoSeleccionado)
        {
            StockException ex = new StockException("No hay suficiente stock");

            foreach (Producto item in listProductos)
            {
                if (item.IdProducto == idProductoAValidar)
                {
                    if (item.Cantidad > 0)
                    {
                        if (cantidaProductoSeleccionado <= item.Cantidad)
                        {
                            continue;
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Método que actualiza las cantidades de productos que han sido solicitados en un Pedido
        /// </summary>
        /// <param name="productoseleccionadoId">Id del producto a modificar</param>
        /// <param name="cantidadamodificar">Cantidad solicitada de un producto</param>
        /// <returns></returns>
        public static bool ModificarCantidad(int productoseleccionadoId, int cantidadamodificar)
        {
            bool retValue = false;

            if (productoseleccionadoId > 0 && cantidadamodificar > 0)
            {

                for (int i = 0; i < Restaurant.listaDeProductos.Count; i++)
                {
                    if (Restaurant.listaDeProductos[i].IdProducto == productoseleccionadoId)
                    {
                        Restaurant.listaDeProductos[i].Cantidad -= cantidadamodificar;
                        Restaurant.listaDeProductos[i].ModificarStockProductos(Restaurant.listaDeProductos[i]);
                    }
                }
                retValue = true;
            }

            return retValue;
        }
        /// <summary>
        /// Método que devuelve un objeto de tipo Cliente buscando en la lista por Dni
        /// </summary>
        /// <param name="dniCliente">String que representa el Dni del cliente a buscar</param>
        /// <returns>Devuelve un objeto de tipo Cliente</returns>
        public static Cliente DevolverClientePorDni(string dniCliente)
        {
            Cliente retValue = null;

            foreach (Cliente item in listaDeClientes)
            {

                if (int.TryParse(dniCliente, out int auxDni))
                {

                    if (item.Dni == auxDni)
                    {
                        retValue = item;
                        return retValue;
                    }

                }

            }
            return retValue;
        }

        /// <summary>
        /// Método que devuelve un objeto de tipo Empleado buscando por Dni
        /// </summary>
        /// <param name="dniEmpleado">String que represente el dni del empleado a buscar</param>
        /// <returns>Devuelve un Objeto de tipo Empleado</returns>
        public static Empleado DevolverEmpleadoPorDni(string dniEmpleado)
        {
            Empleado retValue = null;

            foreach (Empleado item in listaDeEmpleados)
            {

                if (int.TryParse(dniEmpleado, out int auxDni))
                {

                    if (item.Dni == auxDni)
                    {
                        retValue = item;
                        return retValue;
                    }

                }

            }
            return retValue;
        }
        /// <summary>
        /// Método que arma el StringBuilder que contendrá los datos a imprimir en el ticket de Delivery
        /// </summary>
        /// <param name="pedidoActualDelivery">Objeto de tipo Pedido con los datos a imprimir</param>
        /// <param name="clientePedido">String con los datos del cliente que realiza el pedido</param>
        /// <returns>Devuelve un bolleano para control de ejecución</returns>
        public static bool GenerarTicketDelivery(Pedido pedidoActualDelivery, string clientePedido)
        {
            string rutaDeArchivo = String.Format("{0}\\ticketDelivery.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Texto ArchivoDeTexto = new Texto();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------DATOS DEL CLIENTE-------------");
            sb.AppendLine($"{clientePedido}");
            sb.AppendLine("----------DIRECCION DE ENTREGA-------------");
            sb.AppendLine($"{DireccionDelivery}");
            sb.AppendLine("----------DETALLE DEL PEDIDO-------------");
            foreach (ItemPedido item in listaDeItemPedido)
            {
                sb.AppendLine(String.Format("{0,-20}|{1,10}", item.NombreItem, item.PrecioItem));
            }

            sb.AppendLine("------------------------------------------");
            sb.AppendLine($"MONTO TOTAL: {pedidoActualDelivery.MontoPedido.ToString()}");

            return ArchivoDeTexto.Guardar(rutaDeArchivo, sb.ToString());
        }

        /// <summary>
        /// Método que habilita los datos para ser guardados en un archivo con formato XML
        /// </summary>
        /// <param name="ListaActualDePedidos">Lista de pedidos a guardar en el archivo</param>
        /// <returns>Devuelve un booleano para control de ejecucion</returns>
        public static bool Guardar(List<Pedido> ListaActualDePedidos)
        {
            string path = String.Format("{0}\\listaDePedidos.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Xml<List<Pedido>> auxPedido = new Xml<List<Pedido>>();

            return auxPedido.Guardar(path, ListaActualDePedidos);
        }

        /// <summary>
        /// Mñetodo que toma los datos del archivo XML con los que se cargará la lista de pedidos
        /// </summary>
        /// <returns>Devuelve una lista de pedidos</returns>
        public static List<Pedido> Leer()
        {
            List<Pedido> datos = new List<Pedido>();
            string path = String.Format("{0}\\listaDePedidos.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Xml<List<Pedido>> auxListaPedidos = new Xml<List<Pedido>>();

            auxListaPedidos.Leer(path, out datos);

            return datos;

        }

        /// <summary>
        /// Método que agrega pedidos en preparacion y con tipo de consumo Insitu a la Cola de pedidos en preparación
        /// </summary>
        public static void EncolarPedidosEnPreparacion()
        {
            listaDePedidos = Leer();

            foreach (Pedido estePedido in listaDePedidos)
            {
                if (estePedido.EstadoPedido == Pedido.EEstadoPedido.Preparando && estePedido.TipoConsumo == Pedido.ETipoConsumo.Insitu)
                {
                    colaDePedidosEnPreparacion.Enqueue(estePedido);
                }

            }
        }

        /// <summary>
        /// Método asociado al evento encolar pedido y que permite sumar un pedido a la cola de pedidos en preparación
        /// </summary>
        /// <param name="auxPedido"></param>
        public static void EncolarPedidoReciente(Pedido auxPedido)
        {
            colaDePedidosEnPreparacion.Enqueue(auxPedido);
        }

        /// <summary>
        /// Método que visibiliza la invocación al evento nuevoPedido tomando como parámetro un Pedido
        /// </summary>
        /// <param name="auxPedido"></param>
        public static void InvocarEvento(Pedido auxPedido)
        {
            nuevoPedido.Invoke(auxPedido);
        }
        #endregion
    }
}

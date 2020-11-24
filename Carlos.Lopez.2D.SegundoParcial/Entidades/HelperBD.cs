using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    /// <summary>
    /// Clase estatica que maneja las consultas a la base de datos Restaurant
    /// </summary>

    public static class HelperBD
    {
        #region Atributos y Constantes
        /// <summary>
        /// Define el objeto conexión que utilizará en las consultas
        /// </summary>
        private static SqlConnection sqlconexion;
        /// <summary>
        /// Define el objeto SqlCommand que será usado para ejecutar las consultas
        /// </summary>
        private static SqlCommand sqlcomando;
        /// <summary>
        /// Define la dirección de conexión con la base datos
        /// </summary>
        const string STRINGCONNEC = "Data Source=.\\sqlexpress; Initial Catalog=Restaurant; Integrated Security=True;";
        #endregion

        #region Constructor Estático
        static HelperBD()
        {
            sqlconexion = new SqlConnection();
            sqlconexion.ConnectionString = STRINGCONNEC;
            sqlcomando = new SqlCommand();
            sqlcomando.Connection = sqlconexion;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Método que realiza una consulta Select a la tabla de Empleado de la base de datos
        /// </summary>
        /// <returns>Devuelve una lista de empleados</returns>
        public static List<Empleado> TraerEmpleados()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            string consulta = " Select * from Empleado ";

            try
            {
                sqlcomando.CommandText = consulta;
                sqlconexion.Open();
                SqlDataReader dr = sqlcomando.ExecuteReader();

                while (dr.Read())
                {
                    listaEmpleados.Add(new Empleado(dr["Nombre"].ToString(), dr["Apellido"].ToString(), int.Parse(dr["Dni"].ToString()), dr["Usuario"].ToString(), dr["ClaveAcceso"].ToString(), int.Parse(dr["Id"].ToString())));
                }

                return listaEmpleados;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }

        /// <summary>
        /// Método que realiza una consulta Select a la tabla de Cliente de la base de datos
        /// </summary>
        /// <returns>Devuelve una lista de Clientes</returns>
        public static List<Cliente> TraerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string consulta = " Select * from Cliente ";

            try
            {
                sqlcomando.CommandText = consulta;
                sqlconexion.Open();
                SqlDataReader dr = sqlcomando.ExecuteReader();

                while (dr.Read())
                {
                    listaClientes.Add(new Cliente(dr["Nombre"].ToString(), dr["Apellido"].ToString(), int.Parse(dr["Dni"].ToString()), int.Parse(dr["Id"].ToString())));
                }

                return listaClientes;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }

        /// <summary>
        /// Método que realiza una consulta Select a la tabla de Producto de la base de datos
        /// </summary>
        /// <returns>Devuelve una lista de Productos</returns>
        public static List<Producto> TraerProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            string consulta = " Select * from Producto ";

            try
            {
                sqlcomando.CommandText = consulta;
                sqlconexion.Open();
                SqlDataReader dr = sqlcomando.ExecuteReader();

                while (dr.Read())
                {
                    string tipoProducto = dr["Tipo"].ToString();

                    if (tipoProducto == "Cocina")
                    {
                        listaProductos.Add(new ProductoCocina(dr["Nombre"].ToString(), float.Parse(dr["Precio"].ToString()), int.Parse(dr["Stock"].ToString()), dr["Marca"].ToString(), int.Parse(dr["Id"].ToString())));

                    }
                    else
                    {
                        listaProductos.Add(new ProductoPostre(dr["Nombre"].ToString(), float.Parse(dr["Precio"].ToString()), int.Parse(dr["Stock"].ToString()), dr["Marca"].ToString(), int.Parse(dr["idProducto"].ToString())));
                    }
                }

                return listaProductos;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }

        /// <summary>
        /// Método que realiza una consulta Select a la tabla de Pedido de la base de datos
        /// </summary>
        /// <returns>Devuelve una lista de Pedidos</returns>
        public static List<Pedido> TraerPedidos()
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            string consulta = " Select * from Pedido order by Id";

            try
            {
                sqlcomando.CommandText = consulta;
                sqlconexion.Open();
                SqlDataReader dr = sqlcomando.ExecuteReader();

                while (dr.Read())
                {
                    string auxEstadoPedido = dr["EstadoPedido"].ToString();

                    switch (auxEstadoPedido)
                    {
                        case ("Preparando"):
                            if (dr["TipoConsumo"].ToString() == "Delivery")
                            {
                                listaPedidos.Add(new Pedido(int.Parse(dr["Id"].ToString()), int.Parse(dr["IdEmpleado"].ToString()), int.Parse(dr["DniCliente"].ToString()), float.Parse(dr["Monto"].ToString()), Pedido.EEstadoPedido.Preparando, Pedido.ETipoConsumo.Delivery));
                            }
                            else
                            {
                                listaPedidos.Add(new Pedido(int.Parse(dr["Id"].ToString()), int.Parse(dr["IdEmpleado"].ToString()), int.Parse(dr["DniCliente"].ToString()), float.Parse(dr["Monto"].ToString()), Pedido.EEstadoPedido.Preparando, Pedido.ETipoConsumo.Insitu));
                            }
                            break;
                        case ("Listo"):
                            if (dr["TipoConsumo"].ToString() == "Delivery")
                            {
                                listaPedidos.Add(new Pedido(int.Parse(dr["Id"].ToString()), int.Parse(dr["IdEmpleado"].ToString()), int.Parse(dr["DniCliente"].ToString()), float.Parse(dr["Monto"].ToString()), Pedido.EEstadoPedido.Listo, Pedido.ETipoConsumo.Delivery));
                            }
                            else
                            {
                                listaPedidos.Add(new Pedido(int.Parse(dr["Id"].ToString()), int.Parse(dr["IdEmpleado"].ToString()), int.Parse(dr["DniCliente"].ToString()), float.Parse(dr["Monto"].ToString()), Pedido.EEstadoPedido.Listo, Pedido.ETipoConsumo.Insitu));
                            }
                            break;
                        case ("Entregado"):
                            if (dr["TipoConsumo"].ToString() == "Delivery")
                            {
                                listaPedidos.Add(new Pedido(int.Parse(dr["Id"].ToString()), int.Parse(dr["IdEmpleado"].ToString()), int.Parse(dr["DniCliente"].ToString()), float.Parse(dr["Monto"].ToString()), Pedido.EEstadoPedido.Entregado, Pedido.ETipoConsumo.Delivery));
                            }
                            else
                            {
                                listaPedidos.Add(new Pedido(int.Parse(dr["Id"].ToString()), int.Parse(dr["IdEmpleado"].ToString()), int.Parse(dr["DniCliente"].ToString()), float.Parse(dr["Monto"].ToString()), Pedido.EEstadoPedido.Entregado, Pedido.ETipoConsumo.Insitu));
                            }
                            break;
                        default:
                            break;
                    }
                }
                return listaPedidos;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }

        /// <summary>
        /// Método que realiza un Update en la columna Stock de la tabla de Productos de la Base de datos 
        /// </summary>
        /// <param name="unProducto">Recibe un objeto de tipo Producto</param>
        /// <returns>Devuelve un booleano para control de ejecucion</returns>
        public static bool ActualizarStockProducto(Producto unProducto)
        {
            string consulta = "Update Producto Set Stock = @Stock where Id = @auxID";
            bool retValue = false;
            try
            {
                sqlcomando.CommandText = consulta;
                sqlcomando.Parameters.Clear();
                sqlcomando.Parameters.Add(new SqlParameter("@Stock", unProducto.Cantidad));
                sqlcomando.Parameters.Add(new SqlParameter("@auxID", unProducto.IdProducto));

                sqlconexion.Open();
                int retorno = sqlcomando.ExecuteNonQuery();
                retValue = true;

                return retValue;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }

        /// <summary>
        /// Método que realiza un Update a la columna EstadoPedido de la tabla Pedido
        /// </summary>
        /// <param name="unPedido">Recibe un objeto de tipo Pedido</param>
        /// <returns>Devuelve un bolleano para control de ejecución</returns>
        public static bool ActualizarEstadoPedido(Pedido unPedido)
        {
            string consulta = "Update Pedido Set EstadoPedido = @EstadoPedido where Id = @auxID";
            bool retValue = false;
            try
            {
                sqlcomando.CommandText = consulta;
                sqlcomando.Parameters.Clear();
                sqlcomando.Parameters.Add(new SqlParameter("@EstadoPedido", Pedido.EEstadoPedido.Listo.ToString()));
                sqlcomando.Parameters.Add(new SqlParameter("@auxID", unPedido.IdPedido));

                sqlconexion.Open();
                int retorno = sqlcomando.ExecuteNonQuery();
                retValue = true;

                return retValue;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }

        /// <summary>
        /// Método que realiza un Insert en la tabla de Pedidos y devuelve el pedido generado con el Id más alto
        /// </summary>
        /// <param name="auxIdEmpleado">entero que representa el Id de Empleado</param>
        /// <param name="auxDniCliente">Entero que representa el Dni del cliente</param>
        /// <param name="auxTipoConsumo">String que representa si el pedido es Delivery o Insitu</param>
        /// <param name="auxEstadoPedido">String que representa si el pedido está en preparación, listo o entregado </param>
        /// <param name="auxMonto">float que representa el monto del pedido</param>
        /// <returns></returns>
        public static Pedido GenerarPedido(int auxIdEmpleado, int auxDniCliente, string auxTipoConsumo, string auxEstadoPedido, float auxMonto)
        {
            Pedido auxPedido = null;
            List<Pedido> auxListaPedido = new List<Pedido>();

            string consultaInsert = "INSERT INTO Pedido ([IdEmpleado],[DniCliente],[TipoConsumo] ,[EstadoPedido],[Monto]) VALUES (@IdEmpleado ,@DniCliente,@TipoConsumo, @EstadoPedido,@Monto)";
            try

            {
                sqlcomando.CommandText = consultaInsert;
                sqlcomando.Parameters.Clear();
                sqlcomando.Parameters.Add(new SqlParameter("@IdEmpleado", auxIdEmpleado));
                sqlcomando.Parameters.Add(new SqlParameter("@DniCliente", auxDniCliente));
                sqlcomando.Parameters.Add(new SqlParameter("@TipoConsumo", auxTipoConsumo));
                sqlcomando.Parameters.Add(new SqlParameter("@EstadoPedido", auxEstadoPedido));
                sqlcomando.Parameters.Add(new SqlParameter("@Monto", auxMonto));

                sqlconexion.Open();
                int retorno = sqlcomando.ExecuteNonQuery();
                if (retorno > 0)
                {
                    sqlconexion.Close();
                    auxListaPedido = TraerPedidos();
                    if (auxListaPedido.Count > 0)
                    {
                        for (int i = 0; i < auxListaPedido.Count; i++)
                        {
                            if (i == (auxListaPedido.Count - 1))
                            {
                                auxPedido = auxListaPedido[i];
                            }
                        }
                    }
                }

                return auxPedido;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Pedido
    {
        #region Atributos
        private int idPedido;
        private int idEmpleado;
        private int dniCliente;
        private float montoPedido;
        private EEstadoPedido estadoPedido;
        private ETipoConsumo tipoConsumo;
        /// <summary>
        /// Enumerado del estado en que se encuentra un pedido: Preparando, Listo o Entregado si se trata de Delivery
        /// </summary>
        public enum EEstadoPedido
        {
            Preparando,
            Listo,
            Entregado
        }
        /// <summary>
        /// Enumerado que define si un pedido será para consumo en el local (Insitu) o para entrega Delivery
        /// </summary>
        public enum ETipoConsumo
        {
            Insitu,
            Delivery
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad el atributo estado.
        /// </summary>
        public EEstadoPedido EstadoPedido
        {
            get
            {
                return this.estadoPedido;
            }
            set
            {
                this.estadoPedido = value;
            }
        }

        /// <summary>
        /// Propiedad el atributo de tipo Enum TipoConsumo
        /// </summary>
        public ETipoConsumo TipoConsumo
        {
            get
            {
                return this.tipoConsumo;
            }
            set
            {
                this.tipoConsumo = value;
            }
        }

        /// <summary>
        /// Propiedad el atributo Id de Pedido
        /// </summary>
        public int IdPedido
        {
            get
            {
                return this.idPedido;
            }
            set
            {
                this.idPedido = value;
            }
        }

        /// <summary>
        /// Propiedad el atributo Id de Empleado
        /// </summary>
        public int IdEmpleado
        {
            get
            {
                return this.idEmpleado;
            }
            set
            {
                this.idEmpleado = value;
            }
        }

        /// <summary>
        /// Propiedad el atributo Dni del cliente
        /// </summary>
        public int DniCliente
        {
            get
            {
                return this.dniCliente;
            }
            set
            {
                this.dniCliente = value;
            }
        }

        /// <summary>
        /// Propiedad el atributo Monto del pedido
        /// </summary>
        public float MontoPedido
        {
            get
            {
                return this.montoPedido;
            }
            set
            {
                this.montoPedido = value;
            }
        }

        #endregion

        #region Constructores

        public Pedido()
        {

        }

        public Pedido(int idPedido, int idEmpleado, int dniCliente, float monto, EEstadoPedido estadoPedido, ETipoConsumo tipoConsumo)
        {
            this.montoPedido = monto;
            this.idPedido = idPedido;
            this.idEmpleado = idEmpleado;
            this.dniCliente = dniCliente;
            this.estadoPedido = estadoPedido;
            this.tipoConsumo = tipoConsumo;
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Sobrecarga del operador == para verificar si un paquete tiene el mismo ID que otro.
        /// </summary>
        /// <param name="p1">Primer paquete a comparar.</param>
        /// <param name="p2">Segundo paquete a comparar.</param>
        /// <returns>Retorna verdadero si los paquetes tienen el mismo ID, caso contrario retorna falso.</returns>
        public static bool operator ==(Pedido unPedido, Pedido otroPedido)
        {
            return (unPedido.IdPedido == otroPedido.IdPedido);
        }

        /// <summary>
        /// Sobrecarga del operador != para verificar si un paquete tiene el mismo ID que otro.
        /// </summary>
        /// <param name="p1">Primer paquete a comparar.</param>
        /// <param name="p2">Segundo paquete a comparar.</param>
        /// <returns>Retorna verdadero si los paquetes no tienen el mismo ID, caso contrario retorna falso.</returns>

        public static bool operator !=(Pedido unPedido, Pedido otroPedido)
        {
            return !(unPedido == otroPedido);
        }
        #endregion
    }
}

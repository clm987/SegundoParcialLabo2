using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace System.Collections.Generic
{
    public static class ListExtension
    {
        /// <summary>
        /// Método de extensión para calcular el monto de un pedido 
        /// </summary>
        /// <param name="productosSeleccionadosPedido">Recibe una lista de ItemPedido</param>
        /// <returns></returns>
        public static float CalcularMontoPedido(this List<ItemPedido> productosSeleccionadosPedido)
        {
            float total = 0;
            for (int i = 0; i < productosSeleccionadosPedido.Count; i++)
            {
                total += productosSeleccionadosPedido[i].CantidadItem * productosSeleccionadosPedido[i].PrecioItem;
            }

            return total;
        }
    }
}

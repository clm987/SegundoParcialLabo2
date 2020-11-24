using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ItemPedido
    {
        #region Atributos y propiedades
        private string nombre;
        private string marca;
        private float precio;
        private int cantidad;
        private int idProducto;

        public string NombreItem
        {
            get { return nombre; }
        }
        public string MarcaItem
        {
            get { return marca; }
        }
        public float PrecioItem
        {
            get { return precio; }
        }
        public int CodigoItem
        {
            get { return idProducto; }
        }
        public int CantidadItem
        {
            get { return cantidad; }
            set { this.cantidad = value; }
        }
        #endregion

        #region Contructor
        public ItemPedido(string nombre, string marca, float precio, int cantidad, int idProducto)
        {
            this.nombre = nombre;
            this.marca = marca;
            this.precio = precio;
            this.cantidad = cantidad;
            this.idProducto = idProducto;
        }
        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoPostre : Producto
    {
        #region Propiedades

        public override string Marca
        {
            get { return base.marca; }
        }

        public override string Nombre
        {
            get { return base.nombre; }
        }

        public override float PrecioUnitario
        {
            get { return base.precioUnitario; }
        }

        public override int Cantidad
        {
            get { return base.cantidad; }
            set { this.cantidad = value; }
        }

        public override int IdProducto
        {
            get { return base.idProducto; }
        }

        public override ETipoDeProducto TipoDeProducto
        {
            get { return Producto.ETipoDeProducto.Postre; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// /Sobrecarga del contructor de la clase base que genera el Id único auto-incremental
        /// </summary>
        /// <param name="nombre">string que representa el nombre del producto</param>
        /// <param name="precioUnitario">float que representa el precio del producto</param>
        /// <param name="cantidad">entero que representa la cantidad del producto</param>
        /// <param name="marca">string que representa la marca del product</param>
        public ProductoPostre(string nombre, float precioUnitario, int cantidad, string marca, int IdProductoPostre) : base(nombre, precioUnitario, cantidad, marca, IdProductoPostre)
        {

        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Sobrecarga del operador != para validar si dos objetos son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unProductoV"></param>
        /// <param name="otroProductoV"></param>
        /// <returns></returns>
        public static bool operator ==(ProductoPostre unProductoP, ProductoPostre otroProductoP)
        {
            return (unProductoP.IdProducto == otroProductoP.IdProducto);
        }

        /// <summary>
        /// Sobrecarga del operador != para validar si dos objetos NO son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unProductoV"></param>
        /// <param name="otroProductoV"></param>
        /// <returns></returns>
        public static bool operator !=(ProductoPostre unProductoP, ProductoPostre otroProductoP)
        {
            return !(unProductoP.IdProducto == otroProductoP.IdProducto);
        }


        #endregion

        #region Métodos
        /// <summary>
        /// Override del método virtual que permite devolver los datos de un Producto del tipo ProductoKiosko en tipo string
        /// </summary>
        /// <returns>string con los datos del producto</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(IdProducto.ToString());

            return sb.ToString();
        }
        #endregion
    }
}

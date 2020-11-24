using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Excepciones;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class TestExcepciones
    {
        /// <summary>
        /// Método de test unitario que evalúa que se arroje una ImputException al cargar un DNI invalido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ImputException))]
        public void TestValidarDni()
        {
            Validaciones.validarEntradaDni("lalalala");
        }


        /// <summary>
        /// Método de test unitario que evalúa que se arroje una ImputException al cargar un cantidad Invalida
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ImputException))]
        public void TestValidarCantidad()
        {
            Validaciones.validarEntradaCantidad("");
        }

        /// <summary>
        /// Método de test unitario que evalúa que se arroje una StockException al cargar un cantidad superior al stock
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(StockException))]
        public void TestValidarStockInsuficiente()
        {
            //  Arrange
            ProductoCocina auxProducto = new ProductoCocina("Papas", 125, 0, "Propia", 5);
            List<Producto> auxListaProducto = new List<Producto>();
            Restaurant.listaDeProductos.Add(auxProducto);

            //Act
            Restaurant.ConfirmarStock(5,1000);

        }
    }
}

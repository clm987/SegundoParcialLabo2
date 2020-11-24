using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{

    [TestClass]
    public class TestVarios
    {
        /// <summary>
        /// Método de prueba para validar que el método buscarProductoPorId devuelve un producto existente en la lista de manera correcta
        /// </summary>
        [TestMethod]
        public void TestBuscarProductoPorId()
        {
            //Arrange
            ProductoCocina auxProducto = new ProductoCocina("Papas", 125, 0, "Propia", 5);
            Restaurant.listaDeProductos.Add(auxProducto);

            //Act
            Producto unProducto = Restaurant.buscarProductoPorId(5);

            //Assert
            Assert.IsNotNull(unProducto);
        }
        /// <summary>
        /// Método de prueba para validar que el método buscarProductoPorId devuelve un Cliente existente en la lista de manera correcta
        /// </summary>
        [TestMethod]
        public void TestBuscarClientePorDni()
        {
            //Arrange
            Cliente auxCliente = new Cliente("Juan", "Prueba", 15784568, 5);
            Restaurant.listaDeClientes.Add(auxCliente);

            //Act
            Cliente unCliente = Restaurant.DevolverClientePorDni(auxCliente.Dni.ToString());

            //Assert
            Assert.IsNotNull(unCliente);
        }
    }
}

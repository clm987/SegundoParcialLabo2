using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Excepciones;
using ClasesInstanciables;
using EntidadesAbstractas;

namespace TestUnitarios
{
    [TestClass]
    public class TestDeColecciones
    {
        /// <summary>
        /// Método de prueba unitaria que valida que se instancie la lista de Alumnos en la clase Jornada
        /// </summary>
        [TestMethod]
        public void ListaDeAlumnosNula()
        {
                Profesor profesorPrueba = new Profesor();
                Jornada jornadaPrueba = new Jornada(Universidad.EClases.SPD, profesorPrueba);
                List<Alumno> alumnosPrueba;

            alumnosPrueba = jornadaPrueba.Alumnos;

                Assert.IsNotNull(alumnosPrueba);
        }
        /// <summary>
        /// Método de prueba unitaria que valida que se instancie la lista de Profesores en la clase Universidad
        /// </summary>
        [TestMethod]
        public void ListaDeProfesoresNula()
        {
            Universidad uniTest = new Universidad();
            List<Profesor> Instructores;

            Instructores = uniTest.Instructores;

            Assert.IsNotNull(Instructores);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using ClasesInstanciables;
using EntidadesAbstractas;
using Archivos;

namespace TestUnitarios
{
    [TestClass]
    public class TestDeExcepciones
    {
        /// <summary>
        /// Método de test unitario que evalúa que se arroje una excepción NacionalidadInvalidaException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadIvalidaException()
        {
            Alumno unAlumno = new Alumno(4, "NombrePrueba", "ApellidoPrueba", "95123458", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }
        /// <summary>
        ///  Método de test unitario que evalúa que se arroje una excepción del tipo DniInvalidoException cuando ocurre un error en el formato de Dni
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoException()
        {
            Alumno unAlumno = new Alumno(4, "NombrePrueba", "ApellidoPrueba", "   ", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }
        /// <summary>
        /// Método de test unitario que evalúa que se arroje una excepción AlumnoRepetidoException al intentar cargar dos veces el mismo Alumno
        /// </summary>
        [TestMethod]
        public void TestAlumnoRepetidoException()
        {

            try
            {
                Alumno unAlumno = new Alumno(4, "NombrePrueba", "ApellidoPrueba", "95123458", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
                Profesor unProfesor = new Profesor(4, "NombrePruebaProfesor", "ApellidoPruebaProfesor", "25123458", Persona.ENacionalidad.Argentino);
                Jornada unaJornada = new Jornada(Universidad.EClases.Laboratorio, unProfesor);
                unaJornada += unAlumno;
                unaJornada += unAlumno;
            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

    }
}

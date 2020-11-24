using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerado
        /// <summary>
        /// enum que establece las opciones para el atributo estado de cuenta.
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Atributo de tipo EClases para definir la clase que toma un alumno.
        /// </summary>
        private Universidad.EClases claseQueToma;
        /// <summary>
        /// Atributo de tipo EEstadoCuenta para definir la clase que toma un alumno.
        /// </summary>
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        /// <summary>
        /// Contructor por defecto del objeto Alumno
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Sobrecarga del constructor de la base para asignar la clase que toma el alumno.
        /// </summary>
        /// <param name="id">Entero que representa el legajo de un objeto de tipo Alumno</param>
        /// <param name="nombre">String que hace referencia al atributo nombre de un objeto tipo Alumno</param>
        /// <param name="apellido">String que hace referencia al atributo nombre de un objeto tipo Alumno</param>
        /// <param name="dni">String que hace referencia al atributo nombre de un objeto tipo Alumno/param>
        /// <param name="nacionalidad">enum Enacionalidad que hace referencia al atributo nacionalidad de un objeto tipo  Alumno</param>
        /// <param name="claseQueToma">enum Eclase que hace referencia al atributo clase que toma el alumno </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Sopbrecarga del constructor con parámetros para incluir el estado de cuenta
        /// </summary>
        /// <param name="id">Entero que representa el legajo de un objeto de tipo Alumno</param>
        /// <param name="nombre">String que hace referencia al atributo nombre de un objeto tipo Alumno</param>
        /// <param name="apellido">String que hace referencia al atributo nombre de un objeto tipo Alumno</param>
        /// <param name="dni">String que hace referencia al atributo nombre de un objeto tipo Alumno/param>
        /// <param name="nacionalidad">enum Enacionalidad que hace referencia al atributo nacionalidad de un objeto tipo  Alumno</param>
        /// <param name="claseQueToma">enum EEstadoCuenta que hace referencia al atributo estado de cuenta</param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Implementacion por override del método abstracto ParticiparEnClase
        /// </summary>
        /// <returns>String que contiene los datos de la clase que toma el alumno</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"TOMA CLASE DE: {this.claseQueToma}");
            return sb.ToString();
        }
        /// <summary>
        /// Override del método MostrarDatos para devolver los datos de un Alumno
        /// </summary>
        /// <returns>String que contiene los datos de un objeto de tipo Alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga del método ToString()
        /// </summary>
        /// <returns>String que representa datos de un objeto de tipo Alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Sobrecarga del operador == para determinar si un Alumno es igual a una Clase
        /// </summary>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <param name="clase">enum Eclase que representa la clase. </param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool retValue = false;

            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retValue = true;
            }
            return retValue;
        }
        /// <summary>
        /// Sobrecarga del operador != para determinar si un Alumno es diferente a una Clase
        /// </summary>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <param name="clase">enum Eclase que representa la clase.</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            bool retValue = false;

            if (a.claseQueToma != clase)
            {
                retValue = true;
            }

            return retValue;
        }
        #endregion
    }
}

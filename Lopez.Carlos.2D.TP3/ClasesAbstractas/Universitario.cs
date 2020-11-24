using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        /// <summary>
        /// Entero que representa el legajo de un objeto de tipo Universitario
        /// </summary>
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Universitario
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// Constructor con parámetros para el objeto de tipo Universitario
        /// </summary>
        /// <param name="legajo">Entero que representa el legajo de un objeto de tipo Universitario</param>
        /// <param name="nombre">String que hace referencia al atributo nombre de un objeto tipo Universitario</param>
        /// <param name="apellido">String que hace referencia al atributo apellido de un objeto tipo Universitario</param>
        /// <param name="dni">String que hace referencia al atributo dni de un objeto tipo Universitario</param>
        /// <param name="nacionalidad">enum Enacionalidad que hace referencia al atributo nacionalidad de un objeto tipo Universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método virtual que devuelve un string con los datos de un objeto de tipo Universitario
        /// </summary>
        /// <returns>String que representa los datos de los atributos en un objeto Universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NÚMERO: {this.legajo}");
            return sb.ToString();
        }
        /// <summary>
        /// Método abstracto que define la participación en una clase de acuerdo con el tipo de Universitario que sea un objeto (Alumno o Profesor)
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Override del método Equals para determinar si dos objetos son del mismo tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador == para comparar dos Objetos de tipo Universitario
        /// </summary>
        /// <param name="pg1">Objeto de tipo Universitario</param>
        /// <param name="pg2">Objeto de tipo Universitario</param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retValue = false;

            if ((pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.Dni == pg2.Dni)))
            {
                retValue = true;
            }

            return retValue;
        }
        /// <summary>
        /// Sobrecarga del operador != para comparar dos Objetos de tipo Universitario
        /// </summary>
        /// <param name="pg1">Objeto de tipo Universitario</param>
        /// <param name="pg2">Objeto de tipo Universitario</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            bool retValue = false;
            if (!(pg1 == pg2))
            {
                retValue = true;
            }
            return retValue;
        }
        #endregion
    }
}

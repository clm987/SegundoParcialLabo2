using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public class Profesor : Universitario
    {
        #region Atributos
        private Queue<EClases> ClasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto del objeto Profesor
        /// </summary>
        public Profesor()
        {
        }
        /// <summary>
        /// Constructor  del objeto Profesor para instanciar dentro de el el objeto de tipo Random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor con parámetros del objeto de tipo Profesor
        /// </summary>
        /// <param name="id">Entero que representa el legajo de un objeto de tipo Profesor</param>
        /// <param name="nombre">String que hace referencia al atributo nombre de un objeto tipo Profesor</param>
        /// <param name="apellido">String que hace referencia al atributo nombre de un objeto tipo Profesor</param>
        /// <param name="dni">String que hace referencia al atributo nombre de un objeto tipo Profesor/param>
        /// <param name="nacionalidad">enum Enacionalidad que hace referencia al atributo nacionalidad de un objeto tipo  Profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.ClasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Implementacion por override del método abstracto ParticiparEnClase
        /// </summary>
        /// <returns>tring que contiene los datos de la clase que da el Profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");

            foreach (EClases clases in ClasesDelDia)
            {
                sb.AppendLine(clases.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Override del método MostrarDatos para devolver los datos de un Profesor
        /// </summary>
        /// <returns>String que contiene los datos de un objeto de tipo Profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        ///  Sobrecarga del método ToString()
        /// </summary>
        /// <returns>String que contiene los datos de un objeto de tipo Profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Método que alimenta la cola de clases con base al resultado del método random.Next
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.ClasesDelDia.Enqueue((EClases)random.Next(0, 3));
            }
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Sobrecarga del operador == para comparar si un Profesor es igual a una clase
        /// </summary>
        /// <param name="i">Objeto de tipo Profesor</param>
        /// <param name="clase">enum Eclase</param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool retValue = false;

            foreach (EClases unaClase in i.ClasesDelDia)
            {
                if (unaClase == clase)
                {
                    retValue = true;
                }
            }

            return retValue;
        }
        /// <summary>
        /// Sobrecarga del operador != para comparar si un Profesor es diferente a una clase
        /// </summary>
        /// <param name="i">Objeto de tipo Profesor</param>
        /// <param name="clase">enum Eclase</param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException: Exception
    {
        /// <summary>
        /// Clase de excepciones en caso de alumno repetido
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {

        }

        public AlumnoRepetidoException(string message) : base(message)
        {

        }

        public AlumnoRepetidoException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}

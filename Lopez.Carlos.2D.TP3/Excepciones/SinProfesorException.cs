using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException: Exception
    {
        /// <summary>
        /// Excepción para manejar el caso de una clase sin Profesor asignado
        /// </summary>
        public SinProfesorException() : base("No hay Profesor para la clase.")
        {

        }

        public SinProfesorException(string message) : base(message)
        {

        }

        public SinProfesorException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
    
}

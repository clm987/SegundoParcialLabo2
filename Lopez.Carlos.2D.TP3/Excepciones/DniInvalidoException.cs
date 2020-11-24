using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Clase de excepcion para manejar errores de formato en el dni
        /// </summary>
        public DniInvalidoException(): base("El formato de DNI es incorrecto")
        {

        }

        public DniInvalidoException(string message): base(message)
        {

        }

        public DniInvalidoException(string message, Exception innerException): base(message, innerException)
        {

        }
    }
}

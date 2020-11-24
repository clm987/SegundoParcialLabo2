using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ImputException : Exception
    {
        /// <summary>
        /// Clase derivada de Exception para generar el tipo ImputException que será lanzada ante la eventualidad de errores en la entrada de datos. 
        /// </summary>

        public ImputException()
        {

        }
        /// <summary>
        /// Condtructor que recibe el mesaje y lo devuelve al constuctor de la base.
        /// </summary>
        /// <param name="message">string que representa el mensaje de la excepcion</param>
        public ImputException(string message) : base(message)
        {

        }
        /// <summary>
        /// Constructor que recibe tanto el mensaje como otra excepcion
        /// </summary>
        /// <param name="message">string que representa el mensaje de la excepcion</param>
        /// <param name="innerException">Objeto de tipo Exception que será cargado en la propiedad innerexception de la excepcion sucedanea</param>
        public ImputException(string message, Exception innerException)
        {

        }
    }
}

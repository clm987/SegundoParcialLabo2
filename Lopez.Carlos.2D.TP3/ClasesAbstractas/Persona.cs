using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos y Propiedades
        protected int dni;
        protected string nombre;
        protected string apellido;
        ENacionalidad nacionalidad;

        /// <summary>
        /// Propiedad que muestra y setea el atributo dni. Antes de asignar valida que la nacionalidad sea la correspondiente y que tenga un formato valido
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad que muestra y setea el atributo dni. Antes de asignar valida que la nacionalidad sea la correspondiente y que tenga un formato valido
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad que disponibiliza y valida el atributo nombre. Antes de setear valida que solo contenga letras
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de Aoellido de Objeto de tipo Persona. Antes de setear valida que sea solo letras 
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad del atributo nacionalidad. 
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return nacionalidad;
            }
            set
            {
                nacionalidad = value;
            }
        }
        #endregion

        #region Enumerado
        /// <summary>
        /// Enumerado que establece las posibilidades para el atributo nacionalidad (Argentino o Extrajero)
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de objeto de tipo persona.
        /// </summary>

        public Persona()
        {

        }
        /// <summary>
        /// Constructor con parámetros de objeto de tipo persona. 
        /// </summary>
        /// <param name="nombre">String que hace referencia al atributo nombre de un objeto tipo persona</param>
        /// <param name="apellido">String que hace referencia al atributo apellido de un objeto tipo persona</param>
        /// <param name="nacionalidad">enum Enacionalidad que hace referencia al atributo nacionalidad de un objeto tipo persona</param>
        protected Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        ///  Sobrecarga del constructor con parámetros de objeto de tipo persona.
        /// </summary>
        /// <param name="nombre">String que hace referencia al atributo nombre de un objeto tipo persona</param>
        /// <param name="apellido">String que hace referencia al atributo apellido de un objeto tipo persona</param>
        /// <param name="dni">Entero que hace referencia al atributo dni de un objeto tipo persona</param>
        /// <param name="nacionalidad">enum Enacionalidad que hace referencia al atributo nacionalidad de un objeto tipo persona</param>
        protected Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.Dni = dni;
        }
        /// <summary>
        /// Sobrecarga del constructor con parámetros de objeto de tipo persona.
        /// </summary>
        /// <param name="nombre">String que hace referencia al atributo nombre de un objeto tipo persona</param>
        /// <param name="apellido">String que hace referencia al atributo apellido de un objeto tipo persona</param>
        /// <param name="dni">String que hace referencia al atributo dni de un objeto tipo persona</param>
        /// <param name="nacionalidad">enum Enacionalidad que hace referencia al atributo nacionalidad de un objeto tipo persona</param>
        protected Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Sobrecarga del método ToString()
        /// </summary>
        /// <returns>String que representa datos de un objeto de tipo persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {String.Concat(this.Apellido, ", ", this.Nombre)}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad.ToString()}");
            return sb.ToString();
        }
        /// <summary>
        /// Método que valida que un dato a asignar en el atributo dni cumpla el formato y los parámetros de nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">enum Enacionalidad que hace referencia al atributo nacionalidad de un objeto tipo persona</param>
        /// <param name="dato">Entero que hace referencia al atributo dni de un objeto tipo persona</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return ValidarDni(nacionalidad, dato.ToString());
        }
        /// <summary>
        /// Método que valida que un dato a asignar en el atributo dni cumpla el formato y los parámetros de nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">enum Enacionalidad que hace referencia al atributo nacionalidad de un objeto tipo persona</param>
        /// <param name="dato">Entero que hace referencia al atributo dni de un objeto tipo persona</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retValue = -1;
            if (int.TryParse(dato, out int auxValue) && dato.Length <= 11 && dato.Length >= 4)
            {
                if (auxValue >= 1 && auxValue <= 89999999 && nacionalidad == ENacionalidad.Argentino)
                {
                    retValue = auxValue;
                }
                else if (auxValue >= 90000000 && auxValue <= 99999999 && nacionalidad == ENacionalidad.Extranjero)
                {
                    retValue = auxValue;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            else
            {
                throw new DniInvalidoException();
            }

            return retValue;
        }
        /// <summary>
        /// Método que valida que un string contenga solo letras del alfabeto (a-z) tanto minúsculas como mayúsculas
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$"))
            {
                return dato;
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
